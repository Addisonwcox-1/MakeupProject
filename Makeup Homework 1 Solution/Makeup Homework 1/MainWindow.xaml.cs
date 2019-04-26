using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Makeup_Homework_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())

            {

                var breed = client.GetAsync($@"https://dog.ceo/api/breed/{txtBreed.Text}/images/random").Result;

                if (breed.IsSuccessStatusCode)

                {

                    var dog = breed.Content.ReadAsStringAsync().Result;

                    KillMe dogType = JsonConvert.DeserializeObject<KillMe>(dog);

                    BitmapImage dogPic = new BitmapImage();



                    dogPic.BeginInit();

                    dogPic.UriSource = new Uri(dogType.Message);

                    dogPic.EndInit();

                    imgPuppyPic.Source = dogPic;

                }

                else if (!breed.IsSuccessStatusCode)

                {

                    MessageBox.Show("Please insert another breed name");

                    txtBreed.Clear();

                }

            }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new Image as img;

            var uri = new Uri("https://food.fnr.sndimg.com/content/dam/images/food/video/0/02/023/0238/0238752.jpg.rend.hgtvcom.616.347.suffix/1480464986868.jpeg");
            img.Source = new BitmapImage(uri);
        }
    }
}
