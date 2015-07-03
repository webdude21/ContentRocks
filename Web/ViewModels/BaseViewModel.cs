namespace Web.ViewModels
{
    using Resources;

    public class BaseViewModel
    {
        public int Id { get; set; }

        public virtual string ConfirmDelete
        {
            get
            {
                return Translation.AreYouSureYouWantToDeleteThis;
            }
        }
    }
}