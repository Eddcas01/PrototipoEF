using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDiseno;
using CapaDatos;
namespace vistaFinal
{
    public partial class MDI : Form
    {
        private int childFormNumber = 0;
        sentencia sn = new sentencia();
        string usuarioact;
        public MDI()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MantenimientoDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mantenimientoProductos frm = new mantenimientoProductos(lblUsuario.Text);
            frm.MdiParent = this;
            frm.Show();
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            frm_login login = new frm_login();
            login.ShowDialog();

            lblUsuario.Text = login.obtenerNombreUsuario();
            usuarioact = lblUsuario.Text;
        }

        private void ProcesoDe1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            procesoCliente frm = new procesoCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MantenimientoDe1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           mantenimientoMarcas frm = new mantenimientoMarcas(lblUsuario.Text);
            frm.MdiParent = this;
            frm.Show();
        }

        private void MantenimientoDe2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          mantenimientoLinea  frm = new mantenimientoLinea(lblUsuario.Text);
            frm.MdiParent = this;
            frm.Show();
        }

        private void MantenimientoDe3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           mantenimientoBodegas frm = new mantenimientoBodegas(lblUsuario.Text);
            frm.MdiParent = this;
            frm.Show();
        }

        private void MantenimientoDeVendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
           mantenimientoVendedores frm = new mantenimientoVendedores(lblUsuario.Text);
            frm.MdiParent = this;
            frm.Show();
        }

        private void MantenimientoDeExistenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           mantenimientoExistencias frm = new mantenimientoExistencias(lblUsuario.Text);
            frm.MdiParent = this;
            frm.Show();
        }

        private void ProcesoDe2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
          procesoClienteFac frm = new procesoClienteFac();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ReporteDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ReporteVentas frm = new ReporteVentas();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
