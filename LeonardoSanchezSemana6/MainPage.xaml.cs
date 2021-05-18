using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LeonardoSanchezSemana6
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.33:8080/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<LeonardoSanchezSemana6.Ws.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<LeonardoSanchezSemana6.Ws.Datos> posts = JsonConvert.DeserializeObject<List<LeonardoSanchezSemana6.Ws.Datos>>(content);
                _post = new ObservableCollection<LeonardoSanchezSemana6.Ws.Datos>(posts);

                MYListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Error" + ex.Message, "Aceptar");
            }
        }
        private async void Consultar_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<LeonardoSanchezSemana6.Ws.Datos> posts = JsonConvert.DeserializeObject<List<LeonardoSanchezSemana6.Ws.Datos>>(content);
            _post = new ObservableCollection<Ws.Datos>(posts);

            MYListView.ItemsSource = _post;
        }

        private async void btnPost_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Insertar());
        }

        private async void btnPut_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Put());
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Delete());
        }
    }
}
