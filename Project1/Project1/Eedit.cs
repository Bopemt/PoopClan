using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Eedit : Form
    {
        SampleContext db = new SampleContext();

        public void CB1()
        {
            comboBox1.DataSource = db.Departaments.ToList();
            comboBox1.ValueMember = "DepartamentId";
            comboBox1.DisplayMember = "DepartamentName";
        }

        public void CB2()
        {
            comboBox2.DataSource = db.Computers.ToList();
            comboBox2.ValueMember = "ComputerId";
            comboBox2.DisplayMember = "ComputerId";
        }

        public Eedit()
        {
            InitializeComponent();
            CB1(); CB2();
        }

        private void Departament_Button(object sender, EventArgs e)
        {
            Add_Departament departamentForm = new Add_Departament();
            departamentForm.ShowDialog();
            CB1();
        }

        private void Computer_Button(object sender, EventArgs e)
        {
            Add_Computer computerForm = new Add_Computer();
            computerForm.ShowDialog();
            CB2();
        }
    }
}
