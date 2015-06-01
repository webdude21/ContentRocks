namespace Web.ViewModels.Content
{
    using Models.Content;

    using Web.Infrastructure.Mappings;

    public class CommentViewModel : BaseViewModel, IMapFrom<Comment>
    {
        public string Content { get; set; }

        public int PostId { get; set; }
    }
}