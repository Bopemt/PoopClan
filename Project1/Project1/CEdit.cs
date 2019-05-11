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
    public partial class CEdit : Form
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

        public CEdit()
        {
            InitializeComponent();
            comboBox4.SelectedIndex = 0;
            CB3(); CB2(); CB1();
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
