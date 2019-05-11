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
    public partial class Add_Computer : Form
    {
        SampleContext db = new SampleContext();

        public void CB3()
        {
            comboBox3.DataSource = db.CPUs.ToList();
            comboBox3.ValueMember = "CpuId";
            comboBox3.DisplayMember = "CpuName";
        }

        public void CB2()
        {
            comboBox2.DataSource = db.HDDs.ToList();
            comboBox2.ValueMember = "HddId";
            comboBox2.DisplayMember = "HddName";
        }

        public void CB1()
        {
            comboBox1.DataSource = db.Motherboards.ToList();
            comboBox1.ValueMember = "MotherboardId";
            comboBox1.DisplayMember = "MotherboardName";
        }

        public Add_Computer()
        {
            InitializeComponent();
            comboBox4.SelectedIndex = 0;
            CB3(); CB2(); CB1();
        }

        private void Add_Button(object sender, EventArgs e)
        {
            Computer computer = new Computer();
            computer.status = comboBox4.Text;

            var val = int.Parse(comboBox1.SelectedValue.ToString());
            computer.motherboard = db.Motherboards.Where(
                s => s.MotherboardId == val
                ).FirstOrDefault<Motherboard>();

            var val1 = int.Parse(comboBox1.SelectedValue.ToString());
            computer.hdd = db.HDDs.Where(
                s => s.HddId == val1
                ).FirstOrDefault<HDD>();

            var val2 = int.Parse(comboBox3.SelectedValue.ToString());
            computer.cpu = db.CPUs.Where(
                s => s.CpuId == val2
                ).FirstOrDefault<CPU>();
            db.Computers.Add(computer);
            db.SaveChanges();
            this.Close();
        }

        private void Motherboard_Button(object sender, EventArgs e)
        {
            Add_MotherBoard motherboardForm = new Add_MotherBoard();
            motherboardForm.ShowDialog();
            CB1();
        }

        private void HDD_Button(object sender, EventArgs e)
        {
            Add_HDD hddForm = new Add_HDD();
            hddForm.ShowDialog();
            CB2();
        }

        private void CPU_Button(object sender, EventArgs e)
        {
            Add_CPU cpuForm = new Add_CPU();
            cpuForm.ShowDialog();
            CB3();
        }
    }
}
