﻿namespace Web.ViewModels.Content
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using Config;

    using Models.Content;
    using Models.Contracts;

    using Resources;

    using Infrastructure.Mappings;
    using Infrastructure.Validators;
    using Contracts;

    public class PageViewModel : BaseViewModel, IMapFrom<Page>, IMetaInfoViewModel, IFriendlyUrl
    {
        [DataType(DataType.Html)]
        [Display(Name = "Content", ResourceType = typeof(Translation))]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual string GetHtmlId => $"page-{this.Id}";

        public string PostedOn => this.CreatedOn.ToLongDateString();

        public string PostedOnWithTime => this.CreatedOn.ToString(CultureInfo.CurrentCulture);

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

        public string AuthorName { get; set; }
    }
}