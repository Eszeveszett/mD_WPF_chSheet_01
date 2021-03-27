using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

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
        public string Pictures { get; set; }

        public virtual Charisms Charisma { get; set; }
        public virtual Dexteritys Dexterity { get; set; }
        public virtual Intuitions Intuition { get; set; }
        public virtual Vitalitys Vitality { get; set; }

        [NotMapped]
        public bool letezik { get; set; }
        [NotMapped]
        private string _picture;
        [NotMapped]
        public string picture
        {
            get {
                //if (letezik)
                //{
                    //return string.Format("img\\ad.jpg", Pictures.ToLower());
                    //return string.Format("..\\..\\images\\chIcon\\{0}.jpg", Id);
                //}
                //else
                //{
                //    return string.Format("..\\..\\images\\chIcon\\{0}.jpg", Id);
                //}
                return string.Format("..\\..\\images\\chIcon\\{0}.jpg", Pictures);
            }
        }

        public Races()
        {

        }
    }
}
