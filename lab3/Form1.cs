using lab3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        const int length = 100000;
        Queue<APS> collect = new Queue<APS>(length);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            collect.Clear();
            for (int i = 0; i < length; i++)
            {
                collect.Enqueue(new APS("name" + i.ToString(), i));
            }
            foreach (APS item in collect)
            {
                listView1.Items.Add(item.ToStringPart());
                //listBox1.Items.Add(item.ToStringPart());
            }
        }
    }
}
