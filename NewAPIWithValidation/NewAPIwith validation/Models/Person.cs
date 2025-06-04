
namespace NewAPIWithValidation.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Validation Check
        [CustomDateFormat("dd/MM/yyyy", ErrorMessage = "Date of birth must be in the format of DD/MM/YYYY")]

        public string? Dob {  get; set; }
    }
}
