using System.ComponentModel;

namespace LMS;

partial class LoginForm
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
        textBox2 = new System.Windows.Forms.MaskedTextBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(403, 464);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(180, 50);
        button1.TabIndex = 0;
        button1.Text = "Login";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(403, 540);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(180, 50);
        button2.TabIndex = 1;
        button2.Text = "Register";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(290, 337);
        textBox2.Name = "textBox2";
        textBox2.PasswordChar = '*';
        textBox2.Size = new System.Drawing.Size(613, 35);
        textBox2.TabIndex = 2;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(119, 337);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(165, 35);
        label1.TabIndex = 3;
        label1.Text = "Password";
        label1.Click += label1_Click;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(119, 282);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(165, 35);
        label2.TabIndex = 4;
        label2.Text = "Email";
        label2.Click += label2_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(290, 282);
        textBox1.Name = "textBox1";
        textBox1.PlaceholderText = "Enter your email";
        textBox1.Size = new System.Drawing.Size(613, 35);
        textBox1.TabIndex = 5;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.Location = new System.Drawing.Point(403, 82);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(196, 71);
        label3.TabIndex = 6;
        label3.Text = "Login";
        label3.Click += label3_Click_1;
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(968, 669);
        Controls.Add(label3);
        Controls.Add(textBox1);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(textBox2);
        Controls.Add(button2);
        Controls.Add(button1);
        Text = "LoginForm";
        Load += LoginForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.MaskedTextBox textBox2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Button button1;

    #endregion
}