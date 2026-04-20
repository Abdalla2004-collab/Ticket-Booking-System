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
        buttonBack = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        labelOrganiser = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        textBoxTitle = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
        textBoxTickets = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        textBoxPrice = new System.Windows.Forms.TextBox();
        price = new System.Windows.Forms.Label();
        comboBoxVenue = new System.Windows.Forms.ComboBox();
        label6 = new System.Windows.Forms.Label();
        comboBoxCategory = new System.Windows.Forms.ComboBox();
        label7 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // buttonBack
        // 
        buttonBack.Location = new System.Drawing.Point(552, 932);
        buttonBack.Name = "buttonBack";
        buttonBack.Size = new System.Drawing.Size(209, 56);
        buttonBack.TabIndex = 0;
        buttonBack.Text = "Close";
        buttonBack.UseVisualStyleBackColor = true;
        buttonBack.Click += buttonBack_Click_1;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(552, 850);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(209, 50);
        button2.TabIndex = 1;
        button2.Text = "Add event";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // labelOrganiser
        // 
        labelOrganiser.Font = new System.Drawing.Font("Segoe UI", 14.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelOrganiser.Location = new System.Drawing.Point(304, 41);
        labelOrganiser.Name = "labelOrganiser";
        labelOrganiser.Size = new System.Drawing.Size(720, 89);
        labelOrganiser.TabIndex = 2;
        labelOrganiser.Text = "Add events";
        labelOrganiser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        labelOrganiser.Click += label1_Click;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(205, 227);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(153, 35);
        label2.TabIndex = 3;
        label2.Text = "Event name";
        // 
        // textBoxTitle
        // 
        textBoxTitle.Location = new System.Drawing.Point(364, 227);
        textBoxTitle.Name = "textBoxTitle";
        textBoxTitle.Size = new System.Drawing.Size(559, 35);
        textBoxTitle.TabIndex = 4;
        textBoxTitle.TextChanged += textBox1_TextChanged;
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
        dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
        // 
        // dateTimePicker2
        // 
        dateTimePicker2.Location = new System.Drawing.Point(364, 298);
        dateTimePicker2.Name = "dateTimePicker2";
        dateTimePicker2.Size = new System.Drawing.Size(268, 35);
        dateTimePicker2.TabIndex = 11;
        dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
        // 
        // textBoxTickets
        // 
        textBoxTickets.Location = new System.Drawing.Point(364, 450);
        textBoxTickets.Name = "textBoxTickets";
        textBoxTickets.Size = new System.Drawing.Size(268, 35);
        textBoxTickets.TabIndex = 12;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(205, 453);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(153, 35);
        label1.TabIndex = 13;
        label1.Text = "Tickets";
        // 
        // textBoxPrice
        // 
        textBoxPrice.Location = new System.Drawing.Point(364, 539);
        textBoxPrice.Name = "textBoxPrice";
        textBoxPrice.Size = new System.Drawing.Size(268, 35);
        textBoxPrice.TabIndex = 14;
        // 
        // price
        // 
        price.Location = new System.Drawing.Point(205, 539);
        price.Name = "price";
        price.Size = new System.Drawing.Size(153, 35);
        price.TabIndex = 15;
        price.Text = "Price";
        price.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        price.Click += label5_Click;
        // 
        // comboBoxVenue
        // 
        comboBoxVenue.FormattingEnabled = true;
        comboBoxVenue.Location = new System.Drawing.Point(364, 622);
        comboBoxVenue.Name = "comboBoxVenue";
        comboBoxVenue.Size = new System.Drawing.Size(559, 38);
        comboBoxVenue.TabIndex = 16;
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(205, 625);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(153, 35);
        label6.TabIndex = 17;
        label6.Text = "Venue";
        label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // comboBoxCategory
        // 
        comboBoxCategory.FormattingEnabled = true;
        comboBoxCategory.Location = new System.Drawing.Point(364, 711);
        comboBoxCategory.Name = "comboBoxCategory";
        comboBoxCategory.Size = new System.Drawing.Size(268, 38);
        comboBoxCategory.TabIndex = 18;
        // 
        // label7
        // 
        label7.Location = new System.Drawing.Point(205, 714);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(153, 35);
        label7.TabIndex = 19;
        label7.Text = "Cetegory";
        label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // AddEvents
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1300, 1103);
        Controls.Add(label7);
        Controls.Add(comboBoxCategory);
        Controls.Add(label6);
        Controls.Add(comboBoxVenue);
        Controls.Add(price);
        Controls.Add(textBoxPrice);
        Controls.Add(label1);
        Controls.Add(textBoxTickets);
        Controls.Add(dateTimePicker2);
        Controls.Add(dateTimePicker1);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(textBoxTitle);
        Controls.Add(label2);
        Controls.Add(labelOrganiser);
        Controls.Add(button2);
        Controls.Add(buttonBack);
        Text = "AddBooks";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ComboBox comboBoxCategory;
    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.Label label6;

    private System.Windows.Forms.ComboBox comboBoxVenue;

    private System.Windows.Forms.TextBox textBoxPrice;
    private System.Windows.Forms.Label price;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.TextBox textBoxTickets;

    private System.Windows.Forms.DateTimePicker dateTimePicker1;
    private System.Windows.Forms.DateTimePicker dateTimePicker2;

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBoxTitle;

    private System.Windows.Forms.Button buttonBack;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Label labelOrganiser;

    #endregion
}