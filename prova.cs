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
    List<concorrente> listaConcorrentesValidos = new List<concorrente>();
    List<concorrente> podio = new List<concorrente>();
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

    void mostrarTempoConcorrentesValidos()
    {
        List<float> tempos = new List<float>();

    }

    void tempoProvaConcorrentes()
    {
        foreach (string line in dadosProva)
        {
            string[] dadoLinha = line.Split(" ");
            for (int i = 0; i < listaConcorrentes.Count; i++)
            {
                if(int.Parse(dadoLinha[0]) == listaConcorrentes[i].numero)
                {
                    listaConcorrentes[i].tempoDeProva += float.Parse(dadoLinha[3]);
                }
            }
        }
    }

    void verificarConcorrentesValidos()
    {
        foreach (string line in dadosProva)
        {
            string[] dadoLinha = line.Split(" ");
            for (int i = 0; i < listaConcorrentes.Count; i++)
            {
                if(int.Parse(dadoLinha[0]) == listaConcorrentes[i].numero)
                {
                    listaConcorrentes[i].verificarClassificado(dadoLinha[0],dadoLinha[1],listaEtapas.Count);
                    break;
                }
            }
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
                listaConcorrentesValidos.Add(conc);
            }
        }
        Console.WriteLine("Número de concorrentes com provas válidas: " + counter.ToString());
        return counter;
    }


    void Tabela()
        {

            // VAI TER QUE SER UM FOR OU DO WHILE 

            /*  
             *  
             Console.WriteLine(" _____________________________________________________________________________________________________________");
             Console.WriteLine("|    Posição     |" + "    Número    | " + "    Nome      |" + "    Carro    |" + "  Tempo da Prova   |" + "   Di. Ant.   |" + "  Di.Ldr.   |");

             for(int i = 0; i <= concorrents.Length() / numConcorrentes / listaConcorrentesOrdenada.count; i++){

                Console.WriteLine("|      i+1      | " + "listaConcorrentesOrdenada[i].num | " + "listaConcorrentesOrdenada[i].nome| " + "listaConcorrentesOrdenada[i].carro   | " + "listaConcorrentesOrdenada[i].tempoProva| " + "listaConcorrentesOrdenada[i-1].tempoProva - listaConcorrentesOrdenada[i].tempoProva   | " + "listaConcorrentesOrdenada[0].tempoProva - listaConcorrentesOrdenada[i].tempoProva   |");
                Console.WriteLine(" _____________________________________________________________________________________________________________");
            }
             */
            Console.WriteLine(" _____________________________________________________________________________________________________________");
            Console.WriteLine("|    Posição     |" + "    Número    | " + "    Nome      |" + "    Carro    |" + "  Tempo da Prova   |" + "   Di. Ant.   |" + "  Di.Ldr.   |");
            Console.WriteLine(" _____________________________________________________________________________________________________________");
            Console.WriteLine("|        1       | " + "    x        | " + "    Nome      | " + "    Carro   | " + "       xy:zw      | " + "      x.x    | " + "    y.y    |");
            Console.WriteLine(" _____________________________________________________________________________________________________________");
            Console.WriteLine("|        2       | " + "    x        | " + "    Nome      | " + "    Carro   | " + "       xy:zw      | " + "      x.x    | " + "    y.y    |");
            Console.WriteLine(" _____________________________________________________________________________________________________________");
        }  
}