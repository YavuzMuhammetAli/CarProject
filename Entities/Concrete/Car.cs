using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string marka { get; set; }
        public string model { get; set; }
        public string yakit { get; set; }
        public DateTime yılı { get; set; }
        public string kilometre { get; set; }
        public string vites { get; set; }
        public string motor { get; set; }
    }
}
