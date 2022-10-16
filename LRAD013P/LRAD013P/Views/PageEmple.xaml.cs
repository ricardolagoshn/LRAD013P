using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LRAD013P.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEmple : ContentPage
    {
        public PageEmple()
        {
            InitializeComponent();
        }

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            var emple = new Models.Empleados
            {
                Id = Convert.ToInt32(txtcodigo.Text),
                nombres = txtnombres.Text,
                apellidos = txtapellidos.Text,
                telefono = Convert.ToInt32(txttelefono.Text),
                correo = txtcorreo.Text
            };

            if (await App.dbemple.StoreEmple(emple) > 0)
                await DisplayAlert("Aviso", "Registro Ingresado con exito !!","OK");
                
        }
    }
}