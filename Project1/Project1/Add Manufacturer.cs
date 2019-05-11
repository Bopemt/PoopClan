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
    public partial class Add_Manufacturer : Form
    {
        SampleContext db = new SampleContext();

        public Add_Manufacturer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manufacturer manufacturer = new Manufacturer();
            manufacturer.ManufacturerName = textBox1.Text;
            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();
            this.Close();
        }
    }
}
