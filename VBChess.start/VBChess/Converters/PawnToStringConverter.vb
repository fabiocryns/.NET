Imports System.Globalization
Imports VBChess.Shared

Public Class PawnToStringConverter
    Implements IMultiValueConverter

    Private Const Symbols As String = "♔♕♖♗♘♙♚♛♜♝♞♟"

    Public Function Convert(values() As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
        If values(0) Is Nothing OrElse values(1) Is Nothing Then
            Return String.Empty
        Else
            If values(0).GetType() Is GetType(PawnTypes) AndAlso values(1).GetType() Is GetType(PlayerOrientation) Then
                Dim index As Integer = CType(values(0), Integer)
                Dim orientation As PlayerOrientation = DirectCast(values(1), PlayerOrientation)
                Return Symbols.Substring(index + CInt(IIf(orientation = PlayerOrientation.Bottom, 0, 6)), 1)
            End If
        End If
    End Function

    Public Function ConvertBack(value As Object, targetTypes() As Type, parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class
