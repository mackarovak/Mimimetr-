using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace mimimetrrr
{
    public partial class Statics : Form
    {
        List<Cat> cats = new List <Cat>();
        public Statics(DataBaseHelper dataBase)
        {
            this.cats = dataBase.GetsAllCats();
            InitializeComponent();
        }

        private void Statics_Load(object sender, EventArgs e)
        {
            cats.ForEach((c) =>
            {
                listBox1.Items.Add(c);

            });
            
        }
    }
}
