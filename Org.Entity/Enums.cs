using System.ComponentModel.DataAnnotations;

namespace Org.Entity
{
    public enum Gender
    {
        [Display(Name = "男")] Male,
        [Display(Name = "女")] Female
    }

    public enum MemberState
    {
        [Display(Name = "建立档案")] Record,
        [Display(Name = "背景调查")] Investigate,
        [Display(Name="初步推荐")]Recommend,
        [Display(Name="委员会讨论")]Discuss,
        [Display(Name="报送组织部")]Submit,
        [Display(Name="上级批复")]Approve,
        [Display(Name="组织关系调动")]Transfer,
        [Display(Name="会内职务变动")]Change,
        [Display(Name="个人情况跟踪")]Individual
    }
}