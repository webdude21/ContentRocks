namespace Web.ViewModels.Content
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;

    using AutoMapper;

    using Config;

    using Models.Content;

    using Resources;

    using Web.Infrastructure.Mappings;
    using Web.ViewModels.Contracts;
    using Web.ViewModels.Seo;

    public class PostViewModel : BaseViewModel, IMapFrom<Post>, IMetaInfoViewModel, IHaveCustomMappings
    {
        public string AllTags
        {
            get
            {
                return string.Join(", ", this.Tags.Select(t => t.Name));
            }
        }

        public string AuthorName { get; set; }

        public CategoryViewModel Category { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        [DataType(DataType.Html)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        [MaxLength(50)]
        [Display(Name = "FriendlyUrl", ResourceType = typeof(Translation))]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegex)]
        public string FriendlyUrl { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        public string PostedOnWithTime
        {
            get
            {
                return this.CreatedOn.ToString(CultureInfo.CurrentCulture);
            }
        }

        public string PostedOn
        {
            get
            {
                return this.CreatedOn.ToLongDateString();
            }
        }

        public string PostedOnBy
        {
            get
            {
                return string.Format(Translation.PostedByOn, this.AuthorName, this.PostedOn);
            }
        }

        public ICollection<TagViewModel> Tags { get; set; }

        public string Title { get; set; }

        public string ConfirmDelete
        {
            get
            {
                return Translation.AreYouSureYouWantToDeleteThis;
            }
        }

        public string GetHtmlId
        {
            get
            {
                return "post-" + this.Id;
            }
        }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(
                    sourceModel => sourceModel.AuthorName,
                    result => result.MapFrom(fullModel => fullModel.Author.UserName));
        }
    }
}