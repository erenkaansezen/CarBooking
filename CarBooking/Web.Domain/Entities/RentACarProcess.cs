using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Domain.Entities
{
    public class RentACarProcess
    {
        public int RentACarProcessID { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        [Column(TypeName = "Date")]
        public DateTime PickUpDate { get; set; }
        public TimeOnly PickUpTime { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DropOffDate { get; set; }
        public TimeOnly DropOffTime { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public string PickUpDescription { get; set; }
        public string DropOffDescription { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
