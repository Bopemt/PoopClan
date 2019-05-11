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
    public partial class Add_HDD : Form
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

        public Add_HDD()
        {
            InitializeComponent();
            CB1();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            HDD hdd = new HDD();
            var val = int.Parse(comboBox1.SelectedValue.ToString());
            hdd.manufacturer = db.Manufacturers.Where(
                s => s.ManufacturerId == val
                ).FirstOrDefault<Manufacturer>();
            hdd.capacity = Convert.ToInt32(textBox1.Text);
            hdd.HddName = textBox2.Text;
            db.HDDs.Add(hdd);
            db.SaveChanges();
            this.Close();
        }
    }
}

