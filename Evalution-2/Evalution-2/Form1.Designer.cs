namespace Evalution_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RemoveCategory = new System.Windows.Forms.Button();
            this.AddCategory = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.AddExpenseButton = new System.Windows.Forms.Button();
            this.DayViewButton = new System.Windows.Forms.Button();
            this.MonthViewButton = new System.Windows.Forms.Button();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.TotalButton = new System.Windows.Forms.Button();
            this.EditModePanel = new System.Windows.Forms.Panel();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.FilterButton = new System.Windows.Forms.Button();
            this.ViewPanel = new System.Windows.Forms.Panel();
            this.RemoveAllutton = new System.Windows.Forms.Button();
            this.ViewButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SideViewLabel = new System.Windows.Forms.Label();
            this.ExpensePanel = new System.Windows.Forms.Panel();
            this.AddNewPanel = new System.Windows.Forms.Panel();
            this.AddOkButton = new System.Windows.Forms.Button();
            this.valueBox = new System.Windows.Forms.TextBox();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SetButton = new System.Windows.Forms.Button();
            this.BudgetBox = new System.Windows.Forms.TextBox();
            this.BudgetComboBox = new System.Windows.Forms.ComboBox();
            this.SidePanelButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.EditPanel = new System.Windows.Forms.Panel();
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CustomSearchBoxTo = new System.Windows.Forms.TextBox();
            this.FilterBox = new System.Windows.Forms.ComboBox();
            this.CustomSearchBoxFrom = new System.Windows.Forms.TextBox();
            this.FilterSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.GridViewPanel = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ExpenseGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SidePanel.SuspendLayout();
            this.EditModePanel.SuspendLayout();
            this.ViewPanel.SuspendLayout();
            this.ExpensePanel.SuspendLayout();
            this.AddNewPanel.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            this.EditPanel.SuspendLayout();
            this.FilterPanel.SuspendLayout();
            this.GridViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(195, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 26);
            this.label7.TabIndex = 19;
            this.label7.Text = "Name :-";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(195, 42);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 30);
            this.textBox1.TabIndex = 18;
            // 
            // RemoveCategory
            // 
            this.RemoveCategory.BackColor = System.Drawing.Color.Crimson;
            this.RemoveCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveCategory.Location = new System.Drawing.Point(114, 7);
            this.RemoveCategory.Name = "RemoveCategory";
            this.RemoveCategory.Size = new System.Drawing.Size(34, 25);
            this.RemoveCategory.TabIndex = 17;
            this.RemoveCategory.Text = "X";
            this.RemoveCategory.UseVisualStyleBackColor = false;
            this.RemoveCategory.Click += new System.EventHandler(this.RemoveCategoryClick);
            // 
            // AddCategory
            // 
            this.AddCategory.BackColor = System.Drawing.Color.SkyBlue;
            this.AddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddCategory.Location = new System.Drawing.Point(148, 7);
            this.AddCategory.Name = "AddCategory";
            this.AddCategory.Size = new System.Drawing.Size(34, 25);
            this.AddCategory.TabIndex = 11;
            this.AddCategory.Text = "+";
            this.AddCategory.UseVisualStyleBackColor = false;
            this.AddCategory.Click += new System.EventHandler(this.AddCategoryClick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(537, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Date :-";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(362, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Amount :-";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Category :-";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Food",
            "Snacks",
            "Clothes"});
            this.comboBox1.Location = new System.Drawing.Point(3, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(537, 39);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(154, 33);
            this.textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(366, 41);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(154, 31);
            this.textBox2.TabIndex = 2;
            // 
            // AddExpenseButton
            // 
            this.AddExpenseButton.BackColor = System.Drawing.Color.SkyBlue;
            this.AddExpenseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddExpenseButton.Location = new System.Drawing.Point(697, 39);
            this.AddExpenseButton.Name = "AddExpenseButton";
            this.AddExpenseButton.Size = new System.Drawing.Size(133, 33);
            this.AddExpenseButton.TabIndex = 0;
            this.AddExpenseButton.Text = "Add Expenses";
            this.AddExpenseButton.UseVisualStyleBackColor = false;
            this.AddExpenseButton.Click += new System.EventHandler(this.AddExpenseButton_Click);
            // 
            // DayViewButton
            // 
            this.DayViewButton.BackColor = System.Drawing.Color.SkyBlue;
            this.DayViewButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DayViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DayViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayViewButton.Location = new System.Drawing.Point(0, 33);
            this.DayViewButton.Name = "DayViewButton";
            this.DayViewButton.Size = new System.Drawing.Size(200, 35);
            this.DayViewButton.TabIndex = 5;
            this.DayViewButton.Text = "Day view";
            this.DayViewButton.UseVisualStyleBackColor = false;
            this.DayViewButton.Click += new System.EventHandler(this.DayViewButtonClick);
            // 
            // MonthViewButton
            // 
            this.MonthViewButton.BackColor = System.Drawing.Color.SkyBlue;
            this.MonthViewButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.MonthViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MonthViewButton.Location = new System.Drawing.Point(0, 0);
            this.MonthViewButton.Name = "MonthViewButton";
            this.MonthViewButton.Size = new System.Drawing.Size(200, 33);
            this.MonthViewButton.TabIndex = 6;
            this.MonthViewButton.Text = "Month View";
            this.MonthViewButton.UseVisualStyleBackColor = false;
            this.MonthViewButton.Click += new System.EventHandler(this.MonthViewButton_Click);
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(95)))), ((int)(((byte)(197)))));
            this.SidePanel.Controls.Add(this.RemoveButton);
            this.SidePanel.Controls.Add(this.TotalButton);
            this.SidePanel.Controls.Add(this.EditModePanel);
            this.SidePanel.Controls.Add(this.EditButton);
            this.SidePanel.Controls.Add(this.FilterButton);
            this.SidePanel.Controls.Add(this.ViewPanel);
            this.SidePanel.Controls.Add(this.RemoveAllutton);
            this.SidePanel.Controls.Add(this.ViewButton);
            this.SidePanel.Controls.Add(this.panel3);
            this.SidePanel.Controls.Add(this.SideViewLabel);
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SidePanel.Location = new System.Drawing.Point(0, 10);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(200, 734);
            this.SidePanel.TabIndex = 2;
            this.SidePanel.Visible = false;
            // 
            // RemoveButton
            // 
            this.RemoveButton.BackColor = System.Drawing.Color.SkyBlue;
            this.RemoveButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RemoveButton.Location = new System.Drawing.Point(0, 660);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(200, 33);
            this.RemoveButton.TabIndex = 23;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = false;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButtonClick);
            // 
            // TotalButton
            // 
            this.TotalButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(235)))));
            this.TotalButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.TotalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalButton.Location = new System.Drawing.Point(0, 449);
            this.TotalButton.Name = "TotalButton";
            this.TotalButton.Size = new System.Drawing.Size(200, 59);
            this.TotalButton.TabIndex = 12;
            this.TotalButton.Text = "Total Expense";
            this.TotalButton.UseVisualStyleBackColor = false;
            this.TotalButton.Click += new System.EventHandler(this.TotalButtonClick);
            // 
            // EditModePanel
            // 
            this.EditModePanel.Controls.Add(this.UpdateButton);
            this.EditModePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditModePanel.Location = new System.Drawing.Point(0, 385);
            this.EditModePanel.Name = "EditModePanel";
            this.EditModePanel.Size = new System.Drawing.Size(200, 64);
            this.EditModePanel.TabIndex = 15;
            this.EditModePanel.Visible = false;
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.SkyBlue;
            this.UpdateButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UpdateButton.Location = new System.Drawing.Point(0, 0);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(200, 33);
            this.UpdateButton.TabIndex = 22;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButtonClick);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(235)))));
            this.EditButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(0, 333);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(200, 52);
            this.EditButton.TabIndex = 14;
            this.EditButton.Text = "Edit Mode";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButtonClick);
            // 
            // FilterButton
            // 
            this.FilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(235)))));
            this.FilterButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterButton.Location = new System.Drawing.Point(0, 273);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(200, 60);
            this.FilterButton.TabIndex = 9;
            this.FilterButton.Text = "Filter";
            this.FilterButton.UseVisualStyleBackColor = false;
            this.FilterButton.Click += new System.EventHandler(this.FilterButtonClick);
            // 
            // ViewPanel
            // 
            this.ViewPanel.Controls.Add(this.DayViewButton);
            this.ViewPanel.Controls.Add(this.MonthViewButton);
            this.ViewPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ViewPanel.Location = new System.Drawing.Point(0, 169);
            this.ViewPanel.Name = "ViewPanel";
            this.ViewPanel.Size = new System.Drawing.Size(200, 104);
            this.ViewPanel.TabIndex = 17;
            this.ViewPanel.Visible = false;
            // 
            // RemoveAllutton
            // 
            this.RemoveAllutton.BackColor = System.Drawing.Color.Crimson;
            this.RemoveAllutton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RemoveAllutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveAllutton.Location = new System.Drawing.Point(0, 693);
            this.RemoveAllutton.Name = "RemoveAllutton";
            this.RemoveAllutton.Size = new System.Drawing.Size(200, 41);
            this.RemoveAllutton.TabIndex = 13;
            this.RemoveAllutton.Text = "Remove All";
            this.RemoveAllutton.UseVisualStyleBackColor = false;
            this.RemoveAllutton.Click += new System.EventHandler(this.RemoveAlluttonClick);
            // 
            // ViewButton
            // 
            this.ViewButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(235)))));
            this.ViewButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewButton.Location = new System.Drawing.Point(0, 110);
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.Size = new System.Drawing.Size(200, 59);
            this.ViewButton.TabIndex = 16;
            this.ViewButton.Text = "View";
            this.ViewButton.UseVisualStyleBackColor = false;
            this.ViewButton.Click += new System.EventHandler(this.ViewButtonClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SkyBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 10);
            this.panel3.TabIndex = 8;
            // 
            // SideViewLabel
            // 
            this.SideViewLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SideViewLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SideViewLabel.ForeColor = System.Drawing.Color.AliceBlue;
            this.SideViewLabel.Location = new System.Drawing.Point(0, 0);
            this.SideViewLabel.Name = "SideViewLabel";
            this.SideViewLabel.Size = new System.Drawing.Size(200, 100);
            this.SideViewLabel.TabIndex = 7;
            this.SideViewLabel.Text = "   Expense    Application \r\nFeatures";
            this.SideViewLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ExpensePanel
            // 
            this.ExpensePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(95)))), ((int)(((byte)(176)))));
            this.ExpensePanel.Controls.Add(this.AddNewPanel);
            this.ExpensePanel.Controls.Add(this.comboBox1);
            this.ExpensePanel.Controls.Add(this.label7);
            this.ExpensePanel.Controls.Add(this.label3);
            this.ExpensePanel.Controls.Add(this.AddExpenseButton);
            this.ExpensePanel.Controls.Add(this.textBox3);
            this.ExpensePanel.Controls.Add(this.label1);
            this.ExpensePanel.Controls.Add(this.label2);
            this.ExpensePanel.Controls.Add(this.textBox1);
            this.ExpensePanel.Controls.Add(this.textBox2);
            this.ExpensePanel.Controls.Add(this.AddCategory);
            this.ExpensePanel.Controls.Add(this.RemoveCategory);
            this.ExpensePanel.Location = new System.Drawing.Point(6, 1);
            this.ExpensePanel.Name = "ExpensePanel";
            this.ExpensePanel.Size = new System.Drawing.Size(824, 89);
            this.ExpensePanel.TabIndex = 11;
            // 
            // AddNewPanel
            // 
            this.AddNewPanel.BackColor = System.Drawing.SystemColors.Control;
            this.AddNewPanel.Controls.Add(this.AddOkButton);
            this.AddNewPanel.Controls.Add(this.valueBox);
            this.AddNewPanel.Location = new System.Drawing.Point(3, 67);
            this.AddNewPanel.Name = "AddNewPanel";
            this.AddNewPanel.Size = new System.Drawing.Size(179, 23);
            this.AddNewPanel.TabIndex = 20;
            this.AddNewPanel.Visible = false;
            // 
            // AddOkButton
            // 
            this.AddOkButton.BackColor = System.Drawing.Color.SkyBlue;
            this.AddOkButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddOkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddOkButton.Location = new System.Drawing.Point(145, 0);
            this.AddOkButton.Name = "AddOkButton";
            this.AddOkButton.Size = new System.Drawing.Size(34, 23);
            this.AddOkButton.TabIndex = 23;
            this.AddOkButton.Text = "Ok";
            this.AddOkButton.UseVisualStyleBackColor = false;
            this.AddOkButton.Click += new System.EventHandler(this.AddOkButtonClick);
            // 
            // valueBox
            // 
            this.valueBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.valueBox.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueBox.Location = new System.Drawing.Point(0, 0);
            this.valueBox.Multiline = true;
            this.valueBox.Name = "valueBox";
            this.valueBox.Size = new System.Drawing.Size(145, 23);
            this.valueBox.TabIndex = 22;
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(95)))), ((int)(((byte)(197)))));
            this.TitlePanel.Controls.Add(this.button1);
            this.TitlePanel.Controls.Add(this.SetButton);
            this.TitlePanel.Controls.Add(this.BudgetBox);
            this.TitlePanel.Controls.Add(this.BudgetComboBox);
            this.TitlePanel.Controls.Add(this.SidePanelButton);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(200, 10);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(833, 49);
            this.TitlePanel.TabIndex = 4;
            this.TitlePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TitlePanelPaint);
            this.TitlePanel.Resize += new System.EventHandler(this.TitlePanelResize);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(387, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 43);
            this.button1.TabIndex = 36;
            this.button1.Text = "Budget";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // SetButton
            // 
            this.SetButton.BackColor = System.Drawing.Color.SkyBlue;
            this.SetButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SetButton.Location = new System.Drawing.Point(772, 2);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(58, 43);
            this.SetButton.TabIndex = 35;
            this.SetButton.Text = "Set";
            this.SetButton.UseVisualStyleBackColor = false;
            this.SetButton.Click += new System.EventHandler(this.SetButtonClick);
            // 
            // BudgetBox
            // 
            this.BudgetBox.Location = new System.Drawing.Point(637, 25);
            this.BudgetBox.Multiline = true;
            this.BudgetBox.Name = "BudgetBox";
            this.BudgetBox.Size = new System.Drawing.Size(133, 21);
            this.BudgetBox.TabIndex = 34;
            // 
            // BudgetComboBox
            // 
            this.BudgetComboBox.FormattingEnabled = true;
            this.BudgetComboBox.Items.AddRange(new object[] {
            "Food",
            "Snacks",
            "Clothes"});
            this.BudgetComboBox.Location = new System.Drawing.Point(637, 3);
            this.BudgetComboBox.Name = "BudgetComboBox";
            this.BudgetComboBox.Size = new System.Drawing.Size(133, 21);
            this.BudgetComboBox.TabIndex = 33;
            // 
            // SidePanelButton
            // 
            this.SidePanelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(201)))), ((int)(((byte)(235)))));
            this.SidePanelButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidePanelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SidePanelButton.Location = new System.Drawing.Point(0, 0);
            this.SidePanelButton.Name = "SidePanelButton";
            this.SidePanelButton.Size = new System.Drawing.Size(75, 49);
            this.SidePanelButton.TabIndex = 0;
            this.SidePanelButton.Text = "≡";
            this.SidePanelButton.UseVisualStyleBackColor = false;
            this.SidePanelButton.Click += new System.EventHandler(this.SidePanelButtonClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SkyBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(200, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(833, 10);
            this.panel4.TabIndex = 9;
            // 
            // EditPanel
            // 
            this.EditPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(95)))), ((int)(((byte)(176)))));
            this.EditPanel.Controls.Add(this.FilterPanel);
            this.EditPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditPanel.Location = new System.Drawing.Point(200, 69);
            this.EditPanel.Name = "EditPanel";
            this.EditPanel.Size = new System.Drawing.Size(833, 93);
            this.EditPanel.TabIndex = 10;
            // 
            // FilterPanel
            // 
            this.FilterPanel.Controls.Add(this.label10);
            this.FilterPanel.Controls.Add(this.ExpensePanel);
            this.FilterPanel.Controls.Add(this.label9);
            this.FilterPanel.Controls.Add(this.CustomSearchBoxTo);
            this.FilterPanel.Controls.Add(this.FilterBox);
            this.FilterPanel.Controls.Add(this.CustomSearchBoxFrom);
            this.FilterPanel.Controls.Add(this.FilterSearch);
            this.FilterPanel.Controls.Add(this.label6);
            this.FilterPanel.Controls.Add(this.label8);
            this.FilterPanel.Controls.Add(this.SearchButton);
            this.FilterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterPanel.Location = new System.Drawing.Point(0, 0);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(833, 93);
            this.FilterPanel.TabIndex = 0;
            this.FilterPanel.Visible = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(246, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 22);
            this.label10.TabIndex = 34;
            this.label10.Text = "To";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(130, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 22);
            this.label9.TabIndex = 33;
            this.label9.Text = "From";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomSearchBoxTo
            // 
            this.CustomSearchBoxTo.Location = new System.Drawing.Point(246, 42);
            this.CustomSearchBoxTo.Multiline = true;
            this.CustomSearchBoxTo.Name = "CustomSearchBoxTo";
            this.CustomSearchBoxTo.Size = new System.Drawing.Size(110, 29);
            this.CustomSearchBoxTo.TabIndex = 29;
            // 
            // FilterBox
            // 
            this.FilterBox.FormattingEnabled = true;
            this.FilterBox.Items.AddRange(new object[] {
            "Food",
            "Snacks",
            "Clothes"});
            this.FilterBox.Location = new System.Drawing.Point(588, 42);
            this.FilterBox.Name = "FilterBox";
            this.FilterBox.Size = new System.Drawing.Size(133, 21);
            this.FilterBox.TabIndex = 32;
            // 
            // CustomSearchBoxFrom
            // 
            this.CustomSearchBoxFrom.Location = new System.Drawing.Point(130, 42);
            this.CustomSearchBoxFrom.Multiline = true;
            this.CustomSearchBoxFrom.Name = "CustomSearchBoxFrom";
            this.CustomSearchBoxFrom.Size = new System.Drawing.Size(110, 29);
            this.CustomSearchBoxFrom.TabIndex = 26;
            // 
            // FilterSearch
            // 
            this.FilterSearch.BackColor = System.Drawing.Color.SkyBlue;
            this.FilterSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FilterSearch.Location = new System.Drawing.Point(727, 33);
            this.FilterSearch.Name = "FilterSearch";
            this.FilterSearch.Size = new System.Drawing.Size(93, 48);
            this.FilterSearch.TabIndex = 31;
            this.FilterSearch.Text = "Search";
            this.FilterSearch.UseVisualStyleBackColor = false;
            this.FilterSearch.Click += new System.EventHandler(this.FilterSearchClick);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 60);
            this.label6.TabIndex = 27;
            this.label6.Text = "Custom date Search";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(502, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 48);
            this.label8.TabIndex = 30;
            this.label8.Text = "Category Filter";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.SkyBlue;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchButton.Location = new System.Drawing.Point(362, 33);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(93, 48);
            this.SearchButton.TabIndex = 28;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButtonClick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SkyBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1033, 10);
            this.panel5.TabIndex = 11;
            // 
            // GridViewPanel
            // 
            this.GridViewPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GridViewPanel.Controls.Add(this.panel1);
            this.GridViewPanel.Controls.Add(this.dateTimePicker1);
            this.GridViewPanel.Controls.Add(this.ExpenseGridView);
            this.GridViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewPanel.Location = new System.Drawing.Point(200, 162);
            this.GridViewPanel.Name = "GridViewPanel";
            this.GridViewPanel.Size = new System.Drawing.Size(833, 582);
            this.GridViewPanel.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(456, 50);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // ExpenseGridView
            // 
            this.ExpenseGridView.AllowUserToAddRows = false;
            this.ExpenseGridView.AllowUserToDeleteRows = false;
            this.ExpenseGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ExpenseGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ExpenseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExpenseGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExpenseGridView.Location = new System.Drawing.Point(0, 0);
            this.ExpenseGridView.Name = "ExpenseGridView";
            this.ExpenseGridView.ReadOnly = true;
            this.ExpenseGridView.Size = new System.Drawing.Size(833, 582);
            this.ExpenseGridView.TabIndex = 4;
            this.ExpenseGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpenseGridView_CellClick);
            this.ExpenseGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpenseGridViewCellValueChanged);
            this.ExpenseGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.ExpenseGridView_RowsRemoved);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(290, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 744);
            this.Controls.Add(this.GridViewPanel);
            this.Controls.Add(this.EditPanel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.TitlePanel);
            this.Controls.Add(this.SidePanel);
            this.Controls.Add(this.panel5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SidePanel.ResumeLayout(false);
            this.EditModePanel.ResumeLayout(false);
            this.ViewPanel.ResumeLayout(false);
            this.ExpensePanel.ResumeLayout(false);
            this.ExpensePanel.PerformLayout();
            this.AddNewPanel.ResumeLayout(false);
            this.AddNewPanel.PerformLayout();
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.EditPanel.ResumeLayout(false);
            this.FilterPanel.ResumeLayout(false);
            this.FilterPanel.PerformLayout();
            this.GridViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddExpenseButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button MonthViewButton;
        private System.Windows.Forms.Button DayViewButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button AddCategory;
        private System.Windows.Forms.Button RemoveCategory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Button SidePanelButton;
        private System.Windows.Forms.Label SideViewLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.Panel EditPanel;
        private System.Windows.Forms.Panel FilterPanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CustomSearchBoxTo;
        private System.Windows.Forms.ComboBox FilterBox;
        private System.Windows.Forms.TextBox CustomSearchBoxFrom;
        private System.Windows.Forms.Button FilterSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Panel ExpensePanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel AddNewPanel;
        private System.Windows.Forms.Button AddOkButton;
        private System.Windows.Forms.TextBox valueBox;
        private System.Windows.Forms.ComboBox BudgetComboBox;
        private System.Windows.Forms.TextBox BudgetBox;
        private System.Windows.Forms.Button SetButton;
        private System.Windows.Forms.Button TotalButton;
        private System.Windows.Forms.Button RemoveAllutton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Panel GridViewPanel;
        private System.Windows.Forms.DataGridView ExpenseGridView;
        private System.Windows.Forms.Button ViewButton;
        private System.Windows.Forms.Panel ViewPanel;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Panel EditModePanel;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
    }
}

