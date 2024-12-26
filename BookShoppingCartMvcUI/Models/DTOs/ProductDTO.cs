using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShoppingCartMvcUI.Models.DTOs;
public class ProductDTO
{


    [Required]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public List<OrderDetail> OrderDetail { get; set; }
    public List<CartDetail> CartDetail { get; set; }
    public Stock Stock { get; set; }
    [Required]
    public int Quantity { get; set; }
    [NotMapped]
    public string CategoryName { get; set; }
    
    
    //
    public int Id { get; set; }

    [Required]
    [MaxLength(40)]
    public string? ProductName { get; set; }

    [Required]
    [MaxLength(40)]
    public string? Description { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public double Discount { get; set; }
    public string? Image { get; set; }
    
    public IFormFile? ImageFile { get; set; }
    public IEnumerable<SelectListItem>? CategoryList { get; set; }
}
