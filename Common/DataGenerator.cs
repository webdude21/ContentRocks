namespace Common
{
    using System.Collections.Generic;

    using Models;
    using Models.SEO;

    public class DataGenerator
    {
        private readonly RandomDataGenerator randomGenerator;

        public DataGenerator()
        {
            this.randomGenerator = RandomDataGenerator.Instance;
        }

        public Post GetPost(int id)
        {
            return new Post
                       {
                           DateStamp =
                               new DateStamp
                                   {
                                       CreatedOn = this.randomGenerator.GeneraDateTime(),
                                       ModifiedOn = this.randomGenerator.GeneraDateTime()
                                   },
                           Id = id,
                           MetaInfo =
                               new MetaInfo
                                   {
                                       Description = this.randomGenerator.GetString(4, 10),
                                       Tags =
                                           new List<Tag>
                                               {
                                                   new Tag
                                                       {
                                                           Id = id,
                                                           Name =
                                                               this.randomGenerator.GetString(
                                                                   3,
                                                                   10)
                                                       }
                                               },
                                       Title = this.randomGenerator.GetString(4, 10)
                                   },
                           Title = this.randomGenerator.GetString(4, 10)
                       };
        }
    }
}