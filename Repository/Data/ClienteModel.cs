using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Repository.Data
{
    public class ClienteModel
    {
        public int id { get; set; }
        public int id_banco { get; set; }
        
        [Required]
        [StringLength (100, MinimumLength = 3)]
        public string nombre { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string apellido { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string documento { get; set; }
        public string direccion { get; set; }
        public string mail { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string celular { get; set; }
        public string estado { get; set; }

    }
}
