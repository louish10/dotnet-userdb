using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Name cannot be blank")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext _)
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            yield return new ValidationResult("Name must not be empty", new[] { nameof(Name) });
        }
    }
}