using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace Repository.Data
{
    public class FacturaRepository : IFactura
    {
        private IDbConnection conexionDB;
        public FacturaRepository(string _connectionString)
        {
            conexionDB = new DbConnection(_connectionString).dbConnection();
        }
        public bool add(FacturaModel factura)
        {
            try
            {
                if (conexionDB.Execute("insert into factura(id, id_cliente, nro_factura, fecha_hora, " +
                    "total, total_iva5, total_iva10, total_iva, total_letras, sucursal) values (@id, @id_cliente, @nro_factura, @fecha_hora, " +
                    "@total, @total_iva5, @total_iva10, @total_iva, @total_letras, @sucursal)", factura) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FacturaModel get(int id)
        {
            try
            {
                return conexionDB.Query<FacturaModel>("Select * from factura where id = @id", new { id }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<FacturaModel> list()
            {
            try
            {
                return conexionDB.Query<FacturaModel>("Select * from factura");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool remove(int id)
        {
            try
            {
                if (conexionDB.Execute("Delete from factura where id = @id", new { id }) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(FacturaModel factura)
        {
           try
           {
               if (conexionDB.Execute("Update factura set id_cliente = @id_cliente, nro_factura = @nro_factura, fecha_hora = @fecha_hora, " +
                        "total = @total, total_iva5 = @total_iva5, total_iva10 = @total_iva10, total_iva = @total_iva, total_letras = @total_letras, sucursal = @sucursal" +
                        " where id = @id", factura) > 0)
                   return true;
              else
                   return false;
           }
           catch (Exception ex)
           {
               throw ex;
           }
        }
    }
}
