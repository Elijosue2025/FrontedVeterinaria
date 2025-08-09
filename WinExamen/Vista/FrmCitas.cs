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
    public partial class FrmCitas : Form
    {
        private APICita apiCita;

        public FrmCitas()
        {
            InitializeComponent();
            apiCita = new APICita();
        }

        private async void FrmCitas_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarFormulario();
                await CargarCitas();
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
            fecharegistro.Value = DateTime.Now;
            fechacita.Value = DateTime.Now.AddDays(1);

            // Configurar estado por defecto
            estado_cita.Text = "Programada";

            // Deshabilitar el campo ID (se genera automáticamente)
            id_cita.ReadOnly = true;
            id_cita.BackColor = SystemColors.Control;

            LimpiarCampos();
        }

        // Cargar todas las citas - Botón Listar
        private async void ListarCita_Click(object sender, EventArgs e)
        {
            await CargarCitas();
        }

        private async Task CargarCitas()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var citas = await apiCita.ObtenerTodasCitasAsync();
                dataGridView1.DataSource = citas;

                ConfigurarDataGridView();

                MessageBox.Show($"Se cargaron {citas.Count} citas exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar citas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // Guardar nueva cita - Botón Guardar
        private async void guardarCita_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                {
                    return;
                }

                var nuevaCita = new Citas
                {
                    fk_mascota = int.TryParse(fk_mascota.Text, out int mascotaId) ? mascotaId : 0,
                    ci_fechaCita = fechacita.Value,
                    ci_motivo = motivo_cita.Text.Trim(),
                    ci_observaciones = observaciones_cita.Text.Trim(),
                    ci_estadoCita = estado_cita.Text.Trim(),
                    ci_fechaCreacion = fecharegistro.Value,
                    ci_estado = true
                };

                if (apiCita.ValidarCita(nuevaCita))
                {
                    this.Cursor = Cursors.WaitCursor;

                    var resultado = await apiCita.CrearCitaAsync(nuevaCita);

                    if (resultado)
                    {
                        MessageBox.Show("Cita creada exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await CargarCitas();
                        LimpiarCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor complete todos los campos obligatorios", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar cita: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // Actualizar cita existente - Botón Actualizar
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Por favor seleccione una cita para actualizar", "Selección requerida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(id_cita.Text) || id_cita.Text == "0")
                {
                    MessageBox.Show("Debe seleccionar una cita válida para actualizar", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarCampos())
                {
                    return;
                }

                var cita = new Citas
                {
                    pk_cita = int.Parse(id_cita.Text),
                    fk_mascota = int.TryParse(fk_mascota.Text, out int mascotaId) ? mascotaId : 0,
                    ci_fechaCita = fechacita.Value,
                    ci_motivo = motivo_cita.Text.Trim(),
                    ci_observaciones = observaciones_cita.Text.Trim(),
                    ci_estadoCita = estado_cita.Text.Trim(),
                    ci_fechaCreacion = fecharegistro.Value,
                    ci_estado = true
                };

                this.Cursor = Cursors.WaitCursor;

                var resultado = await apiCita.ActualizarCitaAsync(cita);

                if (resultado)
                {
                    MessageBox.Show("Cita actualizada exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await CargarCitas();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar cita: {ex.Message}", "Error",
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
                    var cita = (Citas)dataGridView1.CurrentRow.DataBoundItem;

                    if (cita != null)
                    {
                        CargarDatosEnCampos(cita);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar cita: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento adicional para selección con SelectionChanged
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.DataBoundItem is Citas cita)
                {
                    CargarDatosEnCampos(cita);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de la cita: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEnCampos(Citas cita)
        {
            id_cita.Text = cita.pk_cita.ToString();
            fk_mascota.Text = cita.fk_mascota.ToString();
            fechacita.Value = cita.ci_fechaCita;
            motivo_cita.Text = cita.ci_motivo;
            observaciones_cita.Text = cita.ci_observaciones;
            estado_cita.Text = cita.ci_estadoCita;
            fecharegistro.Value = cita.ci_fechaCreacion ?? DateTime.Now;
        }

        private void ConfigurarDataGridView()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["pk_cita"].HeaderText = "ID";
                dataGridView1.Columns["pk_cita"].Width = 50;

                dataGridView1.Columns["fk_mascota"].HeaderText = "ID Mascota";
                dataGridView1.Columns["ci_fechaCita"].HeaderText = "Fecha Cita";
                dataGridView1.Columns["ci_motivo"].HeaderText = "Motivo";
                dataGridView1.Columns["ci_observaciones"].HeaderText = "Observaciones";
                dataGridView1.Columns["ci_estadoCita"].HeaderText = "Estado";
                dataGridView1.Columns["ci_fechaCreacion"].HeaderText = "Fecha Creación";
                dataGridView1.Columns["ci_estado"].HeaderText = "Activo";
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(fk_mascota.Text) || !int.TryParse(fk_mascota.Text, out int mascotaId) || mascotaId <= 0)
            {
                MessageBox.Show("Debe especificar un ID de mascota válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fk_mascota.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(motivo_cita.Text))
            {
                MessageBox.Show("El motivo de la cita es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                motivo_cita.Focus();
                return false;
            }

            if (fechacita.Value < DateTime.Today)
            {
                MessageBox.Show("La fecha de la cita no puede ser anterior a hoy", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fechacita.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(estado_cita.Text))
            {
                estado_cita.Text = "Programada";
            }

            return true;
        }

        private void LimpiarCampos()
        {
            id_cita.Text = "0";
            fk_mascota.Clear();
            motivo_cita.Clear();
            observaciones_cita.Clear();
            estado_cita.Text = "Programada";
            fechacita.Value = DateTime.Now.AddDays(1);
            fecharegistro.Value = DateTime.Now;

            fk_mascota.Focus();
        }

        // Eventos existentes mantenidos por compatibilidad
        private void label2_Click(object sender, EventArgs e)
        {
            // Evento mantenido
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Evento mantenido
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Evento mantenido
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Evento mantenido
        }

        // Validar entrada numérica en ID de mascota
        private void fk_mascota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Limpiar recursos al cerrar el formulario
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                apiCita?.Dispose();
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}