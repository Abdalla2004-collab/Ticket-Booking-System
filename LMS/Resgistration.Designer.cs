using System.ComponentModel;

namespace LMS;

partial class Resgistration
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
        label1 = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        textBox3 = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        textBox4 = new System.Windows.Forms.TextBox();
        button2 = new System.Windows.Forms.Button();
        label5 = new System.Windows.Forms.Label();
        comboBoxRole = new System.Windows.Forms.ComboBox();
        label6 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(519, 612);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(185, 55);
        button1.TabIndex = 0;
        button1.Text = "Register";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(117, 231);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(181, 35);
        label1.TabIndex = 1;
        label1.Text = "Full name";
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(319, 231);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(634, 35);
        textBox1.TabIndex = 2;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(319, 309);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(634, 35);
        textBox2.TabIndex = 3;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(117, 309);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(181, 35);
        label2.TabIndex = 4;
        label2.Text = "Email";
        // 
        // textBox3
        // 
        textBox3.Location = new System.Drawing.Point(319, 377);
        textBox3.Name = "textBox3";
        textBox3.Size = new System.Drawing.Size(634, 35);
        textBox3.TabIndex = 5;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(117, 391);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(181, 35);
        label3.TabIndex = 6;
        label3.Text = "Password";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(117, 461);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(181, 35);
        label4.TabIndex = 7;
        label4.Text = "Confirm Password";
        // 
        // textBox4
        // 
        textBox4.Location = new System.Drawing.Point(319, 461);
        textBox4.Name = "textBox4";
        textBox4.Size = new System.Drawing.Size(634, 35);
        textBox4.TabIndex = 8;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(519, 718);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(185, 55);
        button2.TabIndex = 9;
        button2.Text = "Back to login";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // label5
        // 
        label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label5.Location = new System.Drawing.Point(334, 85);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(425, 68);
        label5.TabIndex = 10;
        label5.Text = "Registration page";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // comboBoxRole
        // 
        comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxRole.FormattingEnabled = true;
        comboBoxRole.Items.AddRange(new object[] { "Organiser", "Customer" });
        comboBoxRole.Location = new System.Drawing.Point(319, 534);
        comboBoxRole.Name = "comboBoxRole";
        comboBoxRole.Size = new System.Drawing.Size(291, 38);
        comboBoxRole.TabIndex = 11;
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(117, 537);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(181, 35);
        label6.TabIndex = 12;
        label6.Text = "Role";
        // 
        // Resgistration
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1110, 832);
        Controls.Add(label6);
        Controls.Add(comboBoxRole);
        Controls.Add(label5);
        Controls.Add(button2);
        Controls.Add(textBox4);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(textBox3);
        Controls.Add(label2);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(label1);
        Controls.Add(button1);
        Text = "Resgistration";
        Load += Resgistration_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label6;

    private System.Windows.Forms.ComboBox comboBoxRole;

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBox4;

    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox1;

    #endregion
}