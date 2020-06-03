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
    public partial class Facturas : Form
    {
        modelo mo = new modelo();
        
        public Facturas(string id)
        {
            InitializeComponent();
            string sql1 = "SELECT * FROM ventas_encabezado where codigo_cliente = '"+id+"' ";
            string consulta = "select documento_ventaenca from ventas_encabezado where codigo_cliente = '"+id+"' ";
          string con = mo.consulta(consulta);
            string sql2 = "SELECT * FROM ventas_detalle where documento_ventaenca = '"+con+"' ";
            actualizardatagriew(sql1);
            actualizardatagriew2(sql2);
           
        }


        public void actualizardatagriew(string algo)
        {

            DataTable dt = mo.consultaLogica2(algo);
            Dgb_encabezadoProductosP.DataSource = dt;
            if (dt.Rows.Count < 1)
            {


                MessageBox.Show("No hay facturas registradas ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
        public void actualizardatagriew2(string encab)
        {
            DataTable dt = mo.consultaLogica2(encab);
            Dgb_detalleProductosP.DataSource = dt;
       
        }
    }
}
