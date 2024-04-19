using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class FacturaModel
    {
        public int id { get; set; }
        public int id_cliente { get; set; }

        [RegularExpression(@"^\d{3}-\d{3}-\d{6}$", ErrorMessage = "El número de factura no es válido.")]
        public string nro_factura { get; set; }
        public DateTime fecha_hora { get; set; }

        [Required(ErrorMessage = "El campo Total es obligatorio.")]
        public double total { get; set; }

        [Required(ErrorMessage = "El campo Total_Iva5 es obligatorio.")]
        public double total_iva5 { get; set; }

        [Required(ErrorMessage = "El campo Total_Iva10 es obligatorio.")]
        public double total_iva10 { get; set; }

        [Required(ErrorMessage = "El campo Total_Iva es obligatorio.")]
        public double total_iva { get; set; }

        [StringLength(6, MinimumLength = 6, ErrorMessage = "El campo TotalEnLetras debe tener exactamente 6 caracteres.")]
        [Required(ErrorMessage = "El campo TotalEnLetras es obligatorio.")]
        public string total_letras { get; set; }
        public string sucursal { get; set; }
    }
}
