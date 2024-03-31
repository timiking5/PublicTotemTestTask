using Data.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace PublicTotemTestTask.Controllers;
public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var models = _db.Category.ToList();
        return View(models);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category model)
    {
        if (ModelState.IsValid)
        {
            _db.Category.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(model);
    }
    public IActionResult Edit(int? id)
    {
        if (id is null || id == 0)
        {
            return NotFound();
        }

        var categoryFromDb = _db.Category.FirstOrDefault(x => x.Id == id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    [HttpPost]
    public IActionResult Edit(Category model)
    {
        if (ModelState.IsValid)
        {
            _db.Category.Update(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var categoryFromDb = _db.Category.FirstOrDefault(x => x.Id == id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        var categoryFromDb = _db.Category.FirstOrDefault(x => x.Id == id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        _db.Category.Remove(categoryFromDb);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
