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

    public partial class proceso1 : Form
    {
       
        modelo mo = new modelo();
        public proceso1(string cliente, string idcliente)
        {   InitializeComponent();
   
            lbl_cliente.Text = cliente;
  
            lbl_codcliente.Text = idcliente;
            
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            lbl_noOrden.Text = mo.idmax("ventas_encabezado", "documento_ventaenca");
            Lbl_date.Text = fecha;
            grb_detalle.Enabled = false;

            cmb_productos.llenarse("productos", "codigo_producto", "nombre_producto");
            cmb_vendedores.llenarse("vendedores", "codigo_vendedor", "nombre_vendedor");
        }

        private void Proceso1_Load(object sender, EventArgs e)
        {

        }

        private void Btn_orden_Click(object sender, EventArgs e)
        {

            if (cmb_vendedores.texto2() != "")
            {
                grb_encabezado.Enabled = false;
                string idmax = mo.idmax("ventas_encabezado", "documento_ventaenca");

                string insert1 = "INSERT INTO ventas_encabezado(documento_ventaenca, codigo_cliente, fecha_ventaenca ) VALUES('" + idmax + "', '" + lbl_codcliente.Text + "', '" + Lbl_date.Text + "' );";

                mo.insertar(insert1);

                mo.updateestados("clientes", "codigo_vendedor", cmb_vendedores.ObtenerIndif(), "codigo_cliente", lbl_codcliente.Text);

                grb_detalle.Enabled = true;
            }
            else {
                MessageBox.Show("ingrese el vendedor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }

        private void Btn_agregar_Click(object sender, EventArgs e)
        {
            string documento = lbl_noOrden.Text;
            string primero = cmb_productos.ObtenerIndif();
            string cantidad = Nud_cantidad.Value.ToString();
            string costo = nudCosto.Value.ToString(); ;
            string precio = nudPrecio.Value.ToString() ;

            string consulta2 = "select b.codigo_bodega from bodegas b  INNER JOIN existencias e ON b.codigo_bodega=e.codigo_bodega INNER JOIN productos p on e.codigo_producto=p.codigo_producto where p.codigo_producto= '"+cmb_productos.ObtenerIndif()+"'";
            string codbodega = mo.consulta(consulta2) ;
          
            Dgb_pedidosEspeciales.Rows.Add(documento, primero, cantidad,costo, precio, codbodega);

            string total = Dgb_pedidosEspeciales.CurrentRow.Cells[4].Value.ToString();
            string actual = lbltotal.Text;

            float total1 = float.Parse(total) ;
            float actual2 = float.Parse(actual) ;

            string cant = Nud_cantidad.Value.ToString() ;

            float resultado = actual2 + (total1 * float.Parse(cant));

            lbltotal.Text = Convert.ToString(resultado);



        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string idmax = lbl_noOrden.Text;
            if (Dgb_pedidosEspeciales.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in Dgb_pedidosEspeciales.Rows)
                {
                    string cadena = "INSERT INTO ventas_detalle (documento_ventaenca, codigo_producto, cantidad_ventadet, costo_ventadet, precio_ventadet, codigo_bodega) VALUES('" + idmax + "','" + row.Cells[1].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "' ,'" + row.Cells[3].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "','" + row.Cells[5].Value.ToString() + "');";
                    mo.insertar(cadena);
                    
                }
                string total = lbltotal.Text;
                mo.updateestados("ventas_encabezado","total_ventaenca",total, "codigo_cliente",lbl_codcliente.Text);

                MessageBox.Show("Pedido Realizado");
                this.Close();
            }
            else
            {

                MessageBox.Show("Agregue los productos a la orden ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (Dgb_pedidosEspeciales.SelectedRows.Count == 1)
            {
                if (Dgb_pedidosEspeciales.Rows.Count > 1)
                {

                    string total = Dgb_pedidosEspeciales.CurrentRow.Cells[4].Value.ToString();
                    string actual = lbltotal.Text;

                    float total1 = float.Parse(total);
                    float actual2 = float.Parse(actual);

                    string cant = Dgb_pedidosEspeciales.CurrentRow.Cells[2].Value.ToString();

                    float resultado = actual2 -(total1 * float.Parse(cant)) ;

                    lbltotal.Text = Convert.ToString(resultado);


                    Dgb_pedidosEspeciales.Rows.RemoveAt(Dgb_pedidosEspeciales.CurrentRow.Index);
                }
                else
                {

                    MessageBox.Show("No se puede ingresar un pedido sin productos ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }
        }
    }
}
