using System.Collections.Generic;
using System.IO;
using System.Collections;
using System;

class concorrente
{
    public int numero = 0;
    public int pos = 0;
    public string nome;
    public string carro;
    public float velocidadeMedia;
    public float distanciaPercorrida;
    public float tempoDeProva;
    public bool desclassificado = false;
    
    Dictionary<etapa,float> etapaMaisLenta = new Dictionary<etapa, float>();

    public concorrente()
    {
        desclassificado = false;
    }

    public void verificarClassificado(string inicio,string fim,int numeroEtapas)//verifica se concorrente fez prova válida
    {
        // Console.WriteLine(inicio.Length + inicio);
        // Console.WriteLine(fim.Length + fim);
        //int indiceEtapa = numeroEtapas*2;
        string ultimaEtapa = "E"+(numeroEtapas-1).ToString();//indiceEtapa.ToString();
        if(inicio == "P" && fim != "E1")
        {
            desclassificado = true;
        }else if(fim == "C" && inicio != ultimaEtapa)
        {
            desclassificado = true;
        }else if(inicio != "P" && fim != "C")
        {
            int pontoPartida = 0,pontoChegada = 0;
            string p1 = inicio[1].ToString();
            string p2 = fim[1].ToString();
            pontoPartida = int.Parse(p1);
            pontoChegada = int.Parse(p2);
            if(pontoPartida > pontoChegada || pontoChegada-pontoPartida != 1)
            {
                desclassificado = true;
            }
        }
    }
}