using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace lab3
{
    
    public partial class Form : System.Windows.Forms.Form
    {
        static int length = 10000;
        Queue<APS> collect = new Queue<APS>(length);
        APS[] array = new APS[length];
        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < length; i++)
            {
                APS newObject = new APS("name" + i.ToString(), i);
                collect.Enqueue(newObject);
                array[i] = newObject;
            }
            textBoxCount.Text = APS.count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Форма для ввода имени
            InputBox.InputBox inputBox = new InputBox.InputBox();
            String s = inputBox.getString();    // Строка, введенная пользователем
            if (s != null)
            {
                length++;
                listBox1.Items.Add(new APS(s));
            }
            textBoxCount.Text = APS.count.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            APS selectObject = (APS)listBox1.Items[listBox1.SelectedIndex];
            textBox1.Text = selectObject.name;
            textBox2.Text = selectObject.number.ToString();
            textBox3.Text = selectObject.addres;
            textBox4.Text = selectObject.countUsers.ToString();
            textBox5.Text = selectObject.usersPay.ToString();
            textBox6.Text = selectObject.tarif;
            textBox7.Text = selectObject.freeLines.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int selIndex = listBox1.SelectedIndex;
            APS selectObject = (APS)listBox1.Items[selIndex];
            bool isErrors = false;
            int m1, m2, m4;
            int.TryParse(textBox2.Text, out m1);
            if (int.TryParse(textBox2.Text, out m1) && (m1 >= 0))
            {
                textBox2.BackColor = System.Drawing.Color.White;
            }
            else
            {
                isErrors = true;
                textBox2.Focus();
                textBox2.BackColor = System.Drawing.Color.Red;
            }
            if (int.TryParse(textBox4.Text, out m2) && (m2 >= 0))
            {
                textBox4.BackColor = System.Drawing.Color.White;
            }
            else
            {
                isErrors = true;
                textBox4.Focus();
                textBox4.BackColor = System.Drawing.Color.Red;
            }
            double m3;
            if (double.TryParse(textBox5.Text, out m3) && (m3 >= 0))
            {
                textBox5.BackColor = System.Drawing.Color.White;
            }
            else
            {
                isErrors = true;
                textBox5.Focus();
                textBox5.BackColor = System.Drawing.Color.Red;
            }
            if (int.TryParse(textBox7.Text, out m4) && (m4 >= 0))
            {
                textBox7.BackColor = System.Drawing.Color.White;
            }
            else
            {
                isErrors = true;
                textBox7.Focus();
                textBox7.BackColor = System.Drawing.Color.Red;
            }
            if (isErrors)
            {
                labelWarning.Text = "Численные параметры заданы некорректно";
            }
            else
            {
                selectObject.name = textBox1.Text;
                selectObject.number = m1;
                selectObject.addres = textBox3.Text;
                selectObject.countUsers = m2;
                selectObject.usersPay = m3;
                selectObject.tarif = textBox6.Text;
                selectObject.freeLines = m4;
                labelWarning.Text = "";
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
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
    }
}
