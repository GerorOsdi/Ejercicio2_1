using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Ejercicio2_1.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class infoPais : ContentPage
    {
        ModelRegiones Region;
        public infoPais()
        {
            InitializeComponent();
        }

        public infoPais(ModelRegiones regiones) 
        {
            Region = regiones;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Pin country = new Pin {
                Label = Region.name.common,
                Address = Region.region +"/n"+ Region.subregion
            };
            //MapSpan mapa = new MapSpan();

            var uri = new Uri(Region.maps.googleMaps);
            Device.OpenUri(uri);
            
            Map map = new Map();
            map.Pins.Add(country);
            
        }
    }
}