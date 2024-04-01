using Data.DataAccess;
using Highsoft.Web.Mvc.Charts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModels;
using System.Collections.Generic;

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
    public IActionResult Report(int year, int month)
    {
        var query = _db.ExpenditureRecord.AsQueryable().Include("Category");
        var allExpenditureRecords = query.Where(x => x.Date.Year == year && x.Date.Month == month).ToList();
        var aggregatedRecords = allExpenditureRecords.GroupBy(x => x.Category.Name).Select(gcs => new ExpenditureRecord
        {
            Amount = gcs.Sum(x => x.Amount),
            Category = new Category { Name = gcs.Key }
        }).ToList();

        var pieData = aggregatedRecords.Select(x => new PieSeriesData { Name = x.Category.Name, Y = (double)x.Amount }).ToList();
        ViewData["pieData"] = pieData;

        ReportVM vm = new()
        {
            AggregateByCategory = aggregatedRecords,
            AllRecords = allExpenditureRecords,
            Date = new DateTime(year, month, 1)
        };
        return View(vm);
    }
    public IActionResult OverView()
    {
        var list = _db.ExpenditureRecord.GroupBy(x => new { x.Date.Year, x.Date.Month })
                .Select(gcs => new ExpenditureRecord
                {
                    Date = new DateTime(gcs.Key.Year, gcs.Key.Month, 1),  // standing for first day of month
                    Amount = gcs.Sum(x => x.Amount)
                })
                .ToList();
        return View(list);
    }
}
