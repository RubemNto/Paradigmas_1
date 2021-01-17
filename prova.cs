using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    public void lerFicheiros(string enderecoDadosProva,string enderecoDadosEtapas,string enderecoDadosConcorrentes)
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
    public void escreverVelocidades()
    {
        foreach (concorrente conc in listaConcorrentesValidos)
        {
            Console.WriteLine(conc.nome+" --> "+conc.velocidadeMedia);
        }
    }
    public void tempoMinimoParaProva()
    {
        List<float> tempoMinimo = new List<float>();
        foreach (concorrente conc in listaConcorrentes)
        {
            tempoMinimo.Add(conc.tempoDeProva);
        }
        tempoMinimo.Sort();
        Console.WriteLine("Tempo mínimo para finalizar prova: " + tempoMinimo[0].ToString()+"ms");
    }
    public void etapaLentaConcorrenteRapido()
    {
        concorrente tempConc;
        float menorTempo = 0;
        int index = 0;
        for (int i = 0; i < listaConcorrentesValidos.Count; i++)
        {
            if(i==0)
            {
                menorTempo = listaConcorrentesValidos[i].tempoDeProva;
                index = i;
            }else
            {
                if(listaConcorrentesValidos[i].tempoDeProva < menorTempo)
                {
                    menorTempo = listaConcorrentesValidos[i].tempoDeProva;
                    index = i;
                }
            }
        }
        tempConc = listaConcorrentesValidos[index];
        string[] dados = dadosProva;
        string etapa = "";
        float tempoLento = 0;
        for (int ln = 0; ln < dados.Length; ln++)
        {
            string[] line = dados[ln].Split(" ");
            if(tempConc.numero == int.Parse(line[0]))
            {
                if(tempoLento == 0)
                {
                    tempoLento = float.Parse(line[3]);
                    etapa = line[1]+" "+line[2];
                }else
                {
                    if(tempoLento < float.Parse(line[3]))
                    {
                        tempoLento = float.Parse(line[3]);
                        etapa = line[1]+" "+line[2];
                    }
                }
            }            
        }

        Console.WriteLine(tempConc.nome + " --> " + etapa + " --> " + tempoLento.ToString() + "ms");
    }
    public void calcularVelocidadeConcorrentes()
    {
        //somar as distancias percorridas
        float distancia = 0;
        foreach (etapa et in listaEtapas)
        {
            distancia += et.distancia;
        }
        foreach (concorrente conc in listaConcorrentes)
        {
            conc.velocidadeMedia = distancia/conc.tempoDeProva;
        }
    }
    public void carroMaisRapidoLento()
    {
        Dictionary<concorrente,float> dadoVelocidade = new Dictionary<concorrente,float>();
        foreach (concorrente conc in listaConcorrentesValidos)
        {
            dadoVelocidade.Add(conc,conc.tempoDeProva);            
        }
        foreach (KeyValuePair<concorrente,float> pair in dadoVelocidade.OrderByDescending(key => key.Value))
        {
            Console.WriteLine(pair.Key.carro + " --> " + pair.Value + "ms");
        }
    }
    public void mostrarTempoConcorrentesValidos()
    {
        //descrescente
        Dictionary<concorrente,float> tempos = new Dictionary<concorrente, float>();
        foreach (concorrente item in listaConcorrentesValidos)
        {
            tempos.Add(item,item.tempoDeProva);
        }       
        
        foreach (KeyValuePair<concorrente,float> item in tempos.OrderByDescending(key => key.Value))
        {
            Console.WriteLine(item.Key.ToString() + "-->" + item.Value.ToString());
        }
    }
    public void tempoProvaConcorrentes()
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
    public void verificarConcorrentesValidos()
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
    public void criarConcorrentes()
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
    public void criarEtapas()
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

        foreach (etapa et in listaEtapas)
        {
            et.verificarIndice(listaEtapas.Count);
        }

    }
    public void calcularTempoMedioEtapa()
    {
        string[] dadoLinhas = dadosProva;

        foreach (string line in dadoLinhas)
        {
            foreach (etapa et in listaEtapas)
            {
                if(et.pontos[0] == dadoLinhas[1] && et.pontos[1] == dadoLinhas[2])
                {
                    et.tempoMedio += float.Parse(dadoLinhas[3]);
                }            
            }            
        }

        Dictionary<int,etapa> infoEtapa = new Dictionary<int,etapa>();
        foreach (etapa et in listaEtapas)
        {
            et.tempoMedio /= (float)listaConcorrentesValidos.Count;
            infoEtapa.Add(et.indice,et);
        }
        Console.WriteLine("Tempo medio por etapa");
        foreach(KeyValuePair<int,etapa> pair in infoEtapa.OrderBy(key => key.Key))
        {
            Console.WriteLine(pair.Value.pontos[0]+ pair.Value.pontos[1] + "-->" + pair.Value.tempoMedio+"ms");
        }        
    }
    public void mostrarNumConcorrentes()
    {
        foreach (concorrente conc in listaConcorrentes)
        {
            Console.WriteLine(conc.nome + "-->" + conc.numero);
        }
    }
    public int numConcorrentesProvasValidas()
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