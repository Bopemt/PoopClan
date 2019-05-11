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
    public partial class Add_Administrator : Form
    {
        public Add_Administrator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SampleContext db = new SampleContext())
            {
                Administrator administrator = new Administrator();
                administrator.Login = textBox1.Text;
                administrator.Password = textBox2.Text;
                db.Administrators.Add(administrator);
                db.SaveChanges();
            }
        }
    }
}
