using System.ComponentModel;

namespace LMS;

partial class AdminDashboard
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        TabControl1 = new System.Windows.Forms.TabControl();
        tabPage1 = new System.Windows.Forms.TabPage();
        tableLayoutPanelTab1 = new System.Windows.Forms.TableLayoutPanel();
        dataGridView1 = new System.Windows.Forms.DataGridView();
        flowLayoutPanelTab1Buttons = new System.Windows.Forms.FlowLayoutPanel();
        button6 = new System.Windows.Forms.Button();
        button7 = new System.Windows.Forms.Button();
        tabPage2 = new System.Windows.Forms.TabPage();
        tableLayoutPanelTab2 = new System.Windows.Forms.TableLayoutPanel();
        dataGridView2 = new System.Windows.Forms.DataGridView();
        button4 = new System.Windows.Forms.Button();
        tabPage3 = new System.Windows.Forms.TabPage();
        tableLayoutPanelTab3 = new System.Windows.Forms.TableLayoutPanel();
        labelAddVenueTitle = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        textBox2 = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        textBox3 = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        tabPage4 = new System.Windows.Forms.TabPage();
        tableLayoutPanelTab4 = new System.Windows.Forms.TableLayoutPanel();
        labelDiscountTitle = new System.Windows.Forms.Label();
        dataGridView3 = new System.Windows.Forms.DataGridView();
        panelGridContainer3 = new System.Windows.Forms.Panel();
        flowLayoutPanelDiscountInputs = new System.Windows.Forms.FlowLayoutPanel();
        labelDiscountCode = new System.Windows.Forms.Label();
        textBoxDiscountCode = new System.Windows.Forms.TextBox();
        labelPercentage = new System.Windows.Forms.Label();
        numericPercentage = new System.Windows.Forms.NumericUpDown();
        flowLayoutPanelDiscountButtons = new System.Windows.Forms.FlowLayoutPanel();
        buttonCreateDiscount = new System.Windows.Forms.Button();
        buttonToggleDiscount = new System.Windows.Forms.Button();
        tabPage5 = new System.Windows.Forms.TabPage();
        lblAnalytics = new System.Windows.Forms.Label();
        panelBottom = new System.Windows.Forms.Panel();
        buttonLogoutShared = new System.Windows.Forms.Button();
        labelDashboardTitle = new System.Windows.Forms.Label();
        TabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        tableLayoutPanelTab1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        flowLayoutPanelTab1Buttons.SuspendLayout();
        tabPage2.SuspendLayout();
        tableLayoutPanelTab2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
        tabPage3.SuspendLayout();
        tableLayoutPanelTab3.SuspendLayout();
        tabPage4.SuspendLayout();
        tableLayoutPanelTab4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
        flowLayoutPanelDiscountInputs.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numericPercentage).BeginInit();
        flowLayoutPanelDiscountButtons.SuspendLayout();
        tabPage5.SuspendLayout();
        panelBottom.SuspendLayout();
        SuspendLayout();
        // 
        // labelDashboardTitle
        // 
        labelDashboardTitle.Dock = System.Windows.Forms.DockStyle.Top;
        labelDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelDashboardTitle.Location = new System.Drawing.Point(0, 0);
        labelDashboardTitle.Name = "labelDashboardTitle";
        labelDashboardTitle.Size = new System.Drawing.Size(1000, 100);
        labelDashboardTitle.TabIndex = 0;
        labelDashboardTitle.Text = "Admin Dashboard";
        labelDashboardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // TabControl1
        // 
        TabControl1.Controls.Add(tabPage1);
        TabControl1.Controls.Add(tabPage2);
        TabControl1.Controls.Add(tabPage3);
        TabControl1.Controls.Add(tabPage4);
        TabControl1.Controls.Add(tabPage5);
        TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        TabControl1.Location = new System.Drawing.Point(0, 100);
        TabControl1.Name = "TabControl1";
        TabControl1.SelectedIndex = 0;
        TabControl1.Size = new System.Drawing.Size(1000, 500);
        TabControl1.TabIndex = 1;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(tableLayoutPanelTab1);
        tabPage1.Location = new System.Drawing.Point(4, 39);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new System.Windows.Forms.Padding(30);
        tabPage1.Size = new System.Drawing.Size(992, 457);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Pending Events";
        tabPage1.UseVisualStyleBackColor = true;
        tabPage1.AutoScroll = true;
        // 
        // tableLayoutPanelTab1
        // 
        tableLayoutPanelTab1.ColumnCount = 3;
        tableLayoutPanelTab1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
        tableLayoutPanelTab1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
        tableLayoutPanelTab1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
        tableLayoutPanelTab1.Controls.Add(dataGridView1, 1, 0);
        tableLayoutPanelTab1.Controls.Add(flowLayoutPanelTab1Buttons, 1, 1);
        tableLayoutPanelTab1.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelTab1.Location = new System.Drawing.Point(10, 10);
        tableLayoutPanelTab1.Name = "tableLayoutPanelTab1";
        tableLayoutPanelTab1.RowCount = 2;
        tableLayoutPanelTab1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
        tableLayoutPanelTab1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
        tableLayoutPanelTab1.Size = new System.Drawing.Size(972, 437);
        tableLayoutPanelTab1.TabIndex = 0;
        // 
        // dataGridView1
        // 
        dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridView1.Location = new System.Drawing.Point(51, 3);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.Size = new System.Drawing.Size(868, 351);
        dataGridView1.TabIndex = 0;
        // 
        // flowLayoutPanelTab1Buttons
        // 
        flowLayoutPanelTab1Buttons.Anchor = System.Windows.Forms.AnchorStyles.None;
        flowLayoutPanelTab1Buttons.AutoSize = true;
        flowLayoutPanelTab1Buttons.Controls.Add(button6);
        flowLayoutPanelTab1Buttons.Controls.Add(button7);
        flowLayoutPanelTab1Buttons.Location = new System.Drawing.Point(327, 368);
        flowLayoutPanelTab1Buttons.Name = "flowLayoutPanelTab1Buttons";
        flowLayoutPanelTab1Buttons.Size = new System.Drawing.Size(316, 58);
        flowLayoutPanelTab1Buttons.TabIndex = 1;
        flowLayoutPanelTab1Buttons.WrapContents = false;
        // 
        // button6
        // 
        button6.Location = new System.Drawing.Point(3, 3);
        button6.Name = "button6";
        button6.Size = new System.Drawing.Size(150, 50);
        button6.TabIndex = 0;
        button6.Text = "Approve";
        button6.Click += button6_Click;
        // 
        // button7
        // 
        button7.Location = new System.Drawing.Point(159, 3);
        button7.Name = "button7";
        button7.Size = new System.Drawing.Size(150, 50);
        button7.TabIndex = 1;
        button7.Text = "Reject";
        button7.Click += button7_Click;
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(tableLayoutPanelTab2);
        tabPage2.Location = new System.Drawing.Point(4, 39);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new System.Windows.Forms.Padding(30);
        tabPage2.Size = new System.Drawing.Size(992, 457);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Manage Users";
        tabPage2.UseVisualStyleBackColor = true;
        tabPage2.AutoScroll = true;
        // 
        // tableLayoutPanelTab2
        // 
        tableLayoutPanelTab2.ColumnCount = 3;
        tableLayoutPanelTab2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
        tableLayoutPanelTab2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
        tableLayoutPanelTab2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
        tableLayoutPanelTab2.Controls.Add(dataGridView2, 1, 0);
        tableLayoutPanelTab2.Controls.Add(button4, 1, 1);
        tableLayoutPanelTab2.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelTab2.Location = new System.Drawing.Point(10, 10);
        tableLayoutPanelTab2.Name = "tableLayoutPanelTab2";
        tableLayoutPanelTab2.RowCount = 2;
        tableLayoutPanelTab2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
        tableLayoutPanelTab2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
        tableLayoutPanelTab2.Size = new System.Drawing.Size(972, 437);
        tableLayoutPanelTab2.TabIndex = 0;
        // 
        // dataGridView2
        // 
        dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridView2.Location = new System.Drawing.Point(51, 3);
        dataGridView2.Name = "dataGridView2";
        dataGridView2.Size = new System.Drawing.Size(868, 351);
        dataGridView2.TabIndex = 0;
        // 
        // button4
        // 
        button4.Anchor = System.Windows.Forms.AnchorStyles.None;
        button4.Location = new System.Drawing.Point(410, 368);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(150, 50);
        button4.TabIndex = 1;
        button4.Text = "Delete User";
        button4.Click += button4_Click;
        // 
        // tabPage3
        // 
        tabPage3.Controls.Add(tableLayoutPanelTab3);
        tabPage3.Location = new System.Drawing.Point(4, 39);
        tabPage3.Name = "tabPage3";
        tabPage3.Padding = new System.Windows.Forms.Padding(30);
        tabPage3.Size = new System.Drawing.Size(992, 457);
        tabPage3.TabIndex = 2;
        tabPage3.Text = "Add Venue";
        tabPage3.UseVisualStyleBackColor = true;
        tabPage3.AutoScroll = true;
        // 
        // tableLayoutPanelTab3
        // 
        tableLayoutPanelTab3.ColumnCount = 3;
        tableLayoutPanelTab3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanelTab3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
        tableLayoutPanelTab3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanelTab3.Controls.Add(labelAddVenueTitle, 1, 0);
        tableLayoutPanelTab3.Controls.Add(label4, 0, 1);
        tableLayoutPanelTab3.Controls.Add(textBox1, 1, 1);
        tableLayoutPanelTab3.Controls.Add(label3, 0, 2);
        tableLayoutPanelTab3.Controls.Add(textBox2, 1, 2);
        tableLayoutPanelTab3.Controls.Add(label2, 0, 3);
        tableLayoutPanelTab3.Controls.Add(textBox3, 1, 3);
        tableLayoutPanelTab3.Controls.Add(button1, 1, 4);
        tableLayoutPanelTab3.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelTab3.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanelTab3.Name = "tableLayoutPanelTab3";
        tableLayoutPanelTab3.RowCount = 6;
        tableLayoutPanelTab3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
        tableLayoutPanelTab3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelTab3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelTab3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelTab3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
        tableLayoutPanelTab3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanelTab3.Size = new System.Drawing.Size(992, 457);
        tableLayoutPanelTab3.TabIndex = 0;
        // 
        // labelAddVenueTitle
        // 
        labelAddVenueTitle.Dock = System.Windows.Forms.DockStyle.Fill;
        labelAddVenueTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        labelAddVenueTitle.Location = new System.Drawing.Point(201, 0);
        labelAddVenueTitle.Name = "labelAddVenueTitle";
        labelAddVenueTitle.Size = new System.Drawing.Size(589, 60);
        labelAddVenueTitle.Text = "Add New Venue";
        labelAddVenueTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label4
        // 
        label4.Dock = System.Windows.Forms.DockStyle.Fill;
        label4.Location = new System.Drawing.Point(3, 60);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(192, 50);
        label4.Text = "Venue Name:";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBox1
        // 
        textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        textBox1.Location = new System.Drawing.Point(201, 63);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(589, 35);
        // 
        // label3
        // 
        label3.Dock = System.Windows.Forms.DockStyle.Fill;
        label3.Location = new System.Drawing.Point(3, 110);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(192, 50);
        label3.Text = "Address:";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBox2
        // 
        textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
        textBox2.Location = new System.Drawing.Point(201, 113);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(589, 35);
        // 
        // label2
        // 
        label2.Dock = System.Windows.Forms.DockStyle.Fill;
        label2.Location = new System.Drawing.Point(3, 160);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(192, 50);
        label2.Text = "Capacity:";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBox3
        // 
        textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
        textBox3.Location = new System.Drawing.Point(201, 163);
        textBox3.Name = "textBox3";
        textBox3.Size = new System.Drawing.Size(589, 35);
        // 
        // button1
        // 
        button1.Anchor = System.Windows.Forms.AnchorStyles.None;
        button1.Location = new System.Drawing.Point(420, 225);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(150, 50);
        button1.Text = "Add Venue";
        button1.Click += button1_Click;
        // 
        // tabPage4
        // 
        tabPage4.Controls.Add(tableLayoutPanelTab4);
        tabPage4.Location = new System.Drawing.Point(4, 39);
        tabPage4.Name = "tabPage4";
        tabPage4.Padding = new System.Windows.Forms.Padding(30);
        tabPage4.Size = new System.Drawing.Size(992, 457);
        tabPage4.TabIndex = 3;
        tabPage4.Text = "Discounts";
        tabPage4.UseVisualStyleBackColor = true;
        tabPage4.AutoScroll = true;
        // 
        // tableLayoutPanelTab4
        // 
        tableLayoutPanelTab4.ColumnCount = 3;
        tableLayoutPanelTab4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
        tableLayoutPanelTab4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
        tableLayoutPanelTab4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
        tableLayoutPanelTab4.Controls.Add(labelDiscountTitle, 1, 0);
        tableLayoutPanelTab4.Controls.Add(panelGridContainer3, 1, 1);
        tableLayoutPanelTab4.Controls.Add(flowLayoutPanelDiscountInputs, 1, 2);
        tableLayoutPanelTab4.Controls.Add(flowLayoutPanelDiscountButtons, 1, 3);
        tableLayoutPanelTab4.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelTab4.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanelTab4.Name = "tableLayoutPanelTab4";
        tableLayoutPanelTab4.RowCount = 4;
        tableLayoutPanelTab4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelTab4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
        tableLayoutPanelTab4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
        tableLayoutPanelTab4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
        tableLayoutPanelTab4.Size = new System.Drawing.Size(992, 457);
        tableLayoutPanelTab4.TabIndex = 0;
        // 
        // labelDiscountTitle
        // 
        labelDiscountTitle.Dock = System.Windows.Forms.DockStyle.Fill;
        labelDiscountTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        labelDiscountTitle.Location = new System.Drawing.Point(52, 0);
        labelDiscountTitle.Name = "labelDiscountTitle";
        labelDiscountTitle.Size = new System.Drawing.Size(886, 50);
        labelDiscountTitle.Text = "Manage Discounts";
        labelDiscountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // panelGridContainer3
        // 
        panelGridContainer3.Controls.Add(dataGridView3);
        panelGridContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
        panelGridContainer3.Location = new System.Drawing.Point(52, 53);
        panelGridContainer3.Name = "panelGridContainer3";
        panelGridContainer3.Padding = new System.Windows.Forms.Padding(10);
        panelGridContainer3.Size = new System.Drawing.Size(886, 154);
        panelGridContainer3.TabIndex = 4;
        // 
        // dataGridView3
        // 
        dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridView3.Location = new System.Drawing.Point(10, 10);
        dataGridView3.Name = "dataGridView3";
        dataGridView3.Size = new System.Drawing.Size(866, 134);
        dataGridView3.TabIndex = 1;
        // 
        // flowLayoutPanelDiscountInputs
        // 
        flowLayoutPanelDiscountInputs.Anchor = System.Windows.Forms.AnchorStyles.None;
        flowLayoutPanelDiscountInputs.AutoSize = true;
        flowLayoutPanelDiscountInputs.Controls.Add(labelDiscountCode);
        flowLayoutPanelDiscountInputs.Controls.Add(textBoxDiscountCode);
        flowLayoutPanelDiscountInputs.Controls.Add(labelPercentage);
        flowLayoutPanelDiscountInputs.Controls.Add(numericPercentage);
        flowLayoutPanelDiscountInputs.Location = new System.Drawing.Point(198, 222);
        flowLayoutPanelDiscountInputs.Name = "flowLayoutPanelDiscountInputs";
        flowLayoutPanelDiscountInputs.Size = new System.Drawing.Size(594, 41);
        flowLayoutPanelDiscountInputs.TabIndex = 2;
        flowLayoutPanelDiscountInputs.WrapContents = false;
        // 
        // labelDiscountCode
        // 
        labelDiscountCode.Location = new System.Drawing.Point(3, 0);
        labelDiscountCode.Name = "labelDiscountCode";
        labelDiscountCode.Size = new System.Drawing.Size(80, 35);
        labelDiscountCode.Text = "Code:";
        labelDiscountCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxDiscountCode
        // 
        textBoxDiscountCode.Location = new System.Drawing.Point(89, 3);
        textBoxDiscountCode.Name = "textBoxDiscountCode";
        textBoxDiscountCode.Size = new System.Drawing.Size(200, 35);
        // 
        // labelPercentage
        // 
        labelPercentage.Location = new System.Drawing.Point(295, 0);
        labelPercentage.Name = "labelPercentage";
        labelPercentage.Size = new System.Drawing.Size(120, 35);
        labelPercentage.Text = "Percent:";
        labelPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // numericPercentage
        // 
        numericPercentage.Location = new System.Drawing.Point(421, 3);
        numericPercentage.Name = "numericPercentage";
        numericPercentage.Size = new System.Drawing.Size(80, 35);
        // 
        // flowLayoutPanelDiscountButtons
        // 
        flowLayoutPanelDiscountButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
        flowLayoutPanelDiscountButtons.AutoSize = true;
        flowLayoutPanelDiscountButtons.Controls.Add(buttonCreateDiscount);
        flowLayoutPanelDiscountButtons.Controls.Add(buttonToggleDiscount);
        flowLayoutPanelDiscountButtons.Location = new System.Drawing.Point(311, 388);
        flowLayoutPanelDiscountButtons.Name = "flowLayoutPanelDiscountButtons";
        flowLayoutPanelDiscountButtons.Size = new System.Drawing.Size(368, 56);
        flowLayoutPanelDiscountButtons.TabIndex = 3;
        flowLayoutPanelDiscountButtons.WrapContents = false;
        // 
        // buttonCreateDiscount
        // 
        buttonCreateDiscount.Location = new System.Drawing.Point(3, 3);
        buttonCreateDiscount.Name = "buttonCreateDiscount";
        buttonCreateDiscount.Size = new System.Drawing.Size(180, 50);
        buttonCreateDiscount.Text = "Create Discount";
        buttonCreateDiscount.Click += buttonCreateDiscount_Click;
        // 
        // buttonToggleDiscount
        // 
        buttonToggleDiscount.Location = new System.Drawing.Point(189, 3);
        buttonToggleDiscount.Name = "buttonToggleDiscount";
        buttonToggleDiscount.Size = new System.Drawing.Size(180, 50);
        buttonToggleDiscount.Text = "Toggle Active";
        buttonToggleDiscount.Click += buttonToggleDiscount_Click;
        // 
        // tabPage5
        // 
        tabPage5.Controls.Add(lblAnalytics);
        tabPage5.Location = new System.Drawing.Point(4, 39);
        tabPage5.Name = "tabPage5";
        tabPage5.Padding = new System.Windows.Forms.Padding(30);
        tabPage5.Size = new System.Drawing.Size(992, 457);
        tabPage5.TabIndex = 4;
        tabPage5.Text = "Analytics";
        tabPage5.UseVisualStyleBackColor = true;
        tabPage5.AutoScroll = true;
        // 
        // lblAnalytics
        // 
        lblAnalytics.Dock = System.Windows.Forms.DockStyle.Fill;
        lblAnalytics.Font = new System.Drawing.Font("Segoe UI", 12F);
        lblAnalytics.Location = new System.Drawing.Point(30, 30);
        lblAnalytics.Name = "lblAnalytics";
        lblAnalytics.Size = new System.Drawing.Size(932, 397);
        lblAnalytics.Text = "Analytics Information";
        lblAnalytics.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // panelBottom
        // 
        panelBottom.Controls.Add(buttonLogoutShared);
        panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelBottom.Location = new System.Drawing.Point(0, 600);
        panelBottom.Name = "panelBottom";
        panelBottom.Size = new System.Drawing.Size(1000, 100);
        panelBottom.TabIndex = 2;
        // 
        // buttonLogoutShared
        // 
        buttonLogoutShared.Anchor = System.Windows.Forms.AnchorStyles.None;
        buttonLogoutShared.Location = new System.Drawing.Point(425, 25);
        buttonLogoutShared.Name = "buttonLogoutShared";
        buttonLogoutShared.Size = new System.Drawing.Size(150, 50);
        buttonLogoutShared.TabIndex = 0;
        buttonLogoutShared.Text = "Logout";
        buttonLogoutShared.Click += buttonLogoutShared_Click;
        // 
        // AdminDashboard
        // 
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.MinimumSize = new System.Drawing.Size(1024, 768);
        this.ClientSize = new System.Drawing.Size(1000, 700);
        Controls.Add(TabControl1);
        Controls.Add(panelBottom);
        Controls.Add(labelDashboardTitle);
        Text = "Admin Dashboard";
        TabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        tableLayoutPanelTab1.ResumeLayout(false);
        tableLayoutPanelTab1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        flowLayoutPanelTab1Buttons.ResumeLayout(false);
        tabPage2.ResumeLayout(false);
        tableLayoutPanelTab2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
        tabPage3.ResumeLayout(false);
        tableLayoutPanelTab3.ResumeLayout(false);
        tableLayoutPanelTab3.PerformLayout();
        tabPage4.ResumeLayout(false);
        tableLayoutPanelTab4.ResumeLayout(false);
        tableLayoutPanelTab4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
        flowLayoutPanelDiscountInputs.ResumeLayout(false);
        flowLayoutPanelDiscountInputs.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numericPercentage).EndInit();
        flowLayoutPanelDiscountButtons.ResumeLayout(false);
        flowLayoutPanelDiscountButtons.PerformLayout();
        tabPage5.ResumeLayout(false);
        panelBottom.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label lblAnalytics;
    private System.Windows.Forms.TabPage tabPage5;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.Button button7;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Label labelAddVenueTitle;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TabControl TabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Panel panelBottom;
    private System.Windows.Forms.Button buttonLogoutShared;
    private System.Windows.Forms.Label labelDashboardTitle;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTab1;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTab1Buttons;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTab2;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTab3;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTab4;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDiscountInputs;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDiscountButtons;
    private System.Windows.Forms.Panel panelGridContainer3;

    #endregion

    private System.Windows.Forms.DataGridView dataGridView2;
    private System.Windows.Forms.TabPage tabPage4;
    private System.Windows.Forms.DataGridView dataGridView3;
    private System.Windows.Forms.Label labelDiscountTitle;
    private System.Windows.Forms.Label labelDiscountCode;
    private System.Windows.Forms.TextBox textBoxDiscountCode;
    private System.Windows.Forms.Label labelPercentage;
    private System.Windows.Forms.NumericUpDown numericPercentage;
    private System.Windows.Forms.Button buttonCreateDiscount;
    private System.Windows.Forms.Button buttonToggleDiscount;
}