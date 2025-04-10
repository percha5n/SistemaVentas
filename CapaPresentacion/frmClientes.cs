﻿using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo() { valor = 1, text = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { valor = 0, text = "No Activo" });
            cboestado.DisplayMember = "text";
            cboestado.ValueMember = "valor";
            cboestado.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { valor = columna.Name, text = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "text";
            cbobusqueda.ValueMember = "valor";
            cbobusqueda.SelectedIndex = 0;


            //MOSTRAR TODOS LOS USUARIOS
            List<Cliente> lista = new CN_Cliente().Listar();

            foreach (Cliente item in lista)
            {
                dgvdata.Rows.Add(new object[] {
                        "",
                        item.IdCliente,
                        item.Documento,
                        item.NombreCompleto,
                        item.Correo,
                        item.Telefono,
                        item.Estado == true ? 1 : 0,
                        item.Estado == true ? "Activo" : "No activo",
                });
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Cliente obj = new Cliente()
            {
                IdCliente = string.IsNullOrWhiteSpace(txtid.Text) ? 0 : Convert.ToInt32(txtid.Text),
                Documento = txtdocumento.Text,
                NombreCompleto = txtnombrecompleto.Text,
                Correo = txtcorreo.Text,
                Telefono = txttelefono.Text,
                Estado = Convert.ToInt32((cboestado.SelectedItem as OpcionCombo).valor) == 1
            };

            if (obj.IdCliente == 0)
            {
                // Nuevo registro
                int idgenerado = new CN_Cliente().Registrar(obj, out mensaje);

                if (idgenerado != 0)
                {
                    if (cboestado.SelectedItem is OpcionCombo estadoSeleccionado)
                    {
                        dgvdata.Rows.Add(new object[] {
                            "",
                            idgenerado,
                            obj.Documento,
                            obj.NombreCompleto,
                            obj.Correo,
                            obj.Telefono,
                            estadoSeleccionado.valor.ToString(),
                            estadoSeleccionado.text.ToString()
                        });

                        Limpiar();
                    }
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                bool resultado = new CN_Cliente().Editar(obj, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = obj.IdCliente;
                    row.Cells["Documento"].Value = obj.Documento;
                    row.Cells["NombreCompleto"].Value = obj.NombreCompleto;
                    row.Cells["Correo"].Value = obj.Correo;
                    row.Cells["Telefono"].Value = obj.Telefono;
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).text.ToString();

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "";
            txtdocumento.Text = "";
            txtnombrecompleto.Text = "";
            txtcorreo.Text = "";
            txttelefono.Text = "";
            cboestado.SelectedIndex = 0;
            txtdocumento.Select();
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
            {
                return;
            }

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                string imagePath = @"C:\Users\Ezequ\Desktop\SistemaDeVentas\CapaPresentacion\imagenes\visto20.png";

                if (File.Exists(imagePath))
                {
                    using (Image img = Image.FromFile(imagePath))
                    {
                        var w = img.Width;
                        var h = img.Height;
                        var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                        var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                        e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                        e.Handled = true;
                    }
                }
                else
                {
                    Console.WriteLine("La imagen no existe en la ruta especificada.");
                }
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                txtindice.Text = e.RowIndex.ToString();
                txtid.Text = dgvdata.Rows[e.RowIndex].Cells["Id"].Value?.ToString();
                txtdocumento.Text = dgvdata.Rows[e.RowIndex].Cells["Documento"].Value?.ToString();
                txtnombrecompleto.Text = dgvdata.Rows[e.RowIndex].Cells["NombreCompleto"].Value?.ToString();
                txtcorreo.Text = dgvdata.Rows[e.RowIndex].Cells["Correo"].Value?.ToString();
                txttelefono.Text = dgvdata.Rows[e.RowIndex].Cells["Telefono"].Value?.ToString();

                var estadoValor = dgvdata.Rows[e.RowIndex].Cells["EstadoValor"].Value;
                if (estadoValor != null)
                {
                    int valor;
                    if (int.TryParse(estadoValor.ToString(), out valor))
                    {
                        foreach (OpcionCombo oc in cboestado.Items)
                        {
                            if (Convert.ToInt32(oc.valor) == valor)
                            {
                                cboestado.SelectedItem = oc;
                                break;
                            }
                        }
                    }
                }

            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            if (int.TryParse(txtid.Text, out int id) && id != 0)
            {
                if (MessageBox.Show("Desea eliminar Cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Cliente obj = new Cliente()
                    {
                        IdCliente = txtid.Text == "" ? 0 : Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new CN_Cliente().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (cbobusqueda.SelectedItem == null || !(cbobusqueda.SelectedItem is OpcionCombo))
            {
                MessageBox.Show("Por favor seleccione un criterio de busqueda valido");
                return;
            }
            string columnaFiltro = (cbobusqueda.SelectedItem as OpcionCombo).valor.ToString();

            if (!dgvdata.Columns.Contains(columnaFiltro))
            {
                MessageBox.Show($"La columna '{columnaFiltro}' no existe en la tabla");
                return;
            }
            string textoBusqueda = txtbusqueda.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(textoBusqueda))
            {
                MessageBox.Show("Por favor ingrese un texto para buscar");
                MostrarTodasLasFilas();
                return;
            }
            try
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (!row.IsNewRow) // Ignorar fila nueva si esta en modo edición
                    {
                        var cellValue = row.Cells[columnaFiltro].Value;
                        string valorCelda = cellValue?.ToString()?.Trim()?.ToUpper() ?? string.Empty;

                        row.Visible = valorCelda.Contains(textoBusqueda);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la busqueda: {ex.Message}");
            }
        }
        private void MostrarTodasLasFilas()
        {
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
