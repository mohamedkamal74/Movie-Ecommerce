using Movie.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Ecommerce.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Moviee Movie { get; set; }
        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }
    }
}
