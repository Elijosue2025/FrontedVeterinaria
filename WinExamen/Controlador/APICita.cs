using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WinExamen.Modelo.DTO;

namespace WinExamen.Controlador
{
    internal class APICita
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public APICita()
        {
            _httpClient = new HttpClient();
            _baseUrl = "https://localhost:7157/api/Cita"; // Cambia por tu URL base real

            // Configurar headers
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        #region CRUD Operations Básicas

        /// <summary>
        /// Obtiene todas las citas activas
        /// </summary>
        /// <returns>Lista de citas</returns>
        public async Task<List<Citas>> ObtenerTodasCitasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_baseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var citas = JsonConvert.DeserializeObject<List<Citas>>(jsonContent);
                    return citas ?? new List<Citas>();
                }
                else
                {
                    throw new HttpRequestException($"Error al obtener citas: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al conectar con la API: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene una cita por su ID
        /// </summary>
        /// <param name="id">ID de la cita</param>
        /// <returns>Cita encontrada o null</returns>
        public async Task<Citas> ObtenerCitaPorIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var cita = JsonConvert.DeserializeObject<Citas>(jsonContent);
                    return cita;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw new HttpRequestException($"Error al obtener cita: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener cita por ID: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Crea una nueva cita
        /// </summary>
        /// <param name="cita">Datos de la cita a crear</param>
        /// <returns>True si se creó exitosamente</returns>
        public async Task<bool> CrearCitaAsync(Citas cita)
        {
            try
            {
                // Validar datos antes de enviar
                if (!ValidarCita(cita))
                {
                    throw new ArgumentException("Los datos de la cita no son válidos");
                }

                // Configurar fechas si no están establecidas
                if (cita.ci_fechaCreacion == null || cita.ci_fechaCreacion == default(DateTime))
                {
                    cita.ci_fechaCreacion = DateTime.Now;
                }

                if (cita.ci_estado == null)
                {
                    cita.ci_estado = true;
                }

                var jsonContent = JsonConvert.SerializeObject(cita);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(_baseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error al crear cita: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear cita: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Actualiza una cita existente
        /// </summary>
        /// <param name="cita">Datos de la cita a actualizar</param>
        /// <returns>True si se actualizó exitosamente</returns>
        public async Task<bool> ActualizarCitaAsync(Citas cita)
        {
            try
            {
                if (!ValidarCita(cita))
                {
                    throw new ArgumentException("Los datos de la cita no son válidos");
                }

                var jsonContent = JsonConvert.SerializeObject(cita);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{_baseUrl}/{cita.pk_cita}", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error al actualizar cita: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar cita: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Elimina una cita por su ID (eliminación lógica)
        /// </summary>
        /// <param name="id">ID de la cita a eliminar</param>
        /// <returns>True si se eliminó exitosamente</returns>
        public async Task<bool> EliminarCitaAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception($"Cita con ID {id} no encontrada");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error al eliminar cita: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar cita: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Busca citas por criterio específico
        /// </summary>
        /// <param name="criterio">Campo de búsqueda (motivo, observaciones, estado, etc.)</param>
        /// <param name="busqueda">Término de búsqueda</param>
        /// <returns>Lista de citas que coinciden con el criterio</returns>
        public async Task<List<Citas>> BuscarCitasPorCriterioAsync(string criterio, string busqueda)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/buscar?criterio={criterio}&busqueda={busqueda}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var citas = JsonConvert.DeserializeObject<List<Citas>>(jsonContent);
                    return citas ?? new List<Citas>();
                }
                else
                {
                    throw new HttpRequestException($"Error al buscar citas: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar citas por criterio: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Cambia el estado de una cita (activa/inactiva)
        /// </summary>
        /// <param name="id">ID de la cita</param>
        /// <param name="nuevoEstado">Nuevo estado (true = activa, false = inactiva)</param>
        /// <returns>True si se cambió exitosamente</returns>
        public async Task<bool> CambiarEstadoCitaAsync(int id, bool nuevoEstado)
        {
            try
            {
                var response = await _httpClient.PutAsync($"{_baseUrl}/{id}/estado?nuevoEstado={nuevoEstado}", null);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception($"Cita con ID {id} no encontrada");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error al cambiar estado: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cambiar estado de la cita: {ex.Message}", ex);
            }
        }

        #endregion

        #region Métodos Adicionales Útiles

        /// <summary>
        /// Obtiene todas las citas de una mascota específica
        /// </summary>
        /// <param name="mascotaId">ID de la mascota</param>
        /// <returns>Lista de citas de la mascota</returns>
        public async Task<List<Citas>> ObtenerCitasPorMascotaAsync(int mascotaId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/mascota/{mascotaId}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var citas = JsonConvert.DeserializeObject<List<Citas>>(jsonContent);
                    return citas ?? new List<Citas>();
                }
                else
                {
                    throw new HttpRequestException($"Error al obtener citas por mascota: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener citas por mascota: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene todas las citas de una fecha específica
        /// </summary>
        /// <param name="fecha">Fecha a consultar</param>
        /// <returns>Lista de citas de la fecha</returns>
        public async Task<List<Citas>> ObtenerCitasPorFechaAsync(DateTime fecha)
        {
            try
            {
                string fechaFormateada = fecha.ToString("yyyy-MM-dd");
                var response = await _httpClient.GetAsync($"{_baseUrl}/fecha/{fechaFormateada}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var citas = JsonConvert.DeserializeObject<List<Citas>>(jsonContent);
                    return citas ?? new List<Citas>();
                }
                else
                {
                    throw new HttpRequestException($"Error al obtener citas por fecha: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener citas por fecha: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene todas las citas por estado
        /// </summary>
        /// <param name="estadoCita">Estado de la cita (Programada, Completada, Cancelada)</param>
        /// <returns>Lista de citas con el estado especificado</returns>
        public async Task<List<Citas>> ObtenerCitasPorEstadoAsync(string estadoCita)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/estado/{estadoCita}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var citas = JsonConvert.DeserializeObject<List<Citas>>(jsonContent);
                    return citas ?? new List<Citas>();
                }
                else
                {
                    throw new HttpRequestException($"Error al obtener citas por estado: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener citas por estado: {ex.Message}", ex);
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Valida los datos básicos de una cita antes de enviarla a la API
        /// </summary>
        /// <param name="cita">Cita a validar</param>
        /// <returns>True si es válida</returns>
        public bool ValidarCita(Citas cita)
        {
            if (cita == null) return false;
            if (cita.fk_mascota <= 0) return false;
            if (string.IsNullOrWhiteSpace(cita.ci_motivo)) return false;
            if (cita.ci_fechaCita == default(DateTime)) return false;
            if (cita.ci_fechaCita < DateTime.Today) return false; // No permitir fechas pasadas

            return true;
        }

        /// <summary>
        /// Verifica si una fecha está disponible para una mascota
        /// </summary>
        /// <param name="mascotaId">ID de la mascota</param>
        /// <param name="fechaCita">Fecha de la cita</param>
        /// <returns>True si la fecha está disponible</returns>
        public async Task<bool> ValidarDisponibilidadCitaAsync(int mascotaId, DateTime fechaCita)
        {
            try
            {
                string fechaFormateada = fechaCita.ToString("yyyy-MM-dd");
                var response = await _httpClient.GetAsync($"{_baseUrl}/validar-disponibilidad?mascotaId={mascotaId}&fechaCita={fechaFormateada}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<DisponibilidadResponse>(jsonContent);
                    return resultado?.Disponible ?? false;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al validar disponibilidad: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene los estados de cita disponibles
        /// </summary>
        /// <returns>Lista de estados disponibles</returns>
        public List<string> ObtenerEstadosDisponibles()
        {
            return new List<string>
            {
                "Programada",
                "Completada",
                "Cancelada",
                "En Proceso",
                "Reprogramada"
            };
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
    /// Clase para deserializar respuestas de validación de disponibilidad
    /// </summary>
    public class DisponibilidadResponse
    {
        [JsonProperty("disponible")]
        public bool Disponible { get; set; }

        [JsonProperty("mensaje")]
        public string Mensaje { get; set; }
    }

    #endregion
}