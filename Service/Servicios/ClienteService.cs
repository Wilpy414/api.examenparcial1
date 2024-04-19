using Repository.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Servicios
{
    public class ClienteService
    {
        private readonly ICliente _clienteRepository;

        public ClienteService(ICliente clienteRepository)
        {

            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Add(ClienteModel cliente)
        {
            try
            {
                return await _clienteRepository.add(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar Cliente", ex);
            }
        }

        public async Task<bool> Update(ClienteModel cliente)
        {
            try
            {

                return await _clienteRepository.update(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar Cliente", ex);
            }
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                return await _clienteRepository.remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar Cliente", ex);
            }
        }

        public async Task<ClienteModel> Get(int id)
        {
            try
            {
                return await _clienteRepository.get(id);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener Cliente", ex);
            }
        }

        public async Task<IEnumerable<ClienteModel>> List()
        {
            try
            {
                return await _clienteRepository.list();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo listar Cliente", ex);
            }
        }     

        private bool validacionCliente(ClienteModel cliente)
        {
            if (cliente == null)
                return false;

            if (string.IsNullOrWhiteSpace(cliente.nombre) || cliente.nombre.Length < 3)
                return false;

            if (string.IsNullOrWhiteSpace(cliente.apellido) || cliente.apellido.Length < 3)
                return false;

            if (string.IsNullOrWhiteSpace(cliente.documento) || cliente.documento.Length < 3)
                return false;

            if (string.IsNullOrWhiteSpace(cliente.celular) && (cliente.celular.Length != 10 || !EsNumero(cliente.celular)))

                return false;

            return true;
        }

        private bool EsNumero(string celular)
        {
            {
                foreach (char c in celular)
                {
                    if (!char.IsDigit(c))
                        return false;
                }
                return true;

            }
        }
    }
}