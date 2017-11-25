Imports VBChess.Shared

Public Class ChessBoard
    Public Sub New(topPlayer As Player, bottomPlayer As Player)
        Me.Width = 8
        Me.Height = 8
        ' initialize cells
        ' TODO
        ReDim _cells(7, 7)
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
