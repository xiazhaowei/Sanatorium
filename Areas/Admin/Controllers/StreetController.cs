using Sanatorium.Models;
using System.Linq;
using System.Web.Mvc;

namespace Sanatorium.Admin.Controllers
{
    public class StreetController : BaseController
    {
        public ActionResult Index()
        {
            if (TempData.ContainsKey("ModelState"))
            {
                ModelState.Merge((ModelStateDictionary)TempData["ModelState"]);
            }

            var model = db.Streets.Where(m => m.Id>0);                

            SetMyAccountViewModel();
            return View(model);
        }


        public ActionResult Add(int id)
        {
            var model = new StreetViewModel();
            if(id>0)
            {
                Street street = db.Streets.SingleOrDefault(c=>c.Id==id);
                if(street != null)
                {
                    model.Id = street.Id;
                    model.RegionName = street.RegionName;
                    model.Name = street.Name;
                }
            }
            var regions = db.Regions.Where(c => c.Id > 0).ToList();
            var regionList = new SelectList(regions, "Name", "Name");
            ViewData["regions"] = regionList;

            SetMyAccountViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(StreetViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.Id>0)
                {//edit
                    Street street = db.Streets.Find(model.Id);
                    if(street != null)
                    {
                        street.Name = model.Name;
                        street.RegionName = model.RegionName;
                        db.Entry(street).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        ModelState.AddModelError("", "操作成功");
                        TempData["ModelState"] = ModelState;

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return new HttpNotFoundResult();
                    }
                }
                else
                {
                    db.Streets.Add(new Street {
                        Name = model.Name,
                        RegionName = model.RegionName
                    });
                    db.SaveChanges();

                    ModelState.AddModelError("", "操作成功");
                    TempData["ModelState"] = ModelState;

                    return RedirectToAction("Index");
                }
            }
            SetMyAccountViewModel();
            return View(model);
        }


        public ActionResult Del(int id)
        {
            if(id>0)
            {
                Street street = db.Streets.Find(id);
                if(street != null)
                {
                    db.Streets.Remove(street);
                    db.SaveChanges();

                    ModelState.AddModelError("", "操作成功");
                    TempData["ModelState"] = ModelState;

                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}