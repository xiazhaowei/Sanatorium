using System;
using System.ComponentModel.DataAnnotations;

namespace Sanatorium.Models
{
    public class SanatoriumViewModel
    {
        public int Id { get; set; }

        [Display(Name = "名称")]
        [Required]
        public string Name { get; set; }
        

        public string Region { get; set; }

        public string Street { get; set; }

        public string Community { get; set; }

        [Display(Name = "地址")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "图片")]
        public string Pics { get; set; }

        [Display(Name = "实施单位")]
        public string ShiShiOrg { get; set; }

        [Display(Name = "施工单位")]
        public string ShiGongOrg { get; set; }

        [Display(Name = "预计完工时间")]
        public DateTime? PredictFinishTime { get; set; }

        [Display(Name = "建筑面积")]
        [Required]
        public Single StructureArea { get; set; }

        [Display(Name = "已完工面积")]
        [Required]
        public Single FinishArea { get; set; }

        [Display(Name = "在建面积")]
        [Required]
        public Single DoingArea { get; set; }

        [Display(Name = "即将开工面积")]
        [Required]
        public Single ToDoArea { get; set; }

        [Display(Name = "楼栋数")]
        [Required]
        public int BuildingsCount { get; set; }

        [Display(Name = "建成年代")]
        public string CompletionYear { get; set; }

        [Display(Name = "使用脚手架数量")]
        public int StagingCount { get; set; }
        

        [Display(Name = "开工日期")]
        public DateTime? StartTime { get; set; }

        [Display(Name = "竣工日期")]
        public DateTime? FinishTime { get; set; }



        [Display(Name = "施工单位")]
        public string BuildOrg { get; set; }

        [Display(Name = "施工单位负责人")]
        public string BuildOrgPrincipal { get; set; }

        [Display(Name = "施工单位负电话")]
        public string BuildOrgPhone { get; set; }

        [Display(Name = "施工单位网址")]
        public string BuildOrgWeb { get; set; }

        [Display(Name = "设计单位")]
        public string DesignOrg { get; set; }

        [Display(Name = "设计单位负责人")]
        public string DesignOrgPrincipal { get; set; }

        [Display(Name = "设计单位负电话")]
        public string DesignOrgPhone { get; set; }

        [Display(Name = "设计单位网址")]
        public string DesignOrgWeb { get; set; }

        [Display(Name = "监理单位")]
        public string SupervisionOrg { get; set; }

        [Display(Name = "监理单位负责人")]
        public string SupervisionOrgPrincipal { get; set; }

        [Display(Name = "监理单位负电话")]
        public string SupervisionOrgPhone { get; set; }

        [Display(Name = "监理单位网址")]
        public string SupervisionOrgWeb { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }

        [Display(Name = "农民工工资投诉电话")]
        public string GongZiPhone { get; set; }

        [Display(Name = "居民投诉电话")]
        public string JuMinPhone { get; set; }

        



    }

    public class ZhiDuViewModel
    {
        public int Id { get; set; }

        [Display(Name = "安全制度")]
        public string AnQuanZhiDu { get; set; }

        [Display(Name = "施工制度")]
        public string ShiGongZhidu { get; set; }

        [Display(Name = "消防制度")]
        public string XiaoFangZhidu { get; set; }
    }

    public class DescriptionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "简介")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "施工范围")]
        public string ShiGongScope { get; set; }

        [Display(Name = "施工内容")]
        public string ShiGongContent { get; set; }
    }

    public class XiaoZuViewModel
    {
        public int Id { get; set; }

        [Display(Name = "治安负责人")]
        public string ZhiAnPrincipal { get; set; }

        [Display(Name = "治安负责人电话")]
        public string ZhiAnPrincipalPhone { get; set; }

        [Display(Name = "治安小组成员 姓名-电话")]
        public string ZhiAnMembers { get; set; }

        [Display(Name = "消防负责人")]
        public string XiaoFangPrincipal { get; set; }

        [Display(Name = "消防负责人电话")]
        public string XiaoFangPrincipalPhone { get; set; }

        [Display(Name = "消防小组成员 姓名-电话")]
        public string XiaoFangMembers { get; set; }

        [Display(Name = "紧急负责人")]
        public string YingJiPrincipal { get; set; }

        [Display(Name = "紧急负责人电话")]
        public string YingJiPrincipalPhone { get; set; }

        [Display(Name = "紧急小组成员 姓名-电话")]
        public string YingJiMembers { get; set; }
    }
}