using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace datosFinal
{
   public class sentencias
    {

        conexionFinal con = new conexionFinal();
        public DataTable obtener(string tabla, string campo1)
        {

            string sql = "SELECT " + campo1 + " FROM " + tabla + " where estado = 1  ;";

            OdbcCommand command = new OdbcCommand(sql, con.conexion());
            OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);


            return dt;
        } //seleccionar 1 campo en concreto
        public OdbcDataAdapter llenaTbl(string tabla)// metodo  que obtinene el contenio de una tabla
        {
            string[] camposDesc = obtenerCampos(tabla); //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * FROM " + tabla + " WHERE estado=1 ORDER BY " + camposDesc[0] + " DESC ;";
            //SELECT * FROM tbl_bodega WHERE estado=1 ORDER BY kbodega DESC
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.conexion());
            return dataTable;
        }
        public OdbcDataAdapter llenaTbl2(string sql)// llenar tabla sin alias solo ejecuta
        {

            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.conexion());

            return dataTable;
        }
        public string consultar(string sql)
        {

            string resultado = " ";

            OdbcCommand consulta = new OdbcCommand(sql, con.conexion());
            OdbcDataReader reader = consulta.ExecuteReader();

            while (reader.Read())
            {
                resultado = reader.GetValue(0).ToString();

            }

            return resultado;


        }
        public string[] obtenerCampos(string tabla)//metodo que obtiene la lista de los campos que requiere una tabla
        {
            string[] Campos = new string[30];
            int i = 0;
            try
            {
                OdbcCommand command = new OdbcCommand("DESCRIBE " + tabla + "", con.conexion());
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Campos[i] = reader.GetValue(0).ToString();
                    i++;

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en asignarCombo, revise los parámetros \n -" + tabla); }
            return Campos;// devuelve un arrgeglo con los campos
        }
        public void insertar(string sql)
        {



            OdbcCommand consulta = new OdbcCommand(sql, con.conexion());
            consulta.ExecuteNonQuery();

          }
        public void updateEstados(string tabla, string set, string valorEstado, string WhereCampo, string id)
        {

            string sql = "UPDATE " + tabla + " SET " + set + " = '" + valorEstado + "' WHERE " + WhereCampo + " = " + id + ";";
            OdbcCommand consulta = new OdbcCommand(sql, con.conexion());
            consulta.ExecuteNonQuery();


        }


        public int contarAlias(string tabla)// metodo  que obtinene el contenio de una tabla
        {
            int Campos = 0;

            try
            {
                OdbcCommand command = new OdbcCommand("DESCRIBE " + tabla + "", con.conexion());
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Campos++;

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en obtenerTipo, revise los parámetros de la tabla  \n -" + tabla.ToUpper() + "\n -"); }
            return Campos;// devuelve un arreglo con los tiposlos campos
        }
        public string obtenerSimple(string tabla, string campo, string condicion, string id)// metodo  que obtinene el contenio de una tabla
        {
            string resultado = "";
            string sql = "SELECT " + campo + " FROM " + tabla + " WHERE " + condicion + "=" + id + ";";
            //SELECT * FROM tbl_bodega WHERE estado=1 ORDER BY kbodega DESC
            OdbcCommand command = new OdbcCommand(sql, con.conexion());
            OdbcDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {

                resultado = reader.GetValue(0).ToString();
            }
            return resultado;
        }
        public string obtenerSimple3(string tabla, string campo, string condicion, string id)// metodo  que obtinene el contenio de una tabla con estado 1
        {
            string resultado = "";
            string sql = "SELECT " + campo + " FROM " + tabla + " WHERE " + condicion + "=" + id + " and estado = 1;";
            //SELECT * FROM tbl_bodega WHERE estado=1 ORDER BY kbodega DESC
            OdbcCommand command = new OdbcCommand(sql, con.conexion());
            OdbcDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {

                resultado = reader.GetValue(0).ToString();
            }
            return resultado;
        }

    }
}
