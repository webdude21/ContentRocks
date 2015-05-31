namespace Web.ViewModels
{
    using Models;

    public class PagerViewModel
    {
        public const string PageUrlParam = "?page=";

        public int CurrentPage { get; set; }

        public string FirstPageParam
        {
            get
            {
                return PageUrlParam + 1;
            }
        }

        public string LastPageParam
        {
            get
            {
                return PageUrlParam + (this.TotalPages);
            }
        }

        public bool NextPageButtonEnabled
        {
            get
            {
                return this.CurrentPage < this.TotalPages;
            }
        }

        public string NextPageParam
        {
            get
            {
                return PageUrlParam + (this.CurrentPage + 1);
            }
        }

        public bool PreviousPageButtonEnabled
        {
            get
            {
                return this.CurrentPage > 1;
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