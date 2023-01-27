using System;
using Tectex.Models;
using Textex.Controllers;

namespace Tectex.Controllers {
    public class MyBlogController: Controller 
    {
        private readonly IPostRepository _postRepository;
        public MyBlogController(IPostRepository postRepository) {
            _postRepository = postRepository;
        }

        public IActionResult Post(int id) {
            var post = _postRepository.Get(id);
            if (post == null) return NotFound();

            var model = new PostViewModel{
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                AuthorName = post.Author.Name
            };

            return View(model);
        }
    }
}
