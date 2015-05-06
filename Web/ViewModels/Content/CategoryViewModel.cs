namespace Web.ViewModels.Content
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    using Config;

    using Models.Content;

    using Resources;

    using Web.Infrastructure.Mappings;

    public class CategoryViewModel : BaseViewModel, IMapFrom<Category>
    {
        [MaxLength(50)]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegex)]
        public string FriendlyUrl { get; set; }

        public string Title { get; set; }

        public string GetHtmlId
        {
            get
            {
                return "category-" + this.Id; 
            }
        }

        public string ConfirmDelete
        {
            get
            {
                return Translation.AreYouSureYouWantToDeleteThis + System.Environment.NewLine
                       + Translation.ThisWillDeleteAllPostInTheCategory;
            }
        }

        public static IEnumerable<SelectListItem> GetDropDownModel(IEnumerable<CategoryViewModel> items)
        {
            return items.Select(i => new SelectListItem() { Text = i.Title, Value = i.Id.ToString(), Selected = false });
        }

        public static Category GetCategoryFrom(CategoryViewModel category)
        {
            return new Category
            {
                FriendlyUrl = category.FriendlyUrl,
                Title = category.Title
            };
        }
    }
}
