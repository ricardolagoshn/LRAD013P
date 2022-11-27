using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace LRAD013P.Controllers
{
    public static class AlumnController
    {
        public async static Task<List<Models.Alumnos>> getAlumnos()
        {
            List<Models.Alumnos> listalumnos = new List<Models.Alumnos>();

            try
            {

                using (HttpClient clientRequest = new HttpClient())
                {
                    var response = await clientRequest.GetAsync(Configuracion.GetServiceList);

                    if (response.IsSuccessStatusCode)
                    {
                        var contenido = response.Content.ReadAsStringAsync().Result;
                        listalumnos = JsonConvert.DeserializeObject<List<Models.Alumnos>>(contenido);

                    }

                }
                return listalumnos;

            }
            catch (Exception ex)
            {
                ex.ToString();
                return listalumnos;
            }

            
        }


        public async static Task<int> CreateAlum(Models.Alumnos alum)
        {
            String JsonObject = JsonConvert.SerializeObject(alum);
            StringContent contenido = new StringContent(JsonObject, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            using (HttpClient client = new HttpClient())
            {
                response = await client.PostAsync(Configuracion.PostServiceList, contenido);

                if (response.IsSuccessStatusCode)
                {
                    var resultado = response.Content.ReadAsStringAsync().Result;
                    return 1;
                }
                else
                {
                    return 0;
                }
            }


        }

    }
}
