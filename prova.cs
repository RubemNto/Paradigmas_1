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
    public    List<concorrente> listaConcorrentes = new List<concorrente>();// existem concorrentes validos e n validos
    public    List<concorrente> listaConcorrentesValidos = new List<concorrente>();// existem apenas concorrente validos
    public    List<concorrente> ListaConcorrenteInvalido = new List<concorrente>();//
    public     List<concorrente> podio = new List<concorrente>();
    public     List<etapa> listaEtapas = new List<etapa>();

    public void lerFicheiros(string enderecoDadosProva,string enderecoDadosEtapas,string enderecoDadosConcorrentes)
    {
        if(File.Exists(enderecoDadosConcorrentes)&&File.Exists(enderecoDadosEtapas)&&File.Exists(enderecoDadosProva))
        {
            dadosConcorrentes = File.ReadAllLines(enderecoDadosConcorrentes);
            dadosEtapas = File.ReadAllLines(enderecoDadosEtapas);
            dadosProva = File.ReadAllLines(enderecoDadosProva);
            criarEtapas();
            criarConcorrentes();
            verificarConcorrentesValidos();
            tempoProvaConcorrentes();

        }else
        {
            Console.WriteLine("One or more files don't exist");
            System.Environment.Exit(0);
        }        
    }

    public void registrarPodio()
    {
        Dictionary<concorrente,float> dadoPodio = new Dictionary<concorrente,float>();
        foreach (concorrente conc in listaConcorrentesValidos)
        {
            dadoPodio.Add(conc,conc.tempoDeProva);
        }
        dadoPodio.OrderBy(key => key.Value);
        int pos = 0;
        foreach (KeyValuePair<concorrente,float> pair in dadoPodio)
        {
            pos += 1;
            pair.Key.pos = pos;
            podio.Add(pair.Key);           
        }
    }
    public void escreverVelocidades()
    {
        calcularVelocidadeConcorrentes();
        Dictionary<concorrente,float> dadoVelocidade = new Dictionary<concorrente, float>();
        foreach (concorrente conc in listaConcorrentesValidos)
        {
            dadoVelocidade.Add(conc,conc.velocidadeMedia);
        }
        dadoVelocidade.OrderByDescending(key=>key.Value);
        foreach (KeyValuePair<concorrente,float> temp in dadoVelocidade)
        {
            Console.WriteLine(temp.Key.nome + " --> "+temp.Value+"km/ms");
        }
    }
    public void tempoMinimoParaProva()
    {
        float tempoMinimo = 0;
        string[] linhasProva = dadosProva;
        
        foreach (etapa et in listaEtapas)
        {
            List<float> tempos = new List<float>();
            foreach (string ln in linhasProva)
            {
                string[] dado = ln.Split(" ");
                if(et.pontos[0] == dado[1] && et.pontos[1] == dado[2])
                {
                    tempos.Add(float.Parse(dado[3]));                    
                }
            }
            tempos.Sort();
            tempoMinimo += tempos[0];            
        }
        Console.WriteLine("Tempo mínimo para finalizar prova: " + tempoMinimo.ToString()+"ms");
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
        dadoVelocidade.OrderByDescending(key => key.Value);        
        int counter = 1;
        foreach (KeyValuePair<concorrente,float> pair in dadoVelocidade.OrderByDescending(key => key.Value))
        {
            if(counter == 1)
            {
                Console.WriteLine("Carro mais lento: " +pair.Key.carro + " --> " + pair.Value + "ms");
            }else if(counter == dadoVelocidade.Count)
            {
                Console.WriteLine("Carro mais rápido: " + pair.Key.carro + " --> " + pair.Value + "ms");
            }
            counter++;
        }
    }
    public void mostrarTempoConcorrentesValidos()
    {
        tempoProvaConcorrentes();
        //descrescente
        Dictionary<concorrente,float> tempos = new Dictionary<concorrente, float>();
        foreach (concorrente item in listaConcorrentesValidos)
        {
            tempos.Add(item,item.tempoDeProva);
        }       
        
        foreach (KeyValuePair<concorrente,float> item in tempos.OrderByDescending(key => key.Value))
        {
            Console.WriteLine(item.Key.nome + "-->" + item.Value.ToString()+"ms");
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
                    listaConcorrentes[i].verificarClassificado(dadoLinha[1],dadoLinha[2],listaEtapas.Count);
                    break;
                }
            }
        }
        concorrentesValidos();
    }

    private void concorrentesValidos()
    {
        foreach (concorrente conc in listaConcorrentes)
        {
            if(conc.desclassificado == true)
            {
                ListaConcorrenteInvalido.Add(conc);
            }else
            {
                listaConcorrentesValidos.Add(conc);
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
            string[] ln = line.Split(" ");
            for (int i = 0; i < listaEtapas.Count; i++)
            {
                for (int b = 0; b < listaConcorrentesValidos.Count; b++)
                {
                    if(ln[0] == listaConcorrentesValidos[b].numero.ToString())
                    {
                        if(listaEtapas[i].pontos[0] == ln[1] && listaEtapas[i].pontos[1] == ln[2])
                        {
                            listaEtapas[i].tempoMedio += float.Parse(ln[3]);
                        }
                    }
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
            }
        }
        Console.WriteLine("Número de concorrentes com provas válidas: " + counter.ToString());
        return counter;
    }
    public void Tabela()
    {
        registrarPodio();
        Console.WriteLine(" _______________________________________________________________________________________________________________________________________________________________________________________");
        Console.WriteLine("|" + "\tPosição\t\t" + "|" + "\tNúmero\t\t" + "|" + "\tNome\t\t" + "|" + "\tCarro\t\t" + "|" + "\tTempo da Prova\t\t" + "|" + "\tDi. Ant.\t\t" + "|" + "\tDi.Ldr.\t\t"+"|");
        Console.WriteLine(" ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

        for(int i = 0; i < listaConcorrentes.Count;i++)
        {
            if(i < podio.Count)
            {
                if(i != 0)
                {
                    Console.WriteLine("|\t"+"{0}"+"\t\t|\t" + "{1}"+"\t\t|\t" + "{2}"+"\t\t|\t" + "{3}"+"\t\t|\t" + "{4}"+"\t\t\t|\t" + "{5}"+"\t\t\t|\t" + "{6}"+"\t\t|\t",podio[i].pos,podio[i].numero,podio[i].nome,podio[i].carro,podio[i].tempoDeProva,MathF.Abs(podio[i].tempoDeProva-podio[i-1].tempoDeProva),MathF.Abs(podio[i].tempoDeProva-podio[0].tempoDeProva));
                    Console.WriteLine(" ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

                }else
                {
                    Console.WriteLine("|\t"+"{0}"+"\t\t|\t" + "{1}"+"\t\t|\t" + "{2}"+"\t\t|\t" + "{3}"+"\t\t|\t" + "{4}"+"\t\t\t|\t" + "{5}"+"\t\t\t|\t" + "{6}"+"\t\t|\t",podio[i].pos,podio[i].numero,podio[i].nome,podio[i].carro,podio[i].tempoDeProva,podio[i].tempoDeProva,podio[i].tempoDeProva);
                    Console.WriteLine(" ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                }
            }
        }
        for(int i = 0; i < listaConcorrentes.Count;i++)
        {
            if(listaConcorrentes[i].desclassificado)
            {
                Console.WriteLine("|\t"+"   "+"\t\t|\t" + "{0}" + "\t\t|\t" + "{1}" +"\t\t|\t" + "{2}" + "\t\t|\t" + "   " + "\t\t\t|\t" + "   "+"\t\t\t|\t" + "   "+"\t\t|\t",listaConcorrentes[i].numero.ToString(),listaConcorrentes[i].nome,listaConcorrentes[i].carro);
                Console.WriteLine(" ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
        } 

    }
        // {

        //     // VAI TER QUE SER UM FOR OU DO WHILE 

        //     /*  
        //      *  
        //      Console.WriteLine(" _____________________________________________________________________________________________________________");
        //      Console.WriteLine("|    Posição     |" + "    Número    | " + "    Nome      |" + "    Carro    |" + "  Tempo da Prova   |" + "   Di. Ant.   |" + "  Di.Ldr.   |");

        //      for(int i = 0; i <= concorrents.Length() / numConcorrentes / listaConcorrentesOrdenada.count; i++){

        //         Console.WriteLine("|      i+1      | " + "listaConcorrentesOrdenada[i].num | " + "listaConcorrentesOrdenada[i].nome| " + "listaConcorrentesOrdenada[i].carro   | " + "listaConcorrentesOrdenada[i].tempoProva| " + "listaConcorrentesOrdenada[i-1].tempoProva - listaConcorrentesOrdenada[i].tempoProva   | " + "listaConcorrentesOrdenada[0].tempoProva - listaConcorrentesOrdenada[i].tempoProva   |");
        //         Console.WriteLine(" _____________________________________________________________________________________________________________");
        //     }
        //      */
        //     // Console.WriteLine(" _____________________________________________________________________________________________________________");
        //     // Console.WriteLine("|    Posição     |" + "    Número    | " + "    Nome      |" + "    Carro    |" + "  Tempo da Prova   |" + "   Di. Ant.   |" + "  Di.Ldr.   |");
        //     // Console.WriteLine(" _____________________________________________________________________________________________________________");
        //     // Console.WriteLine("|        1       | " + "    x        | " + "    Nome      | " + "    Carro   | " + "       xy:zw      | " + "      x.x    | " + "    y.y    |");
        //     // Console.WriteLine(" _____________________________________________________________________________________________________________");
        //     // Console.WriteLine("|        2       | " + "    x        | " + "    Nome      | " + "    Carro   | " + "       xy:zw      | " + "      x.x    | " + "    y.y    |");
        //     // Console.WriteLine(" _____________________________________________________________________________________________________________");
        // }  
}