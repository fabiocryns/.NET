Imports System
Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Documents
Imports System.Windows.Markup
Imports System.Windows.Media

<ContentProperty("Text")>
Public Class OutlinedTextBlock
    Inherits FrameworkElement

    Private Sub UpdatePen()
        _pen = New Pen(Stroke, StrokeThickness) With {
                .DashCap = PenLineCap.Round,
                .EndLineCap = PenLineCap.Round,
                .LineJoin = PenLineJoin.Round,
                .StartLineCap = PenLineCap.Round
            }
        InvalidateVisual()
    End Sub

    Public Shared ReadOnly FillProperty As DependencyProperty = DependencyProperty.Register(
        "Fill",
        GetType(Brush),
        GetType(OutlinedTextBlock),
        New FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender))

    Public Shared ReadOnly StrokeProperty As DependencyProperty = DependencyProperty.Register(
        "Stroke",
        GetType(Brush),
        GetType(OutlinedTextBlock),
        New FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender, AddressOf StrokePropertyChangedCallback))

    Private Shared Sub StrokePropertyChangedCallback(dependencyObject As DependencyObject, dependencyPropertyChangedEventArgs As DependencyPropertyChangedEventArgs)
        Dim o As OutlinedTextBlock = TryCast(dependencyObject, OutlinedTextBlock)
        If Not o Is Nothing Then o.UpdatePen()
    End Sub

    Public Shared ReadOnly StrokeThicknessProperty As DependencyProperty = DependencyProperty.Register(
        "StrokeThickness",
        GetType(Double),
        GetType(OutlinedTextBlock),
        New FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender, AddressOf StrokePropertyChangedCallback))

    Public Shared ReadOnly FontFamilyProperty As DependencyProperty = TextElement.FontFamilyProperty.AddOwner(
        GetType(OutlinedTextBlock),
        New FrameworkPropertyMetadata(AddressOf OnFormattedTextUpdated))

    Public Shared ReadOnly FontSizeProperty As DependencyProperty = TextElement.FontSizeProperty.AddOwner(
        GetType(OutlinedTextBlock),
        New FrameworkPropertyMetadata(AddressOf OnFormattedTextUpdated))

    Public Shared ReadOnly FontStretchProperty As DependencyProperty = TextElement.FontStretchProperty.AddOwner(
        GetType(OutlinedTextBlock),
        New FrameworkPropertyMetadata(AddressOf OnFormattedTextUpdated))

    Public Shared ReadOnly FontStyleProperty As DependencyProperty = TextElement.FontStyleProperty.AddOwner(
        GetType(OutlinedTextBlock),
        New FrameworkPropertyMetadata(AddressOf OnFormattedTextUpdated))

    Public Shared ReadOnly FontWeightProperty As DependencyProperty = TextElement.FontWeightProperty.AddOwner(
        GetType(OutlinedTextBlock),
        New FrameworkPropertyMetadata(AddressOf OnFormattedTextUpdated))

    Public Shared ReadOnly TextProperty As DependencyProperty = DependencyProperty.Register(
        "Text",
        GetType(String),
        GetType(OutlinedTextBlock),
        New FrameworkPropertyMetadata(AddressOf OnFormattedTextInvalidated))

    Public Shared ReadOnly TextAlignmentProperty As DependencyProperty = DependencyProperty.Register(
        "TextAlignment",
        GetType(TextAlignment),
        GetType(OutlinedTextBlock),
        New FrameworkPropertyMetadata(AddressOf OnFormattedTextUpdated))

    Public Shared ReadOnly TextDecorationsProperty As DependencyProperty = DependencyProperty.Register(
        "TextDecorations",
        GetType(TextDecorationCollection),
        GetType(OutlinedTextBlock),
        New FrameworkPropertyMetadata(AddressOf OnFormattedTextUpdated))

    Public Shared ReadOnly TextTrimmingProperty As DependencyProperty = DependencyProperty.Register(
        "TextTrimming",
        GetType(TextTrimming),
        GetType(OutlinedTextBlock),
        New FrameworkPropertyMetadata(AddressOf OnFormattedTextUpdated))

    Public Shared ReadOnly TextWrappingProperty As DependencyProperty = DependencyProperty.Register(
        "TextWrapping",
        GetType(TextWrapping),
        GetType(OutlinedTextBlock),
        New FrameworkPropertyMetadata(TextWrapping.NoWrap, AddressOf OnFormattedTextUpdated))

    Private _formattedText As FormattedText
    Private _textGeometry As Geometry
    Private _pen As Pen

    Public Sub New()
        UpdatePen()
        Me.TextDecorations = New TextDecorationCollection()
    End Sub

    Public Property Fill As Brush
        Get
            Return CType(GetValue(FillProperty), Brush)
        End Get
        Set
            SetValue(FillProperty, Value)
        End Set
    End Property

    Public Property FontFamily As FontFamily

        Get
            Return CType(GetValue(FontFamilyProperty), FontFamily)
        End Get
        Set
            SetValue(FontFamilyProperty, Value)
        End Set
    End Property

    <TypeConverter(GetType(FontSizeConverter))>
    Public Property FontSize As Double
        Get
            Return CType(GetValue(FontSizeProperty), Double)
        End Get
        Set
            SetValue(FontSizeProperty, Value)
        End Set
    End Property

    Public Property FontStretch As FontStretch

        Get
            Return CType(GetValue(FontStretchProperty), FontStretch)
        End Get
        Set
            SetValue(FontStretchProperty, Value)
        End Set
    End Property

    Public Property FontStyle As FontStyle

        Get
            Return CType(GetValue(FontStyleProperty), FontStyle)
        End Get
        Set
            SetValue(FontStyleProperty, Value)
        End Set
    End Property

    Public Property FontWeight As FontWeight

        Get
            Return CType(GetValue(FontWeightProperty), FontWeight)
        End Get
        Set
            SetValue(FontWeightProperty, Value)
        End Set
    End Property

    Public Property Stroke As Brush

        Get
            Return CType(GetValue(StrokeProperty), Brush)
        End Get
        Set
            SetValue(StrokeProperty, Value)
        End Set
    End Property

    Public Property StrokeThickness As Double

        Get
            Return CType(GetValue(StrokeThicknessProperty), Double)
        End Get
        Set
            SetValue(StrokeThicknessProperty, Value)
        End Set
    End Property

    Public Property Text As String

        Get
            Return CType(GetValue(TextProperty), String)
        End Get
        Set
            SetValue(TextProperty, Value)
        End Set
    End Property

    Public Property TextAlignment As TextAlignment

        Get
            Return CType(GetValue(TextAlignmentProperty), TextAlignment)
        End Get
        Set
            SetValue(TextAlignmentProperty, Value)
        End Set
    End Property

    Public Property TextDecorations As TextDecorationCollection

        Get
            Return CType(GetValue(TextDecorationsProperty), TextDecorationCollection)
        End Get
        Set
            SetValue(TextDecorationsProperty, Value)
        End Set
    End Property

    Public Property TextTrimming As TextTrimming

        Get
            Return CType(GetValue(TextTrimmingProperty), TextTrimming)
        End Get
        Set
            SetValue(TextTrimmingProperty, Value)
        End Set
    End Property

    Public Property TextWrapping As TextWrapping

        Get
            Return CType(GetValue(TextWrappingProperty), TextWrapping)
        End Get
        Set
            SetValue(TextWrappingProperty, Value)
        End Set
    End Property

    Protected Overrides Sub OnRender(drawingContext As DrawingContext)

        Me.EnsureGeometry()

        drawingContext.DrawGeometry(Nothing, _pen, _textGeometry)
        drawingContext.DrawGeometry(Me.Fill, New Pen(Me.Stroke, Me.StrokeThickness), _textGeometry)
    End Sub

    Protected Overrides Function MeasureOverride(availableSize As Size) As Size

        Me.EnsureFormattedText()

        ' constrain the formatted text according to the available size
        Dim w As Double = availableSize.Width
        Dim h As Double = availableSize.Height
        ' the Math.Min call Is important - without this constraint (which seems arbitrary, but Is the maximum allowable text width), things blow up when availableSize Is infinite in both directions
        ' the Math.Max call Is to ensure we don't hit zero, which will cause MaxTextHeight to throw
        _formattedText.MaxTextWidth = Math.Min(3579139, w)
        _formattedText.MaxTextHeight = Math.Max(0.0001, h)

        ' return the desired size
        Return New Size(Math.Ceiling(_formattedText.Width), Math.Ceiling(_formattedText.Height))
    End Function

    Protected Overrides Function ArrangeOverride(finalSize As Size) As Size

        Me.EnsureFormattedText()

        ' update the formatted text with the final size
        _formattedText.MaxTextWidth = finalSize.Width
        _formattedText.MaxTextHeight = Math.Max(finalSize.Height, 0.0001)

        ' need to re-generate the geometry now that the dimensions have changed
        _textGeometry = Nothing

        Return finalSize
    End Function

    Private Shared Sub OnFormattedTextInvalidated(dependencyObject As DependencyObject, e As DependencyPropertyChangedEventArgs)

        Dim outlinedTextBlock As OutlinedTextBlock = CType(dependencyObject, OutlinedTextBlock)
        outlinedTextBlock._formattedText = Nothing
        outlinedTextBlock._textGeometry = Nothing

        outlinedTextBlock.InvalidateMeasure()
        outlinedTextBlock.InvalidateVisual()
    End Sub

    Private Shared Sub OnFormattedTextUpdated(dependencyObject As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim OutlinedTextBlock As OutlinedTextBlock = CType(dependencyObject, OutlinedTextBlock)
        OutlinedTextBlock.UpdateFormattedText()
        OutlinedTextBlock._textGeometry = Nothing

        OutlinedTextBlock.InvalidateMeasure()
        OutlinedTextBlock.InvalidateVisual()
    End Sub

    Private Sub EnsureFormattedText()
        If (Not _formattedText Is Nothing) Then Return

        _formattedText = New FormattedText(
            IIf(Text Is Nothing, String.Empty, Text).ToString(),
            CultureInfo.CurrentUICulture,
            FlowDirection,
            New Typeface(FontFamily, FontStyle, FontWeight, FontStretches.Normal),
            FontSize,
            Brushes.Black)

        Me.UpdateFormattedText()
    End Sub

    Private Sub UpdateFormattedText()

        If _formattedText Is Nothing Then Return

        _formattedText.MaxLineCount = CInt(IIf(TextWrapping = TextWrapping.NoWrap, 1, Integer.MaxValue))
        _formattedText.TextAlignment = TextAlignment
        _formattedText.Trimming = TextTrimming

        _formattedText.SetFontSize(FontSize)
        _formattedText.SetFontStyle(FontStyle)
        _formattedText.SetFontWeight(FontWeight)
        _formattedText.SetFontFamily(FontFamily)
        _formattedText.SetFontStretch(FontStretch)
        _formattedText.SetTextDecorations(TextDecorations)
    End Sub

    Private Sub EnsureGeometry()
        If Not _textGeometry Is Nothing Then Return

        EnsureFormattedText()
        _textGeometry = _formattedText.BuildGeometry(New Point(0, 0))
    End Sub
End Class
