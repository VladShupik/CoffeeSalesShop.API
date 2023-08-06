using System.ComponentModel.DataAnnotations;

namespace CoffeeSalesShop.API.Data.Models;

/// <summary>
/// Product Model
/// </summary>
public class Product : BaseModel
{
    /// <summary>
    /// Product code
    /// </summary>
    [Required]
    [StringLength(10, ErrorMessageResourceName = "ProductCodeMaxCharsValidation")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Product Name
    /// </summary>
    [Required]
    [StringLength(50, ErrorMessageResourceName = "NameMaxCharsValidation")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Product description
    /// </summary>
    [StringLength(1000, ErrorMessageResourceName = "ProductDescriptionMaxCharsValidation")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Product Quantity Left
    /// </summary>
    public int QuantityLeft { get; set; } = 0;

    /// <summary>
    /// Product Price
    /// </summary>
    [Range(0, 99999.99, ErrorMessageResourceName = "ProductPriceValidation")]
    public decimal Price { get; set; }
}

