using Sanatorium.Helper;
using Sanatorium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sanatorium.Admin.Controllers
{
    public class SanatoriumController : BaseController
    {
        // GET: Sanatorium
        public ActionResult Index(string region,string street,string community,string name)
        {
            if (TempData.ContainsKey("ModelState"))
            {
                ModelState.Merge((ModelStateDictionary)TempData["ModelState"]);
            }

            var datas = db.Sanatoriums.Where(x=>x.Id>0);

            //筛选
            //筛选
            if (!string.IsNullOrEmpty(region) && region != "选择地区")
            {
                datas = datas.Where(x => x.Region.Contains(region));
            }
            if (!string.IsNullOrEmpty(street) && street != "选择街道")
            {
                datas = datas.Where(x => x.Street.Contains(street));
            }
            if (!string.IsNullOrEmpty(community) && community != "选择社区")
            {
                datas = datas.Where(x => x.Community.Contains(community));
            }
            if (!string.IsNullOrEmpty(name))
            {
                datas = datas.Where(c => c.Name.Contains(name));
            }

            ViewBag.name = name;

            //选择项目
            var regions = db.Regions.Where(c => c.Id > 0).ToList();
            var regionList = new SelectList(regions, "Name", "Name");

            var streets = db.Streets.Where(c => c.Id > 0).ToList();
            var streetList = new SelectList(streets, "Name", "Name");

            var communitys = db.Communitys.Where(c => c.Id > 0).ToList();
            var communityList = new SelectList(communitys, "Name", "Name");

            ViewData["regions"] = regionList;
            ViewData["streets"] = streetList;
            ViewData["communitys"] = communityList;

            SetMyAccountViewModel();
            return View(datas);
        }
        #region 添加

        
        public ActionResult Add(int id)
        {

            var model = new SanatoriumViewModel();
            if (id > 0)
            {
                //编辑
                Sanatorium.Models.Sanatorium sanatorium = db.Sanatoriums.Find(id);
                {
                    if (sanatorium != null)
                    {
                        model.Id = id;
                        model.Name = sanatorium.Name;
                        model.Pics = sanatorium.Pics;
                        model.Region = sanatorium.Region;
                        model.Street = sanatorium.Street;
                        model.Community = sanatorium.Community;
                        model.Address = sanatorium.Address;
                        model.StagingCount = sanatorium.StagingCount;
                        model.CompletionYear = sanatorium.CompletionYear;
                        model.BuildingsCount = sanatorium.BuildingsCount;
                        model.StructureArea = sanatorium.StructureArea;
                        model.FinishArea = sanatorium.FinishArea;
                        model.DoingArea = sanatorium.DoingArea;
                        model.ToDoArea = sanatorium.ToDoArea;
                        model.ShiShiOrg = sanatorium.ShiShiOrg;
                        model.ShiGongOrg = sanatorium.ShiGongOrg;
                        model.StartTime = sanatorium.StartTime;
                        model.FinishTime = sanatorium.FinishTime;
                        model.PredictFinishTime = sanatorium.PredictFinishTime;

                        model.BuildOrg = sanatorium.BuildOrg;
                        model.BuildOrgPrincipal = sanatorium.BuildOrgPrincipal;
                        model.BuildOrgPhone = sanatorium.BuildOrgPhone;
                        model.BuildOrgWeb = sanatorium.BuildOrgWeb;

                        model.DesignOrg = sanatorium.DesignOrg;
                        model.DesignOrgPrincipal = sanatorium.DesignOrgPrincipal;
                        model.DesignOrgPhone = sanatorium.DesignOrgPhone;
                        model.DesignOrgWeb = sanatorium.DesignOrgWeb;

                        model.SupervisionOrg = sanatorium.SupervisionOrg;
                        model.SupervisionOrgPrincipal = sanatorium.SupervisionOrgPrincipal;
                        model.SupervisionOrgPhone = sanatorium.SupervisionOrgPhone;
                        model.SupervisionOrgWeb = sanatorium.SupervisionOrgWeb;

                        model.GongZiPhone = sanatorium.GongZiPhone;
                        model.JuMinPhone = sanatorium.JuMinPhone;

                        

                        model.Remark = sanatorium.Remark;
                    }
                    else
                    {
                        //未找到该项目
                    }
                }
            }

            //选择项目
            //var hremoves = db.HRemoves.Where(h => h.Id > 0).ToList();
            //var selectList = new SelectList(hremoves, "Name", "Name");
            //ViewData["list"] = selectList;

            var regions = db.Regions.Where(c => c.Id > 0).ToList();
            var regionList = new SelectList(regions, "Name", "Name");

            var streets = db.Streets.Where(c => c.Id > 0).ToList();
            var streetList = new SelectList(streets, "Name", "Name");

            var communitys = db.Communitys.Where(c => c.Id > 0).ToList();
            var communityList = new SelectList(communitys, "Name", "Name");

            ViewData["regions"] = regionList;
            ViewData["streets"] = streetList;
            ViewData["communitys"] = communityList;

            SetMyAccountViewModel();
            return View(model);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(SanatoriumViewModel model)
        {
            var requestHelper = new RequestHelper(this.Request);
            if (ModelState.IsValid)
            {
                int id = 0;
                if (model.Id > 0)//修改
                {
                    Models.Sanatorium sanatorium = db.Sanatoriums.SingleOrDefault(h => h.Id == model.Id);
                    if (sanatorium != null)
                    {
                        var filePath = requestHelper.SaveImageToServer();
                        if(!string.IsNullOrEmpty(filePath))
                            sanatorium.Pics = filePath;
                        sanatorium.Name = model.Name;
                        sanatorium.Region = model.Region;
                        sanatorium.Street = model.Street;
                        sanatorium.Community = model.Community;
                        sanatorium.Address = model.Address;
                        sanatorium.ShiShiOrg = model.ShiShiOrg;
                        sanatorium.ShiGongOrg = model.ShiGongOrg;
                        sanatorium.StartTime = model.StartTime.Value;
                        sanatorium.FinishTime = model.FinishTime.Value;
                        sanatorium.PredictFinishTime = model.PredictFinishTime.Value;

                        sanatorium.StructureArea = model.StructureArea;
                        sanatorium.FinishArea = model.FinishArea;
                        sanatorium.DoingArea = model.DoingArea;
                        sanatorium.ToDoArea = model.ToDoArea;
                        sanatorium.BuildingsCount = model.BuildingsCount;
                        sanatorium.StagingCount = model.StagingCount;
                        sanatorium.CompletionYear = model.CompletionYear;

                        sanatorium.BuildOrg = model.BuildOrg;
                        sanatorium.BuildOrgWeb = model.BuildOrgWeb;
                        sanatorium.BuildOrgPrincipal = model.BuildOrgPrincipal;
                        sanatorium.BuildOrgPhone = model.BuildOrgPhone;

                        sanatorium.DesignOrg = model.DesignOrg;
                        sanatorium.DesignOrgWeb = model.DesignOrgWeb;
                        sanatorium.DesignOrgPrincipal = model.DesignOrgPrincipal;
                        sanatorium.DesignOrgPhone = model.DesignOrgPhone;

                        sanatorium.SupervisionOrg = model.SupervisionOrg;
                        sanatorium.SupervisionOrgWeb = model.SupervisionOrgWeb;
                        sanatorium.SupervisionOrgPrincipal = model.SupervisionOrgPrincipal;
                        sanatorium.SupervisionOrgPhone = model.SupervisionOrgPhone;

                        sanatorium.GongZiPhone = model.GongZiPhone;
                        sanatorium.JuMinPhone = model.JuMinPhone;

                        sanatorium.Remark = model.Remark;

                        sanatorium.CreatedOn = DateTime.Now;

                        db.Entry(sanatorium).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        id = sanatorium.Id;
                    }
                }
                else
                {
                    Models.Sanatorium sanatorium = new Models.Sanatorium();
                    var filePath = requestHelper.SaveImageToServer();
                    if (!string.IsNullOrEmpty(filePath))
                        sanatorium.Pics = filePath;
                    sanatorium.Name = model.Name;
                    sanatorium.Region = model.Region;
                    sanatorium.Street = model.Street;
                    sanatorium.Community = model.Community;
                    sanatorium.Address = model.Address;
                    sanatorium.ShiShiOrg = model.ShiShiOrg;
                    sanatorium.ShiGongOrg = model.ShiGongOrg;
                    sanatorium.StartTime = model.StartTime.Value;
                    sanatorium.FinishTime = model.FinishTime.Value;
                    sanatorium.PredictFinishTime = model.PredictFinishTime.Value;

                    sanatorium.StructureArea = model.StructureArea;
                    sanatorium.FinishArea = model.FinishArea;
                    sanatorium.DoingArea = model.DoingArea;
                    sanatorium.ToDoArea = model.ToDoArea;
                    sanatorium.BuildingsCount = model.BuildingsCount;
                    sanatorium.StagingCount = model.StagingCount;
                    sanatorium.CompletionYear = model.CompletionYear;

                    sanatorium.BuildOrg = model.BuildOrg;
                    sanatorium.BuildOrgWeb = model.BuildOrgWeb;
                    sanatorium.BuildOrgPrincipal = model.BuildOrgPrincipal;
                    sanatorium.BuildOrgPhone = model.BuildOrgPhone;

                    sanatorium.DesignOrg = model.DesignOrg;
                    sanatorium.DesignOrgWeb = model.DesignOrgWeb;
                    sanatorium.DesignOrgPrincipal = model.DesignOrgPrincipal;
                    sanatorium.DesignOrgPhone = model.DesignOrgPhone;

                    sanatorium.SupervisionOrg = model.SupervisionOrg;
                    sanatorium.SupervisionOrgWeb = model.SupervisionOrgWeb;
                    sanatorium.SupervisionOrgPrincipal = model.SupervisionOrgPrincipal;
                    sanatorium.SupervisionOrgPhone = model.SupervisionOrgPhone;

                    sanatorium.GongZiPhone = model.GongZiPhone;
                    sanatorium.JuMinPhone = model.JuMinPhone;

                    sanatorium.Remark = model.Remark;

                    sanatorium.CreatedOn = DateTime.Now;

                    db.Sanatoriums.Add(sanatorium);
                    db.SaveChanges();

                    id = sanatorium.Id;
                }
                return RedirectToAction("EditDescriptionInfo", new { id = id });
               
            }

            SetMyAccountViewModel();
            return View(model);
        }

        #endregion

        #region 制度

        
        public ActionResult EditZhiDuInfo(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            Models.Sanatorium sanatorium = db.Sanatoriums.Find(id);
            if (sanatorium == null)
            {
                return RedirectToAction("Index");
            }

            var model = new ZhiDuViewModel();
            model.Id = sanatorium.Id;
            model.ShiGongZhidu = sanatorium.ShiGongZhidu;
            model.AnQuanZhiDu = sanatorium.AnQuanZhiDu;
            model.XiaoFangZhidu = sanatorium.XiaoFangZhidu;

            SetMyAccountViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditZhiDuInfo(ZhiDuViewModel model)
        {
            if (ModelState.IsValid)
            {
                Sanatorium.Models.Sanatorium sanatorium = db.Sanatoriums.Find(model.Id);
                if (sanatorium == null)
                {
                    return RedirectToAction("Index");
                }

                sanatorium.ShiGongZhidu = model.ShiGongZhidu;
                sanatorium.AnQuanZhiDu = model.AnQuanZhiDu;
                sanatorium.XiaoFangZhidu = model.XiaoFangZhidu;

                db.Entry(sanatorium).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                ModelState.AddModelError("", "操作成功");
                TempData["ModelState"] = ModelState;
                return RedirectToAction("EditXiaoZuInfo", new { id = model.Id });
            }
            SetMyAccountViewModel();
            return View(model);
        }
        #endregion

        #region 简介

        
        public ActionResult EditDescriptionInfo(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            Models.Sanatorium sanatorium = db.Sanatoriums.Find(id);
            if (sanatorium == null)
            {
                return RedirectToAction("Index");
            }

            var model = new DescriptionViewModel();
            model.Id = sanatorium.Id;
            model.Description = sanatorium.Description;
            model.ShiGongScope = sanatorium.ShiGongScope;
            model.ShiGongContent = sanatorium.ShiGongContent;

            SetMyAccountViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditDescriptionInfo(DescriptionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Models.Sanatorium sanatorium = db.Sanatoriums.Find(model.Id);
                if (sanatorium == null)
                {
                    return RedirectToAction("Index");
                }

                sanatorium.ShiGongScope = model.ShiGongScope;
                sanatorium.ShiGongContent = model.ShiGongContent;
                sanatorium.Description = model.Description;

                db.Entry(sanatorium).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                ModelState.AddModelError("", "操作成功");
                TempData["ModelState"] = ModelState;
                return RedirectToAction("EditZhiDuInfo", new { id = model.Id });
            }
            SetMyAccountViewModel();
            return View(model);
        }
        #endregion

        #region 小组


        public ActionResult EditXiaoZuInfo(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            Models.Sanatorium sanatorium = db.Sanatoriums.Find(id);
            if (sanatorium == null)
            {
                return RedirectToAction("Index");
            }

            var model = new XiaoZuViewModel();
            model.Id = sanatorium.Id;

            model.ZhiAnPrincipal = sanatorium.ZhiAnPrincipal;
            model.ZhiAnPrincipalPhone = sanatorium.ZhiAnPrincipalPhone;
            model.ZhiAnMembers = sanatorium.ZhiAnMembers;

            model.YingJiPrincipal = sanatorium.YingJiPrincipal;
            model.YingJiPrincipalPhone = sanatorium.YingJiPrincipalPhone;
            model.YingJiMembers = sanatorium.YingJiMembers;

            model.XiaoFangPrincipal = sanatorium.XiaoFangPrincipal;
            model.XiaoFangPrincipalPhone = sanatorium.XiaoFangPrincipalPhone;
            model.XiaoFangMembers = sanatorium.XiaoFangMembers;

            SetMyAccountViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditXiaoZuInfo(XiaoZuViewModel model)
        {
            if (ModelState.IsValid)
            {
                Models.Sanatorium sanatorium = db.Sanatoriums.Find(model.Id);
                if (sanatorium == null)
                {
                    return RedirectToAction("Index");
                }

                sanatorium.XiaoFangPrincipal = model.XiaoFangPrincipal;
                sanatorium.XiaoFangPrincipalPhone = model.XiaoFangPrincipalPhone;
                sanatorium.XiaoFangMembers = model.XiaoFangMembers;

                sanatorium.YingJiPrincipal = model.YingJiPrincipal;
                sanatorium.YingJiPrincipalPhone = model.YingJiPrincipalPhone;
                sanatorium.YingJiMembers = model.YingJiMembers;

                sanatorium.ZhiAnPrincipal = model.ZhiAnPrincipal;
                sanatorium.ZhiAnPrincipalPhone = model.ZhiAnPrincipalPhone;
                sanatorium.ZhiAnMembers = model.ZhiAnMembers;

                db.Entry(sanatorium).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                ModelState.AddModelError("", "操作成功");
                TempData["ModelState"] = ModelState;
                return RedirectToAction("Index");
            }
            SetMyAccountViewModel();
            return View(model);
        }
        #endregion


        public ActionResult Detail(int id)
        {
            Models.Sanatorium sanatorium = db.Sanatoriums.Find(id);
            if (sanatorium == null)
            {
                return new HttpNotFoundResult();
            }
            SetMyAccountViewModel();
            return View(sanatorium);
        }

        public ActionResult Del(int id)
        {
            Sanatorium.Models.Sanatorium sanatorium = db.Sanatoriums.Find(id);
            if (sanatorium == null)
            {
                return RedirectToAction("Index");
            }
           
            db.Sanatoriums.Remove(sanatorium);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}