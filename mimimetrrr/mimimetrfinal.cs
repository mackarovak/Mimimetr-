using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Resources;
using mimimetrrr.Properties;

namespace mimimetrrr
{
    public partial class mimimetrfinal : Form
    {
        Random rnd = new Random();
        List<(int, int)> pairs = new List<(int, int)>();
        List<Cat> cats = new List<Cat>();
        int currentPair = 0;
        DataBaseHelper dataBase;

        public List<T> Shuffle<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int k = rnd.Next(0, i);
                T value = list[k];
                list[k] = list[i];
                list[i] = value;
            }
            return list;
        }

        public void ShowPair(int i)
        {
            (int, int) current = pairs[i];

            
            Cat left = cats[current.Item1];
            Cat right = cats[current.Item2];

            pictureBox1.Image = (Image)Resources.ResourceManager.GetObject(convertName4Resources(left.filename));
            pictureBox2.Image = (Image)Resources.ResourceManager.GetObject(convertName4Resources(right.filename));
            label3.Text = left.name;
            label4.Text = right.name;

        }

        public mimimetrfinal()
        {
            
            InitializeComponent();
        }

        private string convertName4Resources(string name)
        {
            return "_" + name.Split('.')[0];
        }

        private void eventAnswer(object sender, EventArgs e)
        {
            Cat clickedCat;
            if (sender == pictureBox1)
            {
                clickedCat = cats[pairs[currentPair].Item1];
            } else {
                clickedCat = cats[pairs[currentPair].Item2];
            }
            clickedCat.votes++;
            dataBase.UpdateCat(clickedCat);

            currentPair = (currentPair + 1);

            if (currentPair >= pairs.Count)
            {
                Statics statics = new Statics(dataBase);
                statics.Show();
            }
            else
            {
                ShowPair(currentPair);
            }
           
        }

        private void mimimetrfinal_Load(object sender, EventArgs e)
        {

            dataBase = new DataBaseHelper();
            cats = dataBase.GetsAllCats();

            int count = cats.Count;
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (rnd.NextDouble() > 0.5)
                    {
                        pairs.Add((i, j));
                    }
                    else
                    {
                        pairs.Add((j, i));
                    }
                }
            }
            pairs = Shuffle(pairs);

            ShowPair(0);
        }
    }
}
