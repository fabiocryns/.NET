
Imports VBChess.Shared

Public Class Pawn
    Inherits ChessPiece

    Public Sub New(owner As Player, board As ChessBoard, position As Point)
        MyBase.New(owner, board, position)

    End Sub

    Public Overrides ReadOnly Property PawnType As PawnTypes
        Get
            Return PawnTypes.Pawn
        End Get
    End Property

    Friend Overrides Function IsMoveValid(newPosition As Point) As Boolean
        If Not MyBase.IsMoveValid(newPosition) Then Return False

        If (Owner.Orientation = PlayerOrientation.Top) Then
            If Position.Value.X <> newPosition.X Then
                Return newPosition.Y = Position.Value.Y + 1 AndAlso Not Board(newPosition.X, newPosition.Y).Content.Value Is Nothing
            Else
                Return Board(newPosition.X, newPosition.Y).Content.Value Is Nothing AndAlso ((newPosition.Y = Position.Value.Y + 1) OrElse (newPosition.Y = Position.Value.Y + 2 AndAlso Position.Value.Y = 1 AndAlso Board(newPosition.X, 2).Content.Value Is Nothing))
            End If
        Else
            If Position.Value.X <> newPosition.X Then
                Return (newPosition.Y = Position.Value.Y - 1) AndAlso Not (Board(newPosition.X, newPosition.Y).Content.Value Is Nothing)
            Else
                Return (Board(newPosition.X, newPosition.Y).Content.Value Is Nothing) AndAlso ((newPosition.Y = Position.Value.Y - 1) OrElse (newPosition.Y = Position.Value.Y - 2 AndAlso Position.Value.Y = 6 AndAlso Board(newPosition.X, 5).Content.Value Is Nothing))
            End If
        End If
    End Function
End Class
