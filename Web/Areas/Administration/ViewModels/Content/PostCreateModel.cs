namespace Web.Areas.Administration.ViewModels.Content
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Config;

    using Models.Content;
    using Models.Identity;

    using Resources;

    using Web.Infrastructure.Validators;

    public class PostCreateViewModel
    {
        [NotMapped]
        public const string ModelBinderProperties = "Id,Title,Content,MetaDescription,MetaKeywords,CategoryId,FriendlyUrl";

        public virtual ApplicationUser Author { get; set; }

        public int CategoryId { get; set; }

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

        public static Post GetPostFrom(PostCreateViewModel postCreateModel)
        {
            return new Post
                       {
                           CategoryId = postCreateModel.CategoryId,
                           Content = postCreateModel.Content,
                           Author = postCreateModel.Author,
                           FriendlyUrl = postCreateModel.FriendlyUrl,
                           MetaDescription = postCreateModel.MetaDescription,
                           MetaTitle = postCreateModel.MetaTitle,
                           Title = postCreateModel.Title
                       };
        }
    }
}