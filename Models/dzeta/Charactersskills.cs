using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mD_WPF_chSheet_01.Models.dzeta
{
    public partial class Charactersskills
    {
        public int? CharacterId { get; set; }
        public int? SkillId { get; set; }

        public virtual Characters Character { get; set; }
        public virtual Skills Skill { get; set; }

        public Charactersskills()
        {

        }
    }
}
