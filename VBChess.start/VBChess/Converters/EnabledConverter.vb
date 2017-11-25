Imports System.Globalization

Public Class EnabledConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        Dim enabled As Boolean = CBool(value)
        Return IIf(enabled, SelectableBrush, TransparentBrush)
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function

    Private Shared TransparentBrush As New SolidColorBrush(Colors.Transparent)
    Private Shared SelectableBrush As New RadialGradientBrush(New GradientStopCollection({New GradientStop(Color.FromArgb(0, 0, 128, 0), 1), New GradientStop(Color.FromArgb(128, 0, 128, 0), 0.75)}))
End Class
