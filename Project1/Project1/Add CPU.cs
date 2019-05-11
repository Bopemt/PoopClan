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
    public partial class Add_CPU : Form
    {
        SampleContext db = new SampleContext();

        public void CB1()
        {
            comboBox1.DataSource = db.Manufacturers.ToList();
            comboBox1.ValueMember = "ManufacturerId";
            comboBox1.DisplayMember = "ManufacturerName";
        }

        public Add_CPU()
        {
            InitializeComponent();
            CB1();
        }

        private void Manufacturer_Button(object sender, EventArgs e)
        {
            Add_Manufacturer manufacturerForm = new Add_Manufacturer();
            manufacturerForm.ShowDialog();
            CB1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CPU cpu = new CPU();
            var val = int.Parse(comboBox1.SelectedValue.ToString());
            cpu.manufacturer = db.Manufacturers.Where(
                s => s.ManufacturerId == val
                ).FirstOrDefault<Manufacturer>();
            cpu.CpuName = textBox1.Text;
            cpu.rate = textBox2.Text;
            db.CPUs.Add(cpu);
            db.SaveChanges();
            this.Close();
        }
    }
}

