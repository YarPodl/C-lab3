using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace lab3
{
   

    public partial class Form : System.Windows.Forms.Form
    {
        Queue<APS> collect = new Queue<APS>();
        APS[] array = new APS[0];
        APS selectingObject;
        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {

            textBoxCount.Text = APS.count.ToString();
            APS newAPS = new APS("Наша станция", 12345, "ул. Рождественского, 51", 1100, 35.50, "Стандартный", 900);
            collect.Enqueue(newAPS);
            Array.Resize(ref array, collect.Count);
            array[collect.Count - 1] = newAPS;
            textBoxIndex.Text = (collect.Count - 1).ToString();
            buttonSelect_Click(null, null);
            textBoxCount.Text = APS.count.ToString();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Форма для ввода имени
            InputBox.InputBox inputBox = new InputBox.InputBox();
            String s = inputBox.getString();    // Строка, введенная пользователем
            if (s != null)
            {
                APS newAPS = new APS(s);
                collect.Enqueue(newAPS);
                Array.Resize(ref array, collect.Count);
                array[collect.Count - 1] = newAPS;
                textBoxIndex.Text = (collect.Count - 1).ToString();
                buttonSelect_Click(null, null);
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
            for (int i = 0; i < array.Length; i++)
            {
                array[i].freeLines = i;
            }
            sWatch.Stop();
            listView1.Items.Add("Время последовательного доступа к массиву: "
                + sWatch.ElapsedTicks);

            Random random = new Random();
            sWatch.Restart();
            for (int i = 0; i < array.Length; i++)
            {
                array[random.Next(array.Length)].countUsers = i;
            }
            sWatch.Stop();
            listView1.Items.Add("Время произвольного доступа к массиву: "
                + sWatch.ElapsedTicks);

            sWatch.Restart();
            for (int i = 0; i < collect.Count; i++)
            {
                APS temp = collect.Dequeue();
                temp.tarif = "Тариф";
                collect.Enqueue(temp);
            }
            sWatch.Stop();
            listView1.Items.Add("Время последовательного доступа к очереди: "
                + sWatch.ElapsedTicks);

            //Queue<APS> tempQueue = new Queue<APS>(collect.Count);
            sWatch.Restart();
            for (int i = 0; i < collect.Count; i++)
            {
                int n = random.Next(collect.Count);
                RandomAcces.randomAcces(collect, n);
                //collect = tempQueue;
            }
            sWatch.Stop();
            listView1.Items.Add("Время произвольного доступа к очереди: "
                + sWatch.ElapsedTicks);
        }

        private void buttonGener_Click(object sender, EventArgs e)
        {
            int count;
            if (int.TryParse(textBoxGener.Text, out count) && (count >= 0) && (count + collect.Count < int.MaxValue - 100))
            {
                int newCount = collect.Count + count;
                textBoxIndex.BackColor = System.Drawing.Color.White;
                Array.Resize(ref array, newCount);
                for (int i = collect.Count; i < newCount; i++)
                {
                    APS newObject = new APS("name" + i.ToString(), i);
                    collect.Enqueue(newObject);
                    array[i] = newObject;
                }
            }
            else
            {
                textBoxIndex.Focus();
                textBoxIndex.BackColor = System.Drawing.Color.Red;
            }
            textBoxCount.Text = APS.count.ToString();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            int index;
            if (int.TryParse(textBoxIndex.Text, out index) && (index >= 0) && (index < collect.Count))
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

        private void buttonView_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (APS item in collect)
            {
                listView1.Items.Add(item.ToString());
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                textBoxIndex.Text = listView1.SelectedIndices[0].ToString();
                buttonSelect_Click(null, null);
            }
        }
    }
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
}
