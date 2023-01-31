using System;
using Tectex.Models;
using MarkDig;
using Tectex.Markdown;

namespace Tectex.Controllers {

    public class PostController: Controller 
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository) {
            _postRepository = postRepository;
        }

        public IActionResult Post(string User.Nick) {
            var post = _postRepository.Get(User.Nick);
            if (post == null) return NotFound();

            var model = new PostViewModel {
                Title = post.Title,
                PostContent = Markdown.ParseHtmlString(Post.Content) // можно было бы встроить трансляцию во view, но пока так
                AuthorNick = post.Author.Nick
            };

            return View(model);
        }
    }
}
