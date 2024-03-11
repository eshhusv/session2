using session2.Model;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace session2
{
    public partial class MainWindow : Window
    {
        private HttpClient httpClient;
        public MainWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            Task.Run(() => Load());
        }

        private async Task Load()
        {
            var list = await httpClient.GetFromJsonAsync<ResponseClass>("http://localhost:4914/PersonLocations");
            foreach(Person i in list.response)
            {
                          
                var geometryDrawing = new GeometryDrawing();
                geometryDrawing.Geometry = new EllipseGeometry(new Point(150, 150), 150, 150);
                if (i.personRole == "Сотрудник")
                    geometryDrawing.Brush = Brushes.Blue;
                else
                    geometryDrawing.Brush = Brushes.Green;

                var drawingBrush = new DrawingBrush(geometryDrawing);

                var rectangle = new Rectangle();
                rectangle.Width = 100;
                rectangle.Height = 100;
                rectangle.Fill = drawingBrush;

                grid.Children.Add(rectangle);

            }
        }
    }
}