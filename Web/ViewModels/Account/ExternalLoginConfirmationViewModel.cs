namespace Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    using Resources;

    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Translation), Name = "Email")]
        public string Email { get; set; }
    }
}