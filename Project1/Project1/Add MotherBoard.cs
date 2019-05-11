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
using System.Data.SqlClient;

namespace Project1
{
    public partial class Add_MotherBoard : Form
    {
        SampleContext db = new SampleContext();

        public void CB1()
        {
            comboBox1.DataSource = db.Manufacturers.ToList();
            comboBox1.ValueMember = "ManufacturerId";
            comboBox1.DisplayMember = "ManufacturerName";
        }

        private void Manufacturer_Button(object sender, EventArgs e)
        {
            Add_Manufacturer manufacturerForm = new Add_Manufacturer();
            manufacturerForm.ShowDialog();
            CB1();
        }

        public Add_MotherBoard()
        {
            InitializeComponent();
            CB1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Motherboard motherboard = new Motherboard();
            motherboard.MotherboardName = textBox1.Text;

            var val = int.Parse(comboBox1.SelectedValue.ToString());
            motherboard.manufacturer = db.Manufacturers.Where(
                s => s.ManufacturerId == val
                ).FirstOrDefault<Manufacturer>();

            db.Motherboards.Add(motherboard);
            db.SaveChanges();
            this.Close();
        }
    }
}
