using Microsoft.AspNetCore.Mvc;

namespace MYWebApplication.Controllers
{
    // Product verisi class yoluyla oluşturuldu 
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
           
            // Veri taşıma VievBag Property yazıyoruz ViewBag.{isim belirle} = 
            ViewBag.name = "Asp:net ";
            // Veri Taşıma ViewData Prop yazıyoruz ViewData["parametre"]="değer"
            ViewData["age"] = 30;

            ViewData["names"] = new List<string>() { "Ahmet", "Mehmet", "Cem" };
            // Bir sayfada bir diğer sayfaya değer taşımak veri aktarmak istediğimizde kullanılır TempData 
            TempData["surname"] = "Koyluoglu";
            return View();
        }
        public IActionResult Index2() 
        {
            // Sayfayı başka bir Action Methoduna yönlendirmek için öncelikle 
            // RedirectToAction("Yönlendirmek isediğimiz Action ismi", "ikinci parametre ise Controller içerir ")
            return RedirectToAction("Index","Ornek");
           
        }
        public IActionResult Index3()
        { // TempData ile Index 1 içindeki veriyi Index3 sayfasına taşıdık
            return View();
        }

        public IActionResult Index4()
        {
            // (ViewModellemek) Veriden çekiyormuşcasına bir list verisi oluşturuldu 
            var productList = new List<Product>()
            {
                new() {Id=1, Name="Kalem" },
                new() {Id=2, Name="Defter"},
                new() {Id=3, Name="Silgi"}

            };
            return View(productList);
        }


        // Action Method Parametre Tanımlama
        public IActionResult ParametreView(int id )
        {
            return RedirectToAction("JsonResultParametre","Ornek", new {id=id});
        }
        public IActionResult JsonResultParametre(int id ) 
        {
            return Json(new { id = id});
        }

        // Geriye String bir ifade döndürmek için kullandığımız ifade ContentResulttur
        public IActionResult ContentResult() { return Content("ContentResult"); }
        // Geriye JSON bir ifade döndürmek için kullandığımız ifade JsonResultur
        public IActionResult JsonResult() { return Json(new {Id=1, name="Kalem1", price=100 }); }
        // Geriye hiç bir şey döndürmemek için kullandığımız ifade EmptyResulttur
        public IActionResult EmptyResult() { return new EmptyResult(); }
    }
}
