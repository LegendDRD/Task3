using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace GameDevAS
{
    [Serializable]
    public partial class Form1 : Form
    {
        int mapsizing =690;
        int Turn = 0;
        Random r = new Random();
        Map map = new Map(20, 20, 28,10);

        const int spacing = 20;
        const int Size = 20;
        Button t = new Button();
        public Form1()
       {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateMap();
            DisplayMap();
            textBox1.Text = (++Turn).ToString();

        }

        private void DisplayMap()
        {
            groupBox1.Controls.Clear();

            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(MeleeUnits))
                {
                    int start_x = 20;
                    int start_Y = 20;
                    start_x = groupBox1.Location.X;
                    start_Y = groupBox1.Location.Y;
                    MeleeUnits m = (MeleeUnits)u;
                    

                    t.Size = new Size(Size, Size);
                    t.Location = new Point(start_x + (m.Xpos * Size), start_Y + (m.Ypos * Size));
                    if (m.symbol == "=")
                    {

                        if (m.symbol == "=")
                        {
                            t.Text = "=";
                            t.ForeColor = Color.Blue;

                        }
                        else
                        {
                            t.Text = "=";
                            t.ForeColor = Color.Red;
                        }
                        if (m.isDead())
                        {
                            t.Text = "X";
                        }
                        groupBox1.Controls.Add(t);
                        t.Click += new EventHandler(Buttonunit_Click);

                    }
                    else
                    {
                        if (m.Fact ==1)
                        {
                            t.Text = ">";
                            t.ForeColor = Color.Blue;

                        }
                        else
                        {
                            t.Text = ">";
                            t.ForeColor = Color.Red;
                        }
                        if (m.isDead())
                        {
                            t.Text = "X";
                        }
                        groupBox1.Controls.Add(t);
                        t.Click += new EventHandler(Buttonunit_Click);
                    }
                    

                }



            }
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(RangedUnits))
                {
                    int start_x = 20;
                    int start_Y = 20;
                    start_x = groupBox1.Location.X;
                    start_Y = groupBox1.Location.Y;
                    RangedUnits r = (RangedUnits)u;
                    Button b = new Button();

                    b.Size = new Size(Size, Size);
                    b.Location = new Point(start_x + (r.Xpos * Size), start_Y + (r.Ypos * Size));
                   
                    if (r.symbol == "}")
                    {
                        

                        b.Size = new Size(Size, Size);
                        b.Location = new Point(start_x + (r.Xpos * Size), start_Y + (r.Ypos * Size));



                        if (r.Fact == 1)
                        {

                            b.Text = "}";
                            b.ForeColor = Color.Blue;

                        }
                        else
                        {

                            b.Text = "}";
                            b.ForeColor = Color.Red;
                        }
                        if (r.isDead())
                        {
                            b.Text = "X";
                        }
                        groupBox1.Controls.Add(b);
                        b.Click += new EventHandler(Buttonunit_Click);


                        if (r.Fact == 1)
                        {

                            b.Text = "}";
                            b.ForeColor = Color.Blue;

                        }
                        else
                        {

                            b.Text = "}";
                            b.ForeColor = Color.Red;
                        }
                        if (r.isDead())
                        {
                            b.Text = "X";
                        }
                        groupBox1.Controls.Add(b);
                        b.Click += new EventHandler(Buttonunit_Click);
                    }
                    else {

                        b.Size = new Size(Size, Size);
                        b.Location = new Point(start_x + (r.Xpos * Size), start_Y + (r.Ypos * Size));



                        if (r.Fact == 1)
                        {

                            b.Text = "->";
                            b.ForeColor = Color.Blue;

                        }
                        else
                        {

                            b.Text = "->";
                            b.ForeColor = Color.Red;
                        }
                        if (r.isDead())
                        {
                            b.Text = "X";
                        }
                        groupBox1.Controls.Add(b);
                        b.Click += new EventHandler(Buttonunit_Click);


                        if (r.Fact == 1)
                        {

                            b.Text = "->";
                            b.ForeColor = Color.Blue;

                        }
                        else
                        {

                            b.Text = "->";
                            b.ForeColor = Color.Red;
                        }
                        if (r.isDead())
                        {
                            b.Text = "X";
                        }
                        groupBox1.Controls.Add(b);
                        b.Click += new EventHandler(Buttonunit_Click);


                    }
                }

            }
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(Emperor))
                {
                    int start_x = 20;
                    int start_Y = 20;
                    start_x = groupBox1.Location.X;
                    start_Y = groupBox1.Location.Y;
                    Emperor emperor = (Emperor)u;
                    Button b = new Button();

                    b.Size = new Size(Size, Size);
                    b.Location = new Point(start_x + (emperor.Xpos * Size), start_Y + (emperor.Ypos * Size));



                    if (emperor.Fact == 1)
                    {

                        b.Text = "#";
                        b.ForeColor = Color.Blue;

                    }
                    else
                    {

                        b.Text = "#";
                        b.ForeColor = Color.Red;
                    }
                    if (emperor.isDead())
                    {
                        b.Text = "X";
                    }
                    groupBox1.Controls.Add(b);
                    b.Click += new EventHandler(Buttonunit_Click);
                }

            }
            foreach (Building b in map.Building)
            {
                if (b.GetType() == typeof(FactoryBuilding))
                {
                    int start_x = 20;
                    int start_Y = 20;
                    start_x = groupBox1.Location.X;
                    start_Y = groupBox1.Location.Y;
                    FactoryBuilding m = (FactoryBuilding)b;
                    Button a = new Button();

                    a.Size = new Size(Size, Size);
                    a.Location = new Point(start_x + (m.Xpos * Size), start_Y + (m.Ypos * Size));

                    if (m.Fact == 1)
                    {
                        a.Text = "F";
                        a.ForeColor = Color.Blue;

                    }
                    else
                    {
                        a.Text = "F";
                        a.ForeColor = Color.Red;
                    }
                    if (m.isDestoryed())
                    {
                        a.Text = "X";
                    }
                    groupBox1.Controls.Add(a);
                    a.Click += new EventHandler(Buttonunit_Click1);
                }

            }
            foreach (ResourceBuilding b in map.RB)
            {
                if (b.GetType() == typeof(ResourceBuilding))
                {
                    int start_x = 20;
                    int start_Y = 20;
                    start_x = groupBox1.Location.X;
                    start_Y = groupBox1.Location.Y;
                    ResourceBuilding m = (ResourceBuilding)b;
                    Button a = new Button();

                    a.Size = new Size(Size, Size);
                    a.Location = new Point(start_x + (m.Xpos * Size), start_Y + (m.Ypos * Size));

                    if (m.Fact == 1)
                    {
                        a.Text = "RB";
                        a.ForeColor = Color.Blue;

                    }
                    else
                    {
                        a.Text = "RB";
                        a.ForeColor = Color.Red;
                    }
                    if (m.isDestoryed())
                    {
                        a.Text = "X";
                    }
                    groupBox1.Controls.Add(a);
                    a.Click += new EventHandler(Buttonunit_Click2);
                }

            }
        }
        private void UpdateMap()
        {

            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(MeleeUnits))
                {
                    MeleeUnits m = (MeleeUnits)u;
                    if (m.health >1) {

                        if (m.health < 25)
                        {
                            switch (r.Next(0, 4))
                            {
                                case 0: ((MeleeUnits)u).NewMovePos(Direction.Nort); break;
                                case 1: ((MeleeUnits)u).NewMovePos(Direction.East); break;
                                case 2: ((MeleeUnits)u).NewMovePos(Direction.South); break;
                                case 3: ((MeleeUnits)u).NewMovePos(Direction.West); break;

                            }
                        }
                        else if (m.health < 5) //WHen the melee unit health drops below 5 health they will change faction
                        {
                            if (m.Fact == 0) //This if statement will check which faction the melee unit is in to help change it to the other team
                            {
                                t.ForeColor = Color.Blue;
                                m.Fact = 1;
                                m.health = 6;
                            }
                            else
                            {
                                m.Fact = 0;
                                m.health = 6;
                                t.ForeColor = Color.Red;
                            }
                        }
                        else
                        {
                            bool inCombat = false;
                            foreach (Unit e in map.Units)
                            {

                                if (u.AttackRange(e))
                                {
                                    u.Combat(e);
                                    inCombat = true;
                                }
                            }
                            if (!inCombat)
                            {
                                Unit c = u.UnitDistance(map.Units);
                                m.NewMovePos(m.Directionto(c));
                            }

                        }
                    }

                }

            }
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(RangedUnits))
                {
                    RangedUnits ra = (RangedUnits)u;
                    if (ra.health>1) {
                        if (ra.health < 25)
                        {
                            switch (r.Next(0, 4))
                            {
                                case 0: ((RangedUnits)u).NewMovePos(Direction.Nort); break;
                                case 1: ((RangedUnits)u).NewMovePos(Direction.East); break;
                                case 2: ((RangedUnits)u).NewMovePos(Direction.South); break;
                                case 3: ((RangedUnits)u).NewMovePos(Direction.West); break;

                            }
                        }else if (ra.health <5) //WHen the ranged unit health drops below 5 health they will change faction
                        {
                            if (ra.Fact == 0) //This if statement will check which faction the ranged unit is in to help change it to the other team
                            {
                                t.ForeColor = Color.Blue;
                                ra.Fact = 1;
                                ra.health =6;
                            }else
                            {
                                ra.Fact = 0;
                                ra.health = 6;
                                t.ForeColor = Color.Red;
                            }
                            



                        }
                        else
                        {
                            bool inCombat = false;
                            foreach (Unit e in map.Units)
                            {

                                if (u.AttackRange(e))
                                {
                                    u.Combat(e);
                                    inCombat = true;
                                }
                            }
                            if (!inCombat)
                            {
                                Unit c = u.UnitDistance(map.Units);
                                ra.NewMovePos(ra.Directionto(c));
                            }

                        }
                    }

                }

            }
            foreach(Unit u in map.Units)
            {
                if (u.GetType()== typeof(Emperor))
                {
                    Emperor ra = (Emperor)u;
                    if (ra.health > 1)
                    {
                        if (ra.health < 25)
                        {
                            switch (r.Next(0, 4))
                            {
                                case 0: ((Emperor)u).NewMovePos(Direction.Nort); break;
                                case 1: ((Emperor)u).NewMovePos(Direction.East); break;
                                case 2: ((Emperor)u).NewMovePos(Direction.South); break;
                                case 3: ((Emperor)u).NewMovePos(Direction.West); break;

                            }
                        }
                        else if (ra.health < 5) //When the Emperor unit health drops below 5 health they will change faction
                        {
                            if (ra.Fact == 0) //This if statement will check which faction the Emperor unit is in to help change it to the other team
                            {
                                t.ForeColor = Color.Blue;
                                ra.Fact = 1;
                                ra.health = 6;
                            }
                            else
                            {
                                ra.Fact = 0;
                                ra.health = 6;
                                t.ForeColor = Color.Red;
                            }




                        }
                        else
                        {
                            bool inCombat = false;
                            foreach (Unit e in map.Units)
                            {

                                if (u.AttackRange(e))
                                {
                                    u.Combat(e);
                                    inCombat = true;
                                }
                            }
                            if (!inCombat)
                            {
                                Unit c = u.UnitDistance(map.Units);
                                ra.NewMovePos(ra.Directionto(c));
                            }

                        }
                    }

                }
            
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateMap();
            DisplayMap();
            textBox1.Text = (++Turn).ToString();
           
        }
        public void Buttonunit_Click(object sender, EventArgs args)
        {
            int y = (((Button)sender).Location.Y - groupBox1.Location.Y) / Size;
            int x = (((Button)sender).Location.X - groupBox1.Location.X) / Size;
            textBox2.Text = ((Button)sender).Location.ToString();

            foreach (Unit u in map.Units)
            {
                if (u.GetType()== typeof (RangedUnits))
                {
                    RangedUnits r = (RangedUnits)u;
                    if (r.Xpos == x && r.Ypos ==y)
                    {
                        textBox2.Text = r.ToString();

                    }
                }else if (u.GetType() == typeof(MeleeUnits))
                {
                    MeleeUnits m = (MeleeUnits)u;
                    if (m.Xpos == x && m.Ypos == y)
                    {
                        textBox2.Text = m.ToString();
                    }
                }
                else if (u.GetType() == typeof(Emperor))
                {
                    Emperor emperor = (Emperor)u;
                    if (emperor.Xpos == x && emperor.Ypos == y)
                    {
                        textBox2.Text = emperor.ToString();
                    }
                }
            }


        }
        public void Buttonunit_Click1(object sender, EventArgs args)
        {
            int y = (((Button)sender).Location.Y - groupBox1.Location.Y) / Size;
            int x = (((Button)sender).Location.X - groupBox1.Location.X) / Size;
            textBox2.Text = ((Button)sender).Location.ToString();

            foreach (FactoryBuilding u in map.Building)
            {
                if (u.GetType() == typeof(FactoryBuilding))
                {
                    FactoryBuilding r = (FactoryBuilding)u;
                    if (r.Xpos == x && r.Ypos == y)
                    {
                        textBox2.Text = r.toString();

                    }
                }
                else if (u.GetType() == typeof(FactoryBuilding))
                {
                    FactoryBuilding m = (FactoryBuilding)u;
                    if (m.Xpos == x && m.Ypos == y)
                    {
                        textBox2.Text = m.toString();
                    }
                }
            }


        }
        public void Buttonunit_Click2(object sender, EventArgs args)
        {
            int y = (((Button)sender).Location.Y - groupBox1.Location.Y) / Size;
            int x = (((Button)sender).Location.X - groupBox1.Location.X) / Size;
            textBox2.Text = ((Button)sender).Location.ToString();

            foreach (ResourceBuilding u in map.RB)
            {
                if (u.GetType() == typeof(ResourceBuilding))
                {
                    ResourceBuilding r = (ResourceBuilding)u;
                    if (r.Xpos == x && r.Ypos == y)
                    {
                        textBox2.Text = r.toString();

                    }
                }
                else if (u.GetType() == typeof(ResourceBuilding))
                {
                    ResourceBuilding m = (ResourceBuilding)u;
                    if (m.Xpos == x && m.Ypos == y)
                    {
                        textBox2.Text = m.toString();
                    }
                }
            }


        }

        private void Start_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void savebtm_Click(object sender, EventArgs e)
        {

            SaveMap();

           
            
        }

        private void loadbtm_Click(object sender, EventArgs e)
        {

            LoadMap();
            
        }
        public void SaveMap()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsout = new FileStream("Save.dat", FileMode.Create, FileAccess.Write, FileShare.None);


            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, map);
                    
                    MessageBox.Show("Info Saved");


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);

            }
        }
        public void LoadMap()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsin = new FileStream("Save.dat", FileMode.Open, FileAccess.Read, FileShare.None);

            try
            {
                using (fsin)
                {

                    map = (Map)bf.Deserialize(fsin);

                    MessageBox.Show("Save Loaded");
                }
            }

            catch (Exception ea)
            {
                MessageBox.Show("Error" + ea);
            }

            UpdateMap();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void mapsize_Click(object sender, EventArgs e)
        {
         
        }
    }
}
