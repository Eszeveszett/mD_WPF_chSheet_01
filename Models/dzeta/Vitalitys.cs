using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mD_WPF_chSheet_01.Models.dzeta
{
    public partial class Vitalitys
    {
        public Vitalitys()
        {
            Races = new HashSet<Races>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string StrengthDescription { get; set; }
        public int? StrengthMin { get; set; }
        public int? StrengthMax { get; set; }
        public string EnduranceDescription { get; set; }
        public int? EnduranceMin { get; set; }
        public int? EnduranceMax { get; set; }
        public string ToughtnessDescription { get; set; }
        public int? ToughtnessMin { get; set; }
        public int? ToughtnessMax { get; set; }

        public virtual ICollection<Races> Races { get; set; }

    }
}
