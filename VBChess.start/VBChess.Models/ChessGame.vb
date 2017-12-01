Imports VBChess.Shared

Public Class ChessGame
    Public Sub New()
        _Players = {New Player(PlayerOrientation.Bottom), New Player(PlayerOrientation.Top)}
        _CurrentPlayer = New Cell(Of Player)(Players(0))
        _Board = New ChessBoard(Players(1), Players(0))
    End Sub

    Public Sub MovePiece(fromPoint As Point, toPoint As Point)
        If CanMovePiece(fromPoint, toPoint) Then
            If Board.Item(toPoint.X, toPoint.Y).Content.Value.PawnType = PawnTypes.King Then
                IsFinished.Value = True
            Else
                Board.Item(toPoint.X, toPoint.Y).Content.Value = Board.Item(fromPoint.X, fromPoint.Y).Content.Value
                Board.Item(fromPoint.X, fromPoint.Y).Content.Value = Nothing
                If CurrentPlayer.Value.ToString().Equals(Players(0).ToString()) Then
                    CurrentPlayer.Value = Players(1)
                Else
                    CurrentPlayer.Value = Players(0)
                End If
            End If
        Else
                Throw New NotSupportedException()
        End If
    End Sub
    Public Function CanMovePiece(fromPoint As Point, toPoint As Point) As Boolean
        If IsFinished().Value Then
            Return False
        Else
            Dim piece As ChessPiece = Board.Item(fromPoint.X, fromPoint.Y).Content.Value
            If piece.Owner.ToString().Equals(CurrentPlayer.ToString()) Then
                Return piece.IsMoveValid(toPoint)
            Else
                Return False
            End If
        End If
    End Function

    Public Property IsFinished As Cell(Of Boolean) = New Cell(Of Boolean)(False)
    Public ReadOnly Property Board As ChessBoard
    Public ReadOnly Property Players As IEnumerable(Of Player)
    Public ReadOnly Property CurrentPlayer As Cell(Of Player)
End Class
