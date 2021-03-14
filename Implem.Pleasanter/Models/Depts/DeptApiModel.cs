﻿using Implem.Pleasanter.Models.Shared;
using System;
namespace Implem.Pleasanter.Models
{
    [Serializable]
    public class DeptApiModel : _BaseApiModel
    {
        public int? TenantId { get; set; }
        public int? DeptId { get; set; }
        public int? Ver { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string Body { get; set; }
        public bool? Disabled { get; set; }
        public string Comments { get; set; }
        public int? Creator { get; set; }
        public int? Updator { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }

        public DeptApiModel()
        {
        }
    }
}
