using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warhammer_Fantasy_Battles_Card_Game
{
    class Unit
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Faction { get; set; }
        public string UnitType { get; set; }
        public string Entity { get; set; }
        public string Race { get; set; }
        public string DamageType { get; set; }
        public string Bonus { get; set; }
        public int Cost { get; set; }
        public int HP { get; set; }
        public int CurrentHP { get; set; }
        public int Armour { get; set; }
        public int MeleeAttack { get; set; }
        public int MeleeDefence { get; set; }
        public int WeaponStrength { get; set; }  
        public int MeleeArmorPiercingDamage { get; set; }
        public int vigor { get; set; }
        public int MissileDamage { get; set; }
        public int Ammunition { get; set; }
        public int missileArmorPiercingDamage { get; set; }
        public int Accuracy { get; set; }
        public int ChargeBonus { get; set; }
        public bool power { get; set; }

        public Resist Resistence { get; set; }
        public LoreofBuff Buff { get; set; }
        public LoreofSupport Support { get; set; }
        public LoreofDamage Damage { get; set; }

        public Unit()
        {
            vigor = 4;
        }
    }

    class Resist
    {
        public int MissileResist { get; set; }
        public int MagicResist { get; set; }
        public int PyhsicalResist { get; set; }
    }

    class LoreofBuff
    {
        public int buff(int howMuch)
        {
            return howMuch;
        }
    }

    class LoreofSupport
    {
        public void heal(Unit unit, int howMuch)
        {
            unit.CurrentHP += howMuch;
        }
    }

    class LoreofDamage
    {
        public void damage(Unit unit, int howMuch)
        {
            unit.CurrentHP -= howMuch;
        }
    }
}
