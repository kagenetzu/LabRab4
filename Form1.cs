using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4
{
    public partial class Form1 : Form
    {
        List<Drink> drinksList = new List<Drink>();

        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.drinksList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 15; ++i)
            {
                switch (rnd.Next() % 3) 
                {
                    case 0: 
                        this.drinksList.Add(Juice.Generate());
                        break;
                    case 1: 
                        this.drinksList.Add(Soda.Generate());
                        break;
                    case 2: 
                        this.drinksList.Add(Alcohol.Generate());
                        break;
                        
                }
            }
            ShowInfo();
        }

        private void ShowInfo()
        {
            int juiceCount = 0;
            int sodaCount = 0;
            int alcoholCount = 0;

            foreach (var drink in this.drinksList)
            {
                if (drink is Juice)
                {
                    juiceCount += 1;
                }
                else if (drink is Soda)
                {
                    sodaCount += 1;
                }
                else if (drink is Alcohol)
                {
                    alcoholCount += 1;
                }
            }

            richTextBox1.Text = $"Сок: {juiceCount}\nГазировка: {sodaCount}\nАлкоголь: {alcoholCount}\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.drinksList.Count == 0)
            {
                richTextBox2.Text = "В автомате нет напитков.";
                return;
            }

            var drink = this.drinksList[0];
            this.drinksList.RemoveAt(0);

            richTextBox2.Text = drink.GetInfo();

            ShowInfo();
        }
    }
}
