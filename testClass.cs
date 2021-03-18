using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mD_WPF_chSheet_01
{
    public class testClass
    {

        private string _race;

        public string race
        {
            get { return _race; }
            set { _race = value; }
        }
        private int _age;

        public int age
        {
            get { return _age; }
            set { _age = value; }
        }

        //public string two { get; set; }
        //public string three { get; set; }
        //public string flour { get; set; }

        public testClass(string race, int age)
        {
            this.race = race;
            this.age = age;
        }
    }
}
