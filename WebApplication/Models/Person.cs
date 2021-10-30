using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.Features;

namespace Models {
public class Person {
    public int id { get; set; }
    
    [Required]
    [StringLength(50, ErrorMessage = "Name is too long")]
    public string firstName { get; set; }
    
    [Required]
    [StringLength(70, ErrorMessage = "Name is too long")]
    public string lastName { get; set; }
    public string hairColor { get; set; }
    public string eyeColor { get; set; }
    
    [Range(18, 110, ErrorMessage = "Please enter valid adult age >18 and <110")]
    public int age { get; set; }
    public float weight { get; set; }
    public int height { get; set; }
    public string sex { get; set; } = "Non";
    
    
    public string GetFullName()
    {
        return firstName + " " + lastName;
    }
}


}