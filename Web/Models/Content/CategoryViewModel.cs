namespace Web.Models.Content
{
    using Config;
    using global::Models.Content;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Web.Infrastructure.Mappings;
    using Web.Models;
    using System.Web.Mvc;

    public class CategoryViewModel : BaseViewModel, IMapFrom<Category>
    {
        [MaxLength(50)]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegexValidator)]
        public string FriendlyUrl { get; set; }

        public string Title { get; set; }

        public static IEnumerable<SelectListItem> GetDropDownModel(IEnumerable<CategoryViewModel> items)
        {
            return items.Select(i => new SelectListItem() { Text = i.Title, Value = i.Id.ToString(), Selected = false });
        }
    }
}
