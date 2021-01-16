using System.Collections.Generic;
using System.IO;
using System.Collections;
using System;

class concorrente
{
    public int numero = 0;
    public string nome;
    public string carro;
    float velocidadeMedia;
    public bool desclassificado = false;
    public float tempoDeProva;
    Dictionary<etapa,float> etapaMaisLenta = new Dictionary<etapa, float>();

    public concorrente()
    {
        desclassificado = false;
    }

    public void verificarClassificado(string inicio,string fim,int numeroEtapas)//verifica se concorrente fez prova válida
    {
        //int indiceEtapa = numeroEtapas*2;
        string ultimaEtapa = "E"+(numeroEtapas-1).ToString();//indiceEtapa.ToString();
        if(inicio == "P" && fim != "E1")
        {
            desclassificado = true;
        }else if(fim == "C" && inicio != ultimaEtapa)
        {
            desclassificado = true;
        }else
        {
            int pontoPartida = 0,pontoChegada = 0;
            string p1 = inicio[1]+"";
            string p2 = fim[1]+"";
            pontoPartida = int.Parse(p1);
            pontoChegada = int.Parse(p2);
            if(pontoPartida > pontoChegada || pontoChegada-pontoPartida != 1)
            {
                desclassificado = true;
            }
        }
    }
}