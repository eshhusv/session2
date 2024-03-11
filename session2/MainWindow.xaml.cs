using session2.Model;

using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace session2
{
    public partial class MainWindow : Window
    {
        private HttpClient httpClient;
        private Response? list;
        public MainWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private void UpdateList(object state)
        {
            grid.Children.Clear();
            Task.Run(() => Load());
            Dr();
        }
        private async Task Load()
        {
             list= await httpClient.GetFromJsonAsync<Response>("http://localhost:4914/PersonLocations");
        }
        private  void Dr()
        {
            if (list != null)
            {
                foreach (Person i in list!.response!)
                {
                    switch (i.lastSecurityPointNumber) 
                    {
                        case 0:
                            setPosition(1050, 180, i);
                            break;
                        case 1:
                            setPosition(1200, 180, i);
                            break;
                        case 2:
                            setPosition(1300, 180, i);
                            break;
                        case 3:
                            setPosition(1400, 180, i);
                            break;
                        case 4:
                            setPosition(1500, 180, i);
                            break;
                        case 5:
                            setPosition(1680, 180, i);
                            break;
                        case 6:
                            setPosition(1800, 180, i);
                            break;
                        case 7:
                            setPosition(1800, 480, i);
                            break;
                        case 8:
                            setPosition(1488, 480, i);
                            break;
                        case 9:
                            setPosition(1350, 480, i);
                            break;
                        case 10:
                            setPosition(1250, 480, i);
                            break;
                        case 11:
                            setPosition(1150, 480, i);
                            break;
                        case 12:
                            setPosition(900, 480, i);
                            break;
                        case 13:
                            setPosition(800, 480, i);
                            break;
                        case 14:
                            setPosition(600, 480, i);
                            break;
                        case 15:
                            setPosition(200, 480, i);
                            break;
                        case 16:
                            setPosition(20, 480, i);
                            break;
                        case 17:
                            setPosition(20, 180, i);
                            break;
                        case 18:
                            setPosition(100, 180, i);
                            break;
                        case 19:
                            setPosition(200, 180, i);
                            break;
                        case 20:
                            setPosition(250, 180, i);
                            break;
                        case 21:
                            setPosition(500, 180, i);
                            break;
                        case 22:
                            setPosition(700, 180, i);
                            break;
                    }
                }
            }
        }

        private void setPosition(int x, int y, Person i)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 20;
            ellipse.Height = 20;
            if (i.personRole == "Сотрудник")
                ellipse.Fill = Brushes.Blue;
            else
                ellipse.Fill = Brushes.Green;

            Canvas.SetLeft(ellipse, x);
            Canvas.SetTop(ellipse, y);
            grid.Children.Add(ellipse);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TimerCallback timeCB = new TimerCallback(UpdateList!);
            Timer time = new Timer(timeCB, null, 0, 3000);
        }
    }
}