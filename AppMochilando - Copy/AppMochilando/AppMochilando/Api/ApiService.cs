using AppMochilando.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMochilando.Api
{
    public static class ApiService
    {
        public const string _url = "https://servico-wk3.conveyor.cloud/";

        public static async Task<List<Cliente>> ObterCliente()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _url + "/api/clientes";
                string response = await client.GetStringAsync(url);
                List<Cliente> cliente = JsonConvert.DeserializeObject<List<Cliente>>(response);
                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
