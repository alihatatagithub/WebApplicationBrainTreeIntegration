using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBrainTreeIntegration.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AutherName { get; set; }
        public double Price { get; set; }
    }
}
