using System.ComponentModel;

namespace LMS;

partial class EditEvent
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
        comboBoxCategory = new System.Windows.Forms.ComboBox();
        button1 = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        textBoxTitle = new System.Windows.Forms.TextBox();
        button2 = new System.Windows.Forms.Button();
        dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
        dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        comboBoxVenue = new System.Windows.Forms.ComboBox();
        textBoxPrice = new System.Windows.Forms.TextBox();
        textBoxTickets = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        label7 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // comboBoxCategory
        // 
        comboBoxCategory.FormattingEnabled = true;
        comboBoxCategory.Location = new System.Drawing.Point(392, 460);
        comboBoxCategory.Name = "comboBoxCategory";
        comboBoxCategory.Size = new System.Drawing.Size(213, 38);
        comboBoxCategory.TabIndex = 0;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(392, 605);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(185, 54);
        button1.TabIndex = 1;
        button1.Text = "Save";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(161, 82);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(147, 51);
        label1.TabIndex = 2;
        label1.Text = "Event name";
        label1.Click += label1_Click;
        // 
        // textBoxTitle
        // 
        textBoxTitle.Location = new System.Drawing.Point(392, 82);
        textBoxTitle.Name = "textBoxTitle";
        textBoxTitle.Size = new System.Drawing.Size(270, 35);
        textBoxTitle.TabIndex = 3;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(392, 696);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(185, 55);
        button2.TabIndex = 4;
        button2.Text = "Cancel";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // dateTimePicker2
        // 
        dateTimePicker2.Location = new System.Drawing.Point(392, 178);
        dateTimePicker2.Name = "dateTimePicker2";
        dateTimePicker2.Size = new System.Drawing.Size(270, 35);
        dateTimePicker2.TabIndex = 5;
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.CustomFormat = "hh:mm:ss";
        dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dateTimePicker1.Location = new System.Drawing.Point(392, 242);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.ShowUpDown = true;
        dateTimePicker1.Size = new System.Drawing.Size(270, 35);
        dateTimePicker1.TabIndex = 6;
        // 
        // comboBoxVenue
        // 
        comboBoxVenue.FormattingEnabled = true;
        comboBoxVenue.Location = new System.Drawing.Point(392, 534);
        comboBoxVenue.Name = "comboBoxVenue";
        comboBoxVenue.Size = new System.Drawing.Size(229, 38);
        comboBoxVenue.TabIndex = 7;
        // 
        // textBoxPrice
        // 
        textBoxPrice.Location = new System.Drawing.Point(392, 321);
        textBoxPrice.Name = "textBoxPrice";
        textBoxPrice.Size = new System.Drawing.Size(255, 35);
        textBoxPrice.TabIndex = 8;
        // 
        // textBoxTickets
        // 
        textBoxTickets.Location = new System.Drawing.Point(392, 391);
        textBoxTickets.Name = "textBoxTickets";
        textBoxTickets.Size = new System.Drawing.Size(220, 35);
        textBoxTickets.TabIndex = 9;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(161, 324);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(111, 51);
        label2.TabIndex = 10;
        label2.Text = "Price";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(161, 242);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(111, 51);
        label3.TabIndex = 11;
        label3.Text = "Event time";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(161, 384);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(111, 51);
        label4.TabIndex = 12;
        label4.Text = "Tickets";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(161, 463);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(111, 51);
        label5.TabIndex = 13;
        label5.Text = "Category";
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(161, 162);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(111, 51);
        label6.TabIndex = 14;
        label6.Text = "Event date";
        // 
        // label7
        // 
        label7.Location = new System.Drawing.Point(161, 534);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(111, 51);
        label7.TabIndex = 15;
        label7.Text = "Venue";
        // 
        // EditEvent
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(909, 806);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(textBoxTickets);
        Controls.Add(textBoxPrice);
        Controls.Add(comboBoxVenue);
        Controls.Add(dateTimePicker1);
        Controls.Add(dateTimePicker2);
        Controls.Add(button2);
        Controls.Add(textBoxTitle);
        Controls.Add(label1);
        Controls.Add(button1);
        Controls.Add(comboBoxCategory);
        Text = "EditEvent";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ComboBox comboBoxVenue;
    private System.Windows.Forms.TextBox textBoxPrice;
    private System.Windows.Forms.TextBox textBoxTickets;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.DateTimePicker dateTimePicker1;
    private System.Windows.Forms.DateTimePicker dateTimePicker2;

    private System.Windows.Forms.ComboBox comboBoxCategory;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBoxTitle;
    private System.Windows.Forms.Button button2;

    #endregion
}