namespace Web.ViewModels.Content
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    using Config;

    using Models.Content;

    using Web.Infrastructure.Mappings;

    public class CategoryViewModel : BaseViewModel, IMapFrom<Category>
    {
        [MaxLength(50)]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegex)]
        public string FriendlyUrl { get; set; }

        public string Title { get; set; }

        public static IEnumerable<SelectListItem> GetDropDownModel(IEnumerable<CategoryViewModel> items)
        {
            return items.Select(i => new SelectListItem() { Text = i.Title, Value = i.Id.ToString(), Selected = false });
        }
    }
}
