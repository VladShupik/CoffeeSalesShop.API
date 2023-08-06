using System.ComponentModel.DataAnnotations;

namespace CoffeeSalesShop.API.Data.Models;

/// <summary>
/// User Model
/// </summary>
public class User : BaseModel
{
    /// <summary>
    /// User First Name
    /// </summary>
    [Required]
    [StringLength(50, ErrorMessageResourceName = "FirstNameMaxCharsValidation")]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// User Last Name
    /// </summary>
    [Required]
    [StringLength(50, ErrorMessageResourceName = "LastNameMaxCharsValidation")]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// User Email
    /// </summary>
    [Required]
    [EmailAddress(ErrorMessageResourceName = "InvalidEmailValidation")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// User Password Hash
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// Reference to a specific role
    /// </summary>
    [Required]
    public int RoleId { get; set; }
}
