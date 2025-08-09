using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WinExamen.Controlador
{
    public class APIVeterinaria
    {
        private readonly HttpClient _httpClient; // Conectar a mi API
        private readonly string _baseUrl;        // Dirección del API

        public APIVeterinaria(string baseUrl) // Constructor
        {
            _baseUrl = baseUrl.TrimEnd('/');
            _httpClient = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string endPoint) // Método genérico para listar datos
        {
            var respuesta = await _httpClient.GetAsync($"{_baseUrl}/{endPoint}"); // Leer los datos
            respuesta.EnsureSuccessStatusCode();

            var contenido = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(contenido);
        }

    }
}
