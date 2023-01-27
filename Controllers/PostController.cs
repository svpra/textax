using System;
using Tectex.Models;

namespace Tectex.Controllers {

    public class PostController: Controller 
    {
        private readonly IPostRepository _postRepository;
        public MyBlogController(IPostRepository postRepository) {
            _postRepository = postRepository;
        }

        public IActionResult Post(string User.Nick) {
            var post = _postRepository.Get(User.Nick);
            if (post == null) return NotFound();

            var model = new PostViewModel {
                Title = post.Title,
                Content = post.Content,
                AuthorNick = post.Author.Nick
            };

            return View(model);
        }
    }
}
