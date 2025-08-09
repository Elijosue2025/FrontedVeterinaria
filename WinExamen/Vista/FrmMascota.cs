using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinExamen.Controlador;
using WinExamen.Modelo.DTO;

namespace WinExamen.Vista
{
    public partial class FrmMascota : Form
    {
        private ApiMascota apiMascota;
        private APIDuenio apiDuenio; // Para cargar dueños disponibles

        public FrmMascota()
        {
            InitializeComponent();
            apiMascota = new ApiMascota();
            apiDuenio = new APIDuenio();
        }

        private async void FrmPacientes_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarFormulario();
                await CargarMascotas();
                await CargarDueniosDisponibles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarFormulario()
        {
            // Configurar el DataGridView
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Agregar evento de selección
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            // Configurar fechas por defecto
            fechaNacimiento.Text = DateTime.Now.AddYears(-1).ToString("dd/MM/yyyy");
            textBox11.Text = DateTime.Now.ToString("dd/MM/yyyy"); // Fecha registro

            // Configurar estado por defecto
            textBox9.Text = "True"; // Estado activo

            // Deshabilitar el campo ID (se genera automáticamente)
            pk_mascota.ReadOnly = true;
            pk_mascota.BackColor = SystemColors.Control;

            LimpiarCampos();
        }

        // Cargar todas las mascotas
        private async void listarMascotas_Click(object sender, EventArgs e)
        {
            await CargarMascotas();
        }

        private async Task CargarMascotas()
        {
            try
            {
                // Mostrar cursor de espera
                this.Cursor = Cursors.WaitCursor;

                var mascotas = await apiMascota.ObtenerTodasMascotasAsync();
                dataGridView1.DataSource = mascotas;

                // Configurar columnas del DataGridView
                ConfigurarDataGridView();

                // Mostrar mensaje informativo
                if (mascotas.Count == 0)
                {
                    MessageBox.Show("No se encontraron mascotas registradas.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Se cargaron {mascotas.Count} mascotas exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar mascotas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // Agregar nueva mascota
        private async void agregarMascota_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (!ValidarCampos())
                {
                    return;
                }

                var nuevaMascota = new Mascotas
                {
                    ma_nombre = nombreMascota.Text.Trim(),
                    ma_especie = especieMascota.Text.Trim(),
                    ma_raza = razaMascota.Text.Trim(),
                    ma_fechaNacimiento = DateTime.TryParse(fechaNacimiento.Text, out DateTime fechaNac) ? fechaNac : DateTime.Now.AddYears(-1),
                    ma_peso = decimal.TryParse(pesoMascota.Text, out decimal peso) ? peso : (decimal?)null,
                    ma_color = colorMascota.Text.Trim(),
                    ma_genero = generoMascota.Text.Trim(),
                    fk_duenio = int.TryParse(textBox12.Text, out int duenioId) ? duenioId : 0,
                    ma_fechaRegistro = DateTime.TryParse(textBox11.Text, out DateTime fechaReg) ? fechaReg : DateTime.Now,
                    ma_estado = bool.TryParse(textBox9.Text, out bool estado) ? estado : true
                };

                // Validar con el método de la API
                if (apiMascota.ValidarMascota(nuevaMascota))
                {
                    this.Cursor = Cursors.WaitCursor;

                    var resultado = await apiMascota.CrearMascotaAsync(nuevaMascota);

                    if (resultado)
                    {
                        MessageBox.Show("Mascota creada exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await CargarMascotas(); // Recargar lista
                        LimpiarCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor complete todos los campos obligatorios correctamente", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar mascota: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // Actualizar mascota existente
        private async void actualizasMascota_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Por favor seleccione una mascota para actualizar", "Selección requerida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(pk_mascota.Text) || pk_mascota.Text == "0")
                {
                    MessageBox.Show("Debe seleccionar una mascota válida para actualizar", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarCampos())
                {
                    return;
                }

                var mascota = new Mascotas
                {
                    pk_mascota = int.Parse(pk_mascota.Text),
                    ma_nombre = nombreMascota.Text.Trim(),
                    ma_especie = especieMascota.Text.Trim(),
                    ma_raza = razaMascota.Text.Trim(),
                    ma_fechaNacimiento = DateTime.TryParse(fechaNacimiento.Text, out DateTime fechaNac) ? fechaNac : DateTime.Now.AddYears(-1),
                    ma_peso = decimal.TryParse(pesoMascota.Text, out decimal peso) ? peso : (decimal?)null,
                    ma_color = colorMascota.Text.Trim(),
                    ma_genero = generoMascota.Text.Trim(),
                    fk_duenio = int.TryParse(textBox12.Text, out int duenioId) ? duenioId : 0,
                    ma_fechaRegistro = DateTime.TryParse(textBox11.Text, out DateTime fechaReg) ? fechaReg : DateTime.Now,
                    ma_estado = bool.TryParse(textBox9.Text, out bool estado) ? estado : true
                };

                this.Cursor = Cursors.WaitCursor;

                var resultado = await apiMascota.ActualizarMascotaAsync(mascota);

                if (resultado)
                {
                    MessageBox.Show("Mascota actualizada exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await CargarMascotas(); // Recargar lista
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar mascota: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // Al seleccionar una fila del DataGridView
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.DataBoundItem is Mascotas mascota)
                {
                    CargarDatosEnCampos(mascota);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de la mascota: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEnCampos(Mascotas mascota)
        {
            pk_mascota.Text = mascota.pk_mascota.ToString();
            nombreMascota.Text = mascota.ma_nombre;
            especieMascota.Text = mascota.ma_especie;
            razaMascota.Text = mascota.ma_raza;
            fechaNacimiento.Text = mascota.ma_fechaNacimiento.ToString("dd/MM/yyyy");
            pesoMascota.Text = mascota.ma_peso?.ToString() ?? "";
            colorMascota.Text = mascota.ma_color;
            generoMascota.Text = mascota.ma_genero;
            textBox12.Text = mascota.fk_duenio.ToString();
            textBox11.Text = mascota.ma_fechaRegistro?.ToString("dd/MM/yyyy") ?? DateTime.Now.ToString("dd/MM/yyyy");
            textBox9.Text = mascota.ma_estado.ToString();
        }

        private async Task CargarDueniosDisponibles()
        {
            try
            {
                var duenios = await apiDuenio.ObtenerTodosDueniosAsync();

                // Crear un tooltip o mensaje para mostrar los dueños disponibles
                if (duenios.Count > 0)
                {
                    string toolTipText = "Dueños disponibles:\n";
                    foreach (var duenio in duenios.Take(10)) // Mostrar solo los primeros 10
                    {
                        toolTipText += $"ID: {duenio.pk_duenio} - {duenio.NombreCompleto}\n";
                    }

                    ToolTip toolTip = new ToolTip();
                    toolTip.SetToolTip(textBox12, toolTipText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar dueños: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConfigurarDataGridView()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["pk_mascota"].HeaderText = "ID";
                dataGridView1.Columns["pk_mascota"].Width = 50;

                dataGridView1.Columns["ma_nombre"].HeaderText = "Nombre";
                dataGridView1.Columns["ma_especie"].HeaderText = "Especie";
                dataGridView1.Columns["ma_raza"].HeaderText = "Raza";
                dataGridView1.Columns["ma_fechaNacimiento"].HeaderText = "Fecha Nacimiento";
                dataGridView1.Columns["ma_peso"].HeaderText = "Peso";
                dataGridView1.Columns["ma_color"].HeaderText = "Color";
                dataGridView1.Columns["ma_genero"].HeaderText = "Género";
                dataGridView1.Columns["fk_duenio"].HeaderText = "ID Dueño";
                dataGridView1.Columns["ma_fechaRegistro"].HeaderText = "Fecha Registro";
                dataGridView1.Columns["ma_estado"].HeaderText = "Estado";

                // Ocultar columnas calculadas que no necesitamos mostrar
                if (dataGridView1.Columns["Edad"] != null)
                    dataGridView1.Columns["Edad"].Visible = false;
                if (dataGridView1.Columns["NombreConEspecie"] != null)
                    dataGridView1.Columns["NombreConEspecie"].Visible = false;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(nombreMascota.Text))
            {
                MessageBox.Show("El nombre de la mascota es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nombreMascota.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(especieMascota.Text))
            {
                MessageBox.Show("La especie es obligatoria", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                especieMascota.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(razaMascota.Text))
            {
                MessageBox.Show("La raza es obligatoria", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                razaMascota.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox12.Text) || !int.TryParse(textBox12.Text, out int duenioId) || duenioId <= 0)
            {
                MessageBox.Show("Debe especificar un ID de dueño válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox12.Focus();
                return false;
            }

            if (!DateTime.TryParse(fechaNacimiento.Text, out DateTime fechaNac))
            {
                MessageBox.Show("La fecha de nacimiento debe tener un formato válido (dd/MM/yyyy)", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fechaNacimiento.Focus();
                return false;
            }

            if (fechaNac > DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fechaNacimiento.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(pesoMascota.Text) && !decimal.TryParse(pesoMascota.Text, out decimal peso))
            {
                MessageBox.Show("El peso debe ser un número válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pesoMascota.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            pk_mascota.Text = "0";
            nombreMascota.Clear();
            especieMascota.Clear();
            razaMascota.Clear();
            fechaNacimiento.Text = DateTime.Now.AddYears(-1).ToString("dd/MM/yyyy");
            pesoMascota.Clear();
            colorMascota.Clear();
            generoMascota.Clear();
            textBox12.Clear(); // ID Dueño
            textBox11.Text = DateTime.Now.ToString("dd/MM/yyyy"); // Fecha registro
            textBox9.Text = "True"; // Estado

            // Enfocar el primer campo
            nombreMascota.Focus();
        }

        // Eventos adicionales para mejorar la experiencia de usuario
        private void label12_Click(object sender, EventArgs e)
        {
            // Mostrar formulario de dueños o información adicional
            MessageBox.Show("Ingrese el ID del dueño. Use el botón de información para ver dueños disponibles.",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Validar entrada numérica en campos específicos
        private void pesoMascota_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, punto decimal y backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo números para ID de dueño
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Método para eliminar mascota (si quieres agregarlo)
        private async void EliminarMascota()
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Por favor seleccione una mascota para eliminar", "Selección requerida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var mascota = (Mascotas)dataGridView1.CurrentRow.DataBoundItem;

                var confirmResult = MessageBox.Show($"¿Está seguro de eliminar a {mascota.NombreConEspecie}?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;

                    var resultado = await apiMascota.EliminarMascotaAsync(mascota.pk_mascota);

                    if (resultado)
                    {
                        MessageBox.Show("Mascota eliminada exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await CargarMascotas(); // Recargar lista
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar mascota: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

       

        // Método para mostrar edad calculada
        private void MostrarEdadMascota()
        {
            if (DateTime.TryParse(fechaNacimiento.Text, out DateTime fechaNac))
            {
                int edad = apiMascota.CalcularEdad(fechaNac);
                MessageBox.Show($"La mascota tiene {edad} años", "Edad",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
