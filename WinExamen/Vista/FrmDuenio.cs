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
    public partial class FrmDuenio : Form
    {
        private APIDuenio apiDuenio;

        public FrmDuenio()
        {
            InitializeComponent();
            apiDuenio = new APIDuenio();
        }

        private async void FrmDuenio_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarFormulario();
                await CargarDuenios();
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

            // Configurar fecha por defecto
            fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Configurar estado por defecto
            checkBox1.Checked = true;

            // Deshabilitar el campo ID (se genera automáticamente)
            pk_duenio.ReadOnly = true;
            pk_duenio.BackColor = SystemColors.Control;

            LimpiarCampos();
        }

        // Cargar todos los dueños
        private async void listarDuenio_Click(object sender, EventArgs e)
        {
            await CargarDuenios();
        }

        private async Task CargarDuenios()
        {
            try
            {
                // Mostrar cursor de espera
                this.Cursor = Cursors.WaitCursor;

                var duenios = await apiDuenio.ObtenerTodosDueniosAsync();
                dataGridView1.DataSource = duenios;

                // Configurar columnas del DataGridView
                ConfigurarDataGridView();

                // Mostrar mensaje informativo
                if (duenios.Count == 0)
                {
                    MessageBox.Show("No se encontraron dueños registrados.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Se cargaron {duenios.Count} dueños exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar dueños: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // Agregar nuevo dueño
        private async void agregardueño_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (!ValidarCampos())
                {
                    return;
                }

                var nuevoDuenio = new Dueniocs
                {
                    d_nombre = textBox2.Text.Trim(),
                    d_apellido = apellido.Text.Trim(),
                    d_telefono = textBox4.Text.Trim(),
                    d_email = email.Text.Trim(),
                    d_direccion = direccion.Text.Trim(),
                    d_fechaRegistro = DateTime.TryParse(fecha.Text, out DateTime fechaRegistro) ? fechaRegistro : DateTime.Now,
                    d_estado = checkBox1.Checked
                };

                // Validar con el método de la API
                if (apiDuenio.ValidarDuenio(nuevoDuenio))
                {
                    this.Cursor = Cursors.WaitCursor;

                    var resultado = await apiDuenio.CrearDuenioAsync(nuevoDuenio);

                    if (resultado)
                    {
                        MessageBox.Show("Dueño creado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await CargarDuenios(); // Recargar lista
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
                MessageBox.Show($"Error al guardar dueño: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // Actualizar dueño existente
        private async void Actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Por favor seleccione un dueño para actualizar", "Selección requerida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(pk_duenio.Text) || pk_duenio.Text == "0")
                {
                    MessageBox.Show("Debe seleccionar un dueño válido para actualizar", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarCampos())
                {
                    return;
                }

                var duenio = new Dueniocs
                {
                    pk_duenio = int.Parse(pk_duenio.Text),
                    d_nombre = textBox2.Text.Trim(),
                    d_apellido = apellido.Text.Trim(),
                    d_telefono = textBox4.Text.Trim(),
                    d_email = email.Text.Trim(),
                    d_direccion = direccion.Text.Trim(),
                    d_fechaRegistro = DateTime.TryParse(fecha.Text, out DateTime fechaRegistro) ? fechaRegistro : DateTime.Now,
                    d_estado = checkBox1.Checked
                };

                this.Cursor = Cursors.WaitCursor;

                var resultado = await apiDuenio.ActualizarDuenioAsync(duenio);

                if (resultado)
                {
                    MessageBox.Show("Dueño actualizado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await CargarDuenios(); // Recargar lista
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar dueño: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // Al seleccionar una fila del DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dataGridView1.CurrentRow != null)
                {
                    var duenio = (Dueniocs)dataGridView1.CurrentRow.DataBoundItem;

                    if (duenio != null)
                    {
                        CargarDatosEnCampos(duenio);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar dueño: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método adicional para manejar selección con clic en cualquier parte de la fila
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.DataBoundItem is Dueniocs duenio)
                {
                    CargarDatosEnCampos(duenio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del dueño: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEnCampos(Dueniocs duenio)
        {
            pk_duenio.Text = duenio.pk_duenio.ToString();
            textBox2.Text = duenio.d_nombre;
            apellido.Text = duenio.d_apellido;
            textBox4.Text = duenio.d_telefono;
            email.Text = duenio.d_email;
            direccion.Text = duenio.d_direccion;
            fecha.Text = duenio.d_fechaRegistro?.ToString("dd/MM/yyyy") ?? DateTime.Now.ToString("dd/MM/yyyy");
            checkBox1.Checked = duenio.d_estado;
        }

        private void ConfigurarDataGridView()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["pk_duenio"].HeaderText = "ID";
                dataGridView1.Columns["pk_duenio"].Width = 50;

                dataGridView1.Columns["d_nombre"].HeaderText = "Nombre";
                dataGridView1.Columns["d_apellido"].HeaderText = "Apellido";
                dataGridView1.Columns["d_telefono"].HeaderText = "Teléfono";
                dataGridView1.Columns["d_email"].HeaderText = "Email";
                dataGridView1.Columns["d_direccion"].HeaderText = "Dirección";
                dataGridView1.Columns["d_fechaRegistro"].HeaderText = "Fecha Registro";
                dataGridView1.Columns["d_estado"].HeaderText = "Estado";

                // Ocultar columnas calculadas que no necesitamos mostrar
                if (dataGridView1.Columns["NombreCompleto"] != null)
                    dataGridView1.Columns["NombreCompleto"].Visible = false;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("El nombre es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(apellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                apellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(email.Text))
            {
                MessageBox.Show("El email es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                email.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("El teléfono es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
                return false;
            }

            // Validar formato de email básico
            if (!email.Text.Contains("@") || !email.Text.Contains("."))
            {
                MessageBox.Show("Por favor ingrese un email válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                email.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            pk_duenio.Text = "0";
            textBox2.Clear();
            apellido.Clear();
            textBox4.Clear();
            email.Clear();
            direccion.Clear();
            fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            checkBox1.Checked = true;

            // Enfocar el primer campo
            textBox2.Focus();
        }

        // Eventos adicionales para mejorar la experiencia de usuario
        private void label2_Click(object sender, EventArgs e)
        {
            // Método vacío mantenido por compatibilidad
        }

        // Agregar evento KeyPress para validar entrada numérica en teléfono
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, backspace y control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Método para manejar el evento Enter en los campos de texto
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Mover al siguiente control
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        // Botón adicional para eliminar (si quieres agregarlo)
        private async void EliminarDuenio()
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Por favor seleccione un dueño para eliminar", "Selección requerida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var duenio = (Dueniocs)dataGridView1.CurrentRow.DataBoundItem;

                var confirmResult = MessageBox.Show($"¿Está seguro de eliminar a {duenio.NombreCompleto}?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;

                    var resultado = await apiDuenio.EliminarDuenioAsync(duenio.pk_duenio);

                    if (resultado)
                    {
                        MessageBox.Show("Dueño eliminado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await CargarDuenios(); // Recargar lista
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar dueño: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // Limpiar recursos al cerrar el formulario
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                apiDuenio?.Dispose();
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        // Método para buscar dueños (si quieres agregar funcionalidad de búsqueda)
    }
}