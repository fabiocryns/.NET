Imports VBChess.Shared

Public MustInherit Class ChessPiece
    Public Sub New(owner As Player, board As ChessBoard, position As Point)
        _Owner = owner
        _Board = board
        _Position = New Cell(Of Point)(position)
    End Sub

    Friend Overridable Function IsMoveValid(newPosition As Point) As Boolean
        Return newPosition.X >= 0 AndAlso newPosition.X < 8 _
                AndAlso newPosition.Y >= 0 AndAlso newPosition.Y < 8 _
                AndAlso Me.Position.Value <> newPosition
    End Function

    Public ReadOnly Property Position() As Cell(Of Point)
    Public ReadOnly Property Owner() As Player
    Public ReadOnly Property Board() As ChessBoard

    Public MustOverride ReadOnly Property PawnType As PawnTypes

End Class
