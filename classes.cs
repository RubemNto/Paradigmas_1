using System.Collections.Generic;
using System.Collections;
using System;

class Concorrente
{
    private int _numIdentity = 0;
    private int _time = 0;
    private int _position = 0;
    private String _name = "0";
    private String _car;
    private String[] cars = {"car1","car2","car3"};   
    public Concorrente()
    {
        _time = 0;
        _numIdentity = 0;
        _position = 0;
    }

    public void SetUpIdentity(int Identity_Number)
    {
        _numIdentity = Identity_Number;
        //return _numIdentity;
    }

    public void SetUpRandomName(List<String> names)
    {
        _name = names[new Random().Next(0,names.Count)];
    }

    public void SetUpCar()
    {
        _car = cars[new Random().Next(0,cars.Length)];
    }

    public int GetIdentity()
    {
        return _numIdentity;
    }

    public String GetCar()
    {
        return _car;
    }
    public String GetName()
    {
        return _name;
    }

    public int GetPosition()
    {
        return _position;
    }

    public int GetTime()
    {
        return _time;
    }
    
}

class Prova
{
    //gera uma prova com um número inteiro de etapas
    //e que recebe um array de concorrentes
    int _steps;
    Concorrente[] players;

    public Prova(Concorrente[] concorrentes,int steps)
    {
        //Return a rally game with a number of
        //contestants determined by the user and a number of steps
        
        players = concorrentes;        
        _steps = steps;
    }

    public Prova(Concorrente[] concorrentes,int randMin,int randMax)
    {
        //Return a rally game with a number of contestants determined
        // by the user and a number of steps defined by the user
        
        players = concorrentes;        
        _steps = new Random().Next(randMin,randMax);
    }

    public int GetSteps()
    {
        return _steps;
    }

    public void results()
    {
        Console.Write("Posição\t\tNúmero\t\tNome\t\tCarro\t\tTempo de Prova\t\tDiferença com anterior\t\tDiferença com líder\n");
        for (int i = 0; i < players.Length; i++)
        {
            Console.WriteLine(players[i].GetPosition()+"\t\t"+players[i].GetIdentity()+"\t\t"+players[i].GetName()+"\t\t"+players[i].GetCar()+"\t\t"+players[i].GetTime());
        }
    }

}

class Etapa
{
    //cada concorrente usa essa classe para verificar
    //qual etapa está realizando e se realizou a estapa até o final 
    public Etapa()
    {
        
    }
}
