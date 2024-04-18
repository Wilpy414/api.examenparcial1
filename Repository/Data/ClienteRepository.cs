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
    public class ClienteRepository : ICliente
    {
        private IDbConnection conexionDB;
        public ClienteRepository(string _connectionString)
        {
            conexionDB = new DbConnection(_connectionString).dbConnection();
        }
        public bool add(ClienteModel cliente)
        {
            try
            {
                if (conexionDB.Execute("insert into cliente(id, id_banco, nombre, apellido, " +
                    "documento, direccion, mail, celular, estado) values (@id, @id_banco, @nombre, " +
                    "@apellido, @documento, @direccion, @mail, @celular, @estado)", cliente) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel get(int id)
        {
            try
            {
                return conexionDB.Query<ClienteModel>("Select * from cliente where id = @id", new {id}).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ClienteModel> list()
        {
            try
            {
                return conexionDB.Query<ClienteModel>("Select * from cliente");
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
                if (conexionDB.Execute("Delete from cliente where id = @id", new {id}) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(ClienteModel cliente, int id)
        {
            try
            {
                if (conexionDB.Execute("Update cliente set id_banco = @id_banco, nombre = @nombre, " +
                    "apellido = @apellido, documento= @documento, direccion = @direccion, mail = @mail, celular = @celular, estado = @estado" +
                    " where id = @id", cliente) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(ClienteModel cliente)
        {
            throw new NotImplementedException();
        }
    }
}
