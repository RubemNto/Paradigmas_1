using System.Collections.Generic;
using System;


namespace projetopratico
{
    class Program
    {
        static void Main(String[] args)
        {
            //Configurar os participantes para a prova
            int randomNum = new Random().Next(3,10);
            List<String> names = new List<String>{"Liam","Noah","Oliver","William","Elijah","James","Bob","Lucas","Mason","Ethan","Olivia","Emma","Ava","Sophia","Isabel","Carla","Amelia","Mia","Harper","Evelyn"};
            Concorrente[] participants = new Concorrente[randomNum];
            
            for (int i = 0; i < participants.Length; i++)
            {
                participants[i] = new Concorrente();
                participants[i].SetUpIdentity(i+1);
                participants[i].SetUpCar();
                participants[i].SetUpRandomName(names);
            }
            //Realização das provas

            //AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH

            Console.WriteLine("Hello world!");

            //new Prova(participants,3).results();  
        }
    }
}
