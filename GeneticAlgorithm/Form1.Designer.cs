namespace GeneticAlgorithm
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.LabelAmountThings = new System.Windows.Forms.Label();
            this.LabelСapacity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.СhanceMutation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GoButton = new System.Windows.Forms.Button();
            this.IterationsTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PopulationSizeTextbox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.руководствоПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.данныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.InputAmountThings = new System.Windows.Forms.Label();
            this.CapacityBag = new System.Windows.Forms.Label();
            this.CapacitySet = new System.Windows.Forms.Label();
            this.CountCostGreedy = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SameResultTextBox = new System.Windows.Forms.TextBox();
            this.CountWeightBest = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CostCountBest = new System.Windows.Forms.Label();
            this.CountWeightGreedy = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelAmountThings
            // 
            resources.ApplyResources(this.LabelAmountThings, "LabelAmountThings");
            this.LabelAmountThings.Name = "LabelAmountThings";
            // 
            // LabelСapacity
            // 
            resources.ApplyResources(this.LabelСapacity, "LabelСapacity");
            this.LabelСapacity.Name = "LabelСapacity";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // СhanceMutation
            // 
            this.СhanceMutation.AcceptsReturn = true;
            resources.ApplyResources(this.СhanceMutation, "СhanceMutation");
            this.СhanceMutation.Name = "СhanceMutation";
            this.СhanceMutation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.СhanceMutation_KeyPress_1);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // GoButton
            // 
            resources.ApplyResources(this.GoButton, "GoButton");
            this.GoButton.ForeColor = System.Drawing.Color.Red;
            this.GoButton.Name = "GoButton";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // IterationsTextBox
            // 
            this.IterationsTextBox.AcceptsReturn = true;
            resources.ApplyResources(this.IterationsTextBox, "IterationsTextBox");
            this.IterationsTextBox.Name = "IterationsTextBox";
            this.IterationsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IterationsTextBox_KeyPress_1);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Arial", 8F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chart1.Legends.Add(legend1);
            resources.ApplyResources(this.chart1, "chart1");
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.LabelBorderWidth = 5;
            series1.Legend = "Legend1";
            series1.LegendText = "Стоимость лучшего набора";
            series1.Name = "MaxCost";
            series2.BorderWidth = 5;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series2.LabelBorderWidth = 5;
            series2.Legend = "Legend1";
            series2.LegendText = "Средняя стоимость всех наборов";
            series2.Name = "AverageCost";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            // 
            // PopulationSizeTextbox
            // 
            this.PopulationSizeTextbox.AcceptsReturn = true;
            resources.ApplyResources(this.PopulationSizeTextbox, "PopulationSizeTextbox");
            this.PopulationSizeTextbox.Name = "PopulationSizeTextbox";
            this.PopulationSizeTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PopulationSizeTextbox_KeyPress_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "SampleData.xlsx";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.руководствоПользователяToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            resources.ApplyResources(this.помощьToolStripMenuItem, "помощьToolStripMenuItem");
            // 
            // руководствоПользователяToolStripMenuItem
            // 
            this.руководствоПользователяToolStripMenuItem.Name = "руководствоПользователяToolStripMenuItem";
            resources.ApplyResources(this.руководствоПользователяToolStripMenuItem, "руководствоПользователяToolStripMenuItem");
            this.руководствоПользователяToolStripMenuItem.Click += new System.EventHandler(this.руководствоПользователяToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.данныеToolStripMenuItem,
            this.помощьToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // данныеToolStripMenuItem
            // 
            this.данныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изФайлаToolStripMenuItem});
            this.данныеToolStripMenuItem.Name = "данныеToolStripMenuItem";
            resources.ApplyResources(this.данныеToolStripMenuItem, "данныеToolStripMenuItem");
            // 
            // изФайлаToolStripMenuItem
            // 
            this.изФайлаToolStripMenuItem.Name = "изФайлаToolStripMenuItem";
            resources.ApplyResources(this.изФайлаToolStripMenuItem, "изФайлаToolStripMenuItem");
            this.изФайлаToolStripMenuItem.Click += new System.EventHandler(this.изФайлаToolStripMenuItem_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InputAmountThings
            // 
            resources.ApplyResources(this.InputAmountThings, "InputAmountThings");
            this.InputAmountThings.Name = "InputAmountThings";
            // 
            // CapacityBag
            // 
            resources.ApplyResources(this.CapacityBag, "CapacityBag");
            this.CapacityBag.Name = "CapacityBag";
            // 
            // CapacitySet
            // 
            resources.ApplyResources(this.CapacitySet, "CapacitySet");
            this.CapacitySet.Name = "CapacitySet";
            // 
            // CountCostGreedy
            // 
            resources.ApplyResources(this.CountCostGreedy, "CountCostGreedy");
            this.CountCostGreedy.Name = "CountCostGreedy";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // SameResultTextBox
            // 
            this.SameResultTextBox.AcceptsReturn = true;
            resources.ApplyResources(this.SameResultTextBox, "SameResultTextBox");
            this.SameResultTextBox.Name = "SameResultTextBox";
            this.SameResultTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SameResultTextBox_KeyPress);
            // 
            // CountWeightBest
            // 
            resources.ApplyResources(this.CountWeightBest, "CountWeightBest");
            this.CountWeightBest.Name = "CountWeightBest";
            this.CountWeightBest.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // CostCountBest
            // 
            resources.ApplyResources(this.CostCountBest, "CostCountBest");
            this.CostCountBest.Name = "CostCountBest";
            // 
            // CountWeightGreedy
            // 
            resources.ApplyResources(this.CountWeightGreedy, "CountWeightGreedy");
            this.CountWeightGreedy.Name = "CountWeightGreedy";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.CountWeightGreedy);
            this.Controls.Add(this.CostCountBest);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CountWeightBest);
            this.Controls.Add(this.SameResultTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CountCostGreedy);
            this.Controls.Add(this.CapacitySet);
            this.Controls.Add(this.CapacityBag);
            this.Controls.Add(this.InputAmountThings);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PopulationSizeTextbox);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.IterationsTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.СhanceMutation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelСapacity);
            this.Controls.Add(this.LabelAmountThings);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelAmountThings;
        private System.Windows.Forms.Label LabelСapacity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox СhanceMutation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.TextBox IterationsTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox PopulationSizeTextbox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem руководствоПользователяToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem данныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изФайлаToolStripMenuItem;
        private System.Windows.Forms.Label InputAmountThings;
        private System.Windows.Forms.Label CapacityBag;
        private System.Windows.Forms.Label CapacitySet;
        private System.Windows.Forms.Label CountCostGreedy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SameResultTextBox;
        private System.Windows.Forms.Label CountWeightBest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label CostCountBest;
        private System.Windows.Forms.Label CountWeightGreedy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

