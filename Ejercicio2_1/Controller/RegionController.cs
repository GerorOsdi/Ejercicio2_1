using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ejercicio2_1.Models;
using Newtonsoft.Json;

namespace Ejercicio2_1.Controller
{
    public class RegionController
    {          
            public async static Task<List<ModelRegiones>> getRegion(string region) {

                List<ModelRegiones> lstRegions = new List<ModelRegiones>();

                using (HttpClient Cliente = new HttpClient())
                {
                    var rest = await Cliente.GetAsync("https://restcountries.com/v3.1/region/"+region);

                    if (rest.IsSuccessStatusCode)
                    {
                        var contenido = rest.Content.ReadAsStringAsync().Result;

                        lstRegions = JsonConvert.DeserializeObject<List<ModelRegiones>>(contenido);
                    }

                }
                return lstRegions;
            }
        }
}
