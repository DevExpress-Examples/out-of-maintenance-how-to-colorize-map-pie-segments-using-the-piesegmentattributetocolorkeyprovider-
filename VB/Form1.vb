Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraMap

Namespace ColorizerPieSegmentAttributeProvider
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ' Create a map control with initial settings and add it to the form.
            Dim map As New MapControl() With {.Dock = DockStyle.Fill}
            Me.Controls.Add(map)

            ' Create a layer to load image tiles from OpenStreetMap.
            Dim tileLayer As New ImageTilesLayer()
            tileLayer.DataProvider = New OpenStreetMapDataProvider()
            map.Layers.Add(tileLayer)

            ' Create a vector items layer.
            Dim itemsLayer As New VectorItemsLayer() With {.Data = CreateData(), .Colorizer = CreateColorizer()}
            map.Layers.Add(itemsLayer)

            ' Create a legend.
            map.Legends.Add(New ColorListLegend() With {.Layer = itemsLayer})
        End Sub

        Private Function CreateData() As MapDataAdapterBase
            Dim storage As New MapItemStorage()

            Dim pie As New MapPie() With {.Location = New GeoPoint(50, 13), .Size = 100}
            pie.Segments.Add(CreatePieSegment("A", 100, "color1"))
            pie.Segments.Add(CreatePieSegment("B", 50, "color2"))
            pie.Segments.Add(CreatePieSegment("C", 120, "color3"))
            storage.Items.Add(pie)

            Return storage
        End Function

        Private Function CreatePieSegment(ByVal argument As Object, ByVal value As Double, ByVal colorKey As Object) As PieSegment
            Dim segment As New PieSegment()
            segment.Argument = argument
            segment.Value = value
            segment.Attributes.Add(New MapItemAttribute() With {.Name = "color", .Value = colorKey})
            Return segment
        End Function

        Private Function CreateColorizer() As MapColorizer
            Dim colorizer As New KeyValueColorizer()
            colorizer.AddItem("color1", New ColorizerColorTextItem() With {.Color = Color.Coral, .Text = "Category A"})
            colorizer.AddItem("color2", New ColorizerColorTextItem() With {.Color = Color.Orange, .Text = "Category B"})
            colorizer.AddItem("color3", New ColorizerColorTextItem() With {.Color = Color.LightBlue, .Text = "Category C"})


            colorizer.ColorItemKeyProvider = New PieSegmentAttributeToColorKeyProvider() With {.AttributeName = "color"}

            Return colorizer
        End Function
    End Class

End Namespace

