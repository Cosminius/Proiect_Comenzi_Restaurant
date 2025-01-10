namespace Proiect_Medii_Restaurantul_Meu.Models
{
    public class ProductIngredient
    {
        public int ProductId {  get; set; } 
        public Product Product { get; set; }
        public int IngredientId {  get; set; }
        public Ingredient Ingredient { get; set; }
    }
}