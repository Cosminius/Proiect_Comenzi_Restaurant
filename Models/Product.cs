using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Medii_Restaurantul_Meu.Models
{
    public class Product
    {
        public Product() { 
            ProductIngredients = new List<ProductIngredient>();
        }
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

        //Navigation properties, si adaug ValdiateNever pentru ca pot aparea erori
        [ValidateNever]
        public Category? Category { get; set; } // un produs apartine unei anumite categorii
        [ValidateNever]
        public ICollection<OrderItem>? OrderItems { get; set; } //Un produus paote sa fie in mai multe comenzi
        [ValidateNever]
        public ICollection<ProductIngredient>? ProductIngredients { get; set; }// un produs poate avea mai multe ingredinte
                                                                               //Pentru a adauga imagini adaugam urmatoarele proprietati
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; } = "https://via.placeholder.com/150";
      

    }
}