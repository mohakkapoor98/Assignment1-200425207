using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1_200425207.Models
{
    public class Equipments
    {
        [Key]
        public string EquipmentID { get; set; }

        public string Model { get; set; }

        public int Size { get; set; }

        public double Price { get; set; }

        [ForeignKey("ProductID")]
        public int ProductID { get; set; }
    }
}
