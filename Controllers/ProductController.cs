using BBsBaskets.Data;
using BBsBaskets.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BBsBaskets.Controllers
{
    public class ProductController : Controller
    {
        private readonly BBsBasketsDbContext _db;

        public ProductController(BBsBasketsDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _db.Products;
            return View(objProductList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
            if (obj.Name == obj.Price.ToString())
            {
                ModelState.AddModelError("Name", "The Price cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Product added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _db.Products.Find(id);
            //var productFromDbFirst = _db.Products.FirstOrDefault(x => x.Id == id);
            //var productFromDbSingle = _db.Products.SingleOrDefault(x => x.Id == id);
            
            if(productFromDb == null)
            {
                return NotFound();
            }
            
            return View(productFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (obj.Name == obj.Price.ToString())
            {
                ModelState.AddModelError("Name", "The Price cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _db.Products.Find(id);
            //var productFromDbFirst = _db.Products.FirstOrDefault(x => x.Id == id);
            //var productFromDbSingle = _db.Products.SingleOrDefault(x => x.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Products.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                       
            _db.Products.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Product deletedd successfully";
            return RedirectToAction("Index");
          
        }
    }
}
