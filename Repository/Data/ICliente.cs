using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface ICliente
    {
        bool add(ClienteModel cliente);
        bool remove(int id);
        bool update(ClienteModel cliente,int id);
        ClienteModel get(int id);
        IEnumerable<ClienteModel> list();
    }
}
