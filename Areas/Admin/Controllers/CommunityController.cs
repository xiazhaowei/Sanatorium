using Sanatorium.Models;
using System.Linq;
using System.Web.Mvc;

namespace Sanatorium.Admin.Controllers
{
    public class CommunityController : BaseController
    {
        public ActionResult Index()
        {
            if (TempData.ContainsKey("ModelState"))
            {
                ModelState.Merge((ModelStateDictionary)TempData["ModelState"]);
            }

            var model = db.Communitys.Where(m => m.Id>0);                

            SetMyAccountViewModel();
            return View(model);
        }


        public ActionResult Add(int id)
        {
            var model = new CommunityViewModel();
            if(id>0)
            {
                Community community = db.Communitys.SingleOrDefault(c=>c.Id==id);
                if(community != null)
                {
                    model.Id = community.Id;
                    model.Name = community.Name;
                    model.StreetName = community.StreetName;
                }
            }
            var streets = db.Streets.Where(c => c.Id > 0).ToList();
            var streetList = new SelectList(streets, "Name", "Name");
            ViewData["streets"] = streetList;

            SetMyAccountViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(CommunityViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.Id>0)
                {//edit
                    Community community = db.Communitys.Find(model.Id);
                    if(community != null)
                    {
                        community.Name = model.Name;
                        community.StreetName = model.StreetName;

                        db.Entry(community).State = System.Data.Entity.EntityState.Modified;
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
                    db.Communitys.Add(new Community {
                        Name = model.Name,
                        StreetName=model.StreetName
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
                Community community = db.Communitys.Find(id);
                if(community != null)
                {
                    db.Communitys.Remove(community);
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