using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BE1WebApi.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }



        public int ProductId { get; set; }
        public virtual Product Product { get; set; }



        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
