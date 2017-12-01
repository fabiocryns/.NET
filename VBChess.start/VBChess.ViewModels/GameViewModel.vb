Imports System.ComponentModel
Imports System.Windows.Input
Imports VBChess.Models
Imports VBChess.Shared

Public Class GameViewModel
    Public Sub New()
        Me.Game = New ChessGame()
        Me.SelectedSquare = New Cell(Of SquareViewModel)(Nothing)
        Me.IsFinished = Game.IsFinished
        Me.Players = Game.Players
        Me.CurrentPlayer = Game.CurrentPlayer
        Me.Board = New Cell(Of ChessBoardViewModel)(New ChessBoardViewModel(Me)) 'TODO
    End Sub

    Public Property IsFinished As ICell(Of Boolean)
    Public ReadOnly Property Board As ICell(Of ChessBoardViewModel)
    Public ReadOnly Property Players As IEnumerable(Of Player)
    Public ReadOnly Property CurrentPlayer As ICell(Of Player)
    Public ReadOnly Property SelectedSquare As ICell(Of SquareViewModel)

    Private Game As ChessGame

    Public Class ChessBoardViewModel
        Public Sub New(gameVm As GameViewModel)
            Dim rows = New List(Of RowViewModel)
            For i As Integer = 0 To gameVm.Game.Board.Height - 1
                rows.Add(New RowViewModel(gameVm, i))
            Next
            Me.Rows = rows
        End Sub
        Public ReadOnly Property Rows As IEnumerable(Of RowViewModel)
    End Class

    Public Class RowViewModel
        Public Sub New(gameVm As GameViewModel, row As Integer)
            Dim squares = New List(Of SquareViewModel)
            For i As Integer = 0 To gameVm.Game.Board.Width - 1
                squares.Add(New SquareViewModel(gameVm, i, row))
            Next
            Me.Squares = squares
        End Sub
        Public ReadOnly Property Squares As IEnumerable(Of SquareViewModel)
    End Class

    Public Class SquareViewModel
        Public Sub New(gameVm As GameViewModel, x As Integer, y As Integer)
            _X = x
            _Y = y
            GameViewModel = gameVm
            Me.Content = DerivedCell.Create(Of ChessPiece, SquareContent)(gameVm.Game.Board(x, y).Content, Function(piece As ChessPiece)
                                                                                                               If (piece Is Nothing) Then
                                                                                                                   Return Nothing
                                                                                                               Else
                                                                                                                   Return New SquareContent(piece.PawnType, piece.Owner)
                                                                                                               End If
                                                                                                           End Function)
            _Click = New ClickCommand(Me)
            _Selected = DerivedCell.Create(Of SquareViewModel, Boolean)(gameVm.SelectedSquare, Function(ss As SquareViewModel)
                                                                                                   Return ss Is Me
                                                                                               End Function)
        End Sub
        Public ReadOnly Property X As Integer
        Public ReadOnly Property Y As Integer
        Public ReadOnly Property Selected As ICell(Of Boolean)
        Public ReadOnly Property Content As ICell(Of SquareContent)
        Public ReadOnly Property Click As ICommand
        Private Property GameViewModel As GameViewModel

        Public Class ClickCommand
            Implements ICommand

            Private Property SquareVm As SquareViewModel
            Private Property CanExecuteValue As Boolean
            Public Sub New(squareVm As SquareViewModel)
                _SquareVm = squareVm
                _CanExecuteValue = CanExecute()
            End Sub
            Private Function CanExecute() As Boolean
                If SquareVm.GameViewModel.IsFinished.Value Then Return False
                If SquareVm.GameViewModel.SelectedSquare.Value Is Nothing Then
                    Return Not SquareVm.Content.Value Is Nothing AndAlso SquareVm.Content.Value.Owner Is SquareVm.GameViewModel.CurrentPlayer.Value
                Else
                    Dim ss As SquareViewModel = SquareVm.GameViewModel.SelectedSquare.Value
                    Return SquareVm.GameViewModel.SelectedSquare.Value.Equals(SquareVm) OrElse SquareVm.GameViewModel.Game.CanMovePiece(New Point(ss.X, ss.Y), New Point(SquareVm.X, SquareVm.Y))
                End If
            End Function
            Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

            Public Sub Execute(parameter As Object) Implements ICommand.Execute
                Dim ss As SquareViewModel = SquareVm.GameViewModel.SelectedSquare.Value
                If ss Is Nothing Then
                    SquareVm.GameViewModel.SelectedSquare.Value = SquareVm
                Else
                    SquareVm.GameViewModel.SelectedSquare.Value = Nothing
                    If Not ss.Equals(SquareVm) Then
                        SquareVm.GameViewModel.Game.MovePiece(New Point(ss.X, ss.Y), New Point(SquareVm.X, SquareVm.Y))
                    End If
                End If
            End Sub
            Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
                Return CanExecuteValue
            End Function
        End Class

        Public Class SquareContent
            Public Sub New(pawnType As PawnTypes, owner As Player)
                Me.PawnType = pawnType
                Me.Owner = owner
            End Sub
            Public ReadOnly Property PawnType As PawnTypes
            Public ReadOnly Property Owner As Player
        End Class
    End Class
End Class