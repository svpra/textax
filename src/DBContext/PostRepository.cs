using System;
using Tectex.Models;

namespace Tectex {
    public interface IPostRepository
    {
        Post Get(int id);
    }

    public class PostRepository: IPostRepository 
    {
        protected readonly BlogDbContext _context;
        public PostRepository(BlogDbContext context) {
            _context = context;
        }

        Post Get(int id) {
            return _context.Posts.Include(x => x.Author);
        }
    }
}
