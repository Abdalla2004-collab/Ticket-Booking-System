using System.ComponentModel;

namespace LMS;

partial class ViewEvents
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
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(407, 599);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(233, 61);
        button1.TabIndex = 0;
        button1.Text = "Back to homepage";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 15.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(329, 31);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(400, 98);
        label1.TabIndex = 1;
        label1.Text = "Upcoming Events\r\n";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ViewEvents
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1044, 714);
        Controls.Add(label1);
        Controls.Add(button1);
        Text = "ViewBooks";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;

    #endregion
}