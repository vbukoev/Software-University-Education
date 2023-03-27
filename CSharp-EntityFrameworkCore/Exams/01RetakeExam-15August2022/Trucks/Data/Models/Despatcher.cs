using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        
        public Despatcher()
        {
            Trucks = new HashSet<Truck>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Position { get; set; }

        public ICollection<Truck> Trucks { get; set; }
    }
}
