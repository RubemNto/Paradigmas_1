using System.Collections.Generic;
using System.IO;
using System.Collections;
using System;
class etapa
{
    public float tempoMedio;
    public int indice;
    public string[] pontos = new string[2];
    public float distancia;

    public etapa()
    {

    }

    public void verificarIndice(int numeroEtapas)
    {
        if(pontos[0] == "P" && pontos[1] == "E1")
        {
            indice = 1;
        }else if(pontos[0] == ("E"+(numeroEtapas-1).ToString()) && pontos[1] == "C")
        {
            indice = numeroEtapas;
        }else
        {
            string[] et = pontos[1].Split("E");
            int indx = int.Parse(et[1]);
            indice = indx;
        }
    }
}