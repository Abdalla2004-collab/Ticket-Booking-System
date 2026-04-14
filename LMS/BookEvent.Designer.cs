using System.ComponentModel;

namespace LMS;

partial class BookEvent
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
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.142858F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(178, 57);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(109, 45);
        label1.TabIndex = 0;
        label1.Text = "label1";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.142858F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.Location = new System.Drawing.Point(178, 161);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(112, 45);
        label2.TabIndex = 1;
        label2.Text = "label2";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.142858F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.Location = new System.Drawing.Point(178, 271);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(111, 45);
        label3.TabIndex = 2;
        label3.Text = "label3";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.142858F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        label4.Location = new System.Drawing.Point(178, 383);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(114, 45);
        label4.TabIndex = 3;
        label4.Text = "label4";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.142858F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        label5.Location = new System.Drawing.Point(178, 490);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(111, 45);
        label5.TabIndex = 4;
        label5.Text = "label5";
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(485, 614);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(114, 57);
        button1.TabIndex = 5;
        button1.Text = "Confirm";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(485, 702);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(114, 52);
        button3.TabIndex = 7;
        button3.Text = "Cancel";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click_1;
        // 
        // numericUpDown1
        // 
        numericUpDown1.Location = new System.Drawing.Point(737, 393);
        numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numericUpDown1.Name = "numericUpDown1";
        numericUpDown1.ReadOnly = true;
        numericUpDown1.Size = new System.Drawing.Size(127, 35);
        numericUpDown1.TabIndex = 8;
        numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // BookEvent
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1119, 809);
        Controls.Add(numericUpDown1);
        Controls.Add(button3);
        Controls.Add(button1);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Text = "BookEvent";
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.NumericUpDown numericUpDown1;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label label1;

    #endregion
}