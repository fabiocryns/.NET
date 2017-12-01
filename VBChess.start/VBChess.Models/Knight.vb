
Imports VBChess.Shared

Public Class Knight
    Inherits ChessPiece

    Public Sub New(owner As Player, board As ChessBoard, position As Point)
        MyBase.New(owner, board, position)

    End Sub

    Public Overrides ReadOnly Property PawnType As PawnTypes
        Get
            Return PawnTypes.Knight
        End Get
    End Property

    Friend Overrides Function IsMoveValid(newPosition As Point) As Boolean
        If Not MyBase.IsMoveValid(newPosition) Then Return False

        If Position.Value.X = newPosition.X OrElse Position.Value.Y = newPosition.Y Then Return False
        Return Math.Abs(Position.Value.X - newPosition.X) + Math.Abs(Position.Value.Y - newPosition.Y) = 3
    End Function
End Class
