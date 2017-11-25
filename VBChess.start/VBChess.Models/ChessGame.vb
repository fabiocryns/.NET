Imports VBChess.Shared

Public Class ChessGame
    Public Sub New()
        ' TODO
    End Sub

    Public Sub MovePiece(fromPoint As Point, toPoint As Point)

    End Sub
    Public Function CanMovePiece(fromPoint As Point, toPoint As Point) As Boolean
        Return False
    End Function

    Public Property IsFinished As Cell(Of Boolean)
    Public ReadOnly Property Board As ChessBoard
    Public ReadOnly Property Players As IEnumerable(Of Player)
    Public ReadOnly Property CurrentPlayer As Cell(Of Player)
End Class
