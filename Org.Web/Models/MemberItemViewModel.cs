using System;
using System.ComponentModel.DataAnnotations;
using Org.Entity;

namespace Org.Web.Models
{
    /// <summary>
    /// 此会员视图状态包含了简要的会员信息，适合于在列表和小卡片中使用
    /// </summary>
    public class MemberItemViewModel
    {
        public int Id { get; set; }

        [Display(Name="姓名"), Required]
        public string Name { get; set; }

        [Display(Name="性别")]
        public Gender Gender { get; set; }

        [Display(Name="出生日期")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString="{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "社会职务")]
        public string SocialPosition { get; set; }
        
        [Display(Name="工作单位")]
        public string WorkUnit { get; set; }

        [Display(Name = "职务")]
        public string WorkPost { get; set; }

        [Display(Name="身份证号"), Required]
        public string IdCardNumber { get; set; }
        
        [Display(Name="手机")]
        public string MobilePhone { get; set; }

        [Display(Name="电子邮箱"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name="发展中")]
        public bool IsCandidate { get; set; }

        [Display(Name="联系有效")]
        public bool IsActive { get; set; }

        public static implicit operator MemberItemViewModel(Member member)
            => new MemberItemViewModel{
                Id = member.Id,
                Name = member.Name,
                BirthDate = member.BirthDate,
                Email = member.Email,
                Gender = member.Gender,
                IdCardNumber = member.IdCardNumber,
                IsActive = member.IsActive,
                IsCandidate = member.IsCandidate,
                MobilePhone = member.MobilePhone,
                SocialPosition = member.SocialPosition,
                WorkPost = member.WorkPost,
                WorkUnit = member.WorkUnit,
            };
    }
}