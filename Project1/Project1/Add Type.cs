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
    public partial class Add_Type : Form
    {
        SampleContext db = new SampleContext();

        public Add_Type()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Type type = new Type
            {
                TypeName = textBox1.Text
            };
            db.Types.Add(type);
            db.SaveChanges();
            this.Close();
        }
    }
}
