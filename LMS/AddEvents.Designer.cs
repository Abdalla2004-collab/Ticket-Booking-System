using System.ComponentModel;

namespace LMS;

partial class AddEvents
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
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(442, 566);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(209, 56);
        button1.TabIndex = 0;
        button1.Text = "Back to homepage";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(442, 479);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(209, 50);
        button2.TabIndex = 1;
        button2.Text = "Add event";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(370, 43);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(332, 89);
        label1.TabIndex = 2;
        label1.Text = "Add events";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        label1.Click += label1_Click;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(205, 227);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(153, 35);
        label2.TabIndex = 3;
        label2.Text = "Event name";
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(364, 227);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(559, 35);
        textBox1.TabIndex = 4;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(205, 298);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(153, 35);
        label3.TabIndex = 8;
        label3.Text = "Date";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(205, 372);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(153, 35);
        label4.TabIndex = 9;
        label4.Text = "Time";
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.CustomFormat = "HH:mm:ss";
        dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dateTimePicker1.Location = new System.Drawing.Point(364, 372);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.ShowUpDown = true;
        dateTimePicker1.Size = new System.Drawing.Size(268, 35);
        dateTimePicker1.TabIndex = 10;
        // 
        // dateTimePicker2
        // 
        dateTimePicker2.Location = new System.Drawing.Point(364, 298);
        dateTimePicker2.Name = "dateTimePicker2";
        dateTimePicker2.Size = new System.Drawing.Size(268, 35);
        dateTimePicker2.TabIndex = 11;
        // 
        // AddEvents
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1043, 741);
        Controls.Add(dateTimePicker2);
        Controls.Add(dateTimePicker1);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(textBox1);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(button2);
        Controls.Add(button1);
        Text = "AddBooks";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.DateTimePicker dateTimePicker1;
    private System.Windows.Forms.DateTimePicker dateTimePicker2;

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Label label1;

    #endregion
}