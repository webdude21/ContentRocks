namespace Web.ViewModels.Account
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class SendCodeViewModel
    {
        public ICollection<SelectListItem> Providers { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        public string SelectedProvider { get; set; }
    }
}