using System.ComponentModel.DataAnnotations;

namespace DETOWN.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
