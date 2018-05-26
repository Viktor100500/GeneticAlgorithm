using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace GeneticAlgorithm
{
    public partial class MainForm : Form
    {
        public int j, i, k, o, m;
        public int[][] Things = new int[1][];

        public MainForm()
        {
            InitializeComponent();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            if (CheckData(InputAmountThings.Text.ToString(), CapacityBag.Text.ToString(), СhanceMutation.Text.ToString(), PopulationSizeTextbox.Text.ToString(), IterationsTextBox.Text.ToString()))
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                int j = Int32.Parse(PopulationSizeTextbox.Text.ToString()); // Размер популяции
                int i = Int32.Parse(InputAmountThings.Text.ToString()); // Количество вещей                 
                int k = Int32.Parse(CapacityBag.Text.ToString()); // Вместимость рюкзака
                int o = Int32.Parse(СhanceMutation.Text.ToString()); // Шанс мутации
                int m = Int32.Parse(IterationsTextBox.Text.ToString()); // Количество итераций
                int SameResults;
                bool check = Int32.TryParse(SameResultTextBox.Text, out SameResults);
                if (check && SameResults != 0)
                {
                    GeneticAlgorithm Go = new GeneticAlgorithm(SameResults,this, j, i, k, o, m, Things, ref chart1, ref CountWeightBest, ref CostCountBest, ref CountWeightGreedy, ref CountCostGreedy);
                }
                else
                {
                    GeneticAlgorithm Go = new GeneticAlgorithm(this, j, i, k, o, m, Things, ref chart1, ref CountWeightBest, ref CostCountBest, ref CountWeightGreedy, ref CountCostGreedy);
                }
                Process.Start("Result.txt");
                button1.Visible = true;
            }
            else
            {
                MessageBox.Show("Проверьте корректность введенных данных", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            Process.Start("LogGeneticAlgorithm.txt");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void СhanceMutation_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else e.Handled = true;
        }

        private void IterationsTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else e.Handled = true;
        }

        private void PopulationSizeTextbox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else e.Handled = true;
        }

        private void SameResultTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else e.Handled = true;
        }

        private void руководствоПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Добро пожаловать в программную среду «Генетический алгоритм». Для того чтобы начать работу, нажмите кнопку Файл – Открыть… Затем выберите подходящий файл с разрешением .xls или .xlsx содержащий таблицу с входными данными. Правильно оформленную таблицу вы можете найти в директории приложения в файле «SampleData.xlsx». После выбора файла, данные автоматически заполнятся. Вы можете изменить параметры ГА, либо сразу запустить процесс ГА. Сила мутации должна быть целым числом от 1 до 100. Кол - во итераций должно быть целым число от 1 до 99999. Размер популяции должен быть целым числом от 1 до 99999. Авто - стоп не является обязательным для заполнения, и может оставаться пустым. Нажмите кнопку «Запуск генетического алгоритма», для запуска основного алгоритма программы. После завершение обработки, все выходные данные будут выведены на форму, а также будет открыт файл с результатами. После закрытия, его можно найти в директории приложения. При нажатии кнопки открыть лог - файл, откроется лог - файл выполнения программы, который также находится в директории приложения. Для запуска алгоритма с новыми входными данными, проделайте все операции сначала. Разработчик: Власов Виктор Антонович. Версия: 1.3", "Руководство пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void DrawingGraf(int AverageCost, int CountCost, int iteration, int AmountIteration)
        {
            chart1.Series["MaxCost"].Points.AddXY(iteration, CountCost);
            chart1.Series["AverageCost"].Points.AddXY(iteration, AverageCost);
        }

        private void изФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        public bool CheckData(string a, string b, string c, string d, string i)
        {
            bool FullBox = false;
            int a1, b1, c1, d1, i1;
            FullBox = Int32.TryParse(a, out a1);
            FullBox = Int32.TryParse(b, out b1);
            FullBox = Int32.TryParse(c, out c1);
            FullBox = Int32.TryParse(d, out d1);
            FullBox = Int32.TryParse(i, out i1);
            
            int Rows;
            for (Rows = 1; Rows < Things[1].Length; Rows++)
            {
                if (FullBox == false) { return FullBox; }
            }
            for (Rows = 0; Rows < Things[2].Length; Rows++)
            {
                if (FullBox == false) { return FullBox; }
            }
            if (FullBox != false)
            {
                if (a1 == 0 || b1 == 0 || c1 == 0 || d1 == 0 || i1 == 0) { FullBox = false; }
            }
            if(c1 > 100) { FullBox = false; }
            return FullBox;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook workbook;
            Excel.Worksheet NwSheet;
            Excel.Range ShtRange;
            DataTable dt = new DataTable();
            workbook = app.Workbooks.Open(openFileDialog1.FileName);
            NwSheet = (Excel.Worksheet)workbook.Sheets.get_Item(1);
            ShtRange = NwSheet.UsedRange;

            InputAmountThings.Text = (ShtRange.Cells[1, 2] as Excel.Range).Value2.ToString(); // Количество вещей
            CapacityBag.Text = (ShtRange.Cells[2, 2] as Excel.Range).Value2.ToString(); // Вместимость рюкзака
            СhanceMutation.Text = (ShtRange.Cells[3, 2] as Excel.Range).Value2.ToString(); // Шанс мутации
            IterationsTextBox.Text = (ShtRange.Cells[4, 2] as Excel.Range).Value2.ToString(); // Количество итераций
            PopulationSizeTextbox.Text = (ShtRange.Cells[5, 2] as Excel.Range).Value2.ToString(); // Размер популяции

            bool FullData;
            FullData = Int32.TryParse((ShtRange.Cells[1, 2] as Excel.Range).Value2.ToString(), out i); // Количество вещей
            FullData = Int32.TryParse((ShtRange.Cells[2, 2] as Excel.Range).Value2.ToString(), out k); // Вместимость рюкзака
            FullData = Int32.TryParse((ShtRange.Cells[3, 2] as Excel.Range).Value2.ToString(), out o); // Шанс мутации
            FullData = Int32.TryParse((ShtRange.Cells[4, 2] as Excel.Range).Value2.ToString(), out m); // Количество итераций
            FullData = Int32.TryParse((ShtRange.Cells[5, 2] as Excel.Range).Value2.ToString(), out j); // Размер популяции
            Things = new int[3][];
            Things[0] = new int[i];
            for (int w = 0; w < i; w++)
            {
                Things[0][w] = w + 1;
            }
            Things[1] = new int[i];
            for (int w = 0; w < i; w++)
            {
                FullData = Int32.TryParse((ShtRange.Cells[8 + w, 2] as Excel.Range).Value2.ToString(), out Things[1][w]);
            }
            Things[2] = new int[i];
            for (int w = 0; w < i; w++)
            {
                FullData = Int32.TryParse((ShtRange.Cells[8 + w, 3] as Excel.Range).Value2.ToString(), out Things[2][w]);
            }
            if (FullData)
            {
                GoButton.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                SameResultTextBox.Visible = true;
            }
            else
            {
                MessageBox.Show("Проверьте корректность введенных данных", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            app.Quit();          
        }
    }
}
