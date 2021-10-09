using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.Features;

namespace Models {
public class Person {
    public int Id { get; set; }
    
    [Required]
    [StringLength(50, ErrorMessage = "Name is too long")]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(70, ErrorMessage = "Name is too long")]
    public string LastName { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    
    [Range(18, 110, ErrorMessage = "Please enter valid adult age >18 and <110")]
    public int Age { get; set; }
    public float Weight { get; set; }
    public int Height { get; set; }
    public string Sex { get; set; } = "Non";

    public string GetFullName()
    {
        return FirstName + " " + LastName;
    }
}


}