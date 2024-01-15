using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using myProjectMVC.Data;
using myProjectMVC.Models;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.RegularExpressions;
using System.Text;

namespace myProjectMVC.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public static int len = 0;
        public static bool flag = true;
        
        public CitiesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<City>> Get()
        {
            return _db.Cities;
        }
        //public IActionResult Index()
        //{
        //    IEnumerable<City> objCitiesList = _db.Cities;
        //    return View(objCitiesList);
        //}
        //public ActionResult Next()
        //{
        //    for (int i = len; i < len + 5; i++)
        //    {

        //    }
        //    IEnumerable<City> objCitiesList = _db.Cities;
        //    return View(objCitiesList);
        //}

        public ActionResult Index(string search)
        {
            //if (search != null)
            //{
            //    Encoding latinEncoding = Encoding.GetEncoding("Windows-1252");
            //    Encoding hebrewEncoding = Encoding.GetEncoding("Windows-1255");

            //    byte[] latinBytes = latinEncoding.GetBytes(search);

            //    string hebrewString = hebrewEncoding.GetString(latinBytes);
            //    search = hebrewString;
            //}

            //    string wordSearch = "";
            //const char FirstHebChar = (char)1488; //א
            //const char LastHebChar = (char)1514; //ת
            ////var regex = new Regex("[a-zA-Z0-9 ]*");
            if (search != null)
            {
                int asc = 0;
                string newWord = "";
                foreach (char item in search)
                {
                    if (item < 'א' || item > 'ת')
                    {
                        asc = (int)item + 31;
                        newWord +=(char)asc;
                    }
                }
                if (newWord.Length >= 1)
                {
                    search = newWord;
                }
                
            }
            if (flag)
            {
                ViewBag.Message = "Your contacts.";
                if (search != null)
                {

                    var model = _db.Cities
                           .OrderBy(c => c.cityName)
                           .Where(c => search == null || c.cityName.Contains(search))
                           .Select(c => new City
                           {
                               cityID = c.cityID,
                               cityName = c.cityName,
                           });
                    return View(model);
                }

                else
                {
                    var model = _db.Cities
                          .OrderBy(c => c.cityName)
                          .Select(c => new City
                          {
                              cityID = c.cityID,
                              cityName = c.cityName,
                          });
                    return View(model);
                }
            }
            else
            {
                ViewBag.Message = "Your contacts.";
                if (search != null)
                {

                    var model = _db.Cities
                           .OrderByDescending(c => c.cityName)
                           .Where(c => search == null || c.cityName.Contains(search))
                           .Select(c => new City
                           {
                               cityID = c.cityID,
                               cityName = c.cityName,
                           });
                    return View(model);
                }

                else
                {
                    var model = _db.Cities
                          .OrderByDescending(c => c.cityName)
                          .Select(c => new City
                          {
                              cityID = c.cityID,
                              cityName = c.cityName,
                          });
                    return View(model);
                }
            }
            

        }
        public IActionResult Sort()
        {
            if (flag)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
            return RedirectToAction("Index");
        }

        //    //GET
        //    public IActionResult Create()
        //    {
        //        return View();
        //    }
        //    //POST
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult Create(City obj)
        //    {
        //        bool flag = false;
        //        if (ModelState.IsValid)
        //        {
        //            foreach(City city in _db.Cities)
        //            {
        //                if(city.cityName.Equals(obj.cityName))
        //                {
        //                    flag = true;
        //                }
        //            }
        //            if (!flag)
        //            {
        //	_db.Cities.Add(obj);
        //	_db.SaveChanges();
        //	return RedirectToAction("Index");
        //}
        //            else
        //            {
        //	return View(obj);
        //}
        //        }
        //        return View(obj);

        //    }
        //GET
        public IActionResult Add()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(City obj)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                foreach (City city in _db.Cities)
                {
                    if (city.cityName.Equals(obj.cityName))
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    _db.Cities.Add(obj);
                    _db.SaveChanges();
                    TempData["success"] = "City create successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(obj);
                }
            }
            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if(id== null || id == 0)
            {
                return NotFound();
            }
            var cityFromDb=_db.Cities.Find(id);
            if(cityFromDb == null)
            {
                return NotFound();
            }
            return View(cityFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(City obj)
        {
            if (ModelState.IsValid)
            {
                _db.Cities.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "City edit successfully";
                return RedirectToAction("Index");
            }

            return View(obj);

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cityFromDb = _db.Cities.Find(id);
            if (cityFromDb == null)
            {
                return NotFound();
            }
            return View(cityFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(City city)
        {
            //id = 10120;
            var obj=_db.Cities.Find(city.cityID);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Cities.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "City delete successfully";
            return RedirectToAction("Index");

        }
        //public IActionResult Search()
        //{
        //    IEnumerable<City> objCitiesList = _db.Cities;
        //    String cityCearch = "אופ";
        //    IEnumerable<City> array = _db.Cities;
        //    //IEnumerable<City> objCitiesList=new IEnumerable<City>();
        //    foreach (City city in _db.Cities)
        //    {
        //        if (city.cityName.Contains(cityCearch))
        //        {
        //            array.Append(city);
        //        }
                

        //    }
        //    return View(objCitiesList);
        //}


    }
}
