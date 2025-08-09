using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WinExamen.Modelo.DTO;

namespace WinExamen.Controlador
{
    internal class APIDuenio
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public APIDuenio()
        {
            _httpClient = new HttpClient();
            _baseUrl = "https://localhost:7034/api/Duenio"; // URL correcta
            // Configurar headers si es necesario
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        #region CRUD Operations

        /// <summary>
        /// Obtiene todos los dueños activos
        /// </summary>
        /// <returns>Lista de dueños</returns>
        public async Task<List<Dueniocs>> ObtenerTodosDueniosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/ListaDuenios");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var duenios = JsonConvert.DeserializeObject<List<Dueniocs>>(jsonContent);
                    return duenios ?? new List<Dueniocs>();
                }
                else
                {
                    throw new HttpRequestException($"Error al obtener dueños: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al conectar con la API: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene un dueño por su ID
        /// </summary>
        /// <param name="id">ID del dueño</param>
        /// <returns>Dueño encontrado o null</returns>
        public async Task<Dueniocs> ObtenerDuenioPorIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/ObtenerDuenio/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var duenio = JsonConvert.DeserializeObject<Dueniocs>(jsonContent);
                    return duenio;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw new HttpRequestException($"Error al obtener dueño: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener dueño por ID: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Crea un nuevo dueño
        /// </summary>
        /// <param name="duenio">Datos del dueño a crear</param>
        /// <returns>True si se creó exitosamente</returns>
        public async Task<bool> CrearDuenioAsync(Dueniocs duenio)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(duenio);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/CrearDuenio", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error al crear dueño: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear dueño: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Actualiza un dueño existente
        /// </summary>
        /// <param name="duenio">Datos del dueño a actualizar</param>
        /// <returns>True si se actualizó exitosamente</returns>
        public async Task<bool> ActualizarDuenioAsync(Dueniocs duenio)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(duenio);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{_baseUrl}/ActualizarDuenio/{duenio.pk_duenio}", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error al actualizar dueño: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar dueño: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Elimina un dueño por su ID
        /// </summary>
        /// <param name="id">ID del dueño a eliminar</param>
        /// <returns>True si se eliminó exitosamente</returns>
        public async Task<bool> EliminarDuenioAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/EliminarDuenio/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception($"Dueño con ID {id} no encontrado");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error al eliminar dueño: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar dueño: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Busca dueños por criterio específico
        /// </summary>
        /// <param name="criterio">Campo de búsqueda (nombre, apellido, email, etc.)</param>
        /// <param name="busqueda">Término de búsqueda</param>
        /// <returns>Lista de dueños que coinciden con el criterio</returns>
       
        /// <summary>
        /// Cambia el estado de un dueño (activo/inactivo)
        /// </summary>
        /// <param name="id">ID del dueño</param>
        /// <param name="nuevoEstado">Nuevo estado (true = activo, false = inactivo)</param>
        /// <returns>True si se cambió exitosamente</returns>
        public async Task<bool> CambiarEstadoDuenioAsync(int id, bool nuevoEstado)
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
                    throw new Exception($"Dueño con ID {id} no encontrado");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error al cambiar estado: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cambiar estado del dueño: {ex.Message}", ex);
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Valida los datos básicos de un dueño antes de enviarlo a la API
        /// </summary>
        /// <param name="duenio">Dueño a validar</param>
        /// <returns>True si es válido</returns>
        public bool ValidarDuenio(Dueniocs duenio)
        {
            if (duenio == null) return false;
            if (string.IsNullOrWhiteSpace(duenio.d_nombre)) return false;
            if (string.IsNullOrWhiteSpace(duenio.d_apellido)) return false;
            if (string.IsNullOrWhiteSpace(duenio.d_email)) return false;
            if (string.IsNullOrWhiteSpace(duenio.d_telefono)) return false;

            return true;
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
    

    #endregion
}