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
    public partial class PageRAPrincipal : ContentPage
    {
        public PageRAPrincipal()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listalumnos.ItemsSource = await Controllers.AlumnController.getAlumnos();
        }
        private async void btnconsumir_Clicked(object sender, EventArgs e)
        {
            await Controllers.AlumnController.getAlumnos();
        }

        private async void agregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageAlumn());
        }

        private void toolupdate_Clicked(object sender, EventArgs e)
        {

        }

        private void listalumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }


    }
}