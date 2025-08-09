using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WinExamen.Modelo.DTO;

namespace WinExamen.Controlador
{
    internal class ApiMascota
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiMascota()
        {
            _httpClient = new HttpClient();
            _baseUrl = "https://localhost:7034/api/Mascotas"; // URL correcta
            // Configurar headers
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        #region CRUD Operations

        /// <summary>
        /// Obtiene todas las mascotas activas
        /// </summary>
        /// <returns>Lista de mascotas</returns>
        public async Task<List<Mascotas>> ObtenerTodasMascotasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/ListaMascotas");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var mascotas = JsonConvert.DeserializeObject<List<Mascotas>>(jsonContent);
                    return mascotas ?? new List<Mascotas>();
                }
                else
                {
                    throw new HttpRequestException($"Error al obtener mascotas: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al conectar con la API: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene una mascota por su ID
        /// </summary>
        /// <param name="id">ID de la mascota</param>
        /// <returns>Mascota encontrada o null</returns>
        public async Task<Mascotas> ObtenerMascotaPorIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/ObtenerMascota/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var mascota = JsonConvert.DeserializeObject<Mascotas>(jsonContent);
                    return mascota;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw new HttpRequestException($"Error al obtener mascota: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener mascota por ID: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Crea una nueva mascota
        /// </summary>
        /// <param name="mascota">Datos de la mascota a crear</param>
        /// <returns>True si se creó exitosamente</returns>
        public async Task<bool> CrearMascotaAsync(Mascotas mascota)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(mascota);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/CrearMascota", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error al crear mascota: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear mascota: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Actualiza una mascota existente
        /// </summary>
        /// <param name="mascota">Datos de la mascota a actualizar</param>
        /// <returns>True si se actualizó exitosamente</returns>
        public async Task<bool> ActualizarMascotaAsync(Mascotas mascota)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(mascota);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{_baseUrl}/ActualizarMascota/{mascota.pk_mascota}", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error al actualizar mascota: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar mascota: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Elimina una mascota por su ID
        /// </summary>
        /// <param name="id">ID de la mascota a eliminar</param>
        /// <returns>True si se eliminó exitosamente</returns>
        public async Task<bool> EliminarMascotaAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/EliminarMascota/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception($"Mascota con ID {id} no encontrada");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error al eliminar mascota: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar mascota: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Busca mascotas por criterio específico
        /// </summary>
        /// <param name="criterio">Campo de búsqueda (nombre, especie, raza, etc.)</param>
        /// <param name="busqueda">Término de búsqueda</param>
        /// <returns>Lista de mascotas que coinciden con el criterio</returns>
        
        /// <summary>
        /// Cambia el estado de una mascota (activa/inactiva)
        /// </summary>
        /// <param name="id">ID de la mascota</param>
        /// <param name="nuevoEstado">Nuevo estado (true = activa, false = inactiva)</param>
        /// <returns>True si se cambió exitosamente</returns>
        public async Task<bool> CambiarEstadoMascotaAsync(int id, bool nuevoEstado)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(nuevoEstado);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), $"{_baseUrl}/CambiarEstado/{id}")
                {
                    Content = content
                });

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception($"Mascota con ID {id} no encontrada");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error al cambiar estado: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cambiar estado de la mascota: {ex.Message}", ex);
            }
        }

       
        /// <summary>
        /// Obtiene todas las mascotas de una especie específica
        /// </summary>
        /// <param name="especie">Especie de la mascota</param>
        /// <returns>Lista de mascotas de la especie</returns>
       
        /// <summary>
        /// Obtiene todas las mascotas de una raza específica
        /// </summary>
        /// <param name="raza">Raza de la mascota</param>
        /// <returns>Lista de mascotas de la raza</returns>
       
        #endregion

        #region Helper Methods

        /// <summary>
        /// Valida los datos básicos de una mascota antes de enviarla a la API
        /// </summary>
        /// <param name="mascota">Mascota a validar</param>
        /// <returns>True si es válida</returns>
        public bool ValidarMascota(Mascotas mascota)
        {
            if (mascota == null) return false;
            if (string.IsNullOrWhiteSpace(mascota.ma_nombre)) return false;
            if (string.IsNullOrWhiteSpace(mascota.ma_especie)) return false;
            if (string.IsNullOrWhiteSpace(mascota.ma_raza)) return false;
            if (mascota.ma_fechaNacimiento == default(DateTime)) return false;
            if (mascota.fk_duenio <= 0) return false;

            return true;
        }

        /// <summary>
        /// Obtiene la edad de una mascota en años
        /// </summary>
        /// <param name="fechaNacimiento">Fecha de nacimiento de la mascota</param>
        /// <returns>Edad en años</returns>
        public int CalcularEdad(DateTime fechaNacimiento)
        {
            var hoy = DateTime.Today;
            var edad = hoy.Year - fechaNacimiento.Year;

            if (fechaNacimiento.Date > hoy.AddYears(-edad))
                edad--;

            return edad;
        }

        /// <summary>
        /// Libera los recursos del HttpClient
        /// </summary>
        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        #endregion
    }

    #region Helper Classes

    /// <summary>
    /// Clase para deserializar respuestas de la API que tienen estructura específica
    /// </summary>
    /// <typeparam name="T">Tipo de datos esperado</typeparam>
    public class ApiResponse<T>
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("duenioId")]
        public int? DuenioId { get; set; }

        [JsonProperty("especie")]
        public string Especie { get; set; }

        [JsonProperty("raza")]
        public string Raza { get; set; }
    }

    #endregion
}