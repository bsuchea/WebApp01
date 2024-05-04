using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp01.Models;
using WebApp01.Models.Entites;
using WebApp01;

namespace WebApp01.Controllers;

public class ProductController : Controller {

    private readonly MysqlContext _dbContext;

    public ProductController(MysqlContext dbContext){
        this._dbContext = dbContext;
    }

    public IActionResult Index(string search,int Page){
        var req = new Request();
        req.Page = Page;
        ViewBag.Search = search;
        var pro = from t in _dbContext.Products 
        join t2 in _dbContext.Categories on t.CategoryId equals t2.Id
        select new {
            t.Id,
            t.Name,
            t.CategoryId,
            t.Qty,
            t.UnitPrice,
            t.Details,
            Category = t2.Name,
        };

        if(!String.IsNullOrEmpty(search)){
            pro = pro.Where(t => t.Name.Contains(search));
        }

        ViewBag.Total = pro.Count();
        ViewBag.Page = req.Page;

        return View(pro.OrderByDescending(t => t.Id).Skip(req.Skip).Take(req.Take).ToList());
    }

    public IActionResult Create(){

        ViewBag.Categories = _dbContext.Categories.ToList();

        return View();
    }

    [HttpPost]
    public IActionResult Save(Product product){

        var pro = _dbContext.Products.FirstOrDefault(t => t.Id == product.Id);

        if(pro == null) {
            _dbContext.Products.Add(product);
        }else{
            pro.Name = product.Name;
            pro.Qty = product.Qty;
            pro.CategoryId = product.CategoryId;
            pro.UnitPrice = product.UnitPrice;
            pro.Details = product.Details;
        }

        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id){
        ViewBag.Categories = _dbContext.Categories.ToList();
        var pro = _dbContext.Products.FirstOrDefault(t => t.Id == id);
        return View(pro);
    }


}