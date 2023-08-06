using System.ComponentModel.DataAnnotations;

namespace CoffeeSalesShop.API.Data.Models;

/// <summary>
/// Role model
/// </summary>
public class Role : BaseModel
{
    /// <summary>
    /// Role Name
    /// </summary>
    [Required]
    [StringLength(10, ErrorMessageResourceName = "NameMaxCharsValidation")]
    public string Name { get; set; } = string.Empty;
}
