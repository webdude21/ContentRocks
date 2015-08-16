namespace Web.ViewModels.Content
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using Config;

    using Models.Content;
    using Models.Contracts;

    using Resources;

    using Web.Infrastructure.Mappings;
    using Web.Infrastructure.Validators;
    using Web.ViewModels.Contracts;

    public class PageViewModel : BaseViewModel, IMapFrom<Page>, IMetaInfoViewModel, IFriendlyUrl
    {
        [DataType(DataType.Html)]
        [Display(Name = "Content", ResourceType = typeof(Translation))]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual string GetHtmlId
        {
            get
            {
                return string.Format("page-{0}", this.Id);
            }
        }

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

        [Display(Name = "Title", ResourceType = typeof(Translation))]
        public string Title { get; set; }

        [MaxLength(50)]
        [Display(Name = "FriendlyUrl", ResourceType = typeof(Translation))]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegex)]
        [CheckForExistingFriendlyUrl]
        public string FriendlyUrl { get; set; }

        public virtual string AllTags
        {
            get
            {
                return string.Empty;
            }
            set
            {
            }
        }

        [Display(Name = "MetaDescription", ResourceType = typeof(Translation))]
        public string MetaDescription { get; set; }

        [Display(Name = "MetaTitle", ResourceType = typeof(Translation))]
        public string MetaTitle { get; set; }
    }
}