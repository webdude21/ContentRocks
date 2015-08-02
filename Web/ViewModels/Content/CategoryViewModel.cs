namespace Web.ViewModels.Content
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    using Config;

    using Models.Content;

    using Resources;

    using Infrastructure.Mappings;

    public class CategoryViewModel : BaseViewModel, IMapFrom<Category>
    {
        public override string ConfirmDelete
        {
            get
            {
                return Translation.AreYouSureYouWantToDeleteThis + Environment.NewLine
                       + Translation.ThisWillDeleteAllPostInTheCategory;
            }
        }

        [MaxLength(50)]
        [Required]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegex)]
        public string FriendlyUrl { get; set; }

        public string GetHtmlId
        {
            get
            {
                return "category-" + this.Id;
            }
        }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public static Category GetCategoryFrom(CategoryViewModel category)
        {
            return new Category { FriendlyUrl = category.FriendlyUrl, Title = category.Title };
        }

        public static IEnumerable<SelectListItem> GetDropDownModel(IEnumerable<CategoryViewModel> items)
        {
            return items.Select(i => new SelectListItem { Text = i.Title, Value = i.Id.ToString(), Selected = false });
        }
    }
}