using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string MarkaAdi { get; set; }
        public string Model { get; set; }
        public int Stok { get; set; }
    }
}
