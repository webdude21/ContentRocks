namespace Web.Areas.Administration.ViewModels.Content
{
    using System;

    using Models.Content;

    using Web.Infrastructure.Mappings;
    using Web.ViewModels;

    public class FileEntityViewModel : BaseViewModel, IMapFrom<FileEntity>
    {
        public DateTime CreatedOn { get; set; }

        public string FileName { get; set; }

        public string GetHtmlId
        {
            get
            {
                return string.Format("file-{0}", this.Id);
            }
        }

        public string MimeType { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public string Url { get; set; }

        public string UrlWithoutSlash
        {
            get
            {
                return this.Url.Substring(1);
            }
        }
    }
}