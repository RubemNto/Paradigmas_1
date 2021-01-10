using System.Collections.Generic;
using System.IO;
using System.Collections;
using System;

class Prova
{
    public string[] dados;
    List<Concorrente> concorrentes = new List<Concorrente>(0);
    public Prova(string endereco)
    {
        lerFicheiro(endereco);
        organizarFicheiro(endereco);
    }

    void lerFicheiro(string endreco)
    {
        string textFile;
        if(File.Exists(endreco))
        {
            textFile = File.ReadAllText(endreco);
            dados = textFile.Split(' ');            
        }
    }

    void organizarFicheiro(string endereco)
    {        
        int contador = 0;
        int registro = 0;
        List<string> linhas = new List<string>(); 
        string[] linhasFicheiro = File.ReadAllLines(endereco);
        List<int> num = new List<int>();
        bool foundClone = false;
        for (int i = 0; i < dados.Length; i = i+4)
        {
            int readNumber = int.Parse(dados[i]);
            Console.WriteLine(readNumber);
            foreach (int n in num)
            {                
                readNumber = int.Parse(dados[i]);//problem. compiler doesn`t read the number, help help help!!!!
                if(readNumber == n)
                {
                    foundClone = true;                    
                    break;
                }else
                {
                    foundClone = false;
                    registro = readNumber;
                }
            }
            if(foundClone == false)
            {
                contador++;
                num.Add(registro);
            }
        }        
        int[] numeros = new int[contador];
        for (int i = 0; i < numeros.Length; i++)
        {
            numeros[i] = i+1;
        }
        int controlador = 1;
        while(controlador <= numeros[numeros.Length-1])
        {
            foreach (string ln in linhasFicheiro)
            {
                for (int i = 0; i < numeros.Length; i++)
                {
                    if(ln[0] == controlador)
                    {
                        linhas.Add(ln);
                    }
                }
            }
            controlador++;
        }
        string final = "";
        for (int i = 0; i < linhas.Count; i++)
        {
            final = "\n" + linhas[i];     
        }
        File.WriteAllText(endereco,final);
    }
    // void dividirDados(string[] _dados)
    // {
        

    // }
}

class Concorrente
{

}

// class Concorrente
// {
//     private int _numIdentity = 0;
//     private int _time = 0;
//     private int _position = 0;
//     private String _name = "0";
//     private String _car;
//     private String[] cars = {"car1","car2","car3"};   
//     public Concorrente()
//     {
//         _time = 0;
//         _numIdentity = 0;
//         _position = 0;
//     }

//     public void SetUpIdentity(int Identity_Number)
//     {
//         _numIdentity = Identity_Number;
//         //return _numIdentity;
//     }

//     public void SetUpRandomName(List<String> names)
//     {
//         _name = names[new Random().Next(0,names.Count)];
//     }

//     public void SetUpCar()
//     {
//         _car = cars[new Random().Next(0,cars.Length)];
//     }

//     public int GetIdentity()
//     {
//         return _numIdentity;
//     }

//     public String GetCar()
//     {
//         return _car;
//     }
//     public String GetName()
//     {
//         return _name;
//     }

//     public int GetPosition()
//     {
//         return _position;
//     }

//     public int GetTime()
//     {
//         return _time;
//     }
    
// }

// class Prova
// {
//     //gera uma prova com um número inteiro de etapas
//     //e que recebe um array de concorrentes
//     int _steps;
//     Concorrente[] players;
//     string textFolder = @"";
//     string textFile = @"";
//     string text;
//     string[] data;    

//     public Prova(Concorrente[] concorrentes,int steps)
//     {
//         //Return a rally game with a number of
//         //contestants determined by the user and a number of steps        
//         players = concorrentes;        
//         _steps = steps;
        
//     }

//     public Prova(Concorrente[] concorrentes,int randMin,int randMax)
//     {
//         //Return a rally game with a number of contestants determined
//         // by the user and a number of steps defined by the user        
//         players = concorrentes;        
//         _steps = new Random().Next(randMin,randMax);
        
//     }

//     // public void writeData()
//     // {
//     //     foreach(string item in data)
//     //     {
//     //         Console.WriteLine(item);
//     //     }
//     // }

//     public int GetSteps()
//     {
//         return _steps;
//     }

//     public void results()
//     {
//         Console.Write("Posição\t\tNúmero\t\tNome\t\tCarro\t\tTempo de Prova\t\tDiferença com anterior\t\tDiferença com líder\n");
//         for (int i = 0; i < players.Length; i++)
//         {
//             Console.WriteLine(players[i].GetPosition()+"\t\t"+players[i].GetIdentity()+"\t\t"+players[i].GetName()+"\t\t"+players[i].GetCar()+"\t\t"+players[i].GetTime());
//         }
//     }

// }

// class Etapa
// {
//     //cada concorrente usa essa classe para verificar
//     //qual etapa está realizando e se realizou a estapa até o final 
//     public Etapa()
//     {
        
//     }
// }
