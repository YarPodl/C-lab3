using System;

namespace lab3
{
    
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(new APS("Наша станция", 12345, "ул. Рождественского, 51", 1100, 35.50, "Стандартный", 900));
            textBoxCount.Text = APS.count.ToString();
            listBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Форма для ввода имени
            InputBox.InputBox inputBox = new InputBox.InputBox();
            String s = inputBox.getString();    // Строка, введенная пользователем
            if (s != null)
            {
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
            try
            {
                selectObject.name = textBox1.Text;
                int m = int.Parse(textBox2.Text);
                if (m < 0)
                {
                    System.Windows.Forms.MessageBox.Show("Число не может быть отрицательным");
                }
                else
                {
                    selectObject.number = m;
                }
                selectObject.addres = textBox3.Text;
                m = int.Parse(textBox4.Text);
                if (m < 0)
                {
                    System.Windows.Forms.MessageBox.Show("Число не может быть отрицательным");
                }
                else
                {
                    selectObject.countUsers = m;
                }
                double m1 = double.Parse(textBox5.Text);
                if (m1 < 0)
                {
                    System.Windows.Forms.MessageBox.Show("Число не может быть отрицательным");
                }
                else
                {
                    selectObject.usersPay = m1;
                }
                selectObject.tarif = textBox6.Text;
                m = int.Parse(textBox7.Text);
                if (m < 0)
                {
                    System.Windows.Forms.MessageBox.Show("Число не может быть отрицательным");
                }
                else
                {
                    selectObject.freeLines = m;
                }
            }
            catch (Exception)   // Фокус и подчвечивания ошибочного поля
            {
                System.Windows.Forms.MessageBox.Show("Численные параметры заданы некорректно");
            }
            // Необходимо для обновления названия в listbox
            // name присваивается !!! в качестве произвольного значения
            listBox1.DisplayMember = selectObject.name; 
            listBox1.SelectedIndex = selIndex;

        }

        
    }
}
