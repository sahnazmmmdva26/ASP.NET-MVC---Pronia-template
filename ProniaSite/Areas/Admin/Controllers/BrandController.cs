using Microsoft.AspNetCore.Mvc;
using ProniaSite.DAL;
using ProniaSite.Models;

namespace ProniaSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            List<Brand> brands = new List<Brand>();
            using (AppDbContext context = new AppDbContext())
            {
                brands = context.Brands.ToList();
            }
            return View(brands);
        }
        public IActionResult Delete(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Brand brand = context.Brands.Find(id);
                if (brand is null) return NotFound();
                context.Brands.Remove(brand);
                context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id == null) return BadRequest();
            Brand brand = new Brand();
            using (AppDbContext context = new AppDbContext())
            {
                brand = context.Brands.Find(id);
                if (brand is null) return NotFound();
            }
            return View(brand);
        }
        [HttpPost]
        public IActionResult Update(int? id, Brand brand)
        {
            if (id == null) return BadRequest();
            Brand existBrand = new Brand();
            if (brand is null) return NotFound();
            using (AppDbContext context = new AppDbContext())
            {
                existBrand = context.Brands.Find(id);
                existBrand.Image = brand.Image;
                context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Brands.Add(brand);
                context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
