using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Cars
    {
        public int Id { get; set; }

        public string Models { get; set; }

        public int Year { get; set; }

        public int CarsOwnerId { get; set; }

        public CarOwner CarOwner { get; set; }
    }
}
