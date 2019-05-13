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
    public partial class Authorization : Form
    {
        bool t1 = true;
        bool t2 = true;
        public Authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SampleContext bd = new SampleContext();
            try
            {
                Administrator u = bd.Administrators.Find(textBox1.Text);

                if (u.Password.Equals(textBox2.Text))
                {
                    MessageBox.Show("Correct");
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login or password is incorrect");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Login or password is incorrect");
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (t1) { textBox2.Text = string.Empty; t1 = false; }
            textBox2.UseSystemPasswordChar = true;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (t2) { textBox1.Text = string.Empty; t2 = false; }
        }
    }
}
