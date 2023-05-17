using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string tc { get; set; }
        public string email { get; set; }
        public DateTime dogum_yili { get; set; }
        public string telefon { get; set; }
        public string sifre { get; set; }
    }
}
