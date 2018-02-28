using Sanatorium.Helper;
using Sanatorium.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Sanatorium.Admin.Controllers
{
    public class ArticleController : BaseController
    {
        // GET: RedHeadFile
        public ActionResult Index(string name)
        {
            if (TempData.ContainsKey("ModelState"))
            {
                ModelState.Merge((ModelStateDictionary)TempData["ModelState"]);
            }
            
            var model = db.Articles.Where(f => f.Id > 0);
            if(!string.IsNullOrEmpty(name))
            {
                model = model.Where(x => x.Title.Contains(name));
            }
            ViewBag.name = name;

            SetMyAccountViewModel();
            return View(model);
        }

        public ActionResult Add(int id)
        {
            var model = new ArticleViewModel();
            
            if (id > 0)
            {
                Article article = db.Articles.Find(id);
                if (article == null)
                {
                    return new HttpNotFoundResult();
                }
                model.Id = article.Id;
                model.Title = article.Title;
                model.Content = article.Content;
            }

            SetMyAccountViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(ArticleViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.Id>0)
                {
                    Article article = db.Articles.Find(model.Id);
                    if(article == null)
                    {
                        return new HttpNotFoundResult();
                    }
                    article.Title = model.Title;
                    article.Content = model.Content;
                    
                    db.Entry(article).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    db.Articles.Add(new Article {
                        Title=model.Title,
                        Content=model.Content,
                        CreatedOn=DateTime.Now
                    });
                    db.SaveChanges();
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
                Article article = db.Articles.Find(id);
                if(article != null)
                {
                    db.Articles.Remove(article);
                    db.SaveChanges();                    
                }
            }

            return RedirectToAction("Index");
        }


        public ActionResult Upload()
        {
            var requestHelper = new RequestHelper(this.Request);
            var filePath = requestHelper.SaveImageToServer();

            return Content(filePath);
        }
    }
}