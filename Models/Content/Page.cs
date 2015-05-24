namespace Models.Content
{
    using System.ComponentModel.DataAnnotations;

    using Config;

    using Models.Contracts;

    public class Page : AuthoredContent, IFriendlyUrl, IMetaInfo
    {
        [DataType(DataType.Html)]
        public string Content { get; set; }

        [MaxLength(50)]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegex)]
        public string FriendlyUrl { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }
    }
}