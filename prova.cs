using System.Collections.Generic;
using System.IO;
using System.Collections;
using System;

class prova
{
    string[] dadosProva;
    string[] dadosEtapas;
    string[] dadosConcorrentes;
    List<concorrente> listaConcorrentes = new List<concorrente>();
    List<etapa> listaEtapas = new List<etapa>();
    void lerFicheiros(string enderecoDadosProva,string enderecoDadosEtapas,string enderecoDadosConcorrentes)
    {
        string leitura= " ";
        if(File.Exists(enderecoDadosConcorrentes))
        {
            //leitura = File.ReadAllText(enderecoDadosConcorrentes);
            dadosConcorrentes = File.ReadAllLines(enderecoDadosConcorrentes);//leitura.Split(" ");
            dadosEtapas = File.ReadAllLines(enderecoDadosEtapas);
        }        
    }

    void criarConcorrentes()
    {
        foreach (string line in dadosConcorrentes)
        {
            concorrente novoConcorrente = new concorrente();
            string[] dadoLinha = line.Split(" ");
            novoConcorrente.numero = int.Parse(dadoLinha[0]);
            novoConcorrente.nome = dadoLinha[1];
            novoConcorrente.carro = dadoLinha[2];
            listaConcorrentes.Add(novoConcorrente);            
        }
    }

    void criarEtapas()
    {
        foreach (string line in dadosEtapas)
        {
            etapa novaEtapa = new etapa();
        }

    }

    void Tabela()
    {

    }    
}