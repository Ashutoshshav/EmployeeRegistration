using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [CustomValidation(typeof(Employee), nameof(ValidateAge))]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string EmailId { get; set; }

        [Required]
        [Range(1000000000, 9999999999, ErrorMessage = "Invalid Mobile Number")]
        public long Mobile { get; set; }

        [Required]
        [StringLength(50)]
        public string Qualification { get; set; }

        [Required]
        [StringLength(50)]
        public string Designation { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Salary")]
        [Display(Name = "Expected Salary")]
        public decimal ExpectedSalary { get; set; }

        public static ValidationResult ValidateAge(DateTime dob, ValidationContext context)
        {
            if (dob > DateTime.Now.AddYears(-18))
                return new ValidationResult("Employee must be at least 18 years old");

            return ValidationResult.Success;
        }
    }
}
