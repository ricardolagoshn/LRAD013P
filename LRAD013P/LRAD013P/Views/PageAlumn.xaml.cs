using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using System.IO;

namespace LRAD013P.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAlumn : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;

        public PageAlumn()
        {
            InitializeComponent();
        }

        private String traeImagenToBase64()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();

                    string Base64String = Convert.ToBase64String(fotobyte);
                    return Base64String;
                }
            }
            return null;
        }

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {

            var alumn = new Models.Alumnos
            {
                nombres = txtnombres.Text,
                apellidos = txtapellidos.Text,
                telefono = txttelefono.Text,
                direccion = txtdireccion.Text,
                foto = traeImagenToBase64()
            };


            if (await Controllers.AlumnController.CreateAlum(alumn) > 0)
                await DisplayAlert("Alumno Creado", "El Alumno " + alumn.nombres + "ha sido creado","OK");
            else
                await DisplayAlert("Error", "El Alumno " + alumn.nombres + " no ha sido creado", "OK");
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "UCENMLABRAD",
                Name = "Foto.jpg",
                SaveToAlbum = true,
            });

            if (photo != null)
            {
                foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }


        }
    }
}