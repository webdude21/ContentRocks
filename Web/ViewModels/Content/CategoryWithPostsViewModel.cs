namespace Web.ViewModels.Content
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Config;

    using Models.Content;

    using Web.Infrastructure.Mappings;

    public class CategoryWithPostsViewModel : BaseViewModel, IMapFrom<Category>
    {
        [MaxLength(50)]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegex)]
        public string FriendlyUrl { get; set; }

        public string Title { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }
    }
}