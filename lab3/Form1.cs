using lab3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        APS[] array = new APS[length];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (APS item in collect)
            {
                listView1.Items.Clear();
                listView1.Items.Add(item.ToStringPart());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();
            for (int i = 0; i < length; i++)
            {
                array[i].freeLines = i;
            }
            sWatch.Stop();
            listView1.Items.Add("Время последовательного доступа к массиву: "
                + sWatch.ElapsedTicks);
            
            Random random = new Random();
            sWatch.Restart();
            for (int i = 0; i < length; i++)
            {
                array[random.Next(length)].countUsers = i;
            }
            sWatch.Stop();
            listView1.Items.Add("Время произвольного доступа к массиву: "
                + sWatch.ElapsedTicks);

            sWatch.Restart();
            for (int i = 0; i < length; i++)
            {
                APS temp = collect.Dequeue();
                temp.tarif = "Тариф";
                collect.Enqueue(temp);
            }
            sWatch.Stop();
            listView1.Items.Add("Время последовательного доступа к очереди: "
                + sWatch.ElapsedTicks);

            Queue<APS> tempQueue = new Queue<APS>(length);
            sWatch.Restart();
            for (int i = 0; i < length; i++)
            {
                int n = random.Next(length);
                for (int j = 0; j < n; j++)
                {
                    tempQueue.Enqueue(collect.Dequeue());
                }
                APS temp = collect.Dequeue();
                temp.usersPay = i;
                tempQueue.Enqueue(temp);
                for (int j = n + 1; j < length; j++)
                {
                    tempQueue.Enqueue(collect.Dequeue());
                }
                collect = tempQueue;
            }
            sWatch.Stop();
            listView1.Items.Add("Время произвольного доступа к очереди: "
                + sWatch.ElapsedTicks);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < length; i++)
            {
                APS newObject = new APS("name" + i.ToString(), i);
                collect.Enqueue(newObject);
                array[i] = newObject;
            }
        }
    }
}
