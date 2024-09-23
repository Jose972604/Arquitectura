using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class Citas
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdMedico { get; set; }
        public DateTime? Fecha { get; set; }
        public string Estado { get; set; }
    }
}
