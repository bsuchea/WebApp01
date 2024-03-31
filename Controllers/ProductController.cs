using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp01.Models;
using WebApp01.Models.Entites;

namespace WebApp01.Controllers;

public class ProductController : Controller {

    private readonly MysqlContext _dbContext;

    public ProductController(MysqlContext dbContext){
        this._dbContext = dbContext;
    }

    public IActionResult Index(){

        var pro = _dbContext.Products.ToList();

        return View(pro);
    }

    public IActionResult Create(){

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
            pro.UnitPrice = product.UnitPrice;
            pro.Details = product.Details;
        }

        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id){
        var pro = _dbContext.Products.FirstOrDefault(t => t.Id == id);
        return View(pro);
    }


}