using Microsoft.AspNetCore.Mvc;
using WebApp01.Models;
using WebApp01.Models.Entites;

namespace WebApp01.Controllers;

public class SaleController : Controller
{
    private readonly MysqlContext _dbContext;

    public SaleController(MysqlContext dbContext){
        this._dbContext = dbContext;
    }

    public IActionResult Index(){
        return View();
    }

    [HttpGet]
    public IActionResult Create() {

        ViewBag.Products = _dbContext.Products.ToList();

        return View();
    }

    [HttpPost]
    public IActionResult Create(Sale sale) {
        ViewBag.Products = _dbContext.Products.ToList();

        if (ModelState.IsValid) {
            
            var product = _dbContext.Products.FirstOrDefault(t => t.Id == sale.ProductId);

            sale.Amount = product.UnitPrice * sale.Qty;
            
            _dbContext.Sales.Add(sale);

            product.Qty = product.Qty - sale.Qty;

            _dbContext.SaveChanges();

            return RedirectToAction("Preview", sale.Id);

        }

        return View(sale);
    }

    public ActionResult Preview(int id) {

        ViewBag.Sale = (from t in _dbContext.Sales 
                    join t2 in _dbContext.Products on t.ProductId equals t2.Id 
                    where t.Id == id select new { 
                        t.Id,
                        t.ProductId,
                        t.Customer,
                        t.CustomerPhone,
                        Product = t2.Name,
                        t2.UnitPrice,
                        t.Qty,
                        t.Amount
                    }).FirstOrDefault();
                    
        return View();
    }
}
