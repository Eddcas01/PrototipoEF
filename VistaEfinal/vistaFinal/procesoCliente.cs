using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using modeloFinal;
namespace vistaFinal
{
    public partial class procesoCliente : Form
    {
        modelo mo = new modelo();
        string sql = "SELECT codigo_cliente as 'COD CLIENTE', nombre_cliente AS 'NOMBRE', direccion_cliente AS 'DIRECCION', nit_cliente AS 'NIT', telefono_cliente AS 'TELEFONO', estado AS 'ESATDO' FROM clientes WHERE estado = 1";
        public procesoCliente()
        {
            InitializeComponent();
            llenartbl();
        }


        void llenartbl()
        {

            DataTable dt = mo.consultaLogica2(sql);
            Dgb_ordenesPendientes.DataSource = dt;
        }
        private void Btn_seleccionar_Click(object sender, EventArgs e)
        {
            if (Dgb_ordenesPendientes.SelectedRows.Count == 1)
            {


                string idcliente = Dgb_ordenesPendientes.CurrentRow.Cells[0].Value.ToString();
                string consulta = "select nombre_cliente from clientes where codigo_cliente = '"+idcliente+"' ";
               string nombrecliente= mo.consulta(consulta);

                proceso1 frm = new proceso1(nombrecliente, idcliente);
                frm.MdiParent = this.MdiParent;
                frm.Show();


            }
        }
    }
}
