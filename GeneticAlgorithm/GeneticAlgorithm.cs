using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;


namespace GeneticAlgorithm
{
    class GeneticAlgorithm
    {
        // глобальная рандомная переменная
        public Random rand = new Random(DateTime.Now.Millisecond);
        public int MutateAmount, CrossingAmount;
        public int SameResultCheck;

        // Конструктор работы ГА без ограничения
        public GeneticAlgorithm(MainForm Form, int AmountPopulation, int AmountThings, int CapacityBag, int MutationChance, int AmountIteration, int[][] Things, ref Chart chart1, ref Label TextGenWeight, ref Label TextGenCost, ref Label TextGreedyWeight, ref Label TextGreedyCost)
        {
            int[] CountWeight = new int[AmountPopulation];
            int[] CountCost = new int[AmountPopulation];
            int[][] Population = GeneratePopulation(AmountPopulation, AmountThings, CapacityBag, Things, ref CountCost, ref CountWeight);
            CountCost = CountCostCalc(Things, Population);
            CountWeight = CountWeightCalc(Things, Population);
            CreateLogFile();
            PrintResults(Form, 0, CountWeight, CountCost, Population, AmountIteration, ref chart1, ref TextGenWeight, ref TextGenCost);
            GreedyAlgorithm(ref Form, Things, CapacityBag, ref TextGreedyWeight, ref TextGreedyCost);

            for (int i = 0; i < AmountIteration; i++)
            {
                GenerationX(ref CountWeight, ref CountCost, ref Population, AmountPopulation, AmountThings, CapacityBag, MutationChance, Things);
                PrintResults(Form, i+1, CountWeight, CountCost, Population, AmountIteration, ref chart1, ref TextGenWeight, ref TextGenCost);
            }

            CreatAndPrintResults(CountWeight, CountCost, Population, Things);
        }

        // Конструктор работы ГА с ограничением
        public GeneticAlgorithm(int SameResults, MainForm Form, int AmountPopulation, int AmountThings, int CapacityBag, int MutationChance, int AmountIteration, int[][] Things, ref Chart chart1, ref Label TextGenWeight, ref Label TextGenCost, ref Label TextGreedyWeight, ref Label TextGreedyCost)
        {
            int[] CountWeight = new int[AmountPopulation];
            int[] CountCost = new int[AmountPopulation];
            int[][] Population = GeneratePopulation(AmountPopulation, AmountThings, CapacityBag, Things, ref CountCost, ref CountWeight);
            CountCost = CountCostCalc(Things, Population);
            CountWeight = CountWeightCalc(Things, Population);
            CreateLogFile();
            PrintResults(Form, 0, CountWeight, CountCost, Population, AmountIteration, ref chart1, ref TextGenWeight, ref TextGenCost);
            GreedyAlgorithm(ref Form, Things, CapacityBag, ref TextGreedyWeight, ref TextGreedyCost);

            for (int i = 0; i < AmountIteration; i++)
            {
                if (SameResultCheck <= SameResults)
                {
                    int OldValue = CountCost[0];
                    GenerationX(ref CountWeight, ref CountCost, ref Population, AmountPopulation, AmountThings, CapacityBag, MutationChance, Things);
                    PrintResults(Form, i + 1, CountWeight, CountCost, Population, AmountIteration, ref chart1, ref TextGenWeight, ref TextGenCost);
                    int NewValue = CountCost[0];
                    if (OldValue == NewValue) { SameResultCheck++; }
                    else SameResultCheck = 0;
                }
                else break;
            }
            CreatAndPrintResults(CountWeight, CountCost, Population, Things);
        }

        // Работа генетического алгоритма 
        public void GenerationX(ref int[] CountWeight, ref int[] CountCost, ref int[][] Population, int AmountPopulation, int AmountThings, int CapacityBag, int MutationChance, int[][] Things)
        {
            SortPopulation(ref Population, ref CountWeight, ref CountCost);
            Population = Crossover(Population, CapacityBag, Things, MutationChance);
            CountCost = CountCostCalc(Things, Population);
            CountWeight = CountWeightCalc(Things, Population);
        }

        // Печать результатов в лог-файл и на диаграмму
        public void PrintResults(MainForm Form, int Iteration, int[] CountWeight, int[] CountCost, int[][] Population, int AmountIteration, ref Chart chart1, ref Label TextGenWeight, ref Label TextGenCost)
        {
            FileStream fs = new FileStream("LogGeneticAlgorithm.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Номер итерации: " + (Iteration));
            sw.WriteLine("Лучшая особь ");
            sw.Write("  Генотип: ");
            for (int i = 0; i < Population[0].Length; i++)
            {
                sw.Write(Population[0][i]);
            }
            sw.WriteLine();
            sw.WriteLine("  Стоимость: " + CountCost[0]);
            sw.WriteLine("  Вес: " + CountWeight[0]);
            int Averagecost = 0;
            for (int i = 0; i < CountCost.Length; i++)
            {
                Averagecost += CountCost[i];
            }
            Averagecost = Averagecost / CountCost.Length;
            sw.WriteLine("Средная стоимость наборов: " + Averagecost);
            sw.WriteLine("Количество скрещиваний: " + CrossingAmount);
            sw.WriteLine("Количество мутаций: " + MutateAmount);
            sw.WriteLine();
            chart1.Series["MaxCost"].Points.AddXY(Iteration, CountCost[0]);
            chart1.Series["AverageCost"].Points.AddXY(Iteration, Averagecost);
            TextGenCost.Text = ("Стоимость лучшего рюкзака: " + CountCost[0]);
            TextGenWeight.Text = ("Вес лучшего рюкзака: " + CountWeight[0]);
            Form.Refresh();
            sw.Close();
            fs.Close();
        }

        // Создания лог-файла
        public void CreateLogFile()
        {
            FileStream fs = new FileStream("LogGeneticAlgorithm.txt", FileMode.Create);
            fs.Close();
        }

        // Создание файла с ответом
        public void CreatAndPrintResults(int[] CountWeight, int[] CountCost, int[][] Population, int[][] Things)
        {
            FileStream fs = new FileStream("Result.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Результат работы генетического алгоритма:");
            sw.WriteLine("Общая сумма = " + CountCost[0]);
            sw.WriteLine("Общий вес = " + CountWeight[0]);
            sw.WriteLine("Вещи: ");
            for (int i = 0; i < Population[0].Length; i++)
            {
                if (Population[0][i] == 1)
                {
                    sw.Write("Номер: " + (i + 1));
                    sw.Write(" Стоимость: " + Things[2][i]);
                    sw.Write(" Вес: " + Things[1][i]);
                    sw.WriteLine();
                };
            }
            sw.Close();
            fs.Close();
        }

        // Первоначальная генерация популяции
        public int[][] GeneratePopulation(int AmountPopulation, int AmountThings, int CapacityBag, int[][] Things, ref int[] CountCost, ref int[] CountWeight)
        {
            int[][] Population = new int[AmountPopulation][];
            int j = 0;
            bool Full = false;
            for (int i = 0; i < AmountPopulation; i++)
            {
                Full = false;
                Population[i] = new int[AmountThings];
                while (CountWeight[i] <= CapacityBag)
                {
                    j = rand.Next(0, AmountThings);
                    Population[i][j] = 1;
                    CountWeight[i] += Things[1][j];
                    CountCost[i] += Things[2][j];
                    for (int q = 0; q < Population[0].Length; q++)
                    {
                        if (Population[i][q] == 1) { Full = true; }
                        else { Full = false; break; };
                    }
                    if (CountWeight[i] > CapacityBag)
                    {
                        Population[i][j] = 0;
                        CountWeight[i] -= Things[1][j];
                        CountCost[i] -= Things[2][j];
                        break;
                    }
                    if (Full) { break; }
                }
            }
            return Population;
        }

        // Добавление нового рандомного генотипа в популяцию 
        public int[] AddRandomGenotip(int[][] Things, int CapacityBag)
        {
            int S = 0;
            int j = 0;
            int[] Progeny = new int[Things[0].Length];
            while (S <= CapacityBag)
            {
                j = rand.Next(0, Things[0].Length);
                Progeny[j] = 1;
                S += Things[1][j];
                if (S > CapacityBag)
                {
                    Progeny[j] = 0;
                    S -= Things[1][j];
                    break;
                }
            }
            return Progeny;
        }

        // Сортировка по стоимости
        public void SortPopulation(ref int[][] Population, ref int[] CountWeight, ref int[] CountCost)
        {
            int[] Help = new int[CountCost.Length];
            for (int i = 0; i < Help.Length; i++)
            {
                Help[i] = CountCost[i];
            }
            Array.Sort(CountCost, Population);
            Array.Sort(Help, CountWeight);
            Array.Reverse(Population);
            Array.Reverse(CountCost);
            Array.Reverse(CountWeight);
        }

        // Подсчет веса
        public int[] CountWeightCalc(int[][] Things, int[][] Population)
        {
            int[] CountWeight = new int[Population.Length];
            int S = 0;
            for (int i = 0; i < Population.Length; i++)
            {
                for (int j = 0; j < Population[i].Length; j++)
                {
                    S += Population[i][j] * Things[1][j];
                }
                CountWeight[i] = S;
                S = 0;
            }
            return CountWeight;
        }

        // Подсчет стоимости 
        public int[] CountCostCalc(int[][] Things, int[][] Population)
        {
            int[] CountCost = new int[Population.Length];
            int S = 0;
            for (int i = 0; i < Population.Length; i++)
            {
                for (int j = 0; j < Population[i].Length; j++)
                {
                    S += Population[i][j] * Things[2][j];
                }
                CountCost[i] = S;
                S = 0;
            }
            return CountCost;
        }

        // Операция скрещивания особей
        public int[][] Crossover(int[][] Population, int CapacityBag, int[][] Things, int MutationChance)
        {
            int N = Convert.ToInt32((-1 + Math.Sqrt(1 + 8 * Population.Length)) / 2);
            int New = 1;
            int S;
            int[] CrossverRules = new int[Population[0].Length];
            int[][] NewPopulation = new int[Population.Length][];
            NewPopulation[0] = Population[0];
            MutateAmount = 0;
            CrossingAmount = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    for (int h = 0; h < CrossverRules.Length; h++)
                    {
                        CrossverRules[h] = rand.Next(0, 2);
                    }
                    CrossingAmount++;
                    int[] Progeny = new int[Population[0].Length];
                    // Алгоритм скрещивания
                    do
                    {
                        for (int h = 0; h < CrossverRules.Length; h++)
                        {
                            CrossverRules[h] = rand.Next(0, 2);
                        }
                        S = 0;
                        for (int k = 0; k < Population[0].Length; k++)
                        {
                            if (CrossverRules[k] == 1)
                            {
                                Progeny[k] = Population[i][k];
                            }
                            if (CrossverRules[k] == 0)
                            {
                                Progeny[k] = Population[j][k];
                            }
                        }
                        for (int p = 0; p < Population[i].Length; p++)
                        {
                            S += Progeny[p] * Things[1][p];
                        }
                    }
                    while (S > CapacityBag);

                    // Алгоритм мутации
                    bool Found = false;
                    int M = 0;
                    int MutationTry = 0;
                    while (!Found)
                    {
                        if (MutationTry > Population[0].Length * MutationChance / 100) break;
                        M = rand.Next(0, Population[0].Length);
                        if (Progeny[M] == 1) { Progeny[M] = 0; S -= Things[1][M]; Found = true; }
                        MutationTry++;
                    }
                    MutationTry = 0;
                    Found = false;
                    while (!Found)
                    {
                        if (MutationTry > Population[0].Length * MutationChance / 100) break;
                        M = rand.Next(0, Population[0].Length);
                        if (Progeny[M] == 0) { Progeny[M] = 1; S += Things[1][M]; Found = true; MutateAmount++; }
                        MutationTry++;
                        if (S > CapacityBag)
                        {
                            Progeny[M] = 0; S -= Things[1][M]; Found = false;
                            MutateAmount--;
                        }
                    }
                    //
                    NewPopulation[New] = Progeny;
                    New++;
                }
            }
            while (New < Population.Length)
            {
                NewPopulation[New] = AddRandomGenotip(Things, CapacityBag);
                New++;
            }
            return NewPopulation;
        }

        // Жадный алгоритм 
        public void GreedyAlgorithm(ref MainForm Form, int[][] Things, int CapacityBag, ref Label TextGreedyWeight, ref Label TextGreedyCost)
        {
            int[][] GreedyMassiv = new int[3][];
            GreedyMassiv[0] = new int[Things[0].Length];
            GreedyMassiv[1] = new int[Things[0].Length];
            GreedyMassiv[2] = new int[Things[0].Length];
            int GreedyCost = 0, GreedyWeight = 0;
            for (int i = 0; i < GreedyMassiv[1].Length; i++)
            {
                GreedyMassiv[0][i] = Things[1][i];
                GreedyMassiv[1][i] = Things[2][i];
                GreedyMassiv[2][i] = (GreedyMassiv[1][i] * 10000) / GreedyMassiv[0][i];
            }
            int[] Help = new int[GreedyMassiv[0].Length];
            for (int i = 0; i < Help.Length; i++)
            {
                Help[i] = GreedyMassiv[2][i];
            }
            Array.Sort(GreedyMassiv[2], GreedyMassiv[0]);
            Array.Sort(Help, GreedyMassiv[1]);
            for(int i = GreedyMassiv[2].Length - 1; i >=0; i--)
            {
                    GreedyCost += GreedyMassiv[1][i];
                    GreedyWeight += GreedyMassiv[0][i];
                if (GreedyWeight > CapacityBag)
                {
                    GreedyCost -= GreedyMassiv[1][i];
                    GreedyWeight -= GreedyMassiv[0][i];
                    break;
                }
            }
            TextGreedyCost.Text = ("Стоимость лучшего рюкзака: " + GreedyCost);
            TextGreedyWeight.Text = ("Вес лучшего рюкзака: " + GreedyWeight);
            Form.Refresh();
        }
    }
}
