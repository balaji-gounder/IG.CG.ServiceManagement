using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Domain.Entities
{
    public class ApprovalLevelEntity : BaseEntity
    {
        public int ApprovalLevelId { get; set; }
        public string? BranchCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? Level1ApproverCode { get; set; }
        public string? Level2ApproverCode { get; set; }
        public string? Level3ApproverCode { get; set; }
    }

    public class ApprovalLevelDisplayEntity
    {
        public int ApprovalLevelId { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public string? DivisionCode { get; set; }
        public string? DivisionName { get; set; }
        public string? Level1Approver { get; set; }
        public string? Level1ApproverCode { get; set; }
        public string? Level2Approver { get; set; }
        public string? Level2ApproverCode { get; set; }
        public string? Level3Approver { get; set; }
        public string? Level3ApproverCode { get; set; }

    }

    public class ApprovalLevelUsersEntity
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }

    }

}
