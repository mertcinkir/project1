using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Neural_Network
    {
        Neuron neuron1 = new Neuron();
        Neuron neuron2 = new Neuron();
        Neuron neuron3 = new Neuron();
        public List<string> FileRead() //liste şeklinde 150 satır döndürüyor.
        {
            string[] data = new string[150];
            int counter = 0;
            List<string> lines = new List<string>();
            foreach (string line in System.IO.File.ReadLines(@"C:\Users\yusuf\source\repos\Project2\Project2\iris.data"))
            {
                //System.Console.WriteLine(line);
                lines.Add(line);
                counter++;
            }
            return lines;
        }
        public void weight_atama()
        {
            Random random = new Random();
            neuron1.weight1 = random.NextDouble();
            neuron1.weight2 = random.NextDouble();
            neuron1.weight3 = random.NextDouble();
            neuron1.weight4 = random.NextDouble();
            neuron2.weight1 = random.NextDouble();
            neuron2.weight2 = random.NextDouble();
            neuron2.weight3 = random.NextDouble();
            neuron2.weight4 = random.NextDouble();
            neuron3.weight1 = random.NextDouble();
            neuron3.weight2 = random.NextDouble();
            neuron3.weight3 = random.NextDouble();
            neuron3.weight4 = random.NextDouble();
        }

        
        public int Train(List<string> lines, double ogrenme_katsayi,int tekrar_sayisi)
        {
            int dogru_sonuc = 0;
            weight_atama();
            
            for(int i=0; i<=tekrar_sayisi; i++) //<= yapma sebebim sonuncu döngüde doğru bulunanları toplayacak.
            {
                foreach (string line in lines)
                {
                    string[] inputs = line.Split(',');
                    neuron1.canak_uzunluk = Convert.ToDouble(inputs[0]) / 100;
                    neuron1.canak_genislik = Convert.ToDouble(inputs[1]) / 100;
                    neuron1.tac_uzunluk = Convert.ToDouble(inputs[2]) / 100;
                    neuron1.tac_genislik = Convert.ToDouble(inputs[3]) / 100;
                    neuron1.calculator();

                    neuron2.canak_uzunluk = Convert.ToDouble(inputs[0]) / 100;
                    neuron2.canak_genislik = Convert.ToDouble(inputs[1]) / 100;
                    neuron2.tac_uzunluk = Convert.ToDouble(inputs[2]) / 100;
                    neuron2.tac_genislik = Convert.ToDouble(inputs[3]) / 100;
                    neuron2.calculator();

                    neuron3.canak_uzunluk = Convert.ToDouble(inputs[0]) / 100;
                    neuron3.canak_genislik = Convert.ToDouble(inputs[1]) / 100;
                    neuron3.tac_uzunluk = Convert.ToDouble(inputs[2]) / 100;
                    neuron3.tac_genislik = Convert.ToDouble(inputs[3]) / 100;
                    neuron3.calculator();

                    if (Equals(inputs[4], "Iris-setosa"))
                    {
                        //Console.WriteLine(neuron1.output + " " + neuron2.output + " " + neuron3.output);
                        if (i < tekrar_sayisi)
                        {
                            if (highest(neuron1, neuron2, neuron3) == 2)
                            {
                                weight_degistir(2, false, ogrenme_katsayi);
                                weight_degistir(1, true, ogrenme_katsayi);
                            }
                            else if (highest(neuron1, neuron2, neuron3) == 3)
                            {
                                weight_degistir(3, false, ogrenme_katsayi);
                                weight_degistir(1, true, ogrenme_katsayi);
                            }
                        }

                        else { if (highest(neuron1, neuron2, neuron3) == 1) { dogru_sonuc++; } }
                    }
                    else if (Equals(inputs[4], "Iris-versicolor"))
                    {
                        if (i < tekrar_sayisi)
                        {
                            if (highest(neuron1, neuron2, neuron3) == 1)
                            {
                                weight_degistir(1, false, ogrenme_katsayi);
                                weight_degistir(2, true, ogrenme_katsayi);
                            }
                            else if (highest(neuron1, neuron2, neuron3) == 3)
                            {
                                weight_degistir(3, false, ogrenme_katsayi);
                                weight_degistir(2, true, ogrenme_katsayi);
                            }
                        }
                        
                        else { if (highest(neuron1, neuron2, neuron3) == 2) { dogru_sonuc++; } }
                    }
                    else
                    {
                        if (i < tekrar_sayisi)
                        {
                            if (highest(neuron1, neuron2, neuron3) == 1)
                            {
                                weight_degistir(1, false, ogrenme_katsayi);
                                weight_degistir(3, true, ogrenme_katsayi);
                            }
                            else if (highest(neuron1, neuron2, neuron3) == 2)
                            {
                                weight_degistir(2, false, ogrenme_katsayi);
                                weight_degistir(3, true, ogrenme_katsayi);
                            }
                        }
                        else { if (highest(neuron1, neuron2, neuron3) == 3) { dogru_sonuc++; } }
                    }

                }
            }
            return dogru_sonuc;
        }
        public void weight_degistir(int neuron, bool x, double ogrenme_katsayi)
        {
            if(neuron == 1)
            {
                if (x) //weight arttır
                {
                    neuron1.weight1 += ogrenme_katsayi * neuron1.canak_uzunluk;
                    neuron1.weight2 += ogrenme_katsayi * neuron1.canak_genislik;
                    neuron1.weight3 += ogrenme_katsayi * neuron1.tac_uzunluk;
                    neuron1.weight4 += ogrenme_katsayi * neuron1.tac_genislik;
                }
                else
                {
                    neuron1.weight1 -= ogrenme_katsayi * neuron1.canak_uzunluk;
                    neuron1.weight2 -= ogrenme_katsayi * neuron1.canak_genislik;
                    neuron1.weight3 -= ogrenme_katsayi * neuron1.tac_uzunluk;
                    neuron1.weight4 -= ogrenme_katsayi * neuron1.tac_genislik;
                }
            }
            else if (neuron == 2)
            {
                if (x) //weight arttır
                {
                    neuron2.weight1 += ogrenme_katsayi * neuron2.canak_uzunluk;
                    neuron2.weight2 += ogrenme_katsayi * neuron2.canak_genislik;
                    neuron2.weight3 += ogrenme_katsayi * neuron2.tac_uzunluk;
                    neuron2.weight4 += ogrenme_katsayi * neuron2.tac_genislik;
                }
                else
                {
                    neuron2.weight1 -= ogrenme_katsayi * neuron2.canak_uzunluk;
                    neuron2.weight2 -= ogrenme_katsayi * neuron2.canak_genislik;
                    neuron2.weight3 -= ogrenme_katsayi * neuron2.tac_uzunluk;
                    neuron2.weight4 -= ogrenme_katsayi * neuron2.tac_genislik;
                }
            }
            else
            {
                if (x) //weight arttır
                {
                    neuron3.weight1 += ogrenme_katsayi * neuron3.canak_uzunluk;
                    neuron3.weight2 += ogrenme_katsayi * neuron3.canak_genislik;
                    neuron3.weight3 += ogrenme_katsayi * neuron3.tac_uzunluk;
                    neuron3.weight4 += ogrenme_katsayi * neuron3.tac_genislik;
                }
                else
                {
                    neuron3.weight1 -= ogrenme_katsayi * neuron3.canak_uzunluk;
                    neuron3.weight2 -= ogrenme_katsayi * neuron3.canak_genislik;
                    neuron3.weight3 -= ogrenme_katsayi * neuron3.tac_uzunluk;
                    neuron3.weight4 -= ogrenme_katsayi * neuron3.tac_genislik;
                }
            }

        }
        public int highest(Neuron neuron1, Neuron neuron2, Neuron neuron3)
        {
            if(neuron1.output > neuron2.output && neuron1.output > neuron3.output) { return 1; }
            else if(neuron2.output > neuron1.output && neuron2.output > neuron3.output) { return 2; }
            else { return 3; }
        }
    }

}
