namespace Models {
public class Adult : Person
{
    public Job jobTitle { get; set; } = new Job();
}
}