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
    public partial class Redit : Form
    {
        SampleContext db = new SampleContext();

        public void CB1()
        {
            comboBox1.DataSource = db.Manufacturers.ToList();
            comboBox1.ValueMember = "ManufacturerId";
            comboBox1.DisplayMember = "ManufacturerName";
        }

        public void CB2()
        {
            comboBox2.DataSource = db.Types.ToList();
            comboBox2.ValueMember = "TypeId";
            comboBox2.DisplayMember = "TypeName";
        }

        public void CB3()
        {
            comboBox3.DataSource = db.Departaments.ToList();
            comboBox3.ValueMember = "DepartamentId";
            comboBox3.DisplayMember = "DepartamentName";
        }

        public void CB4()
        {
            comboBox5.DataSource = db.Computers.ToList();
            comboBox5.ValueMember = "ComputerId";
            comboBox5.DisplayMember = "ComputerId";
        }

        public Redit()
        {
            InitializeComponent();
            using (SampleContext db = new SampleContext())
            {
                comboBox4.SelectedIndex = 0;
                CB4(); CB3();CB2();CB1();
            }
        }

        private void Manufacturer_Button(object sender, EventArgs e)
        {
            Add_Manufacturer manufacturerForm = new Add_Manufacturer();
            manufacturerForm.ShowDialog();
            CB1();
        }

        private void Type_Button(object sender, EventArgs e)
        {
            Add_Type typeForm = new Add_Type();
            typeForm.ShowDialog();
            CB2();
        }

        private void Departament_Button(object sender, EventArgs e)
        {
            Add_Departament departamentForm = new Add_Departament();
            departamentForm.ShowDialog();
            CB3();
        }

        private void Computer_Button(object sender, EventArgs e)
        {
            Add_Computer computerForm = new Add_Computer();
            computerForm.ShowDialog();
            CB4();
        }
    }
}
