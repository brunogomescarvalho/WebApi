using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class CreateEmployeeRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}