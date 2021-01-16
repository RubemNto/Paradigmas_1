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
        if(File.Exists(enderecoDadosConcorrentes))
        {
            dadosConcorrentes = File.ReadAllLines(enderecoDadosConcorrentes);
            dadosEtapas = File.ReadAllLines(enderecoDadosEtapas);
            dadosProva = File.ReadAllLines(enderecoDadosProva);
        }else
        {
            Console.WriteLine("One or more files don't exist");
            System.Environment.Exit(0);
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
            string[] dadoLinha = line.Split(" ");
            novaEtapa.pontos[0] = dadoLinha[0];
            novaEtapa.pontos[1] = dadoLinha[1];
            novaEtapa.distancia = float.Parse(dadoLinha[2]);
            listaEtapas.Add(novaEtapa);
        }
    }
    void mostrarNumConcorrentes()
    {
        foreach (concorrente conc in listaConcorrentes)
        {
            Console.WriteLine(conc.nome + "-->" + conc.numero);
        }
    }
    
    int numConcorrentesProvasValidas()
    {
        int counter = 0;
        foreach (concorrente conc in listaConcorrentes)
        {
            if(conc.desclassificado == false)
            {
                counter++;
            }
        }
        return counter;
    }


    void Tabela()
    {

    }    
}