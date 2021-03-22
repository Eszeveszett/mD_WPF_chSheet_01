using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mD_WPF_chSheet_01.Models.dzeta
{
    public partial class Charisms
    {
        public Charisms()
        {
            Races = new HashSet<Races>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string AppearanceDescription { get; set; }
        public int? AppearanceMin { get; set; }
        public int? AppearanceMax { get; set; }
        public string InfluenceDescription { get; set; }
        public int? InfluenceMin { get; set; }
        public int? InfluenceMax { get; set; }
        public string LuckDescription { get; set; }
        public int? LuckMin { get; set; }
        public int? LuckMax { get; set; }

        public virtual ICollection<Races> Races { get; set; }
    }
}
