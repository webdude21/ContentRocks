namespace Web.ViewModels
{
    using Models;

    public class PagerViewModel
    {
        public const string PageUrlParam = "?page=";

        public int CurrentPage { get; set; }

        public string NextPageParam
        {
            get
            {
                return PageUrlParam + (this.CurrentPage + 1);
            }
        }

        public string PreviousPageParam
        {
            get
            {
                return PageUrlParam + (this.CurrentPage - 1);
            }
        }

        public int TotalPages { get; set; }

        public static PagerViewModel ConvertFrom(Pager pager)
        {
            return new PagerViewModel { CurrentPage = pager.CurrentPage, TotalPages = pager.TotalPages };
        }

        public string GetPageParam(int page)
        {
            return PageUrlParam + page;
        }
    }
}