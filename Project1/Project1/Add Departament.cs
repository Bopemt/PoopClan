using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Project1
{
    public partial class Add_Departament : Form
    {
        public Add_Departament()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SampleContext db = new SampleContext())
            {
                Departament departament = new Departament();
                departament.DepartamentName = textBox1.Text;
                db.Departaments.Add(departament);
                db.SaveChanges();
                this.Close();
            }
        }
    }
}
