using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PasswordValidation
{
    class Program
    {
        static void menu()
        {
            string text = "[O]Oprettelse\t[D]Dans\t\t[F]Fodbold\t[Q]Afslut : ";
            Console.SetCursorPosition(0, 20);
            Console.Write(text);
        }

        public static void opret()
        {

            Console.SetCursorPosition(25, 1);
            Console.Write("Udfyld informationerne");
            Console.SetCursorPosition(0, 1);
            Console.Write("Indtast nyt brugernavn: ");
            string bruger = Console.ReadLine();
            Console.Write("Indtast ny kode: ");
            string kode = Console.ReadLine();

            string databasePath = (@"H:\File\Kundebase.txt");
            var ord = File.ReadAllLines(databasePath);
            string[] databaseArray = File.ReadAllLines(databasePath, Encoding.Unicode);
            string[] words = Regex.Split(databaseArray[0], @";");

            words[0] = bruger;
            words[1] = kode;

            Regex validering = new Regex(@"[A-Z]");
            if (validering.IsMatch(kode))

            {
                Console.WriteLine("jj");
                string oprettelse = string.Join(";", words);
                File.WriteAllText(databasePath, oprettelse + Environment.NewLine);
                //databaseArray = File.WriteAllLines(databasePath);

            }

            else
            {
                Console.WriteLine("fejl");
            }

            Console.ReadKey();

        }

        static void CheckInput()
        {

            bool isQuit = false;

            while (!isQuit)
            {
                Console.Clear();
                menu();
                string valg = Convert.ToString(Console.ReadKey().KeyChar);
                switch (valg)
                {
                    case "O":
                    case "o":
                        opret();
                        break;


                    case "D":
                    case "d":
                        Console.SetCursorPosition(0, 1);
                        // dans();
                        break;

                    case "Q":
                    case "q":
                        isQuit = true;
                        break;
                }



            }








        }

        static void Login()
        {


            Console.SetCursorPosition(0, 1);
            Console.Write("Indtast brugernavn: ");
            string bruger = Console.ReadLine();
            Console.Write("Indtast kode: ");

            string kode = Console.ReadLine();

            string databasePath = (@"H:\File\Kundebase.txt");
            var ord = File.ReadAllLines(databasePath);
            string[] databaseArray = File.ReadAllLines(databasePath);
            string[] words = Regex.Split(databaseArray[0], @";");


            if (bruger == words[0] && kode == words[1])
            {

                Console.SetCursorPosition(25, 1);
                Console.WriteLine("Brugernavn og password er korrekt. Tryk enter");
                Console.ReadKey();
                Console.Clear();


            }
            else
            {
                Console.WriteLine("Fejl");
                Console.ReadKey();

            }

            CheckInput();

        }






        static void Main(string[] args)
        {
            Login();
        }

    }
}


