namespace Web.ViewModels.Content
{
    using System.Collections.Generic;

    using AutoMapper;

    using Models.Content;

    using Resources;

    using Infrastructure.Mappings;
    using System.ComponentModel.DataAnnotations;
    using Seo;
    using System.Linq;

    public class PostViewModel : PageViewModel, IMapFrom<Post>, IHaveCustomMappings
    {
        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

        public CategoryViewModel Category { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public ICollection<TagViewModel> Tags { get; set; }

        [Display(Name = "Tags", ResourceType = typeof(Translation))]
        public override string AllTags
        {
            get
            {
                if (this.Tags == null)
                {
                    return string.Empty;
                }

                return string.Join(",", this.Tags.Select(t => t.Name));
            }
            set
            {
                var allTags = new HashSet<TagViewModel>();

                foreach (var item in value.Split(','))
                {
                    allTags.Add(new TagViewModel { Name = item });
                }

                this.Tags = allTags;
            }
        }

        public IEnumerable<string> GetTagsAsStrings()
        {
            return this.Tags.Select(t => t.Name);
        }

        public override string GetHtmlId
        {
            get
            {
                return "post-" + this.Id;
            }
        }

        public string PostedOnBy
        {
            get
            {
                return string.Format(Translation.PostedByOn, this.AuthorName, this.PostedOn);
            }
        }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(
                    sourceModel => sourceModel.AuthorName,
                    result => result.MapFrom(fullModel => fullModel.Author.UserName))
                .ForMember(
                    sourceModel => sourceModel.AuthorId,
                    result => result.MapFrom(fullModel => fullModel.Author.Id));
        }
    }
}