using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mD_WPF_chSheet_01.objects.characterObject
{
    public class attributionBonus
    {
        public int attributumValue { get; set; }
        public int activeBonus { get; set; }
        public int passiveBonus { get; set; }

        public attributionBonus(int attributumValue, int activeBonus, int passiveBonus)
        {
            this.attributumValue = attributumValue;
            this.activeBonus = activeBonus;
            this.passiveBonus = passiveBonus;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", attributumValue, activeBonus, passiveBonus);
        }
    }
}
