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
    public partial class Add_Peripheral_Device : Form
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

        public Add_Peripheral_Device()
        {
            InitializeComponent();
            comboBox4.SelectedIndex = 0;
            CB1(); CB2(); CB3(); CB4();
        }

        private void Add_Button(object sender, EventArgs e)
        {
            PeripheralDevice peripheral = new PeripheralDevice();
            peripheral.status = comboBox4.Text;
            peripheral.name = textBox2.Text;

            var val = int.Parse(comboBox1.SelectedValue.ToString());
            peripheral.manufacturer = db.Manufacturers.Where(s => s.ManufacturerId == val).FirstOrDefault<Manufacturer>();

            var val1 = int.Parse(comboBox2.SelectedValue.ToString());
            Project1.Type t = db.Types.Where(s => s.TypeId == val1).FirstOrDefault<Type>();
            peripheral.TypeId = t.TypeId;

            var val2 = int.Parse(comboBox3.SelectedValue.ToString());
            peripheral.departament = db.Departaments.Where(s => s.DepartamentId == val2).FirstOrDefault<Departament>();

            var val3 = int.Parse(comboBox5.SelectedValue.ToString());
            peripheral.computer = db.Computers.Where(s => s.ComputerId == val3).FirstOrDefault<Computer>();

            db.PeripheralDevices.Add(peripheral);
            db.SaveChanges();
            this.Close();
        }
        
        private void Add_Peripheral_Device_Load(object sender, EventArgs e)
        {

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
