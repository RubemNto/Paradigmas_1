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
    bool desclassificado;
    float tempoDeProva;
    Dictionary<etapa,float> etapaMaisLenta = new Dictionary<etapa, float>();

    public concorrente()
    {
        
    }
}