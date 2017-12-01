Imports VBChess.Shared
Public Class King
    Inherits ChessPiece

    Public Sub New(owner As Player, board As ChessBoard, position As Point)
        MyBase.New(owner, board, position)
    End Sub

    Public Overrides ReadOnly Property PawnType As PawnTypes
        Get
            Return PawnTypes.King
        End Get
    End Property

    Friend Overrides Function IsMoveValid(newPosition As Point) As Boolean
        If Not MyBase.IsMoveValid(newPosition) Then Return False
        Return newPosition.X >= Position.Value.X - 1 _
            AndAlso newPosition.X <= Position.Value.X + 1 _
            AndAlso newPosition.Y >= Position.Value.Y - 1 _
            AndAlso newPosition.Y <= Position.Value.Y + 1
    End Function
End Class