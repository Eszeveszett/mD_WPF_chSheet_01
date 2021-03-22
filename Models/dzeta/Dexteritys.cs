using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mD_WPF_chSheet_01.Models.dzeta
{
    public partial class Dexteritys
    {
        public Dexteritys()
        {
            Races = new HashSet<Races>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string AgilityDescription { get; set; }
        public int? AgilityMin { get; set; }
        public int? AgilityMax { get; set; }
        public string PerceptionDescription { get; set; }
        public int? PerceptionMin { get; set; }
        public int? PerceptionMax { get; set; }
        public string QuicknessDescription { get; set; }
        public int? QuicknessMin { get; set; }
        public int? QuicknessMax { get; set; }

        public virtual ICollection<Races> Races { get; set; }
    }
}
