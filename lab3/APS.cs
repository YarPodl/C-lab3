using System;

namespace lab3
{
    class APS
    {
        public String name;
        public int number;
        public String addres;
        public int countUsers;
        public double usersPay;
        public String tarif;
        public int freeLines;

        public static int count = 0;

        public APS()
        {
            name = "";
            number = 0;
            addres = "";
            countUsers = 0;
            usersPay = 0;
            tarif = "";
            freeLines = 0;
            count++;
        }
        public APS(String name)
        {
            this.name = name;
            number = 0;
            addres = "";
            countUsers = 0;
            usersPay = 0;
            tarif = "";
            freeLines = 0;
            count++;
        }
        public APS(String name, int number)
        {
            this.name = name;
            this.number = number;
            addres = "";
            countUsers = 0;
            usersPay = 0;
            tarif = "";
            freeLines = 0;
            count++;
        }

        public APS(string name, int number, string addres, int countUsers, double usersPay, string tarif, int freeLines)
        {
            this.name = name;
            this.number = number;
            this.addres = addres;
            this.countUsers = countUsers;
            this.usersPay = usersPay;
            this.tarif = tarif;
            this.freeLines = freeLines;
            count++;
        }
        public override string ToString()
        {
            return name;
        }
        public String ToStringPart()
        {
            return name + "  " + number.ToString();
        }
        public String ToStringFull() 
        {
            return "Название: "
                + name
                + "\nномер: "
                + number.ToString()
                + ", в шестнадцатиричной СС: "
                + Convert.ToString(number, 16)
                + "\nадрес: "
                + addres
                + "\nколичество пользователей: "
                + countUsers.ToString()
                + "\nАбонентская плата: "
                + usersPay.ToString()
                + "\nтариф: "
                + tarif
                + "\nсвободные линии: "
                + freeLines.ToString();
        }
        public void printName()
        {
            Console.WriteLine(name);
        }
        public void printNumber16()
        {
            Console.WriteLine();
        }

        /*public static implicit operator string(APS v)
        {
            throw new NotImplementedException();
        }*/
        ~APS()
        {
            count--;
        }
    }
}
