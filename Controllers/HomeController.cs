using Sanatorium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sanatorium.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        protected hrEntitysContainer db = new hrEntitysContainer();

        // GET: Home
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModels();
            //获取最新项目
            homeViewModel.Sanatoriums = db.Sanatoriums.OrderByDescending(x=>x.CreatedOn).Take(16).ToList();
            //获取最新新闻
            homeViewModel.Articles = db.Articles.OrderByDescending(x=>x.CreatedOn).Take(2).ToList();
            homeViewModel.Regions = db.Regions.Take(3).ToList();

            return View(homeViewModel);
        }

        #region 项目

        
        public ActionResult SanatoriumList(string region,string street,string community,string name)
        {
            var datas = db.Sanatoriums.Where(x=>x.Id>0);

            var regions = db.Regions.Where(c => c.Id > 0).ToList();
            var streets = db.Streets.Where(c => c.Id == 0).ToList();
            var communitys = db.Communitys.Where(c => c.Id == 0).ToList();

            //筛选
            if (!string.IsNullOrEmpty(region) && region!="选择地区")
            {
                datas = datas.Where(x => x.Region.Contains(region));
                streets = db.Streets.Where(x => x.RegionName.Contains(region)).ToList();
            }
            if (!string.IsNullOrEmpty(street) && street!="选择街道")
            {
                datas = datas.Where(x => x.Street.Contains(street));
                communitys = db.Communitys.Where(x => x.StreetName.Contains(street)).ToList();
            }
            if (!string.IsNullOrEmpty(community)&& community!="选择社区")
            {
                datas = datas.Where(x => x.Community.Contains(community));
            }
            if (!string.IsNullOrEmpty(name))
            {
                datas = datas.Where(x => x.Name.Contains(name));
            }

            //选择项目
            
            var regionList = new SelectList(regions, "Name", "Name");
            var streetList = new SelectList(streets, "Name", "Name");
            var communityList = new SelectList(communitys, "Name", "Name");

            ViewData["regions"] = regionList;
            ViewData["streets"] = streetList;
            ViewData["communitys"] = communityList;

            ViewBag.region = region;
            ViewBag.street = street;
            ViewBag.community = community;
            ViewBag.name = name;

            return View(datas);
        }

        public ActionResult SanatoriumInfo(int id)
        {
            Models.Sanatorium sanatorium = db.Sanatoriums.Find(id);
            if (sanatorium == null)
            {
                return new HttpNotFoundResult();
            }
            return View(sanatorium);
        }

        public ActionResult SanatoriumDescInfo(int id)
        {
            Models.Sanatorium sanatorium = db.Sanatoriums.Find(id);
            if (sanatorium == null)
            {
                return new HttpNotFoundResult();
            }
            return View(sanatorium);
        }
        public ActionResult SanatoriumScopeInfo(int id)
        {
            Models.Sanatorium sanatorium = db.Sanatoriums.Find(id);
            if (sanatorium == null)
            {
                return new HttpNotFoundResult();
            }
            return View(sanatorium);
        }
        public ActionResult SanatoriumContentInfo(int id)
        {
            Models.Sanatorium sanatorium = db.Sanatoriums.Find(id);
            if (sanatorium == null)
            {
                return new HttpNotFoundResult();
            }
            return View(sanatorium);
        }

        public ActionResult SanatoriumLinkInfo(int id)
        {
            Models.Sanatorium sanatorium = db.Sanatoriums.Find(id);
            if (sanatorium == null)
            {
                return new HttpNotFoundResult();
            }
            return View(sanatorium);
        }
        public ActionResult SanatoriumZhiDuInfo(int id)
        {
            Models.Sanatorium sanatorium = db.Sanatoriums.Find(id);
            if (sanatorium == null)
            {
                return new HttpNotFoundResult();
            }
            return View(sanatorium);
        }
        #endregion

        #region 文章



        public ActionResult ArticleList(string title)
        {
            var datas = db.Articles.Where(x => x.Id > 0);
            //筛选
            if (!string.IsNullOrEmpty(title))
            {
                datas = datas.Where(x => x.Title.Contains(title));
            }

            ViewBag.title = title;
            return View(datas);
        }

        public ActionResult ArticleInfo(int id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return new HttpNotFoundResult();
            }
            return View(article);
        }

        #endregion

        #region 政策文件



        public ActionResult FileList(string title)
        {
            var datas = db.RedHeadFiles.Where(x => x.Id > 0);
            //筛选
            if (!string.IsNullOrEmpty(title))
            {
                datas = datas.Where(x => x.Title.Contains(title));
            }

            ViewBag.title = title;
            return View(datas);
        }

        public ActionResult FileInfo(int id)
        {
            RedHeadFile redHeadFile = db.RedHeadFiles.Find(id);
            if (redHeadFile == null)
            {
                return new HttpNotFoundResult();
            }
            return View(redHeadFile);
        }

        #endregion
    }
}