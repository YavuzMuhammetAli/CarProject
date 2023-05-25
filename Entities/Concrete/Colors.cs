using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Colors : IEntity
    {
        [System.ComponentModel.DataAnnotations.Key] public int Id { get; set; }
        public string ColorName { get; set; }
    }
}
