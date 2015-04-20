﻿namespace Common
{
    using System.Collections.Generic;
    using System.IO;

    using Common.Contracts;

    using Config;

    using Models.Content;
    using Models.SEO;

    public class ContentFactory : IContentFactory
    {
        private readonly IRandomDataGenerator randomGenerator;

        public ContentFactory(IRandomDataGenerator randomDataGenerator)
        {
            this.randomGenerator = randomDataGenerator;
        }

        public Category GetCategory(int id)
        {
            return new Category { Id = id, Title = this.randomGenerator.GetString(10, 255) };
        }

        public Post GetPost(int id)
        {
            return new Post
                       {
                           Id = id,
                           FriendlyUrl = this.randomGenerator.GetUrlSafeString(4, 10),
                           MetaDescription = this.randomGenerator.GetString(4, 10),
                           Tags = new List<Tag> { new Tag { Name = this.randomGenerator.GetString(5, 10) },
                               new Tag { Name = this.randomGenerator.GetString(5, 10) } },
                           Title = this.randomGenerator.GetString(4, 10),
                           MetaTitle = this.randomGenerator.GetString(5, 10),
                           PostedOn = this.randomGenerator.GeneraDateTime(),
                           ModifiedOn = this.randomGenerator.GeneraDateTime(),
                           CreatedOn = this.randomGenerator.GeneraDateTime()
                       };
        }

        public Post GetRealisticPost()
        {
            return new Post
                       {
                           FriendlyUrl = "css-градиенти-от-изображение",
                           MetaDescription = this.randomGenerator.GetString(4, 10),
                           Tags = new List<Tag> { new Tag { Name = this.randomGenerator.GetString(3, 10) } },
                           Title = "КАК ДА ГЕНЕРИРАМЕ CSS КОД ЗА ПО-СЛОЖНИ ГРАДИЕНТИ (ПРЕЛИВКИ) ОТ ДАДЕНО ИЗОБРАЖЕНИЕ",
                           MetaTitle = "КАК ДА ГЕНЕРИРАМЕ CSS КОД ЗА ПО-СЛОЖНИ ГРАДИЕНТИ (ПРЕЛИВКИ) ОТ ДАДЕНО ИЗОБРАЖЕНИЕ",
                           PostedOn = this.randomGenerator.GeneraDateTime(),
                           ModifiedOn = this.randomGenerator.GeneraDateTime(),
                           CreatedOn = this.randomGenerator.GeneraDateTime(),
                           Content = File.ReadAllText(GlobalConstants.SampleHtmlBlogPost)
                       };
        }
    }
}