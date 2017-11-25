Imports VBChess.Shared

Public Class Player
    Public Sub New(orientation As PlayerOrientation)
        Me.Orientation = orientation
    End Sub
    Public ReadOnly Property Orientation As PlayerOrientation
End Class