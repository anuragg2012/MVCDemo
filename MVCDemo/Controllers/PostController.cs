using Microsoft.AspNetCore.Mvc;
using MVCDemo.Interface;
using MVCDemo.Models;
using MVCDemo.Repository;

namespace MVCDemo.Controllers
{
    public class PostController:Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            var posts =await _postService.GetAllPostsAsync();
            return View(posts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var post =await _postService.GetPostByIdAsync(id);
            if (post == null) return NotFound();
            return View(post);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                await _postService.AddPostAsync(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                await _postService.UpdatePostAsync(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeletePostAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
