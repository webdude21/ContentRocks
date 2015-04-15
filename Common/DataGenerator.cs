﻿namespace Common
{
    using System.Collections.Generic;

    using Common.Contracts;

    using Models.Content;
    using Models.SEO;

    public class ContentFactory : IContentFactory
    {
        private readonly IRandomDataGenerator randomGenerator;

        public ContentFactory(IRandomDataGenerator randomDataGenerator)
        {
            this.randomGenerator = randomDataGenerator;
        }

        public Post GetPost(int id)
        {
            return new Post
                       {
                           Id = id,
                           MetaInfo = new MetaInfo
                                   {
                                       Description = this.randomGenerator.GetString(4, 10),
                                       Tags = new List<Tag> {
                                                   new Tag {
                                                           Id = id,
                                                           Name = this.randomGenerator.GetString(3, 10)
                                                   }
                                               },
                                       Title = this.randomGenerator.GetString(4, 10)
                                   },
                           Title = this.randomGenerator.GetString(4, 10),
                           PostedOn = this.randomGenerator.GeneraDateTime(),
                           ModifiedOn = this.randomGenerator.GeneraDateTime(),
                           CreatedOn = this.randomGenerator.GeneraDateTime()
                       };
        }

        public Category GetCategory(int id)
        {
           return new Category{ Id = id, Title = this.randomGenerator.GetString(10, 255)};
        }
    }
}