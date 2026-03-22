using System.ComponentModel;

namespace LMS;

partial class Homepage
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
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(347, 25);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(302, 91);
        label1.TabIndex = 0;
        label1.Text = "Home Page";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(390, 201);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(229, 57);
        button1.TabIndex = 1;
        button1.Text = "Add book";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(390, 368);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(229, 57);
        button2.TabIndex = 2;
        button2.Text = "View books";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(390, 537);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(229, 57);
        button3.TabIndex = 3;
        button3.Text = "Logout";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // Homepage
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1008, 628);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label1);
        Text = "Homepage";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Label label1;

    #endregion
}