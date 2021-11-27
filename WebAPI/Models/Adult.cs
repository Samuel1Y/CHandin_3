using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models {
public class Adult : Person
{
    public Job JobTitle { get; set; } = new Job();
}
}