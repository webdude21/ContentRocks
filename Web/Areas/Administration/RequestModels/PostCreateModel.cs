namespace Web.Areas.Administration.RequestModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Config;

    using Models.Content;

    using Resources;

    public class PostCreateModel
    {
        [NotMapped]
        public const string ModelBinderProperties = "Id,Title,Content,MetaDescription,MetaKeywords,CategoryId,FriendlyUrl";

        public int CategoryId { get; set; }

        [DataType(DataType.Html)]
        [Display(Name = "Content", ResourceType = typeof(Translation))]
        public string Content { get; set; }

        [MaxLength(50)]
        [Display(Name = "FriendlyUrl", ResourceType = typeof(Translation))]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegex)]
        public string FriendlyUrl { get; set; }

        [Display(Name = "MetaDescription", ResourceType = typeof(Translation))]
        public string MetaDescription { get; set; }

        [Display(Name = "MetaTitle", ResourceType = typeof(Translation))]
        public string MetaTitle { get; set; }

        [MaxLength(200)]
        [Display(Name = "Title", ResourceType = typeof(Translation))]
        public string Title { get; set; }

        public static Post GetPostFrom(PostCreateModel product)
        {
            return new Post
                       {
                           CategoryId = product.CategoryId,
                           Content = product.Content,
                           FriendlyUrl = product.FriendlyUrl,
                           MetaDescription = product.MetaDescription,
                           MetaTitle = product.MetaTitle,
                           Title = product.Title
                       };
        }
    }
}