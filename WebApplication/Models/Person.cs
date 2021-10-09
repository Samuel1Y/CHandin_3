using System.ComponentModel.DataAnnotations;

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
    public int Age { get; set; }
    public float Weight { get; set; }
    public int Height { get; set; }
    public string Sex { get; set; }

    public string GetFullName()
    {
        return FirstName + " " + LastName;
    }
}


}