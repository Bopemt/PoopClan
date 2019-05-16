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
using System.Linq.Dynamic;

namespace Project1
{
    public partial class MainForm : Form
    {
        SampleContext db = new SampleContext();

        public void UpdatePD()
        {
            using (SampleContext db = new SampleContext())
            {
                var res = from dev in db.PeripheralDevices
                          join typ in db.Types on dev.TypeId equals typ.TypeId
                          join man in db.Manufacturers on dev.ManufacturerId equals man.ManufacturerId
                          join dep in db.Departaments on dev.DepartamentId equals dep.DepartamentId
                          select new
                          {
                              dev.PDID,
                              dev.name,
                              dev.status,
                              typ.TypeName,
                              man.ManufacturerName,
                              dep.DepartamentName,
                              dev.ComputerId
                          };
                dataGridView1.DataSource = res.ToList();
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Name";
                dataGridView1.Columns[2].HeaderText = "Status";
                dataGridView1.Columns[3].HeaderText = "Type";
                dataGridView1.Columns[4].HeaderText = "Manufacturer";
                dataGridView1.Columns[5].HeaderText = "Departament";
                dataGridView1.Columns[6].HeaderText = "Computer";
            }
        }

        public void UpdateComp()
        {
            using (SampleContext db = new SampleContext())
            {
                var resn = from cmp in db.Computers
                           join mat in db.Motherboards on cmp.MotherboardId equals mat.MotherboardId
                           join hdd in db.HDDs on cmp.HddId equals hdd.HddId
                           join cp in db.CPUs on cmp.CpuId equals cp.CpuId
                           select new
                           {
                               cmp.ComputerId,
                               cmp.status,
                               mat.MotherboardName,
                               cp.CpuName,
                               hdd.HddName
                           };
                dataGridView2.DataSource = resn.ToList();
                dataGridView2.Columns[0].HeaderText = "ID";
                dataGridView2.Columns[1].HeaderText = "Status";
                dataGridView2.Columns[2].HeaderText = "Motherboard";
                dataGridView2.Columns[3].HeaderText = "CPU";
                dataGridView2.Columns[4].HeaderText = "HDD";
            }
        }

        public void UpdateEmployee()
        {
            using (SampleContext db = new SampleContext())
            {
                var resn = from em in db.Employees
                           join dep in db.Departaments on em.DepartamentId equals dep.DepartamentId
                           select new
                           {
                               em.EmployeeID,
                               em.fullName,
                               em.position,
                               dep.DepartamentName,
                               em.ComputerId
                           };
                dataGridView3.DataSource = resn.ToList();
                dataGridView3.Columns[0].HeaderText = "ID";
                dataGridView3.Columns[1].HeaderText = "Full Name";
                dataGridView3.Columns[2].HeaderText = "Position";
                dataGridView3.Columns[3].HeaderText = "Departament";
                dataGridView3.Columns[4].HeaderText = "Computer";
            }
        }

        public MainForm()
        {
            InitializeComponent();
            UpdatePD();
            UpdateComp();
            UpdateEmployee();
            comboBox1.DataSource = dataGridView1.Columns;
            comboBox1.DisplayMember = "HeaderText";
            comboBox2.DataSource = dataGridView2.Columns;
            comboBox2.DisplayMember = "HeaderText";
            comboBox3.DataSource = dataGridView3.Columns;
            comboBox3.DisplayMember = "HeaderText";
        }

        private void Delete(object sender, EventArgs e)
        {
            switch (Tabform.SelectedIndex)
            {
                case 0:
                    int id = 0;
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        int index = dataGridView1.SelectedRows[0].Index;
                        Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                        PeripheralDevice player = db.PeripheralDevices.Find(id);
                        db.PeripheralDevices.Remove(player);
                    }
                    db.SaveChanges();
                    UpdatePD();
                    break;
                case 1:
                    int index1 = dataGridView2.SelectedRows[0].Index;
                    int id1 = 0;
                    Int32.TryParse(dataGridView2[0, index1].Value.ToString(), out id1);
                    Computer player1 = db.Computers.Find(id1);
                    db.Computers.Remove(player1);
                    db.SaveChanges();
                    UpdateComp();
                    break;
                case 2:
                    int index2 = dataGridView3.SelectedRows[0].Index;
                    int id2 = 0;
                    Int32.TryParse(dataGridView3[0, index2].Value.ToString(), out id2);
                    Employee player2 = db.Employees.Find(id2);
                    db.Employees.Remove(player2);
                    db.SaveChanges();
                    UpdateEmployee();
                    break;
            }
        }

        private void Add(object sender, EventArgs e)
        {
            switch (Tabform.SelectedIndex)
            {
                case 0:
                    Add_Peripheral_Device pdForm = new Add_Peripheral_Device();
                    pdForm.ShowDialog();
                    UpdatePD();
                    break;
                case 1:
                    Add_Computer compForm = new Add_Computer();
                    compForm.ShowDialog();
                    UpdateComp();
                    break;
                case 2:
                    Add_Employee empForm = new Add_Employee();
                    empForm.ShowDialog();
                    UpdateEmployee();
                    break;
            }
        }

        private void Edit(object sender, EventArgs e)
        {
            switch (Tabform.SelectedIndex)
            {
                case 0:
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                    PeripheralDevice player = db.PeripheralDevices.Find(id);

                    Redit plForm = new Redit();

                    plForm.comboBox4.SelectedItem = player.status;
                    plForm.comboBox1.SelectedValue = player.ManufacturerId;
                    plForm.textBox2.Text = player.name;
                    plForm.comboBox2.SelectedValue = player.TypeId;
                    plForm.comboBox3.SelectedValue = player.DepartamentId;
                    plForm.comboBox5.SelectedValue = player.ComputerId;

                    DialogResult result = plForm.ShowDialog(this);

                    if (result == DialogResult.Cancel)
                        return;

                    player.status = plForm.comboBox4.SelectedItem.ToString();
                    player.name = plForm.textBox2.Text;

                    var val = int.Parse(plForm.comboBox1.SelectedValue.ToString());
                    player.manufacturer = db.Manufacturers.Where(s => s.ManufacturerId == val).FirstOrDefault<Manufacturer>();

                    var val1 = int.Parse(plForm.comboBox2.SelectedValue.ToString());
                    player.type = db.Types.Where(s => s.TypeId == val1).FirstOrDefault<Type>();

                    var val12 = int.Parse(plForm.comboBox3.SelectedValue.ToString());
                    player.departament = db.Departaments.Where(s => s.DepartamentId == val12).FirstOrDefault<Departament>();

                    var val3 = int.Parse(plForm.comboBox5.SelectedValue.ToString());
                    player.computer = db.Computers.Where(s => s.ComputerId == val3).FirstOrDefault<Computer>();

                    db.SaveChanges();
                    UpdatePD();
                    MessageBox.Show("Объект обновлен");
                    break;

                case 1:
                    int index1 = dataGridView2.SelectedRows[0].Index;
                    int id1 = 0;
                    Int32.TryParse(dataGridView2[0, index1].Value.ToString(), out id1);

                    Computer player1 = db.Computers.Find(id1);

                    CEdit plForm1 = new CEdit();

                    plForm1.comboBox4.SelectedItem = player1.status;
                    plForm1.comboBox1.SelectedValue = player1.MotherboardId;
                    plForm1.comboBox2.SelectedValue = player1.HddId;
                    plForm1.comboBox3.SelectedValue = player1.CpuId;

                    DialogResult result1 = plForm1.ShowDialog(this);

                    if (result1 == DialogResult.Cancel)
                        return;

                    player1.status = plForm1.comboBox4.SelectedItem.ToString();

                    var val5 = int.Parse(plForm1.comboBox1.SelectedValue.ToString());
                    player1.motherboard = db.Motherboards.Where(s => s.MotherboardId == val5).FirstOrDefault<Motherboard>();

                    var val6 = int.Parse(plForm1.comboBox2.SelectedValue.ToString());
                    player1.hdd = db.HDDs.Where(s => s.HddId == val6).FirstOrDefault<HDD>();

                    var val7 = int.Parse(plForm1.comboBox3.SelectedValue.ToString());
                    player1.cpu = db.CPUs.Where(s => s.CpuId == val7).FirstOrDefault<CPU>();

                    db.SaveChanges();
                    UpdateComp();
                    MessageBox.Show("Объект обновлен");
                    break;

                case 2:
                    int index2 = dataGridView3.SelectedRows[0].Index;
                    int id2 = 0;
                    Int32.TryParse(dataGridView3[0, index2].Value.ToString(), out id2);

                    Employee player2 = db.Employees.Find(id2);

                    Eedit plForm2 = new Eedit();

                    plForm2.textBox1.Text = player2.fullName;
                    plForm2.textBox2.Text = player2.position;
                    plForm2.comboBox1.SelectedValue = player2.DepartamentId;
                    plForm2.comboBox2.SelectedValue = player2.ComputerId;

                    DialogResult result2 = plForm2.ShowDialog(this);

                    if (result2 == DialogResult.Cancel)
                        return;

                    player2.fullName = plForm2.textBox1.Text;
                    player2.position = plForm2.textBox2.Text;
                    var val8 = int.Parse(plForm2.comboBox1.SelectedValue.ToString());
                    player2.departament = db.Departaments.Where(s => s.DepartamentId == val8).FirstOrDefault<Departament>();

                    var val9 = int.Parse(plForm2.comboBox2.SelectedValue.ToString());
                    player2.computer = db.Computers.Where(s => s.ComputerId == val9).FirstOrDefault<Computer>();

                    db.SaveChanges();
                    UpdateEmployee();
                    MessageBox.Show("Объект обновлен");
                    break;
            }
        }

        private void Tabform_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePD();
            UpdateComp();
            UpdateEmployee();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        int num = 0;
        int index;
        private void Search(object sender, EventArgs e)
        {
            num = 0;
            switch (Tabform.SelectedIndex)
            {
                case 0:
                    index = comboBox1.SelectedIndex;
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Selected = false;
                        if (dataGridView1.Rows[i].Cells[index].Value != null)
                            if (dataGridView1.Rows[i].Cells[index].Value.ToString().Contains(textBox1.Text))
                            {
                                dataGridView1.Rows[i].Selected = true; num++;
                            }
                    }
                    MessageBox.Show("Найдено записей: " + Convert.ToString(num));
                    break;
                case 1:
                    index = comboBox2.SelectedIndex;
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        dataGridView2.Rows[i].Selected = false;
                        if (dataGridView2.Rows[i].Cells[index].Value != null)
                            if (dataGridView2.Rows[i].Cells[index].Value.ToString().Contains(textBox2.Text))
                            {
                                dataGridView2.Rows[i].Selected = true; num++;
                            }
                    }
                    MessageBox.Show("Найдено записей: " + Convert.ToString(num));
                    break;
                case 2:
                    index = comboBox3.SelectedIndex;
                    for (int i = 0; i < dataGridView3.RowCount; i++)
                    {
                        dataGridView3.Rows[i].Selected = false;
                        if (dataGridView3.Rows[i].Cells[index].Value != null)
                            if (dataGridView3.Rows[i].Cells[index].Value.ToString().Contains(textBox3.Text))
                            {
                                dataGridView3.Rows[i].Selected = true; num++;
                            }
                    }
                    MessageBox.Show("Найдено записей: " + Convert.ToString(num));
                    break;
            }
        }

        private void SelectAllRow(object sender, DataGridViewCellEventArgs e)
        {
            switch (Tabform.SelectedIndex)
            {
                case 0:
                    dataGridView1.Rows[e.RowIndex].Selected = true; 
                    break;
                case 1:
                    dataGridView2.Rows[e.RowIndex].Selected = true;
                    break;
                case 2:
                    dataGridView3.Rows[e.RowIndex].Selected = true;
                    break;
            }
        }
    }
}

