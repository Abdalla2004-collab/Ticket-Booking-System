using System.ComponentModel;

namespace LMS;

partial class CustomerDashboard
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
        label1 = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        comboBox1 = new System.Windows.Forms.ComboBox();
        label2 = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        button4 = new System.Windows.Forms.Button();
        dataGridView1 = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(489, 44);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(149, 45);
        label1.TabIndex = 0;
        label1.Text = "Welcome";
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(401, 132);
        textBox1.Name = "textBox1";
        textBox1.PlaceholderText = "Search";
        textBox1.Size = new System.Drawing.Size(335, 35);
        textBox1.TabIndex = 1;
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(784, 132);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(121, 38);
        comboBox1.TabIndex = 2;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.Location = new System.Drawing.Point(784, 53);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(137, 45);
        label2.TabIndex = 3;
        label2.Text = "category";
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(967, 127);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(128, 46);
        button1.TabIndex = 4;
        button1.Text = "Search";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(428, 636);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(156, 46);
        button2.TabIndex = 5;
        button2.Text = "Book event";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(646, 636);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(147, 46);
        button3.TabIndex = 6;
        button3.Text = "My Bookings";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // button4
        // 
        button4.Location = new System.Drawing.Point(556, 719);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(128, 46);
        button4.TabIndex = 7;
        button4.Text = "Logout";
        button4.UseVisualStyleBackColor = true;
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new System.Drawing.Point(156, 212);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 72;
        dataGridView1.Size = new System.Drawing.Size(952, 374);
        dataGridView1.TabIndex = 8;
        dataGridView1.Text = "dataGridView1";
        dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        // 
        // CustomerDashboard
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1179, 832);
        Controls.Add(dataGridView1);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label2);
        Controls.Add(comboBox1);
        Controls.Add(textBox1);
        Controls.Add(label1);
        Text = "CustomerDashboard";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.DataGridView dataGridView1;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;

    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Label label1;

    #endregion
}