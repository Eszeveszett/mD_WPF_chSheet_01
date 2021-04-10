using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mD_WPF_chSheet_01.Models.dzeta
{
    public partial class Skills
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public int SkillCost { get; set; }
        public string SkillClass { get; set; }

        public Skills()
        {

        }
        public Skills(int Id, string SkillName, int SkillCost, String SkillClass)
        {
            this.Id = Id;
            this.SkillName = SkillName;
            this.SkillCost = SkillCost;
            this.SkillClass = SkillClass;
        }
    }
}
