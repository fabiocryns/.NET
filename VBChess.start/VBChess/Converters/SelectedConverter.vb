Imports System.Globalization
Imports VBChess.Shared

Public Class SelectedConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        Dim selected As Boolean = CBool(value)
        Select Case parameter.ToString()
            Case "Opacity"
                Return IIf(selected, 1.0, 0.0)
            Case "Stroke"
                Return IIf(selected, Brushes.Gold, StrokeBrush)
        End Select
        Throw New NotImplementedException()
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function

    Private Shared StrokeBrush As New SolidColorBrush(Color.FromArgb(&H66, &HFF, &HFF, &HFF))
End Class
