namespace Web.ViewModels.Content
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;

    using Config;

    using Models.Content;

    using Resources;

    using Web.Infrastructure.Mappings;
    using Web.ViewModels.Contracts;
    using Web.ViewModels.Seo;

    public class PageViewModel : BaseViewModel, IMapFrom<Page>, IMetaInfoViewModel
    {
        public string AllTags
        {
            get
            {
                return string.Join(", ", this.Tags.Select(t => t.Name));
            }
        }

        public string ConfirmDelete
        {
            get
            {
                return Translation.AreYouSureYouWantToDeleteThis;
            }
        }

        [DataType(DataType.Html)]
        [Display(Name = "Content", ResourceType = typeof(Translation))]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        [MaxLength(50)]
        [Display(Name = "FriendlyUrl", ResourceType = typeof(Translation))]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegex)]
        public string FriendlyUrl { get; set; }

        public virtual string GetHtmlId
        {
            get
            {
                return string.Format("page-{0}", this.Id);
            }
        }

        [Display(Name = "MetaDescription", ResourceType = typeof(Translation))]
        public string MetaDescription { get; set; }

        [Display(Name = "MetaTitle", ResourceType = typeof(Translation))]
        public string MetaTitle { get; set; }

        public string PostedOn
        {
            get
            {
                return this.CreatedOn.ToLongDateString();
            }
        }

        public string PostedOnWithTime
        {
            get
            {
                return this.CreatedOn.ToString(CultureInfo.CurrentCulture);
            }
        }

        public ICollection<TagViewModel> Tags { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Translation))]
        public string Title { get; set; }
    }
}