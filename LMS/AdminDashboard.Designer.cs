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
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(431, 495);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(124, 41);
        button1.TabIndex = 0;
        button1.Text = "Add Venue";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click_1;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(431, 560);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(124, 41);
        button2.TabIndex = 1;
        button2.Text = "Logout";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click_1;
        // 
        // AdminDashboard
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(942, 650);
        Controls.Add(button2);
        Controls.Add(button1);
        Text = "AdminDashboard";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

    #endregion
}