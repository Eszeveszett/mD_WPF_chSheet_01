using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mD_WPF_chSheet_01
{
    class primaryAttribution
    {
        private int _Vitality;

        public int Vitality
        {
            get { return _Vitality; }
            set { _Vitality = value; }
        }

        private int _Dexterity;

        public int Dexterity
        {
            get { return _Dexterity; }
            set { _Dexterity = value; }
        }

        private int _Intuition;

        public int Intuition
        {
            get { return _Intuition; }
            set { _Intuition = value; }
        }

        private int _Charisma;

        public int Charisma
        {
            get { return _Charisma; }
            set { _Charisma = value; }
        }

        public primaryAttribution(int Vitality, int Dexterity, int Intuition, int Charisma)
        {
            this.Vitality = Vitality;
            this.Dexterity = Dexterity;
            this.Intuition = Intuition;
            this.Charisma = Charisma;
        }
        public primaryAttribution()
        {

        }
    }
}
