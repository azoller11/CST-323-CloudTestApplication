using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTestApplication.Models
{
    public class Data
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Name { get; set; }
        public int Amount { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Description { get; set; }

        public Data() { }

        public Data(int id, string name, int amount, string description)
        {
            ID = id;
            Name = name;
            Amount = amount;
            Description = description;
        }

    }
}
