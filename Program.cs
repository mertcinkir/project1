using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogru_sonuc =0;
            int epok;
            double lambda;
            
            for(int w = 0; w < 3; w++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Neural_Network sinir_agi = new Neural_Network();
                        if (i == 0) { epok = 20; }
                        else if (i == 1) { epok = 50; }
                        else { epok = 100; }
                        if (j == 0) { lambda = 0.005; }
                        else if (j == 1) { lambda = 0.01; }
                        else { lambda = 0.025; }
                        Console.WriteLine("Epok: " + epok + " Lambda: " + lambda + " Doğruluk Oranı: %" + (sinir_agi.Train(sinir_agi.FileRead(), lambda, epok) / 150.0 * 100.0));
                    }
                    Console.WriteLine("");
                }
            }
            Console.ReadKey();
        }
    }
}
