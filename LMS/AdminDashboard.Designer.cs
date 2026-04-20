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
        button2 = new System.Windows.Forms.Button();
        TabControl1 = new System.Windows.Forms.TabControl();
        tabPage1 = new System.Windows.Forms.TabPage();
        dataGridView1 = new System.Windows.Forms.DataGridView();
        button7 = new System.Windows.Forms.Button();
        button6 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        tabPage2 = new System.Windows.Forms.TabPage();
        dataGridView2 = new System.Windows.Forms.DataGridView();
        button4 = new System.Windows.Forms.Button();
        tabPage3 = new System.Windows.Forms.TabPage();
        label4 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        textBox3 = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
        textBox1 = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        button5 = new System.Windows.Forms.Button();
        tabPage4 = new System.Windows.Forms.TabPage();
        dataGridView3 = new System.Windows.Forms.DataGridView();
        labelDiscountTitle = new System.Windows.Forms.Label();
        labelDiscountCode = new System.Windows.Forms.Label();
        textBoxDiscountCode = new System.Windows.Forms.TextBox();
        labelPercentage = new System.Windows.Forms.Label();
        numericPercentage = new System.Windows.Forms.NumericUpDown();
        buttonCreateDiscount = new System.Windows.Forms.Button();
        buttonToggleDiscount = new System.Windows.Forms.Button();
        button8 = new System.Windows.Forms.Button();
        TabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        tabPage2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
        tabPage3.SuspendLayout();
        tabPage4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericPercentage).BeginInit();
        SuspendLayout();
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(427, 536);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(136, 41);
        button2.TabIndex = 1;
        button2.Text = "Log out";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click_1;
        // 
        // TabControl1
        // 
        TabControl1.Controls.Add(tabPage1);
        TabControl1.Controls.Add(tabPage2);
        TabControl1.Controls.Add(tabPage3);
        TabControl1.Controls.Add(tabPage4);
        TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        TabControl1.Location = new System.Drawing.Point(0, 0);
        TabControl1.Name = "TabControl1";
        TabControl1.SelectedIndex = 0;
        TabControl1.Size = new System.Drawing.Size(910, 670);
        TabControl1.TabIndex = 4;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(dataGridView1);
        tabPage1.Controls.Add(button7);
        tabPage1.Controls.Add(button6);
        tabPage1.Controls.Add(button3);
        tabPage1.Location = new System.Drawing.Point(4, 39);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new System.Windows.Forms.Padding(3);
        tabPage1.Size = new System.Drawing.Size(902, 627);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Pending Events";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new System.Drawing.Point(114, 32);
        dataGridView1.MultiSelect = false;
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowHeadersWidth = 72;
        dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.Size = new System.Drawing.Size(723, 396);
        dataGridView1.TabIndex = 3;
        dataGridView1.Text = "dataGridView1";
        // 
        // button7
        // 
        button7.Location = new System.Drawing.Point(512, 491);
        button7.Name = "button7";
        button7.Size = new System.Drawing.Size(143, 41);
        button7.TabIndex = 2;
        button7.Text = "Reject Event";
        button7.UseVisualStyleBackColor = true;
        button7.Click += button7_Click;
        // 
        // button6
        // 
        button6.Location = new System.Drawing.Point(216, 491);
        button6.Name = "button6";
        button6.Size = new System.Drawing.Size(159, 41);
        button6.TabIndex = 1;
        button6.Text = "Approve Event";
        button6.UseVisualStyleBackColor = true;
        button6.Click += button6_Click;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(375, 557);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(143, 41);
        button3.TabIndex = 0;
        button3.Text = "Log out";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(dataGridView2);
        tabPage2.Controls.Add(button4);
        tabPage2.Controls.Add(button2);
        tabPage2.Location = new System.Drawing.Point(4, 39);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new System.Windows.Forms.Padding(3);
        tabPage2.Size = new System.Drawing.Size(902, 627);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Manage Users";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // dataGridView2
        // 
        dataGridView2.AllowUserToAddRows = false;
        dataGridView2.AllowUserToDeleteRows = false;
        dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView2.Location = new System.Drawing.Point(54, 36);
        dataGridView2.MultiSelect = false;
        dataGridView2.Name = "dataGridView2";
        dataGridView2.ReadOnly = true;
        dataGridView2.RowHeadersWidth = 72;
        dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dataGridView2.Size = new System.Drawing.Size(816, 396);
        dataGridView2.TabIndex = 3;
        // 
        // button4
        // 
        button4.Location = new System.Drawing.Point(427, 470);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(136, 41);
        button4.TabIndex = 2;
        button4.Text = "Delete User";
        button4.UseVisualStyleBackColor = true;
        button4.Click += button4_Click;
        // 
        // tabPage3
        // 
        tabPage3.Controls.Add(label4);
        tabPage3.Controls.Add(label3);
        tabPage3.Controls.Add(label2);
        tabPage3.Controls.Add(textBox3);
        tabPage3.Controls.Add(textBox2);
        tabPage3.Controls.Add(textBox1);
        tabPage3.Controls.Add(button1);
        tabPage3.Controls.Add(label1);
        tabPage3.Controls.Add(button5);
        tabPage3.Location = new System.Drawing.Point(4, 39);
        tabPage3.Name = "tabPage3";
        tabPage3.Padding = new System.Windows.Forms.Padding(3);
        tabPage3.Size = new System.Drawing.Size(902, 627);
        tabPage3.TabIndex = 2;
        tabPage3.Text = "Add Venue";
        tabPage3.UseVisualStyleBackColor = true;
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(170, 140);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(152, 36);
        label4.TabIndex = 8;
        label4.Text = "Venue Name";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(170, 216);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(152, 36);
        label3.TabIndex = 7;
        label3.Text = "Address";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(170, 307);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(152, 36);
        label2.TabIndex = 6;
        label2.Text = "Capacity";
        // 
        // textBox3
        // 
        textBox3.Location = new System.Drawing.Point(361, 304);
        textBox3.Name = "textBox3";
        textBox3.Size = new System.Drawing.Size(120, 35);
        textBox3.TabIndex = 5;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(361, 216);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(397, 35);
        textBox2.TabIndex = 4;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(361, 141);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(397, 35);
        textBox1.TabIndex = 3;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(419, 474);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(134, 41);
        button1.TabIndex = 2;
        button1.Text = "Add Venue";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(385, 22);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(152, 36);
        label1.TabIndex = 1;
        label1.Text = "Add a Venue";
        // 
        // button5
        // 
        button5.Location = new System.Drawing.Point(419, 542);
        button5.Name = "button5";
        button5.Size = new System.Drawing.Size(134, 39);
        button5.TabIndex = 0;
        button5.Text = "Log out";
        button5.UseVisualStyleBackColor = true;
        button5.Click += button5_Click;
        // 
        // tabPage4 — Discount Codes
        // 
        tabPage4.Controls.Add(labelDiscountTitle);
        tabPage4.Controls.Add(dataGridView3);
        tabPage4.Controls.Add(labelDiscountCode);
        tabPage4.Controls.Add(textBoxDiscountCode);
        tabPage4.Controls.Add(labelPercentage);
        tabPage4.Controls.Add(numericPercentage);
        tabPage4.Controls.Add(buttonCreateDiscount);
        tabPage4.Controls.Add(buttonToggleDiscount);
        tabPage4.Controls.Add(button8);
        tabPage4.Location = new System.Drawing.Point(4, 39);
        tabPage4.Name = "tabPage4";
        tabPage4.Padding = new System.Windows.Forms.Padding(3);
        tabPage4.Size = new System.Drawing.Size(902, 627);
        tabPage4.TabIndex = 3;
        tabPage4.Text = "Discount Codes";
        tabPage4.UseVisualStyleBackColor = true;
        // 
        // labelDiscountTitle
        // 
        labelDiscountTitle.Font = new System.Drawing.Font("Segoe UI", 14.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelDiscountTitle.Location = new System.Drawing.Point(320, 15);
        labelDiscountTitle.Name = "labelDiscountTitle";
        labelDiscountTitle.Size = new System.Drawing.Size(300, 40);
        labelDiscountTitle.TabIndex = 10;
        labelDiscountTitle.Text = "Discount Codes";
        labelDiscountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // dataGridView3
        // 
        dataGridView3.AllowUserToAddRows = false;
        dataGridView3.AllowUserToDeleteRows = false;
        dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView3.Location = new System.Drawing.Point(54, 70);
        dataGridView3.MultiSelect = false;
        dataGridView3.Name = "dataGridView3";
        dataGridView3.ReadOnly = true;
        dataGridView3.RowHeadersWidth = 72;
        dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dataGridView3.Size = new System.Drawing.Size(800, 300);
        dataGridView3.TabIndex = 0;
        // 
        // labelDiscountCode
        // 
        labelDiscountCode.Location = new System.Drawing.Point(100, 400);
        labelDiscountCode.Name = "labelDiscountCode";
        labelDiscountCode.Size = new System.Drawing.Size(130, 36);
        labelDiscountCode.TabIndex = 1;
        labelDiscountCode.Text = "Code:";
        // 
        // textBoxDiscountCode
        // 
        textBoxDiscountCode.Location = new System.Drawing.Point(240, 397);
        textBoxDiscountCode.Name = "textBoxDiscountCode";
        textBoxDiscountCode.PlaceholderText = "e.g. SAVE20";
        textBoxDiscountCode.Size = new System.Drawing.Size(200, 35);
        textBoxDiscountCode.TabIndex = 2;
        // 
        // labelPercentage
        // 
        labelPercentage.Location = new System.Drawing.Point(470, 400);
        labelPercentage.Name = "labelPercentage";
        labelPercentage.Size = new System.Drawing.Size(130, 36);
        labelPercentage.TabIndex = 3;
        labelPercentage.Text = "Percentage:";
        // 
        // numericPercentage
        // 
        numericPercentage.Location = new System.Drawing.Point(610, 397);
        numericPercentage.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numericPercentage.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
        numericPercentage.Name = "numericPercentage";
        numericPercentage.Size = new System.Drawing.Size(80, 35);
        numericPercentage.TabIndex = 4;
        numericPercentage.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // buttonCreateDiscount
        // 
        buttonCreateDiscount.Location = new System.Drawing.Point(300, 470);
        buttonCreateDiscount.Name = "buttonCreateDiscount";
        buttonCreateDiscount.Size = new System.Drawing.Size(160, 41);
        buttonCreateDiscount.TabIndex = 5;
        buttonCreateDiscount.Text = "Create Code";
        buttonCreateDiscount.UseVisualStyleBackColor = true;
        buttonCreateDiscount.Click += buttonCreateDiscount_Click;
        // 
        // buttonToggleDiscount
        // 
        buttonToggleDiscount.Location = new System.Drawing.Point(500, 470);
        buttonToggleDiscount.Name = "buttonToggleDiscount";
        buttonToggleDiscount.Size = new System.Drawing.Size(200, 41);
        buttonToggleDiscount.TabIndex = 6;
        buttonToggleDiscount.Text = "Toggle Active";
        buttonToggleDiscount.UseVisualStyleBackColor = true;
        buttonToggleDiscount.Click += buttonToggleDiscount_Click;
        // 
        // button8 — Logout on Discounts tab
        // 
        button8.Location = new System.Drawing.Point(400, 547);
        button8.Name = "button8";
        button8.Size = new System.Drawing.Size(136, 41);
        button8.TabIndex = 7;
        button8.Text = "Log out";
        button8.UseVisualStyleBackColor = true;
        button8.Click += button8_Click;
        // 
        // AdminDashboard
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(910, 670);
        Controls.Add(TabControl1);
        Text = "AdminDashboard";
        TabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        tabPage2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
        tabPage3.ResumeLayout(false);
        tabPage3.PerformLayout();
        tabPage4.ResumeLayout(false);
        tabPage4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericPercentage).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.DataGridView dataGridView1;

    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.Button button7;

    private System.Windows.Forms.Button button4;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.Button button5;

    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.TabControl TabControl1;

    private System.Windows.Forms.TabControl Tab;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;

    private System.Windows.Forms.Button button2;

    #endregion

    private DataGridView dataGridView2;
    private TabPage tabPage4;
    private DataGridView dataGridView3;
    
    private System.Windows.Forms.Label labelDiscountTitle;
    private System.Windows.Forms.Label labelDiscountCode;
    private System.Windows.Forms.TextBox textBoxDiscountCode;
    private System.Windows.Forms.Label labelPercentage;
    private System.Windows.Forms.NumericUpDown numericPercentage;
    private System.Windows.Forms.Button buttonCreateDiscount;
    private System.Windows.Forms.Button buttonToggleDiscount;
    private System.Windows.Forms.Button button8;
}