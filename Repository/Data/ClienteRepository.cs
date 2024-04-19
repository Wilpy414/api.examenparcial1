using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class ClienteRepository : ICliente
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> add(ClienteModel cliente)
        {
            try
            {
                await _context.ClientesEF.AddAsync(cliente);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar Cliente", ex);
            }
        }

        public async Task<bool> update(ClienteModel cliente)
        {
            try
            {
                _context.ClientesEF.Update(cliente);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar Cliente", ex);
            }
        }

        public async Task<bool> remove(int id)
        {
            try
            {
                var cliente = await _context.ClientesEF.FindAsync(id);
                if (cliente != null)
                {
                    _context.ClientesEF.Remove(cliente);
                    return await _context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar Cliente", ex);
            }

        }

        public async Task<ClienteModel> get(int id)
        {
            try
            {
                return await _context.ClientesEF.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener Cliente", ex);
            }
        }

        public async Task<IEnumerable<ClienteModel>> list()
        {
            try
            {
                return await _context.ClientesEF.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo listar Cliente", ex);
            }
        }      
    }
}
