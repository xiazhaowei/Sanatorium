using Sanatorium.Models;
using System.Linq;
using System.Web.Mvc;

namespace Sanatorium.Admin.Controllers
{
    public class RegionController : BaseController
    {
        public ActionResult Index()
        {
            if (TempData.ContainsKey("ModelState"))
            {
                ModelState.Merge((ModelStateDictionary)TempData["ModelState"]);
            }

            var model = db.Regions.Where(m => m.Id>0);                

            SetMyAccountViewModel();
            return View(model);
        }


        public ActionResult Add(int id)
        {
            var model = new RegionViewModel();
            if(id>0)
            {
                Region region = db.Regions.SingleOrDefault(c=>c.Id==id);
                if(region != null)
                {
                    model.Id = region.Id;
                    model.Name = region.Name;
                }
            }
            SetMyAccountViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(RegionViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.Id>0)
                {//edit
                    Region region = db.Regions.Find(model.Id);
                    if(region != null)
                    {
                        region.Name = model.Name;

                        db.Entry(region).State = System.Data.Entity.EntityState.Modified;
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
                    db.Regions.Add(new Region {
                        Name = model.Name,
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
                Region region = db.Regions.Find(id);
                if(region != null)
                {
                    db.Regions.Remove(region);
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