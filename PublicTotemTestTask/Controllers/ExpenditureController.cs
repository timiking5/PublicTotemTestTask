using Data.DataAccess;
using Highsoft.Web.Mvc.Charts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace PublicTotemTestTask.Controllers;
public class ExpenditureController : Controller
{
    private readonly ApplicationDbContext _db;

    public ExpenditureController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var records = _db.ExpenditureRecord.AsQueryable().Include("Category").ToList();
        return View(records);
    }
    public IActionResult Create()
    {
        GetCategoriesToViewData();
        return View();
    }

    private void GetCategoriesToViewData()
    {
        IEnumerable<SelectListItem> categoryList = _db.Category.AsQueryable().Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });
        ViewData["CategoryList"] = categoryList;
    }

    [HttpPost]
    public IActionResult Create(ExpenditureRecord record)
    {
        if (ModelState.IsValid)
        {
            _db.ExpenditureRecord.Add(record);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        GetCategoriesToViewData();
        return View(record);
    }
    public IActionResult Edit(int? id)
    {
        if (id is null || id == 0)
        {
            return NotFound();
        }

        var recordFromDb = _db.ExpenditureRecord.FirstOrDefault(x => x.Id == id);

        if (recordFromDb is null)
        {
            return NotFound();
        }
        GetCategoriesToViewData();
        return View(recordFromDb);
    }
    [HttpPost]
    public IActionResult Edit(ExpenditureRecord record)
    {
        if (ModelState.IsValid)
        {
            _db.ExpenditureRecord.Update(record);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        GetCategoriesToViewData();
        return View(record);
    }
    public IActionResult Delete(int? id)
    {
        if (id is null || id == 0)
        {
            return NotFound();
        }
        var recordFromDb = _db.ExpenditureRecord.FirstOrDefault(x => x.Id == id);
        if (recordFromDb is null)
        {
            return NotFound();
        }
        return View(recordFromDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        if (id is null || id == 0)
        {
            return NotFound();
        }

        var recordFromDb = _db.ExpenditureRecord.FirstOrDefault(x => x.Id == id);
        
        if (recordFromDb is null)
        {
            return NotFound();
        }

        _db.ExpenditureRecord.Remove(recordFromDb);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Report()
    {
        List<PieSeriesData> pieData =
        [
            new PieSeriesData { Name = "FireFox", Y = 45.0 },
            new PieSeriesData { Name = "IE", Y = 26.8 },
            new PieSeriesData { Name = "Chrome", Y = 12.8, Sliced = true, Selected = true },
            new PieSeriesData { Name = "Safari", Y = 8.5 },
            new PieSeriesData { Name = "Opera", Y = 6.2 },
            new PieSeriesData { Name = "Others", Y = 0.7 },
        ];

        ViewData["pieData"] = pieData;

        return View();
    }
}
