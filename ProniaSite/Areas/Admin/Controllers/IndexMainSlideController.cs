using Microsoft.AspNetCore.Mvc;
using ProniaSite.DAL;
using ProniaSite.Models;

namespace ProniaSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IndexMainSlideController : Controller
    {
        public IActionResult Index()
        {
            List<IndexMainSlide> indexMainSlides = new List<IndexMainSlide>();
            using (AppDbContext context = new AppDbContext())
            {
                indexMainSlides = context.IndexMainSlides.ToList();
            }
            return View(indexMainSlides);
        }
        public IActionResult Delete(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                IndexMainSlide indexMainSlide = context.IndexMainSlides.Find(id);
                if (indexMainSlide is null) return NotFound();
                context.IndexMainSlides.Remove(indexMainSlide);
                context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id == null) return BadRequest();
            IndexMainSlide indexMainSlide = new IndexMainSlide();
            using (AppDbContext context = new AppDbContext())
            {
                indexMainSlide = context.IndexMainSlides.Find(id);
                if (indexMainSlide is null) return NotFound();
            }
            return View(indexMainSlide);
        }
        [HttpPost]
        public IActionResult Update(int? id, IndexMainSlide indexMainSlide)
        {
            if (id == null) return BadRequest();
            IndexMainSlide indexMainSlide1 = new IndexMainSlide();
            if (indexMainSlide is null) return NotFound();
            using (AppDbContext context = new AppDbContext())
            {
                indexMainSlide1 = context.IndexMainSlides.Find(id);
                indexMainSlide1.Name = indexMainSlide.Name;
                indexMainSlide1.Image = indexMainSlide.Image;
                indexMainSlide1.Description=indexMainSlide.Description;
                indexMainSlide1.Discount=indexMainSlide.Discount;
                
                context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IndexMainSlide indexMainSlide)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.IndexMainSlides.Add(indexMainSlide);
                context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
