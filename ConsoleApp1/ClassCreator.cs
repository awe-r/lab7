﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using ClassLibrary;

namespace ConsoleApp
{
    public class ClassCreator
    {
        public static Lesson Lesson()
        {
            return new Lesson(Datetime(), Disciplina(), Sotrudnik(), Auditoriya(), Group(), Para(), TaskType());
        }

        public static DateTime Datetime()
        {
            Console.WriteLine("Введите дату проведения в числовом формате День/месяц/год");
            string date;
            date = Console.ReadLine() ?? "";
            DateTime My;
            DateTime dateTime;

            string[] validformats = new[] { "dd/MM/yyyy", "MM/dd/yyyy", "dd-MM-yyyy", "MM-dd-yyyy", };

            CultureInfo provider = CultureInfo.InvariantCulture;

            if (DateTime.TryParseExact(date, validformats, provider,
                                        DateTimeStyles.None, out dateTime))
            {
                My = dateTime;
            }
            else
            {
                My = DateTime.Now;
            }
            return My;

        }

        public static Disciplina Disciplina()
        {
            Console.WriteLine("Введите название: ");
            string Название = Console.ReadLine() ?? "Нет названия";
            Console.WriteLine("Введите сокращение: ");
            string Сокращение = Console.ReadLine() ?? "Нет сокращения";
            return new Disciplina(Название, Сокращение);
        }

        public static Sotrudnik Sotrudnik()
        {
            Console.WriteLine("Введите Фамилию: ");
            string фамилия = Console.ReadLine() ?? "Нет фамилии";
            Console.WriteLine("Введите Имя: ");
            string имя = Console.ReadLine() ?? "Нет имени";
            Console.WriteLine("Введите Отчество: ");
            string отчество = Console.ReadLine() ?? "Нет отчества";
            return new Sotrudnik(фамилия, имя, отчество, Doljnost());

        }

        public static Auditoriya Auditoriya()
        {
            Console.WriteLine("Введите название аудитории: ");
            var Name = Console.ReadLine() ?? "Нет названия";
            Console.WriteLine("Введите количество посадочных мест");
            var Chairs = Convert.ToByte(Console.ReadLine() ?? "Нет названия");
            Console.WriteLine("Введите количество окон в аудитории: ");
            var Windows = Convert.ToByte(Console.ReadLine() ?? "Нет названия");
            return new Auditoriya(Name, Sotrudnik(), Chairs, Windows, Oborudovanie());
        }

        public static ClassLibrary.Group Group()
        {
            Console.Write("Введите название группы: ");
            var name = Console.ReadLine() ?? "Нет названия";
            Console.Write("Введите сокращение: ");
            var shortname = Console.ReadLine() ?? "Нет названия";
            Console.Write("Введите численность: ");
            var chislennost = Convert.ToByte(Console.ReadLine() ?? "0");
            Console.Write("Введите год поступления:");
            var yearPostyp = Convert.ToInt16(Console.ReadLine() ?? DateTime.Today.Year.ToString());
            return new ClassLibrary.Group(name, shortname, chislennost, yearPostyp, Spetialization(), Sotrudnik());
        }

        public static Para Para()
        {
            Console.WriteLine("Введите время начала пары : ");
            string timePara = Console.ReadLine() ?? "Нет времени";
            TimeSpan startPara = DateTime.Parse(timePara).TimeOfDay;

            Console.WriteLine("Введите время конца пары : ");
            timePara = Console.ReadLine() ?? "Нет времени";
            TimeSpan endPara = DateTime.Parse(timePara).TimeOfDay;

            Console.WriteLine("Введите время начала перерыва : ");
            timePara = Console.ReadLine() ?? "Нет времени";
            TimeSpan startBreak = DateTime.Parse(timePara).TimeOfDay;

            Console.WriteLine("Введите время конца перерыва : ");
            timePara = Console.ReadLine() ?? "Нет времени";
            TimeSpan endBreak = DateTime.Parse(timePara).TimeOfDay;
            return new Para(startPara, endPara, startBreak, endBreak, Smena());
        }

        public static TaskType TaskType()
        {
            return TaskType();

        }
        public static Oborudovanie Oborudovanie()
        {
            return Oborudovanie();

        }
        public static Smena Smena()
        {
            Console.WriteLine("Введите название смены");
            string name = Console.ReadLine();
            return new Smena(name);

        }

        public static Korpus Korpus()
        {
            Console.WriteLine("Введите название: ");
            string name = Console.ReadLine() ?? "Нет названия";

            Console.WriteLine("Введите адрес: ");
            string address = Console.ReadLine() ?? "Нет адреса";

            return new Korpus(name, address, Sotrudnik(), Organization());
        }
        public static Doljnost Doljnost()
        {
            return Doljnost();
        }
        public static Organization Organization()
        {
            return Organization();
        }
        public static Spetialization Spetialization()
        {
            Console.WriteLine("Введите название: ");
            string Название = Console.ReadLine() ?? "Нет названия";
            Console.WriteLine("Введите сокращение: ");
            string Сокращение = Console.ReadLine() ?? "Нет сокращения";
            return new Spetialization(Название, Сокращение);
        }
    }
}
