using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraMap;

namespace ColorizerPieSegmentAttributeProvider {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            // Create a map control with initial settings and add it to the form.
            MapControl map = new MapControl() { Dock = DockStyle.Fill };
            this.Controls.Add(map);

            // Create a layer to load image tiles from OpenStreetMap.
            ImageTilesLayer tileLayer = new ImageTilesLayer();
            tileLayer.DataProvider = new OpenStreetMapDataProvider();
            map.Layers.Add(tileLayer);

            // Create a vector items layer.
            VectorItemsLayer itemsLayer = new VectorItemsLayer() {
                Data = CreateData(),
                Colorizer = CreateColorizer()
            };
            map.Layers.Add(itemsLayer);
            
            // Create a legend.
            map.Legends.Add(new ColorListLegend() { Layer = itemsLayer });
        }

        private MapDataAdapterBase CreateData() {
            MapItemStorage storage = new MapItemStorage();

            MapPie pie = new MapPie() { Location = new GeoPoint(50, 13), Size = 100 };
            pie.Segments.Add(CreatePieSegment("A", 100, "color1"));
            pie.Segments.Add(CreatePieSegment("B", 50, "color2"));
            pie.Segments.Add(CreatePieSegment("C", 120, "color3"));
            storage.Items.Add(pie);

            return storage;
        }

        private PieSegment CreatePieSegment(object argument, double value, object colorKey) {
            PieSegment segment = new PieSegment();
            segment.Argument = argument;
            segment.Value = value;
            segment.Attributes.Add(new MapItemAttribute() { Name = "color", Value = colorKey });
            return segment;
        }

        private MapColorizer CreateColorizer() {
            KeyValueColorizer colorizer = new KeyValueColorizer();
            colorizer.AddItem("color1", new ColorizerColorTextItem() { Color = Color.Coral, Text = "Category A" });
            colorizer.AddItem("color2", new ColorizerColorTextItem() { Color = Color.Orange, Text = "Category B" });
            colorizer.AddItem("color3", new ColorizerColorTextItem() { Color = Color.LightBlue, Text = "Category C" });
            

            colorizer.ColorItemKeyProvider = new PieSegmentAttributeToColorKeyProvider() { AttributeName = "color" };
            
            return  colorizer;
        }
    }

}

