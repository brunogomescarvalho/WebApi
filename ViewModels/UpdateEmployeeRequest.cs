using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class UpdateEmployeeRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}