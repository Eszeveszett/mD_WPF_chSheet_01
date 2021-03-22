using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mD_WPF_chSheet_01.Models.dzeta
{
    public partial class Races
    {
        public int Id { get; set; }
        public string RaceName { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public int? VitalityId { get; set; }
        public int? DexterityId { get; set; }
        public int? IntuitionId { get; set; }
        public int? CharismaId { get; set; }

        public virtual Charisms Charisma { get; set; }
        public virtual Dexteritys Dexterity { get; set; }
        public virtual Intuitions Intuition { get; set; }
        public virtual Vitalitys Vitality { get; set; }

        public Races()
        {

        }
    }
}
