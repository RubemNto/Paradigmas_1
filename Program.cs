using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;


namespace projetopratico
{
    class Program
    {
        static void Main(String[] args)
        {
            prova p1 = new prova();
            int input = ' ';
            string addressDadoProva;
            string addressDadoEtapa;
            string addressDadoConcorrente;

            Console.WriteLine("Endereço dos dados da prova");
            addressDadoProva = Console.ReadLine();
            Console.WriteLine("Endereço dos dados das Etapas");
            addressDadoEtapa = Console.ReadLine();
            Console.WriteLine("Endereço dos dados dos concorrentes");
            addressDadoConcorrente = Console.ReadLine();

            p1.lerFicheiros(addressDadoProva,addressDadoEtapa,addressDadoConcorrente);
            do{
            Console.WriteLine("1 - Mostrar Número dos concorrentes");
            Console.WriteLine("2 - Mostrar Número de concorrentes com provas válidas");
            Console.WriteLine("3 - Mostrar tempo concorrentes válidos");
            Console.WriteLine("4 - Mostrar tempo medio das etapas");
            Console.WriteLine("5 - Mostrar carro mais lento e mais rapido");
            Console.WriteLine("6 - Etapa mais lenta do concorrente mais rapido");
            Console.WriteLine("7 - Tempo minimo para a prova");
            Console.WriteLine("8 - Escrever velocidade dos concorrentes");
            Console.WriteLine("9 - Mostrar tabela");
            Console.WriteLine("0 - Quit");

            Console.Write("Input: ");
            input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    p1.mostrarNumConcorrentes();//mostrar os números concorrentes
                    Console.Write("Press any  KEY to continue...");
                    Console.ReadKey();
                    System.Console.Clear();
                    break;
                case 2:
                    p1.numConcorrentesProvasValidas();//conta o numero de concorrentes com provas válidas
                    Console.Write("Press any  KEY to continue...");
                    Console.ReadKey();
                    System.Console.Clear();
                    break;
                case 3:
                    p1.mostrarTempoConcorrentesValidos();//mostrar tempo concorrentes válidos
                    Console.Write("Press any  KEY to continue...");
                    Console.ReadKey();
                    System.Console.Clear();
                    break;
                case 4:
                    p1.calcularTempoMedioEtapa();//tempo medio das etapas
                    Console.Write("Press any  KEY to continue...");
                    Console.ReadKey();
                    System.Console.Clear();
                    break;
                case 5:
                    p1.carroMaisRapidoLento();//carro mais lento e mais rapido
                    Console.Write("Press any  KEY to continue...");
                    Console.ReadKey();
                    System.Console.Clear();
                    break;
                case 6:
                    p1.etapaLentaConcorrenteRapido();//etapa mais lenta do concorrente mais rapido
                    Console.Write("Press any  KEY to continue...");
                    Console.ReadKey();
                    System.Console.Clear();
                    break;
                case 7:
                    p1.tempoMinimoParaProva();//tempo minimo para a prova
                    Console.Write("Press any  KEY to continue...");
                    Console.ReadKey();
                    System.Console.Clear();
                    break;
                case 8:
                    p1.escreverVelocidades();//escrever velocidade dos concorrentes
                    Console.Write("Press any  KEY to continue...");
                    Console.ReadKey();
                    System.Console.Clear();
                    break;
                case 9:
                    p1.Tabela();
                    Console.Write("Press any  KEY to continue...");
                    Console.ReadKey();
                    System.Console.Clear();
                    break;
            }
            }while(input != 0);
        }
    }
}
