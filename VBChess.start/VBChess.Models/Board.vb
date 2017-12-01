Imports VBChess.Shared

Public Class ChessBoard
    Public Sub New(topPlayer As Player, bottomPlayer As Player)
        Me.Width = 8
        Me.Height = 8
        ' initialize cells
        ReDim _cells(7, 7)
        For x As Integer = 0 To 7
            For y As Integer = 0 To 7
                _cells(x, y) = New BoardCell(Me, x, y)
            Next
        Next
        ' initialize the top player
        _cells(0, 0).Content.Value = New Rook(topPlayer, Me, New Point(0, 0))
            _cells(1, 0).Content.Value = New Knight(topPlayer, Me, New Point(1, 0))
            _cells(2, 0).Content.Value = New Bishop(topPlayer, Me, New Point(2, 0))
            _cells(3, 0).Content.Value = New Queen(topPlayer, Me, New Point(3, 0))
            _cells(4, 0).Content.Value = New King(topPlayer, Me, New Point(4, 0))
            _cells(5, 0).Content.Value = New Bishop(topPlayer, Me, New Point(5, 0))
            _cells(6, 0).Content.Value = New Knight(topPlayer, Me, New Point(6, 0))
            _cells(7, 0).Content.Value = New Rook(topPlayer, Me, New Point(7, 0))
            For i As Integer = 0 To 7
                _cells(i, 1).Content.Value = New Pawn(topPlayer, Me, New Point(i, 1))
            Next
            ' initialize the bottom player
            _cells(0, 7).Content.Value = New Rook(bottomPlayer, Me, New Point(0, 7))
            _cells(1, 7).Content.Value = New Knight(bottomPlayer, Me, New Point(1, 7))
            _cells(2, 7).Content.Value = New Bishop(bottomPlayer, Me, New Point(2, 7))
            _cells(3, 7).Content.Value = New Queen(bottomPlayer, Me, New Point(3, 7))
            _cells(4, 7).Content.Value = New King(bottomPlayer, Me, New Point(4, 7))
            _cells(5, 7).Content.Value = New Bishop(bottomPlayer, Me, New Point(5, 7))
            _cells(6, 7).Content.Value = New Knight(bottomPlayer, Me, New Point(6, 7))
            _cells(7, 7).Content.Value = New Rook(bottomPlayer, Me, New Point(7, 7))
            For i As Integer = 0 To 7
                _cells(i, 6).Content.Value = New Pawn(bottomPlayer, Me, New Point(i, 6))
            Next
    End Sub

    Public ReadOnly Property Width As Integer
    Public ReadOnly Property Height As Integer
    Private _cells As BoardCell(,)

    Default Public ReadOnly Property Item(x As Integer, y As Integer) As BoardCell
        Get
            If x >= 0 And y >= 0 And x < 8 And y < 8 Then
                Return _cells(x, y)
            Else
                Throw New ArgumentException("The index is invalid!")
            End If

        End Get
    End Property

End Class
