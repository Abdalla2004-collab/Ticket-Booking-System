using System.ComponentModel;

namespace LMS;

partial class ManageVenues
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
        textBox1 = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
        textBox3 = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(355, 340);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(131, 40);
        button1.TabIndex = 0;
        button1.Text = "Add Venue";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(355, 434);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(131, 43);
        button2.TabIndex = 1;
        button2.Text = "Go back";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click_1;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(283, 87);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(261, 35);
        textBox1.TabIndex = 2;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(283, 159);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(477, 35);
        textBox2.TabIndex = 3;
        // 
        // textBox3
        // 
        textBox3.Location = new System.Drawing.Point(283, 229);
        textBox3.Name = "textBox3";
        textBox3.Size = new System.Drawing.Size(133, 35);
        textBox3.TabIndex = 4;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(84, 90);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(131, 32);
        label1.TabIndex = 5;
        label1.Text = "Venue name";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(84, 159);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(103, 32);
        label2.TabIndex = 6;
        label2.Text = "Address";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(84, 229);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(103, 31);
        label3.TabIndex = 7;
        label3.Text = "Capacity";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(338, 22);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(131, 32);
        label4.TabIndex = 8;
        label4.Text = "Venues";
        // 
        // ManageVenues
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(828, 550);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(textBox3);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(button2);
        Controls.Add(button1);
        Text = "ManageVenues";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

    #endregion
}