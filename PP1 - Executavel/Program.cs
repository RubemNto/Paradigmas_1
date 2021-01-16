using System.Collections.Generic;
using System;
using System.IO;
using classes;


namespace projetopratico
{
    class Program
    {
        //static readonly string rootFolder = @"C:\Users\rubem\OneDrive\Documentos\codes\C#\PARADIGMAS_1";
        // /*static readonly*/ string textFile;// = @"C:\Users\rubem\OneDrive\Documentos\codes\C#\PARADIGMAS_1\information.txt";
        static void Main(String[] args)
        {
            string textFile;
            Console.WriteLine("File adress");
            textFile = Console.ReadLine();


            if (File.Exists(textFile))
            {
                Prova p1 = new Prova(textFile);
            }
            else
            {
                Console.WriteLine("File does not exist!\nPress any key to continue");
                Console.ReadKey();
            }

            //Configurar os participantes para a prova
            // int randomNum = new Random().Next(3,10);
            // List<String> names = new List<String>{"Liam","Noah","Oliver","William","Elijah","James","Bob","Lucas","Mason","Ethan","Olivia","Emma","Ava","Sophia","Isabel","Carla","Amelia","Mia","Harper","Evelyn"};
            // Concorrente[] participants = new Concorrente[randomNum];

            // for (int i = 0; i < participants.Length; i++)
            // {
            //     participants[i] = new Concorrente();
            //     participants[i].SetUpIdentity(i+1);
            //     participants[i].SetUpCar();
            //     participants[i].SetUpRandomName(names);
            // }


            //Realização das provas

            //AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH

            Console.WriteLine("Hello world!");

            //new Prova(participants,3).results();  
        }
    }
}
