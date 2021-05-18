using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeonardoSanchezSemana6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Put : ContentPage
    {
        public Put()
        {
            InitializeComponent();
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //Crear objeto - instancia 
                WebClient cliente = new WebClient();

                //Contenedor para los atributos de la tabla que envia el usuario en las cajas de texto
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                //envio de datos para el PUT
                cliente.UploadValues("http://192.168.100.33:8080/moviles/post.php", "PUT", parametros);
                await DisplayAlert("Alerta", "Actualizado correctamente", "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "ERROR " + ex.Message, "ok");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}