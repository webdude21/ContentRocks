namespace Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    using Resources;

    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Translation))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Translation))]
        public bool RememberMe { get; set; }

        [Required]
        [Display(Name = "UserName", ResourceType = typeof(Translation))]
        public string UserName { get; set; }
    }
}