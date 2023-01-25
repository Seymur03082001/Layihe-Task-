using Layihe_Task_.DAL;
using Layihe_Task_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Layihe_Task_.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class PostController : Controller
    {
        readonly AppDbContext _context;
        public PostController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var post=_context.Posts.ToList();
            return View(post);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if(post == null) return NotFound();
            _context.Posts.Add(post);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            Post post = _context.Posts.Find(id);
            if (post == null) return NotFound();
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0) return BadRequest();
            Post post = _context.Posts.Find(id);
            if (post is null) return NotFound();
            return View(post);
        }

        [HttpPost]
        public IActionResult Update(int id, Post post)
        {
            if (id == null || id == 0 || id != post.Id || post is null) return BadRequest();
            if (!ModelState.IsValid) return View();
            Post anotherpost = _context.Posts.FirstOrDefault(s => s.Description == post.Description);
            if (anotherpost != null)
            {
                anotherpost.Description = _context.Posts.Find(id).Description;
            }
            Post exist = _context.Posts.Find(id);
            exist.Name = post.Name;
            exist.Title = post.Title;
            exist.Description = post.Description;
            //_context.Posts.Update(post);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
