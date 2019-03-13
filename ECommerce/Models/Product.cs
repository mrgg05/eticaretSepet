using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Product
    {

        public int ProductId { get; set; }
        public int ProducerId { get; set; }
        public int CategoryId { get; set; }

        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ProductUrl { get; set; }

        public virtual Producer Producer { get; set; }
        public virtual Category Category { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }

    }
}