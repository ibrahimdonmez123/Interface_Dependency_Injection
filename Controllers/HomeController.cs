using Interface_Dependency_Injection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Interface_Dependency_Injection.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //PROCEDURLERİM
        // create procedure spGetProductByID
        //           (
        //           @ID int
        //       )
        //as
        //select * from Products where ID = @ID




        //        create procedure SpInsertProducts
        //(
        //@Adi nvarchar(50),
        //@Fiyat decimal,
        //@Kategori nvarchar(50)
        //)
        //as
        //insert into Products values (@Adi,@Fiyat,@Kategori)



        private IProductRepository repository;
        public HomeController(IProductRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View(repository.GetAllProducts());
        }

        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Product product)
        {
            return RedirectToAction("Index", repository.Add(product));
        }

        public IActionResult Guncelle(int id)
        {
            return View(repository.GetProduct(id));
        }

        [HttpPost]
        public IActionResult Guncelle(Product prd)
        {
            return RedirectToAction("Index", repository.Update(prd));
        }

        public IActionResult detaylar(int id)
        {
            return View(repository.GetProduct(id));
        }


        public IActionResult Sil(int id)
        {
            return RedirectToAction("Index", repository.Delete(id));
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}