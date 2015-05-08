﻿namespace Services
{
    using System.Data.Entity;
    using System.Linq;

    using Common;

    using Data.Contracts;

    using Models.Content;

    using Services.Contracts;

    public class PostService : BaseService<Post>, IPostService
    {
        public PostService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.Categories = unitOfWork.Set<Category>();
        }

        public IDbSet<Category> Categories { get; set; }

        public void AddPost(Post newPost)
        {
            Checker.CheckForNull(newPost, "newPost");
            this.CheckIfEntityExists(newPost.Id);
            this.DataSet.Add(newPost);
            this.SaveChanges();
        }

        public IQueryable<Post> GetBy(int id, string friendlyUrl)
        {
            return this.DataSet.Where(p => p.Id == id && p.FriendlyUrl == friendlyUrl);
        }

        public IQueryable<Post> GetTheLatestPosts()
        {
            return this.DataSet.OrderByDescending(post => post.CreatedOn);
        }

        public IQueryable<Post> GetTheLatestPosts(int count, int page = 1)
        {
            return this.GetDataWithPaging(this.GetTheLatestPosts(), count, page);
        }

        public IQueryable<Post> GetTheLatestPostsByAuthor(string authorId, int count, int page = 1)
        {
            return this.GetDataWithPaging(this.GetTheLatestPostsByAuthor(authorId), count, page);
        }

        public IQueryable<Post> GetTheLatestPostsByAuthor(string authorId)
        {
            return this.GetTheLatestPosts().Where(p => p.AuthorId == authorId);
        }
    }
}