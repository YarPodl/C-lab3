using System;

namespace lab2
{
    class APS
    {
        public String name;     // Название АТС
        public int number;      // Номер АТС
        public String addres;   // Адрес
        public int countUsers;  // Количество пользователей
        public double usersPay; // Абонентская плата
        public String tarif;    // Тариф
        public int freeLines;   // Свободные линии

        public static int count = 0;    // Содержит количество объектов

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
        /// <summary>
        /// Возвращает имя
        /// </summary>
        /// <returns>Содержит имя объекта</returns>
        public override string ToString()
        {
            return name;
        }
        /// <summary>
        /// Возвращает все поля объекта
        /// </summary>
        /// <returns>Строка, содержащая значения всех полей</returns>
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



        ~APS()
        {
            count--;
        }
    }
}
