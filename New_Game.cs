using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warhammer_Fantasy_Battles_Card_Game
{
    public partial class New_Game : Form
    {
        ArrayList CardCollection = new ArrayList();
        ArrayList ListboxCardCollection = new ArrayList();
        public static ArrayList PlayerDeck = new ArrayList();
        public static ArrayList AIDeck;
        List<string> Factions = new List<string>();
        List<string> ID_Collection = new List<string>();
        Random rnd = new Random();
        string address = "";
        int count = 0, manualCost = 0;

        public New_Game()
        {
            InitializeComponent();
        }

        private void New_Game_Load(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            button4.Enabled = false;
            textBox1.Enabled = false;
            textBox1.WordWrap = true;
            textBox1.ScrollBars = ScrollBars.Vertical;

            Factions.Add("Empire");
            Factions.Add("Greenskins");
            Factions.Add("High Elves");

            for (int i = 0; i < Factions.Count; i++)
            {
                comboBox1.Items.Add(Factions[i]);
            }

            #region Unit Card Create

            #region Empire Unit Roster
            CreateCard("Greatswords", GenerateID(),"Empire","Melee", "Small","Human","Physical","Anti-Small",150,14,8,6,3,12,4,0,0,0,0,0,false);
            CreateCard("Crossbowmen", GenerateID(), "Empire", "Range", "Small", "Human", "Missile","Not",60,6,3,3,2,6,0,8,3,1,7,0,false);
            CreateCard("Empire Knights", GenerateID(), "Empire", "Cavalry", "Large", "Human", "Physical","Not", 100, 8, 8, 4, 4, 8, 1,0,0,0,0,6,false);
            CreateCard("Buff Wizard", GenerateID(), "Empire", "Buff Caster", "Small", "Human", "Physical","Not", 150, 12, 3, 4, 3, 5, 1, 0, 0, 0, 0, 0,true);
            CreateCard("Spearman", GenerateID(), "Empire", "Melee", "Small", "Human","Physical","Anti-Large",40,8,3,3,5,6,0,0,0,0,0,0,false);
            CreateCard("Spearman(Shield)", GenerateID(), "Empire","Melee","Small","Human","Physical","Anti-Large",60, 8, 3, 4, 6, 6, 1,0,0,0,0,0,false);
            CreateCard("Swordsman", GenerateID(), "Empire","Melee","Small","Human","Physical","Not",50,8,3,5,2,6,1,0,0,0,0,0,false);
            CreateCard("Warrior Priest", GenerateID(), "Empire","Melee","Small","Human","Magic","Not",150,12,6,5,5,10,2,0,0,0,0,0,true);
            CreateCard("Witch Hunter", GenerateID(), "Empire", "Range", "Small", "Human", "Magic","Not",200,12,3,5,5,10,1,12,4,4,7,0,true);
            CreateCard("Halberdiers", GenerateID(), "Empire", "Melee", "Small", "Human", "Physical","Anti-Large",80,8,3,4,7,7,2,0,0,0,0,0,false);
            CreateCard("Flagellants", GenerateID(), "Empire", "Melee", "Small", "Human", "Physical","Not",70,12,0,8,2,8,1,0,0,0,0,0,false);
            CreateCard("Handgunners", GenerateID(), "Empire", "Range", "Small", "Human", "Missile","Not", 100,10,2,2,2,5,0,14,4,4,8,0,false);
            CreateCard("Free Company Militia", GenerateID(), "Empire", "Range", "Small", "Human", "Missile","Not", 60,8,3,5,4,6,1,8,3,1,7,0,false);
            CreateCard("Demigryph Knights", GenerateID(), "Empire", "Cavalry", "Large", "Human", "Physical","Not", 200, 12, 8, 6, 4, 14, 4, 0, 0, 0, 0, 8, false);
            CreateCard("Demigryph Knights(Halberds)", GenerateID(), "Empire", "Cavalry", "Large", "Human", "Physical","Anti-Large",200,12,8,5,4,12,3,0,0,0,0,4,false);
            CreateCard("Reiksguard", GenerateID(), "Empire", "Cavalry", "Large", "Human", "Physical","Anti-Small",150,8,8,5,4,10,2,0,0,0,0,8,false);
            CreateCard("Knights of the Blazing Sun", GenerateID(), "Empire", "Cavalry", "Large", "Human", "Magic","Not",150,8,8,4,4,10,2,0,0,0,0,7,false);
            CreateCard("Outriders", GenerateID(), "Empire", "Range", "Large", "Human", "Missile","Not", 80, 6, 3, 3, 3, 5, 0, 8, 4, 3, 7, 0, false);
            CreateCard("Outriders (Grenade Launcher)", GenerateID(), "Empire", "Range", "Large", "Human", "Missile","Not", 120, 6, 3, 3, 3, 5, 0, 12, 4, 5, 7, 0, false);
            CreateCard("Pistoliers", GenerateID(), "Empire", "Range", "Large", "Human", "Missile","Not", 60,6,3,2,2,4,0,6,4,1,8,0,false);
            CreateCard("Steam Tank", GenerateID(), "Empire","Range","Large","Machine", "Missile","Not", 350,24,10,6,2,12,2,15,3,4,7,0,false);
            #endregion

            #region Greenskins Unit Roster
            CreateCard("Goblins", GenerateID(), "Greenskins", "Melee", "Small", "Goblin", "Physical","Anti-Large", 30, 6, 3, 3, 3, 4, 0,0,0,0,0,0,false);
            CreateCard("Goblin Archers", GenerateID(), "Greenskins", "Range", "Small", "Goblin", "Missile","Not", 30, 6, 3, 2, 2, 4, 0,6,3,1,7,0, false);
            CreateCard("Nasty Skulkers", GenerateID(), "Greenskins", "Melee", "Small", "Goblin", "Physical","Not", 50, 6, 3, 5, 2, 6, 2,0,0,0,0,0, false);
            CreateCard("Night Goblin Squig Hoppers", GenerateID(), "Greenskins", "Cavalry", "Large", "Goblin", "Physical","Anti-Small", 80, 8, 4, 5, 2, 8, 2,0,0,0,0,4, false);
            CreateCard("Orc Shaman", GenerateID(), "Greenskins", "Buff Caster", "Small", "Orc", "Physical","Not", 150, 8, 3, 4, 2, 6, 1, 0, 0, 0, 0, 0,true);
            CreateCard("Orc Boyz", GenerateID(), "Greenskins", "Melee", "Small","Orc","Physical","Not",50,8,3,6,2,8,1,0,0,0,0,0,false);
            CreateCard("Orc Big 'Uns", GenerateID(), "Greenskins","Melee","Small", "Orc", "Physical","Anti-Large",80,8,6,7,2,10,2,0,0,0,0,0,false);
            CreateCard("Orc Arred Boyz", GenerateID(), "Greenskins", "Range", "Small", "Orc", "Missile","Not", 60, 7, 3, 5, 2, 6, 0, 6, 4, 2, 6, 0, false);
            CreateCard("Black Orcs",GenerateID(), "Greenskins", "Melee", "Small", "Orc", "Physical","Anti-Small",150,14,8,8,2,15,4,0,0,0,0,0,false);
            CreateCard("Savage Orcs", GenerateID(), "Greenskins", "Melee", "Small", "Orc", "Physical","Not",70,8,0,7,2,10,1,0,0,0,0,0,false);
            CreateCard("Squig Herd", GenerateID(), "Greenskins", "Cavalry", "Large", "Monster", "Physical","Not",80,10,3,6,2,10,1,0,0,0,0,4,false);
            CreateCard("Trolls", GenerateID(), "Greenskins", "Melee", "Large", "Monster", "Physical","Not", 150, 10, 2, 7, 2, 10, 2, 0, 0, 0, 0, 0, false);
            CreateCard("Savage Orc Boar Boyz", GenerateID(), "Greenskins", "Cavalry", "Large", "Orc", "Physical","Not",100,12,0,8,2,12,2,0,0,0,0,4,false);
            CreateCard("Savage Orc Boar Boy Big 'Uns", GenerateID(), "Greenskins", "Cavalry", "Large", "Orc", "Physical","Anti-Large", 150, 14, 0, 8, 2, 14, 3, 0, 0, 0, 0, 5, false);
            CreateCard("Savage Orc Big 'Uns", GenerateID(), "Greenskins", "Melee", "Small", "Orc", "Physical","Anti-Large", 90, 10, 0, 8, 2, 12, 2, 0, 0, 0, 0, 0, false);
            CreateCard("Savage Orc Arrer Boyz", GenerateID(), "Greenskins", "Range", "Small", "Orc", "Missile","Not", 70, 8,0, 5, 2, 7, 0, 7, 3, 1, 6, 0, false);
            CreateCard("Orc Boar Chariot", GenerateID(), "Greenskins", "Cavalry", "Large", "Orc", "Physical","Anti-Small",140,10, 5, 6, 4, 10,2,0,0,0,0,6,false);
            CreateCard("Orc Boar Boyz", GenerateID(), "Greenskins", "Cavalry", "Large", "Orc", "Physical","Not", 90, 10,5, 7, 3, 12, 1, 0, 0, 0, 0, 5, false);
            CreateCard("Orc Boar Boy Big 'Uns", GenerateID(), "Greenskins", "Cavalry", "Large", "Orc", "Physical","Anti-Large", 130,12,6,8,3,12,2,0,0,0,0,6,false);
            CreateCard("Night Goblins", GenerateID(), "Greenskins", "Melee", "Small", "Goblin", "Physical","Not", 40,6,3,6,2,7,1,0,0,0,0,0,false);
            CreateCard("Night Goblin Archers", GenerateID(), "Greenskins", "Range", "Goblin", "Goblin", "Missile","Not", 40,6,3,3,3,5,0,6,3,1,6,0,false);
            CreateCard("Goblin Wolf Riders", GenerateID(), "Greenskins", "Cavalry", "Large", "Goblin", "Physical","Not",60,7,3,4,2,6,1,0,0,0,0,4,false);
            CreateCard("Goblin Wolf Rider Archers", GenerateID(), "Greenskins", "Range", "Large", "Goblin", "Missile","Not", 60,6,3,3,2,4,0,6,3,1,6,0,false);
            CreateCard("Goblin Wolf Chariot", GenerateID(), "Greenskins", "Cavalry", "Large", "Goblin", "Physical","Not",70,8,4,6,2,7,1,0,0,0,0,4,false);
            CreateCard("Giant", GenerateID(), "Greenskins", "Melee", "Large", "Monster", "Physical","Not",180,20,2,7,2,12,2,0,0,0,0,0,false);
            CreateCard("Forest Goblin Spider Riders", GenerateID(), "Greenskins", "Cavalry", "Large", "Goblin", "Physical","Not",60,6,2,5,2,7,1,0,0,0,0,4,false);
            CreateCard("Forest Goblin Spider Rider Archers", GenerateID(), "Greenskins", "Range", "Large", "Goblin", "Missile","Not", 50,6,2,2,2,4,0,5,3,1,6,0,false);
            CreateCard("Arachnarok Spider", GenerateID(), "Greenskins", "Melee", "Large", "Monster", "Physical","Not",200,25,8,8,2,14,3,0,0,0,0,0,false);
            #endregion

            #region High Elves Unit Roster
            CreateCard("Spearmen", GenerateID(),"High Elves","Melee","Small","High Elf", "Physical","Anti-Large",50,10,4, 2, 4,6,0,0,0,0,0,0,false);
            CreateCard("Archers", GenerateID(), "High Elves", "Range", "Small", "High Elf", "Missile","Not", 50, 6, 2, 2, 3, 5, 0,7,4,1,7,0, false);
            CreateCard("Archers(Armour)", GenerateID(), "High Elves", "Range", "Small", "High Elf", "Missile","Not", 60, 6, 4, 2, 3, 5, 0, 7, 4, 1, 7, 0, false);
            CreateCard("Silver Helms", GenerateID(), "High Elves", "Cavalry", "Large", "High Elf", "Physical","Not", 100, 10, 4, 4, 4, 7, 1,0,0,0,0,6, false);
            CreateCard("Silver Helms(Shields)", GenerateID(), "High Elves", "Cavalry", "Large", "High Elf", "Physical","Not", 110, 10, 4, 4, 6, 7, 1, 0, 0, 0, 0, 6, false);
            CreateCard("Support Mage", GenerateID(), "High Elves", "Support Caster", "Small", "High Elf", "Magic","Not", 150,8, 3, 3, 4, 5, 1, 0, 0, 0, 0, 0,true);
            CreateCard("White Lions of Chrace", GenerateID(), "High Elves", "Melee", "Small", "High Elf", "Physical","Anti-Small",80,8,6,6,4,8,2,0,0,0,0,0,false);
            CreateCard("Swordmasters of Hoeth", GenerateID(), "High Elves", "Melee", "Small", "High Elf", "Physical","Anti-Small", 150,12, 8, 8, 5, 14, 4, 0, 0, 0, 0, 0, false);
            CreateCard("Phoenix Guard", GenerateID(), "High Elves", "Melee", "Small", "High Elf", "Physical","Anti-Large", 160,12, 8, 7, 7, 8, 3, 0, 0, 0, 0, 0, false);
            CreateCard("Lothern Sea Guard", GenerateID(), "High Elves", "Range", "Small", "High Elf", "Missile", "Anti-Large", 80, 8, 3, 5, 3, 6, 1, 9, 4, 1, 8, 0, false);
            CreateCard("Lothern Sea Guard(Shields)", GenerateID(), "High Elves", "Range", "Small", "High Elf", "Missile", "Anti-Large", 90, 8, 3, 5, 5, 6, 1, 9, 4, 1, 8, 0, false);
            CreateCard("Gate Guard", GenerateID(), "High Elves", "Range", "Small", "High Elf", "Missile", "Anti-Large", 90, 10, 2, 4, 5, 6, 1, 10, 5, 1, 9, 0, false);
            CreateCard("Dragon Princes", GenerateID(), "High Elves", "Cavalry", "Large", "High Elf", "Physical","Anti-Small", 150, 14, 8, 6, 4, 12, 2, 0, 0, 0, 0, 9, false);
            CreateCard("Ellyrian Reavers", GenerateID(), "High Elves", "Cavalry", "Large", "High Elf", "Physical","Not", 60, 8, 2, 4, 3, 5, 0, 0, 0, 0, 0, 5, false);
            CreateCard("Ellyrian Reaver Archers", GenerateID(), "High Elves", "Range", "Large", "High Elf", "Missile","Not", 60, 8, 2, 2, 3, 5, 0, 5, 4, 1, 7, 0, false);
            CreateCard("Tiranoc Chariot", GenerateID(), "High Elves", "Range", "Large", "High Elf", "Missile","Not", 120, 12, 4, 3, 5, 5, 1, 7, 4, 2, 7, 0, false);
            CreateCard("Ithilmar Chariot", GenerateID(), "High Elves", "Cavalry", "Large", "High Elf", "Physical","Not", 120, 12, 4, 5, 4, 7, 1, 0, 0, 0, 0, 5, false);
            CreateCard("Great Eagle", GenerateID(), "High Elves", "Melee", "Large", "Monster", "Physical","Not", 130, 10, 3, 6, 4, 8, 2, 0, 0, 0, 0, 0, false);
            CreateCard("Flamespyre Phoenix", GenerateID(), "High Elves", "Melee", "Large", "Monster", "Physical","Not", 140, 12, 4, 6, 4, 8, 2, 0, 0, 0, 0, 0, false);
            CreateCard("Frostheart Phoenix", GenerateID(), "High Elves", "Melee", "Large", "Monster", "Physical","Not",150, 14, 4, 7, 4, 10, 2, 0, 0, 0, 0, 0, false);
            CreateCard("Sun Dragon", GenerateID(), "High Elves", "Melee", "Large", "Monster", "Magic","Not", 220, 20, 4, 8, 4, 12, 2, 0, 0, 0, 0, 0, false);
            CreateCard("Moon Dragon", GenerateID(), "High Elves", "Melee", "Large", "Monster", "Magic","Not", 250, 22, 6, 8, 4, 14, 2, 0, 0, 0, 0, 0, false);
            CreateCard("Star Dragon", GenerateID(), "High Elves", "Melee", "Large", "Monster", "Magic","Not", 300, 30, 8, 9, 5, 16, 4, 0, 0, 0, 0, 0, false);
            #endregion

            #endregion

            pBHP.Maximum = 30;
            pBArmour.Maximum = 10;
            pBMA.Maximum = 10;
            pBMD.Maximum = 10;
            pbWS.Maximum = 20;
            pBMissileD.Maximum = 15;
            pBAmmo.Maximum = 5;
            pBCharge.Maximum = 10;

            panel5.Hide(); panel6.Hide();
        }

        private void CreateCard(string name, string id, string faction, string unitType, string entity, string race,string damageType,string bonus,int cost, int hp, int armour, int ma, int md, int ws, int MeleeAP,int missileDamage,int ammunition,int MissileAP,int accuracy,int charge,bool hasPower)
        {
            Unit unit = new Unit();
            unit.Name = name;
            unit.ID = GenerateID();
            unit.Faction = faction;
            unit.UnitType = unitType;
            unit.Entity = entity;
            unit.Race = race;
            unit.Cost = cost;
            unit.HP = hp;
            unit.CurrentHP = hp;
            unit.Armour = armour;
            unit.MeleeAttack = ma;
            unit.MeleeDefence = md;
            unit.WeaponStrength = ws;
            unit.MeleeArmorPiercingDamage = MeleeAP;
            unit.DamageType = damageType;
            unit.MissileDamage = missileDamage;
            unit.Ammunition = ammunition;
            unit.missileArmorPiercingDamage = MissileAP;
            unit.Accuracy = accuracy;
            unit.ChargeBonus = charge;
            unit.power = hasPower;
            unit.Bonus = bonus;
            CardCollection.Add(unit);
        }

        private string GenerateID()
        {
            bool var = false;
            string id;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            do
            {
                id = "";
                var = false;
                id += alphabet[rnd.Next(0,26)];
                id += alphabet[rnd.Next(0, 26)];
                for (int i = 0; i < 4; i++)
                {
                    id += (rnd.Next(0, 10)).ToString();
                }
                id += alphabet[rnd.Next(0, 26)];
                id += alphabet[rnd.Next(0, 26)];

                for (int j = 0; j < ID_Collection.Count; j++)
                {
                    if (id == ID_Collection[j])
                        var = true;
                }
            } while (var);

            ID_Collection.Add(id);
            return id;
        }

        private ArrayList DeckGenerate(string faction)
        {
            ArrayList randomDeck = new ArrayList();
            ArrayList StillGotThese = new ArrayList();
            ArrayList factionCards = new ArrayList();
            Unit unit, unit2;
            int value = 0, length = CardCollection.Count;
            count = 0;

            for (int k = 0; k < length; k++)
            {
                Unit kr = (Unit)CardCollection[k];
                if (kr.Faction == faction)
                {
                    factionCards.Add(kr);
                }
            }
            length = factionCards.Count;

            for (int cost = 0; cost <= 1000;)
            {
                unit = new Unit();
                unit2 = (Unit)factionCards[rnd.Next(0,length)];
                unit.Name = unit2.Name;
                unit.ID = GenerateID();
                unit.Faction = faction;
                unit.UnitType = unit2.UnitType;
                unit.Entity = unit2.Entity;
                unit.Race = unit2.Race;
                unit.Cost = unit2.Cost;
                unit.HP = unit2.HP;
                unit.CurrentHP = unit2.HP;
                unit.Armour = unit2.Armour;
                unit.MeleeAttack = unit2.MeleeAttack;
                unit.MeleeDefence = unit2.MeleeDefence;
                unit.WeaponStrength = unit2.WeaponStrength;
                unit.MeleeArmorPiercingDamage = unit2.MeleeArmorPiercingDamage;
                unit.Accuracy = unit2.Accuracy;
                unit.Ammunition = unit2.Ammunition;
                unit.MissileDamage = unit2.MissileDamage;
                unit.missileArmorPiercingDamage = unit2.missileArmorPiercingDamage;
                unit.ChargeBonus = unit2.ChargeBonus;
                unit.power = unit2.power;
                unit.DamageType = unit2.DamageType;
                unit.Bonus = unit2.Bonus;

                cost += unit.Cost;
                if (cost >= 1000)
                {
                    value = 1000 - count;
                    StillGotThese.Clear();
                    for (int i = 0; i < factionCards.Count; i++)
                    {
                        unit = (Unit)factionCards[i];
                        if (unit.Cost <= value)
                        {
                            StillGotThese.Add(unit);
                            value -= unit.Cost;
                            if (value <= 0)
                                break;
                        }
                    }

                    for (int j = 0; j < StillGotThese.Count; j++)
                    {
                        unit = (Unit)StillGotThese[j];
                        randomDeck.Add(unit);
                        count += unit.Cost;
                    }
                }
                else
                {
                    count = cost;
                    randomDeck.Add(unit);
                }
            }
            return randomDeck;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();

            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel4.Show(); panel1.Show();
            listBox1.Items.Clear(); listBox2.Items.Clear();
            ListboxCardCollection.Clear();
            clean();

            button3.Enabled = true;
            button4.Enabled = true;

            for (int i = 0; i < CardCollection.Count; i++)
            {
                Unit unit = (Unit)CardCollection[i];
                if (unit.Faction == comboBox1.Items[comboBox1.SelectedIndex].ToString())
                {
                    listBox1.DisplayMember = "Name";
                    listBox1.ValueMember = "ID";
                    listBox1.Items.Add(unit);
                    ListboxCardCollection.Add(unit);
                }
            }

            string faction = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            
            if (faction == "Empire")
            {
                address = "Images\\Empire Unit Roster\\Empire.png";
                pictureBox2.Image = Image.FromFile(address);
                textBox1.Text = "The Empire is the largest human nation in the Old World.They are a proud country built on steel, gunpowder and faith in their patron god Sigmar.Their army combines Spearmen, Knights and Cannons with fantasy elements such as Battle Wizards, Steam Tanks and Griffons.";
                textBox1.Text += "Last Bastion of Hope: You gain 1 point when enemy cannot hit your creature.Gain melee attack and base hit chance by spending all points for your next melee attack.";
            }
            else if (faction == "Greenskins")
            {
                address = "Images\\Greenskins Unit Roster\\Greenskins.png";
                pictureBox2.Image = Image.FromFile(address);
                textBox1.Text = "Greenskins is the collective term for Orcs, Goblins and other similar races.\nThese unruly warriors dwell in the Badlands, mountains \nand other wild areas and love nothing more than a good fight.From time to time, they will come together in a great Waaagh!";
                textBox1.Text += "an invasion of civilised lands. Armies of Greenskins feature masses of poorly-disciplined infantry,alongside boar-riding cavalry and monsters like trolls and giant spiders.";
                textBox1.Text += "Waaaagh! : Each succsesfull hit grants +1 waagh point. There are 3 levels of waagh.Level up by gaining 2 points.";
                textBox1.Text += "When a waagh! is activated waagh lvl goes to 0. Lvl 1 waagh grants 2 Orc Boyz, lvl 2 grants 1 orc boyz Big 'Uns,lvl 3 grants 1 black orc";
            }
            else if (faction == "High Elves")
            {
                address = "Images\\High Elves Unit Roster\\Lothern.png";
                pictureBox2.Image = Image.FromFile(address);
                textBox1.Text = "The High Elves are an ancient, proud race who dwell on the island continent of Ulthuan, once home to all Elves.The High Elf military consists of small numbers of highly-discplined elite troops which march to war alongside powerful spellcasters, dragons and phoenixes.High Elves are also masters of diplomacy and trade, able to manipulate other factions to suit themselves.";
                textBox1.Text += "Martial Prowess: All high elf units(above %50 of HP) gains +2 melee defence";
            }

            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.BackColor = Color.Gainsboro;

            label8.Text = comboBox1.Items[comboBox1.SelectedIndex].ToString();

            DoColor(faction);
        }

        private void DoColor(string faction)
        {
            Color clr = Color.Red;

            if (faction == "Empire")
                clr = Color.Red;
            else if (faction == "Greenskins")
                clr = Color.Green;
            else if (faction == "High Elves")
                clr = Color.LightBlue;

            panel1.BackColor = clr;
            panel2.BackColor = clr;
            panel4.BackColor = clr;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PlayerDeck = DeckGenerate(comboBox1.Items[comboBox1.SelectedIndex].ToString());
            listBox2.Items.Clear();
            Unit unit;
            for (int i = 0; i < PlayerDeck.Count; i++)
            {
                unit = (Unit)PlayerDeck[i];
                listBox2.DisplayMember = "Name";
                listBox2.ValueMember = "ID";
                listBox2.Items.Add(unit);
            }
            label4.Text = "Total Cost:" + count;
            btnPlay.Enabled = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            AIDeck = DeckGenerate(Factions[rnd.Next(0, Factions.Count)]);
            Arena arn = new Arena();
            this.Hide();
            arn.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clean();
            show((Unit)listBox1.SelectedItem);
        }

        private void clean()
        {
            pictureBox1.Image = null;
            pBHP.Value = 0;
            pBArmour.Value = 0;
            pBMA.Value = 0;
            pBMD.Value = 0;
            pbWS.Value = 0;
            pBMissileD.Value = 0;
            pBAmmo.Value = 0;
            pBCharge.Value = 0;

            lblName.Text = "Name";
            lblCost.Text = "Cost";
            lblEntity.Text = "Entity";
            lblHP.Text = "HP";
            lblArmor.Text = "Armour";
            lblma.Text = "Melee Attack";
            lblmd.Text = "Melee Defence";
            lblws.Text = "Weapon Strength";
            lblap.Text = "Armor Piercing:";
            lblAmmo.Text = "Ammunition";
            lblMissileD.Text = "Missile Damage";
            lblMissileAP.Text = "Armor Piercing";
            lblCharge.Text = "Charge Bonus";
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            clean();
            show((Unit)listBox2.SelectedItem);
        }

        private void show(Unit selected)
        {
            panel2.Show();
            address = "Images\\" + selected.Faction + " Unit Roster\\" + selected.Name + ".png";
            pictureBox1.Image = Image.FromFile(address);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.BackColor = Color.White;

            pBHP.Value = selected.HP;
            pBArmour.Value = selected.Armour;
            pBMA.Value = selected.MeleeAttack;
            pBMD.Value = selected.MeleeDefence;
            pbWS.Value = selected.WeaponStrength;
            lblHP.Text = "HP " + selected.HP;
            lblArmor.Text = "Armour " + selected.Armour;
            lblma.Text = "Melee Attack " + selected.MeleeAttack;
            lblmd.Text = "Melee Defence " + selected.MeleeDefence;
            lblws.Text = "Weapon Strength " + selected.WeaponStrength;
            lblap.Text = "Armor Piercing: " + selected.MeleeArmorPiercingDamage;
            lblEntity.Text = selected.Entity + " Entity";
            lblType.Text = selected.UnitType + " Specialist";
            lblName.Text = selected.Name;
            lblCost.Text = "Cost " + selected.Cost;

            if (selected.Bonus == "Anti-Large")
                lblBonus.Text = "AL";
            else if (selected.Bonus == "Anti-Small")
                lblBonus.Text = "AS";
            else
                lblBonus.Text = "";

            if(selected.UnitType == "Melee")
            {
                panel5.Hide(); panel6.Hide();
            }
            else if(selected.UnitType == "Range")
            {
                panel5.Show(); panel6.Hide();
                lblAmmo.Text = "Ammunition " + selected.Ammunition.ToString();
                pBAmmo.Value = selected.Ammunition;
                lblMissileD.Text = "Missile Damage " + selected.MissileDamage.ToString();
                pBMissileD.Value = selected.MissileDamage;
                lblMissileAP.Text = "Armor Piercing:" + selected.missileArmorPiercingDamage.ToString();
            }
            else if(selected.UnitType == "Cavalry")
            {
                panel5.Hide(); panel6.Show();
                lblCharge.Text = "Charge Bonus " + selected.ChargeBonus.ToString();
                pBCharge.Value = selected.ChargeBonus;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Unit pickedUnit = (Unit)listBox1.SelectedItem;
            manualCost += pickedUnit.Cost;
            if (manualCost >1000)
            {
                manualCost -= pickedUnit.Cost;
                MessageBox.Show("Your deck has been reach its limit","ALERT");
            }
            else
            {
                Unit unit = new Unit();
                unit.Name = pickedUnit.Name;
                unit.ID = GenerateID();
                unit.Faction = pickedUnit.Faction;
                unit.UnitType = pickedUnit.UnitType;
                unit.Entity = pickedUnit.Entity;
                unit.Race = pickedUnit.Race;
                unit.Cost = pickedUnit.Cost;
                unit.HP = pickedUnit.HP;
                unit.CurrentHP = pickedUnit.HP;
                unit.Armour = pickedUnit.Armour;
                unit.MeleeAttack = pickedUnit.MeleeAttack;
                unit.MeleeDefence = pickedUnit.MeleeDefence;
                unit.WeaponStrength = pickedUnit.WeaponStrength;
                unit.MeleeArmorPiercingDamage = pickedUnit.MeleeArmorPiercingDamage;
                unit.Accuracy = pickedUnit.Accuracy;
                unit.Ammunition = pickedUnit.Ammunition;
                unit.MissileDamage = pickedUnit.MissileDamage;
                unit.missileArmorPiercingDamage = pickedUnit.missileArmorPiercingDamage;
                unit.ChargeBonus = pickedUnit.ChargeBonus;


                listBox2.DisplayMember = "Name";
                listBox2.ValueMember = "ID";
                listBox2.Items.Add(unit);
                PlayerDeck.Add(unit);
                label4.Text = "Total Cost:" + manualCost;
                btnPlay.Enabled = true;
            }
        }
    }
}
