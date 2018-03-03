using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace lab3
{
    class RandomAcces
    {
        public static APS randomAcces(Queue<APS> collect, int index)
        {
            if (index == 0)
            {
                return collect.Peek();
            }
            //Queue<APS> tempQueue = new Queue<APS>(collect.Count);
            for (int j = 0; j < index; j++)
            {
                collect.Enqueue(collect.Dequeue());
            }
            APS temp = collect.Dequeue();
            collect.Enqueue(temp);
            for (int j = index + 1; j < collect.Count; j++)
            {
                collect.Enqueue(collect.Dequeue());
            }
            //collect = tempQueue;
            return temp;
        }
    }
    


    public partial class Form : System.Windows.Forms.Form
    {
        static int length = 10000;
        Queue<APS> collect = new Queue<APS>(length);
        APS[] array = new APS[length];
        APS selectingObject;
        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            textBoxCount.Text = APS.count.ToString();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Форма для ввода имени
            InputBox.InputBox inputBox = new InputBox.InputBox();
            String s = inputBox.getString();    // Строка, введенная пользователем
            if (s != null)
            {
                APS newAps = new APS(s);
                length++;
                collect.Enqueue(newAps);
                Array.Resize(ref array, length);
                array[length - 1] = newAps;
            }
            textBoxCount.Text = APS.count.ToString();
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
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
                selectingObject.name = textBox1.Text;
                selectingObject.number = m1;
                selectingObject.addres = textBox3.Text;
                selectingObject.countUsers = m2;
                selectingObject.usersPay = m3;
                selectingObject.tarif = textBox6.Text;
                selectingObject.freeLines = m4;
                labelWarning.Text = "";
            }
        }

        private void buttonCmpTime_Click(object sender, EventArgs e)
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

        private void buttonGener_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < length; i++)
            {
                APS newObject = new APS("name" + i.ToString(), i);
                collect.Enqueue(newObject);
                array[i] = newObject;
            }
            textBoxCount.Text = APS.count.ToString();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            int index;
            if (int.TryParse(textBoxIndex.Text, out index) && (index >= 0) && (index < length))
            {
                textBoxIndex.BackColor = System.Drawing.Color.White;
                selectingObject = RandomAcces.randomAcces(collect, index);
                textBox1.Text = selectingObject.name;
                textBox2.Text = selectingObject.number.ToString();
                textBox3.Text = selectingObject.addres;
                textBox4.Text = selectingObject.countUsers.ToString();
                textBox5.Text = selectingObject.usersPay.ToString();
                textBox6.Text = selectingObject.tarif;
                textBox7.Text = selectingObject.freeLines.ToString();
            }
            else
            {
                textBoxIndex.Focus();
                textBoxIndex.BackColor = System.Drawing.Color.Red;
            }
        }
    }
}
