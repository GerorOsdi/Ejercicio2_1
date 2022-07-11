using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Ejercicio2_1.Controller;
using Ejercicio2_1.Models;
using Ejercicio2_1.View;

namespace Ejercicio2_1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void lstRegiones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                ModelRegiones itemSelc = e.CurrentSelection[0] as ModelRegiones;

                string rest = await DisplayActionSheet("Aviso", "Ubicacion", null, "Cancelar");

                if (rest == "Ubicacion")
                {
                    await Navigation.PushAsync(new infoPais(itemSelc));
                }
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //List<ModelRegiones> lstModel = new List<ModelRegiones>();
            //lstModel = await RegionController.getRegion("America");
            //lstRegiones.ItemsSource = await RegionController.getRegion("America");
        }

        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (pickRegiones.SelectedIndex == -1) 
            {
                await DisplayAlert("Aviso","No se seleeciono la region", "ok");
            }
            else 
            {
                var itemSelected = pickRegiones.Items[pickRegiones.SelectedIndex];
                lstRegiones.ItemsSource = await RegionController.getRegion(itemSelected);
            }
        }
    }
}
