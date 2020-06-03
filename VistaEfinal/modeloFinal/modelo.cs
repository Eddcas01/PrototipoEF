using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using datosFinal;
using System.Data.Odbc;

namespace modeloFinal
{
   public class modelo
    {
        sentencias sn = new sentencias();
        public string idmax(string tabla, string dato)
        {



            string idmax = sn.obteneridmax(tabla, dato);
            if (idmax == "")
            {

                idmax = "1";
            }

            return idmax;
        }
        public DataTable consultaLogica2(string sql)  //obtener datos de la consulta y llenar un data table
        {
            OdbcDataAdapter dt = sn.llenaTbl2(sql);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }
        public DataTable consultaLogica(string tabla)  //obtener datos de la consulta
        {
            OdbcDataAdapter dt = sn.llenaTbl(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }
        public string ObtenerSimple(string tabla, string campo, string condicion, string id)  //obtener datos sin estado definido
        {

            string resul = sn.obtenerSimple(tabla, campo, condicion, id);
            return resul;
        }
        public string ObtenerSimple3(string tabla, string campo, string condicion, string id)  //obtener con estado 1
        {

            string resul = sn.obtenerSimple3(tabla, campo, condicion, id);
            return resul;
        }
        public string consulta(string sql)
        {

            string resultado = sn.consultar(sql);

            return resultado;
        }
        public void insertar(string sql)
        {

            sn.insertar(sql);

        }
        public void updateestados(string tabla, string set, string valorEstado, string WhereCampo, string id)
        {


            sn.updateEstados(tabla, set, valorEstado, WhereCampo, id);

        }
        public int contarCampos(string tabla)
        {
            return sn.contarAlias(tabla);
        }

    }
}
