namespace Web.Areas.Administration.ViewModels.Content
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Config;

    using Models.Content;
    using Models.Identity;

    using Resources;

    using Web.Infrastructure;
    using Web.Infrastructure.Validators;

    public class PageCreateViewModel
    {
        [NotMapped]
        public const string ModelBinderProperties = "Id,Title,Content,MetaDescription,MetaKeywords,CategoryId,FriendlyUrl";

        public virtual ApplicationUser Author { get; set; }

        [DataType(DataType.Html)]
        [Display(Name = "Content", ResourceType = typeof(Translation))]
        public string Content { get; set; }

        [MaxLength(50)]
        [Display(Name = "FriendlyUrl", ResourceType = typeof(Translation))]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegex)]
        [CheckForExistingFriendlyUrl]
        public string FriendlyUrl { get; set; }

        [Display(Name = "MetaDescription", ResourceType = typeof(Translation))]
        public string MetaDescription { get; set; }

        [Display(Name = "MetaTitle", ResourceType = typeof(Translation))]
        public string MetaTitle { get; set; }

        [MaxLength(200)]
        [Display(Name = "Title", ResourceType = typeof(Translation))]
        public string Title { get; set; }

        public static Page GetPostFrom(PageCreateViewModel pageCreateModel)
        {
            return new Page
            {
                Content = pageCreateModel.Content,
                Author = pageCreateModel.Author,
                FriendlyUrl = pageCreateModel.FriendlyUrl,
                MetaDescription = pageCreateModel.MetaDescription,
                MetaTitle = pageCreateModel.MetaTitle,
                Title = pageCreateModel.Title
            };
        }
    }
}