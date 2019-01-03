using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Core.Order
{
    [Table("Orders")]
    public class Order : BaseEntity<long>
    {
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public string Address { get; set; }
    }
}
