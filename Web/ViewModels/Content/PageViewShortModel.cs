namespace Web.ViewModels.Content
{
    using System.ComponentModel.DataAnnotations;

    using Config;

    using Models.Content;

    using Resources;

    using Web.Infrastructure.Mappings;

    public class PageViewShortModel : IMapFrom<Page>
    {
        [MaxLength(50)]
        [Display(Name = "FriendlyUrl", ResourceType = typeof(Translation))]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegex)]
        public string FriendlyUrl { get; set; }

        public string Title { get; set; }
    }
}