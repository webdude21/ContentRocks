namespace Web.Infrastructure.Validators
{
    using System.ComponentModel.DataAnnotations;

    using Ninject;

    using Services.Contracts;

    public class CheckForExistingFriendlyUrlAttribute : ValidationAttribute
    {
        [Inject]
        public IPageService PageService { get; set; }

        [Inject]
        public IPostService PostService { get; set; }

        public override bool IsValid(object value)
        {
            var friendlyUrl = value as string;

            if (string.IsNullOrWhiteSpace(friendlyUrl))
            {
                return false;
            }

            if (this.PageService.UrlExists(friendlyUrl))
            {
                return false;
            }

            if (this.PostService.UrlExists(friendlyUrl))
            {
                return false;
            }

            return true;
        }
    }
}