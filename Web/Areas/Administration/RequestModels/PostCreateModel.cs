
namespace Web.Areas.Administration.RequestModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using Config;
    using Models.Contracts;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PostCreateModel
    {
        public int CategoryId { get; set; }

        [DataType(DataType.Html)]
        public string Content { get; set; }

        [MaxLength(50)]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegexValidator)]
        public string FriendlyUrl { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        [NotMapped]
        public const string ModelBinderProperties = "Id,Title,Content,MetaDescription,MetaKeywords,CategoryId";
    }
}