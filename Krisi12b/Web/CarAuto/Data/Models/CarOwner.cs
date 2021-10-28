using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CarOwner
    {
        public CarOwner()
        {
            this.Cars = new HashSet<Cars>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Town { get; set; }

        public ICollection<Cars> Cars { get; set; }
    }
}
