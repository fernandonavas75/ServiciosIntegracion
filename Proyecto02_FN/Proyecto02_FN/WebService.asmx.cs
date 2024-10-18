using Proyecto02_FN.DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Proyecto02_FN
{
    /// <summary>
    /// Descripción breve de WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public bool UpdatetData(int id, string cedula,string nombre,string direccion,string telefono)
        {
            ClientesTableAdapter adapter = new ClientesTableAdapter();
            try
            {
                int result = adapter.UpdateQuery(id,cedula,nombre,direccion,telefono,id);
                return result > 0;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }
        [WebMethod]
        public bool CreateData(int id,string cedula,string nombre,string direccion,string telefono)
        {
            ClientesTableAdapter adapter = new ClientesTableAdapter();
            try
            {
                int result = adapter.InsertQuery(id, cedula, nombre, direccion, telefono);
                return result > 0;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }
        [WebMethod]
        public bool DeleteData(int id ,string cedula,string nombre, string direccion , string telefono)
        {
            ClientesTableAdapter adapter = new ClientesTableAdapter();
            try
            {
                int result = adapter.DeleteQuery(id);
                return result > 0;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }
        [WebMethod]
        public DataSet SelectAll()
        {
            ClientesTableAdapter adapter = new ClientesTableAdapter();
            DataSet clientes = new DataSet();
            clientes.Tables.Add(adapter.GetData());
            return clientes;
        }
        [WebMethod]
        public ClientesTableAdapter Select(int id)
        {
            ClientesTableAdapter adapter = new ClientesTableAdapter();
            ClientesTableAdapter clientes = adapter.GetData();
            var clienteFiltrado = clientes.AsEnumerables().Where(=>clientes.id == id);
            if (clienteFiltrado.Any())
            {
                ClientesTableAdapter resultado = new ClientesTableAdapter();
                foreach(var row in clienteFiltrado)
                {
                    resultado.ImportRow(row);
                }
                return resultado;
            }
        }
    }
}
