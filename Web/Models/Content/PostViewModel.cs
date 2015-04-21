﻿namespace Web.Models.Content
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;

    using global::Models.Content;

    using Web.Infrastructure.Mappings;
    using Web.Models.Contracts;
    using Web.Models.Seo;

    public class PostViewModel : BaseViewModel, IMapFrom<Post>, IMetaInfoViewModel, IHaveCustomMappings
    {
        public string AllTags
        {
            get
            {
                return string.Join(", ", this.Tags.Select(t => t.Name));
            }
        }

        public string AuthorName { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        [DataType(DataType.Html)]
        public string Content { get; set; }

        public string FriendlyUrl { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        public DateTime PostedOn { get; set; }

        public ICollection<TagViewModel> Tags { get; set; }

        public string Title { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(
                    sourceModel => sourceModel.AuthorName,
                    result => result.MapFrom(fullModel => fullModel.Author.UserName));
        }
    }
}