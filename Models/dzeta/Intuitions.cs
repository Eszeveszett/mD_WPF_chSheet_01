using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mD_WPF_chSheet_01.Models.dzeta
{
    public partial class Intuitions
    {
        public Intuitions()
        {
            Races = new HashSet<Races>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string IntelligenceDescription { get; set; }
        public int IntelligenceMin { get; set; }
        public int IntelligenceMax { get; set; }
        public string WisdomDescription { get; set; }
        public int WisdomMin { get; set; }
        public int WisdomMax { get; set; }
        public string ResourcefullDescription { get; set; }
        public int ResourcefullMin { get; set; }
        public int ResourcefullMax { get; set; }

        public virtual ICollection<Races> Races { get; set; }
    }
}
