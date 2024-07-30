using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEntityFramework.Entities
{
    [Table(name: "m_product")]
    public class Product
    {
        [Key, Column(name: "id")]
        public Guid Id { get; set; }

        [Column(name: "product_name", TypeName = "Varchar(50)")]
        public string ProductName { get; set; }

        [Column(name: "product_price")]
        public long ProductPrice { get; set; }

        [Column(name: "stock")]
        public int Stock{ get; set; }

    }
}
