using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mD_WPF_chSheet_01.Models.dzeta
{
    public partial class Characters
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RaceId { get; set; }
        public int? Vitality { get; set; }
        public int? Strength { get; set; }
        public int? Endurance { get; set; }
        public int? Toughtness { get; set; }
        public int? Dexterity { get; set; }
        public int? Agility { get; set; }
        public int? Perception { get; set; }
        public int? Quickness { get; set; }
        public int? Intuition { get; set; }
        public int? Intelligence { get; set; }
        public int? Wisdom { get; set; }
        public int? Resourcefull { get; set; }
        public int? Charisma { get; set; }
        public int? Appearance { get; set; }
        public int? Influence { get; set; }
        public int? Luck { get; set; }
        public int? SkillId { get; set; }

        public Races Race { get; set; }

        [NotMapped]
        private string _Gender;
        [NotMapped]
        public string Gender
        {

            get
            {
                if (RaceId % 2 == 1)
                {
                    return "Female";
                }
                else
                {
                    return "Male";
                }
            }
            set
            {
                if (RaceId % 2 == 1)
                {
                    _Gender = "Female";
                }
                else
                {
                    _Gender = "Male";
                }

            }
        }

        public Characters()
        {

        }
    }
}
