using System;
using System.Threading;

namespace Gobierno_pueblo
{
    internal class Program
    {
        enum TipoDeGobierno { LIBERAL, CONCERVADOR }
        enum Politica { PERMISIVA, COERCITIVA }
        enum ContiendaCivil { BAJO, ALTO }
        static void Main(string[] args)
        {
            int CantidadProtestas = 0;
            int CambiosDePoliticas = 0;
            int CambiosDeGobiernos = 0;
            int periodos = 0;
            int numeroDeProtestasPorGobierno = 0;

            bool cambio = false;
            int politicaAnterior = -1;

            Gobierno gobierno = new Gobierno();
            Pueblo pueblo = new Pueblo();

            gobierno.TipoDePartido = valor();

            Console.Write("Si no desea seguir precione F1...\n\n");
            while (Console.ReadKey().Key != ConsoleKey.F1)
            {
                Sleep(1);
                Console.WriteLine("Gobierno: " + (CambiosDeGobiernos + 1).ToString());
                Sleep(1);
                Console.WriteLine("\n\nNumero de periodos:" + (periodos + 1).ToString() + "\n");

                if (cambio == true)
                {
                    cambio = false;
                    gobierno.TipoDePartido = valor();
                    if (gobierno.TipoDePartido == 0)
                    {
                        gobierno.Politica = 0;
                    }
                    else
                    {
                        gobierno.Politica = politicaAnterior;
                    }
                }

                if (gobierno.TipoDePartido == 0)//Liberal
                {
                    Sleep(1);
                    Console.WriteLine("Tipo de gobierno: " + TipoDeGobierno.LIBERAL);

                    if (pueblo.ContiendaCivil == 1)
                    {
                        gobierno.Politica = 0;
                        CambiosDePoliticas++;
                    }
                    if (periodos == 0)
                    {
                        gobierno.Politica = 0;
                    }
                    if (gobierno.Politica == 0)
                    {
                        Sleep(1);
                        Console.WriteLine("Politica del gobierno: " + Politica.PERMISIVA);
                    }
                    else
                    {
                        Sleep(1);
                        Console.WriteLine("Politica del gobierno: " + Politica.COERCITIVA);
                        
                    }
                    if (gobierno.Politica == 0)
                    {
                        Sleep(1);
                        Console.WriteLine("Estado de Contienda Civil: " + ContiendaCivil.BAJO);
                        pueblo.ContiendaCivil = 0;
                    }
                    else
                    {
                        Sleep(1);
                        pueblo.ContiendaCivil = 1;
                        Console.WriteLine("Estado de Contienda Civil: " + ContiendaCivil.ALTO);
                        numeroDeProtestasPorGobierno++;
                        CantidadProtestas++;
                    }
                    //pueblo.ContiendaCivil = 0;

                }
                else//Coercitivo
                {
                    Sleep(1);
                    Console.WriteLine("Tipo de gobierno: " + TipoDeGobierno.CONCERVADOR);
                    gobierno.TipoDePartido = 1;
                    Sleep(1);
                    Console.WriteLine("Politica del gobierno: " + Politica.COERCITIVA);
                    gobierno.Politica = 1;
                    Sleep(1);
                    Console.WriteLine("Estado de Contienda Civil: " + ContiendaCivil.ALTO);
                    pueblo.ContiendaCivil = 1;
                    CantidadProtestas++;
                    numeroDeProtestasPorGobierno++;
                }

                if (gobierno.TipoDePartido == 0)
                {
                    gobierno.Politica = 1;
                }

                periodos++;

                if (periodos == 4)
                {
                    /*if (numeroDeProtestasPorGobierno > 2)
                    {
                        Console.WriteLine("Cambio De Gobierno");
                    }
                    else
                    {
                        Console.WriteLine("Sigue Gobierno");
                    }*/
                    if (numeroDeProtestasPorGobierno == 2)
                    {
                        int n = valor();
                        if (n == 0)
                        {
                            Sleep(1);
                            Console.WriteLine("Sigue Gobierno");
                        }
                        else
                        {
                            Sleep(1);
                            Console.WriteLine("Cambio de Gobierno");
                            politicaAnterior = gobierno.Politica;
                            cambio = true;
                            CambiosDeGobiernos++;
                        }
                        numeroDeProtestasPorGobierno = 0;
                    }
                    if (numeroDeProtestasPorGobierno >= 3)
                    {
                        Sleep(1);
                        Console.WriteLine("Cambio de Gobierno");
                        cambio = true;
                        CambiosDeGobiernos++;
                    }
                    periodos = 0;

                }

                Console.Write("\n\n\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();


            }


            Console.WriteLine("\n\n\nResultados: ");
            Console.WriteLine("P: " + CantidadProtestas.ToString());
            Console.WriteLine("CP: " + CambiosDePoliticas.ToString());
            Console.WriteLine("CG: " + CambiosDeGobiernos.ToString());
        }

        static int valor()
        {
            int valor = new Random().Next(0, 2);
            return valor;
        }
        static void Sleep(int v)
        {
            Thread.Sleep(v * 600);
        }
    }
}
