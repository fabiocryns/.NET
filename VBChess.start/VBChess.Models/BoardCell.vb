Imports VBChess.Shared

Public Class BoardCell
    Public Sub New(parent As ChessBoard, x As Integer, y As Integer, Optional content As ChessPiece = Nothing)
        _Content = New Cell(Of ChessPiece)(content)
        _Parent = parent
        _X = x
        _Y = y
    End Sub

    Public Property Content As Cell(Of ChessPiece)
    Public ReadOnly Property Parent As ChessBoard
    Public ReadOnly Property X As Integer
    Public ReadOnly Property Y As Integer
End Class
