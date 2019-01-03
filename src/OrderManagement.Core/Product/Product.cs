using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Core.Product
{
    [Table("Products")]
    public class Product : BaseEntity<long>
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
