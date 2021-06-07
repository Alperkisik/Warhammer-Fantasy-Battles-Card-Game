using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warhammer_Fantasy_Battles_Card_Game
{
    public partial class Arena : Form
    {
        ArrayList PlayerDeck = new ArrayList();
        ArrayList AIDeck = new ArrayList();
        List<string> AIevents = new List<string>();
        List<string> buffs = new List<string>();
        Random rnd = new Random();
        Unit player, AI;
        ProgressBar pb1,pb2,empirePB1,empirePB2;
        Label waaghlvl1, waaghlvl2,empireValue1,empireValue2;
        Button BTNwaagh,BTNempire;
        int turnCount = 0;
        int empirebuff1 = 0, empirebuff2 = 0;
        string turn = "";
        string PlayersFaction = "",AIsFaction = "";
        int PlayerMDbuff = 0,AImdBuff = 0;
        string address = "";

        public Arena()
        {
            InitializeComponent();
        }

        private void Arena_Load(object sender, EventArgs e)
        {
            buffs.Add("Melee Attack +4"); buffs.Add("Melee Defence +4"); buffs.Add("Melee AP +2"); buffs.Add("Armour +4");
            AIevents.Add("Attack"); AIevents.Add("Defence"); AIevents.Add("Attack"); AIevents.Add("Defence"); AIevents.Add("Attack");
            AIevents.Add("Attack"); AIevents.Add("Defence"); AIevents.Add("Attack"); AIevents.Add("Defence"); AIevents.Add("Attack");
            AIevents.Add("Attack"); AIevents.Add("Defence"); AIevents.Add("Attack"); AIevents.Add("Attack"); AIevents.Add("Attack");
            AIevents.Add("Attack"); AIevents.Add("Defence"); AIevents.Add("Attack"); AIevents.Add("Defence"); AIevents.Add("Attack");
            AIevents.Add("Attack"); AIevents.Add("Attack"); AIevents.Add("Attack"); AIevents.Add("Attack"); AIevents.Add("Attack");
            PlayerDeck = New_Game.PlayerDeck;
            AIDeck = New_Game.AIDeck;

            Unit faction1, faction2;
            faction1 = (Unit)PlayerDeck[0];
            faction2 = (Unit)AIDeck[0];
            PlayersFaction = faction1.Faction;
            AIsFaction = faction2.Faction;
            if (PlayersFaction == "Empire")
            {
                label11.Text = "Empire";
                address = "Images\\Empire Unit Roster\\Empire.png";
                pictureBox1.Image = Image.FromFile(address);

                empireValue1 = new Label();
                empireValue1.Text = "Blessings of Sigmar 0";
                empireValue1.Width = 120;
                empireValue1.Location = new Point(0,10);

                empirePB1 = new ProgressBar();
                empirePB1.Width = 100;
                empirePB1.Maximum = 5;
                empirePB1.Value = 0;
                empirePB1.Location = new Point(130,10);

                BTNempire = new Button();
                BTNempire.Width = 70;
                BTNempire.Height = 30;
                BTNempire.BackColor = Color.White;
                BTNempire.TextAlign = ContentAlignment.MiddleCenter;
                BTNempire.Text = "BUFF";
                BTNempire.Click += new EventHandler(btnEmpireBuff);
                BTNempire.Enabled = false;
                BTNempire.Location = new Point(240,10);

                panel12.Controls.Add(empireValue1); panel12.Controls.Add(empirePB1); panel12.Controls.Add(BTNempire);
            }
            else if (PlayersFaction == "Greenskins")
            {
                label11.Text = "Greenskins";
                address = "Images\\Greenskins Unit Roster\\Greenskins.png";
                pictureBox1.Image = Image.FromFile(address);

                waaghlvl1 = new Label();
                waaghlvl1.Text = "Waaagh! LVL 0";
                waaghlvl1.Width = 100;
                waaghlvl1.Location = new Point(0,10);

                pb1 = new ProgressBar();
                pb1.Width = 100;
                pb1.Maximum = 6;
                pb1.Value = 0;
                pb1.Location = new Point(110,10);

                BTNwaagh = new Button();
                BTNwaagh.Width = 70;
                BTNwaagh.Height = 30;
                BTNwaagh.BackColor = Color.White;
                BTNwaagh.TextAlign = ContentAlignment.MiddleCenter;
                BTNwaagh.Text = "Waagh!";
                BTNwaagh.Click += new EventHandler(btnWaaagh_click);
                BTNwaagh.Enabled = false;
                BTNwaagh.Location = new Point(220,10);

                panel12.Controls.Add(waaghlvl1); panel12.Controls.Add(pb1); panel12.Controls.Add(BTNwaagh);
            }
            else if (PlayersFaction == "High Elves")
            {
                label11.Text = "High Elves";
                address = "Images\\High Elves Unit Roster\\Lothern.png";
                pictureBox1.Image = Image.FromFile(address);
                Label lbl = new Label();
                lbl.Width = 400;
                lbl.Text = "Units (above %50 HP) gains +2 Melee Defence";
                panel12.Controls.Add(lbl);
            }
            pictureBox1.BackColor = Color.White;

            if (AIsFaction == "Empire")
            {
                label12.Text = "Empire";
                address = "Images\\Empire Unit Roster\\Empire.png";
                pictureBox2.Image = Image.FromFile(address);

                empireValue2 = new Label();
                empireValue2.Text = "Blessings of Sigmar 0";
                empireValue2.Width = 120;
                empireValue2.Location = new Point(0, 10);

                empirePB2 = new ProgressBar();
                empirePB2.Width = 100;
                empirePB2.Maximum = 5;
                empirePB2.Value = 0;
                empirePB2.Location = new Point(130, 10);

                panelFaction1.Controls.Add(empireValue2); panelFaction1.Controls.Add(empirePB2);
            }
            else if (AIsFaction == "Greenskins")
            {
                label12.Text = "Greenskins";
                address = "Images\\Greenskins Unit Roster\\Greenskins.png";
                pictureBox2.Image = Image.FromFile(address);
                waaghlvl2 = new Label();
                waaghlvl2.Text = "Waaagh! LVL 0";
                waaghlvl2.Width = 100;
                waaghlvl2.Location = new Point(0, 0);

                pb2 = new ProgressBar();
                pb2.Width = 100;
                pb2.Maximum = 6;
                pb2.Value = 0;
                pb2.Location = new Point(110, 0);

                panelFaction1.Controls.Add(waaghlvl2); panelFaction1.Controls.Add(pb2);

                AIevents.Add("Waaagh"); AIevents.Add("Waaagh"); AIevents.Add("Waaagh"); AIevents.Add("Waaagh"); AIevents.Add("Waaagh");
                AIevents.Add("Waaagh"); AIevents.Add("Waaagh"); AIevents.Add("Waaagh"); AIevents.Add("Waaagh"); AIevents.Add("Waaagh");
            }
            else if (AIsFaction == "High Elves")
            {
                label12.Text = "High Elves";
                address = "Images\\High Elves Unit Roster\\Lothern.png";
                pictureBox2.Image = Image.FromFile(address);
                Label lbl = new Label();
                lbl.Width = 400;
                lbl.Text = "Units (above %50 HP) gains +2 Melee Defence";
                panelFaction1.Controls.Add(lbl);
            }
            pictureBox2.BackColor = Color.White;

            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            pickUnit("ai");
            btnATK1.Enabled = false; btnDEF1.Enabled = false; btnPWR1.Enabled = false;
            

            FillListboxes();
            color();
        }

        private void btnEmpireBuff(object sender, System.EventArgs e)
        {
            empirebuff1 = empirePB1.Value;
            empirePB1.Value = 0;
            empireValue1.Text = "Blessings of Sigmar 0";
            BTNempire.Enabled = false;
        }

        private void btnWaaagh_click(object sender, System.EventArgs e)
        {
            string message = "";
            if(pb1.Value >= 2 && pb1.Value < 4)
            {
                CreateCard("Orc Boyz", "Greenskins", "Melee", "Small", "Orc", "Physical", "Not", 50, 8, 3, 6, 2, 8, 1, 0, 0, 0, 0, 0, false,"player");
                CreateCard("Orc Boyz", "Greenskins", "Melee", "Small", "Orc", "Physical", "Not", 50, 8, 3, 6, 2, 8, 1, 0, 0, 0, 0, 0, false,"player");
                BTNwaagh.Enabled = false;
                message = "2 Orc Boyz joined our forces!";
            }
            else if(pb1.Value >= 4 && pb1.Value < 6)
            {
                CreateCard("Orc Big 'Uns", "Greenskins", "Melee", "Small", "Orc", "Physical", "Anti-Large", 80, 8, 6, 7, 2, 10, 2, 0, 0, 0, 0, 0, false,"player");
                message = "An Orc Big 'Uns joined our forces!";
            }
            else if(pb1.Value == 6)
            {
                CreateCard("Black Orcs", "Greenskins", "Melee", "Small", "Orc", "Physical", "Anti-Small", 150, 14, 8, 8, 2, 15, 4, 0, 0, 0, 0, 0, false,"player");
                message = "A Black Orcs joined our forces!";
            }
            MessageBox.Show("WAAAAAAGH! " + message,"ALERT");
            waaghlvl1.Text = "Waaagh! LVL 0";
            pb1.Value = 0;
            FillListboxes();
        }

        private void btnPICK1_Click(object sender, EventArgs e)
        {
            try
            {
                pickUnit("player");
                if(turnCount == 0)
                {
                    int t = 0;
                    if (t == 0)
                        turn = "player";
                    else if (t == 1)
                        turn = "ai";

                    turnCheck();
                }
                else
                    turnCheck();

                panel3.Show();
            }
            catch
            {
                MessageBox.Show("PICK AN UNIT FROM YOUR DECK", "ALERT");
            }

            btnPICK1.Enabled = false;
        }

        private void pickUnit(string side)
        {
            if (side == "player")
            {
                player = (Unit)lbPlayer.SelectedItem;
                fillCard("player");
                address = "Images\\" + player.Faction + " Unit Roster\\" + player.Name + ".png";
                pictureBox3.Image = Image.FromFile(address);
                pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                label8.Text = player.Name;
                btnATK1.Enabled = true; btnDEF1.Enabled = true;

                if(player.power)
                    btnPWR1.Enabled = true;
                else
                    btnPWR1.Enabled = false;

                if (player.UnitType == "Cavalry")
                    Charge(player,AI,"player");

                string type = player.UnitType;
                if (type == "Buff Caster")
                {
                    LoreofBuff buffs = new LoreofBuff();
                    player.Buff = buffs;
                }
                else if (type == "Damage Caster")
                {
                    LoreofDamage dmg = new LoreofDamage();
                    player.Damage = dmg;
                }
                else if (type == "Support caster")
                {
                    LoreofSupport support = new LoreofSupport();
                    player.Support = support;
                }
            }
            else if (side == "ai")
            {
                AI = (Unit)AIDeck[rnd.Next(0,AIDeck.Count)];
                fillCard("ai");
                address = "Images\\" + AI.Faction + " Unit Roster\\" + AI.Name + ".png";
                pictureBox4.Image = Image.FromFile(address);
                pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                label9.Text = AI.Name;

                if(turnCount > 1)
                    if (AI.UnitType == "Cavalry")
                        Charge(AI, player,"ai");
            }
        }

        private void fillCard(string side)
        {
            if (side == "player")
            {
                lbStats1.Items.Clear();
                label15.Text = player.UnitType + " Unit";

                lbStats1.Items.Add("Bonus " + player.Bonus);
                lbStats1.Items.Add("DAMAGE TYPE " + player.DamageType);
                if (player.UnitType == "Cavalry")
                {
                    lbStats1.Items.Add("------Cavalry Stats------");
                    lbStats1.Items.Add("Charge Bonus " + player.ChargeBonus.ToString());
                }
                else if(player.UnitType == "Range")
                {
                    lbStats1.Items.Add("------Range Stats------");
                    lbStats1.Items.Add("Ammunition " + player.Ammunition.ToString());
                    lbStats1.Items.Add("Missile Damage " + player.MissileDamage.ToString());
                    lbStats1.Items.Add("Missile AP " + player.missileArmorPiercingDamage.ToString());
                }
                lbStats1.Items.Add("------Melee Stats------");
                lbStats1.Items.Add("Armor " + player.Armour.ToString());
                lbStats1.Items.Add("Melee Attack " + player.MeleeAttack.ToString());
                lbStats1.Items.Add("Melee Defence " + player.MeleeDefence.ToString());
                lbStats1.Items.Add("Weapon Strength " + player.WeaponStrength.ToString());
                lbStats1.Items.Add("Melee AP " + player.MeleeArmorPiercingDamage.ToString()); 
                lbStats1.Items.Add("ID=" + player.ID);

                lblHP1.Text = "HP " + player.CurrentHP.ToString();
                progressBar1.Maximum = player.HP;
                progressBar1.Value = player.CurrentHP;

                if (player.Entity == "Small")
                    lblEntity1.Text = "S";
                else if (player.Entity == "Large")
                    lblEntity1.Text = "L";

            }
            else if (side == "ai")
            {
                lbStats2.Items.Clear();
                label14.Text = AI.UnitType + " Unit";

                lbStats2.Items.Add("Bonus " + AI.Bonus);
                lbStats2.Items.Add("DAMAGE TYPE " + AI.DamageType.ToString());
                if (AI.UnitType == "Cavalry")
                {
                    lbStats2.Items.Add("------Cavalry Stats------");
                    lbStats2.Items.Add("Charge Bonus " + AI.ChargeBonus.ToString());
                }
                else if (AI.UnitType == "Range")
                {
                    lbStats2.Items.Add("------Range Stats------");
                    lbStats2.Items.Add("Ammunition " + AI.Ammunition.ToString());
                    lbStats2.Items.Add("Missile Damage " + AI.MissileDamage.ToString());
                    lbStats2.Items.Add("Missile AP " + AI.missileArmorPiercingDamage.ToString());
                }

                lbStats2.Items.Add("------Melee Stats------");
                lbStats2.Items.Add("Armor=" + AI.Armour.ToString());
                lbStats2.Items.Add("Melee Attack=" + AI.MeleeAttack.ToString());
                lbStats2.Items.Add("Melee Defence=" + AI.MeleeDefence.ToString());
                lbStats2.Items.Add("Weapon Strength=" + AI.WeaponStrength.ToString());
                lbStats2.Items.Add("Melee Armor Piercing=" + AI.MeleeArmorPiercingDamage.ToString());
                lbStats2.Items.Add("ID=" + AI.ID);
                lblHP2.Text = "HP " + AI.CurrentHP.ToString();
                progressBar2.Maximum = AI.HP;
                progressBar2.Value = AI.CurrentHP;

                if (AI.Entity == "Small")
                    lblEntity2.Text = "S";
                else if (AI.Entity == "Large")
                    lblEntity2.Text = "L";
            }
        }

        private void color()
        {
            Color color1 = Color.Red, color2 = Color.LightBlue;
            Unit prototype1, prototype2;
            prototype1 = (Unit)PlayerDeck[0];
            prototype2 = (Unit)AIDeck[0];
            string faction = "";

            faction = prototype1.Faction;
            if (faction == "Empire")
                color1 = Color.Red;
            else if(faction == "Greenskins")
                color1 = Color.Green;
            else if (faction == "High Elves")
                color1 = Color.LightBlue;

            faction = prototype2.Faction;
            if (faction == "Empire")
                color2 = Color.Red;
            else if (faction == "Greenskins")
                color2 = Color.Green;
            else if (faction == "High Elves")
                color2 = Color.LightBlue;

            panel1.BackColor = color1;
            panel3.BackColor = color1;
            panel6.BackColor = color1;
            panel7.BackColor = color1;
            panel10.BackColor = color1;
            panel12.BackColor = color1;

            panel4.BackColor = color2;
            panel5.BackColor = color2;
            panel11.BackColor = color2;
            panel8.BackColor = color2;
            panel9.BackColor = color2;
            panelFaction1.BackColor = color2;

        }

        private void turnCheck()
        {
            resetBuffs();

            if (turn == "player")
            {
                labelTurn.Text = "PLAYER'S TURN";
                if (player != null)
                {
                    btnATK1.Enabled = true; btnDEF1.Enabled = true; btnPWR1.Enabled = false; btnPICK1.Enabled = true;
                }
                else if(player == null)
                {
                    btnATK1.Enabled = false; btnDEF1.Enabled = false; btnPWR1.Enabled = false; btnPICK1.Enabled = true;
                }
            }
            else if(turn == "ai")
            {

                labelTurn.Text = "AI'S TURN";

                btnATK1.Enabled = false; btnDEF1.Enabled = false; btnPWR1.Enabled = false; btnPICK1.Enabled = false;
            }
            turnCount++;
            lblTurnCount.Text = "TURN " + turnCount.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDEF1_Click(object sender, EventArgs e)
        {
            lblReportAI.Text = "";
            PlayerMDbuff = 2;
            lblReportPlayer.Text = "Until the next turn Melee defence +" + PlayerMDbuff.ToString();
           
            turn = "ai"; turnCheck();
            aiTurn();
        }

        private void resetBuffs()
        {
            if(turn == "player")
            {
                PlayerMDbuff = 0;
                //label7.Text = "";
            }
            else if(turn == "ai")
            {
                AImdBuff = 0;
                label5.Text = "";
            }
        }

        private void FillListboxes()
        {
            lbPlayer.Items.Clear();
            lbAI.Items.Clear();
            Unit unit;
            for (int i = 0; i < PlayerDeck.Count; i++)
            {
                unit = (Unit)PlayerDeck[i];
                lbPlayer.DisplayMember = "Name";
                lbPlayer.ValueMember = "ID";
                lbPlayer.Items.Add(unit);
            }
            for (int j = 0; j < AIDeck.Count; j++)
            {
                unit = (Unit)AIDeck[j];
                lbAI.DisplayMember = "Name";
                lbAI.ValueMember = "ID";
                lbAI.Items.Add(unit);
            }
        }

        private void btnATK1_Click(object sender, EventArgs e)
        {
            lblReportAI.Text = "";
            lblReportPlayer.Text = "";
            if(player.UnitType =="Melee")
            {
                meleeAttack(player,AI,"player");
            }
            else if(player.UnitType == "Range")
            {
                RangeAttack(player,AI,"player");
                fillCard("player");
            }
            else
            {
                meleeAttack(player, AI, "player");
            }

            check();
            if(player != null)
            {
                turn = "ai"; turnCheck();
                aiTurn();
            }
            else
            {
                btnATK1.Enabled = false; btnDEF1.Enabled = false; btnPWR1.Enabled = false; btnPICK1.Enabled = true;
            }
        }

        private void meleeAttack(Unit attacker,Unit defender,string side)
        {
            int baseHitChance = 3, damage = 0,buff = 0,bonusDamage = 0;
            int result, result1, hitchance, hitDice, result2 = 0;
            bool hit = false;
            
            if(side == "player")
            {
                buff = AImdBuff;
            }
            else if(side == "ai")
            {
                buff = PlayerMDbuff;
            }

            if(defender.Faction == "High Elves")
            {
                if((defender.HP/2) >= defender.CurrentHP)
                    buff += 2;
            }

            if (attacker.Bonus.ToLower() == "anti-large" && defender.Entity.ToLower() == "large")
            {
                bonusDamage = attacker.WeaponStrength / 4;
                baseHitChance += 2;
            }
            else if (attacker.Bonus.ToLower() == "anti-small" && defender.Entity.ToLower() == "small")
            {
                bonusDamage = attacker.WeaponStrength / 4;
                baseHitChance += 2;
            }   
            else if(attacker.Bonus.ToLower() == "not")
            {
                bonusDamage = 0;
                baseHitChance = 3;
            }

            if (attacker.Faction == "Empire" && side == "player")
            {
                damage += empirebuff1;
                baseHitChance += empirebuff1;
            }
            else if(attacker.Faction == "Empire" && side == "ai")
            {
                damage += empirebuff2;
                baseHitChance += empirebuff2;
            }

            result = rnd.Next((defender.MeleeDefence + buff / 2), defender.MeleeDefence + buff);
            result1 = attacker.MeleeAttack - result;
            if (result1 < 0)
                result1 = 0;

            hitchance = baseHitChance + (result1);
            hitDice = rnd.Next(0, 10);
            if (hitDice < hitchance)
                hit = true;
            else
                hit = false;

            if (hit)
            {

                if(player.DamageType == "Physical")
                {
                    result2 = rnd.Next((defender.Armour / 2), defender.Armour);
                    damage += attacker.MeleeArmorPiercingDamage + (attacker.WeaponStrength - result2);
                    if (damage <= 0)
                        damage = attacker.MeleeArmorPiercingDamage;

                    damage += bonusDamage;
                }
                else if(player.DamageType == "Magic")
                {
                    int minDamage = attacker.WeaponStrength / 4;
                    result2 = rnd.Next((defender.Armour / 2), defender.Armour);
                    damage += attacker.MeleeArmorPiercingDamage + minDamage + (attacker.WeaponStrength - result2);

                    if (damage <= 0)
                        damage = attacker.MeleeArmorPiercingDamage + minDamage;

                    damage += bonusDamage;
                }
                else
                {
                    result2 = rnd.Next((defender.Armour / 2), defender.Armour);
                    damage += attacker.MeleeArmorPiercingDamage + (attacker.WeaponStrength - result2);
                    if (damage <= 0)
                        damage = attacker.MeleeArmorPiercingDamage;

                    damage += bonusDamage;
                }
                

                if(side == "player")
                {
                    lblReportPlayer.Text += "\nDealing " + damage + " damage according to this formula:\nHit Chance=" + baseHitChance + "+" + attacker.MeleeAttack + "-" + result + ",\ndamage=" + attacker.MeleeArmorPiercingDamage
                         + "+((WS)" + attacker.WeaponStrength + "- (A)" + result2 + ") + (BD)" + bonusDamage;
                    lblReportPlayer.Text += "\n" + attacker.Name + " deal " + damage + " damage to " + defender.Name + "\nwith %" + hitchance * 10 + " Hit Chance\nHit Dice=" + hitDice;

                    if(PlayersFaction == "Greenskins")
                    {
                        if(pb1.Value < pb1.Maximum)
                        {
                            pb1.Value += 1;
                            if (pb1.Value >= 2)
                            {
                                BTNwaagh.Enabled = true;
                                if(pb1.Value == 2)
                                    waaghlvl1.Text = "Waaagh! LVL 1";
                                else if (pb1.Value == 4)
                                    waaghlvl1.Text = "Waaagh! LVL 2";
                                else if(pb1.Value == 6)
                                    waaghlvl1.Text = "Waaagh! LVL 3";
                            }
                        }
                    }
                       
                }
                else if(side == "ai")
                {
                    lblReportAI.Text += "Dealing " + damage + " damage according to this formula:\nHit Chance=" + baseHitChance + "+" + attacker.MeleeAttack + "-" + result + ",\ndamage=" + attacker.MeleeArmorPiercingDamage
                         + "+((WS)" + attacker.WeaponStrength + "- (A)" + result2 + ") + (BD)" + bonusDamage;
                    lblReportAI.Text += "\n" + attacker.Name + " deal " + damage + " damage to " + defender.Name + "\nwith %" + hitchance * 10 + " Hit Chance\nHit Dice=" + hitDice;

                    if(AIsFaction == "Greenskins")
                    {
                        pb2.Value += 1;
                        if(pb2.Value == 2)
                            waaghlvl2.Text = "Waaagh! LVL 1";
                        else if (pb2.Value == 4)
                            waaghlvl2.Text = "Waaagh! LVL 2";
                        else if (pb2.Value == 6)
                            waaghlvl2.Text = "Waaagh! LVL 3";
                    }
                       
                }
            }
            else
            {
                if (side == "player")
                {
                    lblReportPlayer.Text = attacker.Name + " deal no damage to " + defender.Name + "\n with %" + hitchance * 10 + " Hit Chance,Hit Dice=" + hitDice;
                    if (AIsFaction == "Empire")
                    {
                        if(empirePB2.Value < empirePB2.Maximum)
                            empirePB2.Value++;
                        empireValue2.Text = "Blessings of Sigmar " + empirePB2.Value;
                    }
                        
                }
                else if (side == "ai")
                {
                    lblReportAI.Text = attacker.Name + " deal no damage to " + defender.Name + "\n with %" + hitchance * 10 + " Hit Chance,Hit Dice=" + hitDice;
                    if (PlayersFaction == "Empire")
                    {
                        if(empirePB1.Value < empirePB1.Maximum)
                            empirePB1.Value++;
                        empireValue1.Text = "Blessings of Sigmar " + empirePB1.Value;
                        if (empirePB1.Value > 0)
                            BTNempire.Enabled = true;
                    }
                }
            }
            
            defender.CurrentHP = defender.CurrentHP - damage;
            damage = 0; buff = 0; bonusDamage = 0; empirebuff1 = 0; empirebuff2 = 0;
        }

        private void RangeAttack(Unit attacker, Unit defender, string side)
        {
            if (attacker.Ammunition != 0)
            {
                attacker.Ammunition -= 1;
                int damage = 0, hitDice = 0;
                hitDice = rnd.Next(0, 11);
                if (hitDice < attacker.Accuracy)
                {
                    damage = attacker.missileArmorPiercingDamage + (attacker.MissileDamage - rnd.Next(defender.Armour / 2, defender.Armour));
                    defender.CurrentHP = defender.CurrentHP - damage;
                    if (side == "player")
                    {
                        lblReportPlayer.Text = attacker.Name + " shot " + defender.Name;
                        lblReportPlayer.Text += "\nDeal " + damage + " missile damage";
                        lblReportPlayer.Text += "\nCurrent ammunition " + attacker.Ammunition;
                    }
                    else if (side == "ai")
                    {
                        lblReportAI.Text = attacker.Name + " shot " + defender.Name;
                        lblReportAI.Text += "\nDeal " + damage + " missile damage";
                        lblReportAI.Text += "\nCurrent ammunition " + attacker.Ammunition;
                    }
                }
                else
                {
                    if (side == "player")
                    {
                        lblReportPlayer.Text = attacker.Name + " missed the shot";
                        lblReportPlayer.Text += "\nCurrent ammunition " + attacker.Ammunition;
                    }
                    else if (side == "ai")
                    {
                        lblReportAI.Text = attacker.Name + " missed the shot";
                        lblReportAI.Text += "\nCurrent ammunition " + attacker.Ammunition;
                    }
                }
            }
            else
            {
                meleeAttack(player,AI,side);
            }
        }

        private void Charge(Unit attacker, Unit defender, string side)
        {
            int damage = 0;
            if(defender.Bonus != "Anti-Large")
            {
                if (attacker.DamageType == "Physical")
                {
                    damage = attacker.MeleeArmorPiercingDamage +
                    (attacker.ChargeBonus + attacker.MeleeAttack) -
                    (rnd.Next((defender.Armour / 2), defender.Armour) + rnd.Next((defender.MeleeDefence / 2) + AImdBuff, defender.MeleeDefence) + AImdBuff);
                    if (damage <= 0)
                        damage = attacker.MeleeArmorPiercingDamage;
                }
                else if (attacker.DamageType == "Magic")
                {
                    int minDamage = attacker.WeaponStrength / 4;

                    damage = attacker.MeleeArmorPiercingDamage + minDamage +
                    (attacker.ChargeBonus + attacker.MeleeAttack) -
                    (rnd.Next((defender.Armour / 2), defender.Armour) + rnd.Next((defender.MeleeDefence / 2) + AImdBuff, defender.MeleeDefence) + AImdBuff);
                    if (damage <= 0)
                        damage = attacker.MeleeArmorPiercingDamage + minDamage;
                }

                if (side == "player")
                {
                    lblReportPlayer.Text += attacker.Name + " made a charge to " + defender.Name;
                    lblReportPlayer.Text += "\nDeal " + damage + " Damage";
                }
                else if (side == "ai")
                {
                    lblReportAI.Text += attacker.Name + " made a charge to " + defender.Name;
                    lblReportAI.Text += "\nDeal " + damage + " Damage";
                }
            }
            else
            {
                if (side == "player")
                {
                    lblReportPlayer.Text += attacker.Name + " has not managed to charge " + defender.Name;
                    lblReportPlayer.Text += "\nBecause " + defender.Name + " has charge defence"; 
                }
                else if (side == "ai")
                {
                    lblReportAI.Text += attacker.Name + " has not managed to charge " + defender.Name;
                    lblReportAI.Text += "\nBecause " + defender.Name + " has charge defence";
                }

            }
            defender.CurrentHP = defender.CurrentHP - damage;
            check();
        }

        private void rest_in_piece(Unit rip, string WhichDeck)
        {
            if (WhichDeck == "ai")
            {
                AIDeck.Remove(rip);
                lbGraveyard2.Items.Add("Name:"+rip.Name + " ID:"+rip.ID);
                AI = null;
                if (AIDeck.Count <= 0)
                {
                    player = null;
                    MessageBox.Show("Player won!", "WIN");
                    btnATK1.Enabled = false; btnDEF1.Enabled = false; btnPWR1.Enabled = false; btnPICK1.Enabled = false;
                }
                else
                {
                    pickUnit("ai");
                }  
            }
            else if (WhichDeck == "player")
            {
                PlayerDeck.Remove(rip);
                lbGraveyard1.Items.Add("Name:" + rip.Name + " ID:" + rip.ID);
                label8.Text = "RIP " + rip.Name.ToUpper(); lblEntity1.Text = "";
                label15.Text = ""; lblHP1.Text = "HP " + rip.CurrentHP; progressBar1.Value = 0;
                //lblReportPlayer.Text = "";
                lbStats1.Items.Clear();
                address = "Images\\rip.png";
                pictureBox3.Image = Image.FromFile(address);
                pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                player = null;
                if (PlayerDeck.Count <= 0)
                {
                    AI = null;
                    MessageBox.Show("Enemy won!", "WIN");
                    btnATK1.Enabled = false; btnDEF1.Enabled = false; btnPWR1.Enabled = false; btnPICK1.Enabled = false;
                }
                else
                {
                    lbStats1.Items.Clear();
                    
                    btnATK1.Enabled = false; btnDEF1.Enabled = false; btnPWR1.Enabled = false;
                }
            }
            FillListboxes();
        }

        private void btnPWR1_Click(object sender, EventArgs e)
        {
            string type = player.UnitType;
            if (type == "Buff Caster")
            {
                label7.Text += "-" + buffs[rnd.Next(0, buffs.Count)];
            }
            else if (type == "Damage Caster")
            {
                player.Damage.damage(AI, 5);
                lblReportPlayer.Text = player.Name + " deal 5 damage to " + AI.Name;
            }
            else if (type == "Support caster")
            {
                Unit unt;
                MessageBox.Show("Pick a unit from your deck to heal","TIP");
                try
                {
                     unt = (Unit)lbPlayer.SelectedItem;
                }
                catch
                {
                    bool found = false;
                    do
                    {
                        unt = (Unit)lbPlayer.Items[rnd.Next(0,lbPlayer.Items.Count)];
                        int value1 = unt.HP, value2 = unt.CurrentHP;

                        if (value2 < value1)
                        {
                            found = true;
                        }
                        else
                            found = false;

                    } while (!found);
                }

                player.Support.heal(unt,5);
            }

        }

        private void lbPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                Unit unt = (Unit)lbPlayer.SelectedItem;

                listBox1.Items.Add("ENTITY " + unt.Entity);
                listBox1.Items.Add("DAMAGE TYPE " + unt.DamageType);
                listBox1.Items.Add("Bonus " + unt.Bonus);
                if (unt.UnitType == "Cavalry")
                {
                    listBox1.Items.Add("------Cavalry Stats------");
                    listBox1.Items.Add("Charge Bonus " + unt.ChargeBonus.ToString());
                }
                else if (unt.UnitType == "Range")
                {
                    listBox1.Items.Add("------Range Stats------");
                    listBox1.Items.Add("Ammunition " + unt.Ammunition.ToString());
                    listBox1.Items.Add("Missile Damage " + unt.MissileDamage.ToString());
                    listBox1.Items.Add("Missile AP " + unt.missileArmorPiercingDamage.ToString());
                }
                listBox1.Items.Add("------Melee Stats------");
                listBox1.Items.Add("HP " + unt.CurrentHP.ToString());
                listBox1.Items.Add("Armour " + unt.Armour.ToString());
                listBox1.Items.Add("Melee Defence " + unt.MeleeDefence.ToString());
                listBox1.Items.Add("Melee Attack " + unt.MeleeAttack.ToString());
                listBox1.Items.Add("Melee AP " + unt.MeleeArmorPiercingDamage.ToString());
                listBox1.Items.Add("Weapon Strength " + unt.WeaponStrength.ToString());
                listBox1.Items.Add("ID " + unt.ID);
            }
            catch
            {

            }
        }

        private void lbAI_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                Unit unt = (Unit)lbAI.SelectedItem;

                listBox2.Items.Add("ENTITY " + unt.Entity);
                listBox2.Items.Add("BONUS " + unt.Bonus);
                listBox2.Items.Add("DAMAGE TYPE " + unt.DamageType);
                if (unt.UnitType == "Cavalry")
                {
                    listBox2.Items.Add("------Cavalry Stats------");
                    listBox2.Items.Add("Charge Bonus " + unt.ChargeBonus.ToString());
                }
                else if (unt.UnitType == "Range")
                {
                    listBox2.Items.Add("------Range Stats------");
                    listBox2.Items.Add("Ammunition " + unt.Ammunition.ToString());
                    listBox2.Items.Add("Missile Damage " + unt.MissileDamage.ToString());
                    listBox2.Items.Add("Missile AP " + unt.missileArmorPiercingDamage.ToString());
                }
                listBox2.Items.Add("------Melee Stats------");
                listBox2.Items.Add("HP " + unt.CurrentHP.ToString());
                listBox2.Items.Add("Armour " + unt.Armour.ToString());
                listBox2.Items.Add("Melee Defence " + unt.MeleeDefence.ToString());
                listBox2.Items.Add("Melee Attack " + unt.MeleeAttack.ToString());
                listBox2.Items.Add("Melee AP " + unt.MeleeArmorPiercingDamage.ToString());
                listBox2.Items.Add("Weapon Strength " + unt.WeaponStrength.ToString());
                listBox2.Items.Add("ID " + unt.ID);

            }
            catch
            {

            }
            
        }

        private void check()
        {
            try
            {
                if (player.CurrentHP <= 0)
                {
                    rest_in_piece(player, "player");
                    btnATK1.Enabled = false; btnDEF1.Enabled = false; btnPWR1.Enabled = false; btnPICK1.Enabled = true;
                }
                else
                {
                    progressBar1.Maximum = player.HP;
                    progressBar1.Value = player.CurrentHP;
                    lblHP1.Text = "HP " + player.CurrentHP;
                }

                if (AI.CurrentHP <= 0)
                {
                    rest_in_piece(AI, "ai");
                }
                else
                {
                    progressBar2.Maximum = AI.HP;
                    progressBar2.Value = AI.CurrentHP;
                    lblHP2.Text = "HP " + AI.CurrentHP;
                }
            }
            catch
            {

            }
            
        }

        private void aiTurn()
        {
            if(AI != null)
            {
                btnATK1.Enabled = false; btnDEF1.Enabled = false; btnPWR1.Enabled = false; btnPICK1.Enabled = false;
                Thread.Sleep(2000);
                int action = rnd.Next(0, AIevents.Count);
                string unitType = AI.UnitType;
                if (AIevents[action] == "Attack")
                {
                    if (unitType == "Melee")
                    {
                        if(AIsFaction == "Empire")
                        {
                            if(empirePB2.Value > 1)
                            {
                                if (rnd.Next(0,6) < empirePB2.Value)
                                {
                                    MessageBox.Show("Empire ai used his faction ability! (MA +"+empirePB2.Value.ToString()+" Base hit chance:"+ empirePB2.Value.ToString(), "ALERT");
                                    empirebuff2 = empirePB2.Value;
                                    empirePB2.Value = 0;
                                }
                            }
                        }
                        meleeAttack(AI, player, "ai");
                    }
                    else if (unitType == "Range")
                    {
                        RangeAttack(AI, player, "ai");
                        fillCard("ai");
                    }
                    else
                    {
                        meleeAttack(AI, player, "ai");
                    }
                }
                else if (AIevents[action] == "Defence")
                {
                    AImdBuff = 2;
                    lblReportAI.Text += "\nUntil the next turn Melee defence +" + AImdBuff.ToString();
                }
                else if (AIevents[action] == "Waaagh")
                {
                    if(pb2.Value >= 2)
                    {
                        string message = "";
                        if (pb2.Value >= 2 && pb2.Value < 4)
                        {
                            CreateCard("Orc Boyz", "Greenskins", "Melee", "Small", "Orc", "Physical", "Not", 50, 8, 3, 6, 2, 8, 1, 0, 0, 0, 0, 0, false, "ai");
                            CreateCard("Orc Boyz", "Greenskins", "Melee", "Small", "Orc", "Physical", "Not", 50, 8, 3, 6, 2, 8, 1, 0, 0, 0, 0, 0, false, "ai");
                            message = "2 Orc Boyz joined our enemies!";
                        }
                        else if (pb2.Value >= 4 && pb2.Value < 6)
                        {
                            CreateCard("Orc Big 'Uns", "Greenskins", "Melee", "Small", "Orc", "Physical", "Anti-Large", 80, 8, 6, 7, 2, 10, 2, 0, 0, 0, 0, 0, false, "player");
                            message = "An Orc Big 'Uns joined our enemies!";
                        }
                        else if (pb2.Value == 6)
                        {
                            CreateCard("Black Orcs", "Greenskins", "Melee", "Small", "Orc", "Physical", "Anti-Small", 150, 14, 8, 8, 2, 15, 4, 0, 0, 0, 0, 0, false, "player");
                            message = "A Black Orcs joined our enemies!";
                        }
                        MessageBox.Show("WAAAAAAGH! " + message, "ALERT");
                        waaghlvl2.Text = "Waaagh! LVL 0";
                        pb2.Value = 0;
                        FillListboxes();
                    }
                    else
                    {
                        meleeAttack(AI, player, "ai");
                    }
                }

                check();
                turn = "player"; turnCheck();
            }
            else
            {
                label9.Text = "RIP"; lblEntity2.Text = "";
                label14.Text = ""; lblHP2.Text = "HP"; progressBar2.Value = 0;
                BTNwaagh.Enabled = false;
                lbStats2.Items.Clear();
                address = "Images\\rip.png";
                pictureBox4.Image = Image.FromFile(address);
                pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                MessageBox.Show("GAME OVER!");
                btnATK1.Enabled = false; btnDEF1.Enabled = false; btnPWR1.Enabled = false; btnPICK1.Enabled = false;
            }
        }

        int creation = 1;
        private void CreateCard(string name, string faction, string unitType, string entity, string race, string damageType, string bonus, int cost, int hp, int armour, int ma, int md, int ws, int MeleeAP, int missileDamage, int ammunition, int MissileAP, int accuracy, int charge, bool hasPower,string Side)
        {
            Unit unit = new Unit();
            unit.Name = name;
            unit.ID = "Created Creature " + creation;
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
            
            if(Side == "player")
            {
                PlayerDeck.Add(unit);
            }
            else if(Side == "ai")
            {
                AIDeck.Add(unit);
            }

            creation++;
        }
    }
}
