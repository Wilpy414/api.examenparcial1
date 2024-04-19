using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class FacturaRepository : IFactura
    {
        private readonly ApplicationDbContext _context;

        public FacturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> add(FacturaModel factura)
        {
            try
            {
                await _context.FacturasEF.AddAsync(factura);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar Factura", ex);
            }
        }

        public async Task<bool> update(FacturaModel factura)
        {
            try
            {
                _context.FacturasEF.Update(factura);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar Factura", ex);
            }
        }

        public async Task<bool> remove(int id)
        {
            try
            {
                var factura = await _context.FacturasEF.FindAsync(id);
                if (factura != null)
                {
                    _context.FacturasEF.Remove(factura);
                    return await _context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar Factura", ex);
            }

        }

        public async Task<FacturaModel> get(int id)
        {
            try
            {
                return await _context.FacturasEF.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener Factura", ex);
            }
        }

        public async Task<IEnumerable<FacturaModel>> list()
        {
            try
            {
                return await _context.FacturasEF.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo listar Factura", ex);
            }
        }
    }
}
