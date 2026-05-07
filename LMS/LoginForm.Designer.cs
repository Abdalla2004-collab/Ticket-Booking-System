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
        panelMain = new System.Windows.Forms.Panel();
        tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
        panelButtons = new System.Windows.Forms.Panel();
        flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
        panelMain.SuspendLayout();
        tableLayoutPanelMain.SuspendLayout();
        panelButtons.SuspendLayout();
        flowLayoutPanelButtons.SuspendLayout();
        SuspendLayout();
        // 
        button1.AutoSize = true;
        button1.Location = new System.Drawing.Point(3, 3);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(180, 50);
        button1.TabIndex = 0;
        button1.Text = "Login";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.AutoSize = true;
        button2.Location = new System.Drawing.Point(189, 3);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(180, 50);
        button2.TabIndex = 1;
        button2.Text = "Register";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        textBox2.Name = "textBox2";
        textBox2.PasswordChar = '*';
        textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        textBox2.TabIndex = 2;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label1.Location = new System.Drawing.Point(119, 60);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(120, 35);
        label1.TabIndex = 3;
        label1.Text = "Password";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label2.Location = new System.Drawing.Point(119, 10);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(120, 35);
        label2.TabIndex = 4;
        label2.Text = "Email";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // 
        textBox1.Name = "textBox1";
        textBox1.PlaceholderText = "Enter your email";
        textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        textBox1.TabIndex = 5;

        // 
        // label3
        // 
        label3.Dock = System.Windows.Forms.DockStyle.Top;
        label3.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.Location = new System.Drawing.Point(0, 0);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(968, 120);
        label3.TabIndex = 6;
        label3.Text = "Login";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        // 
        panelMain.Controls.Add(tableLayoutPanelMain);
        panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        panelMain.Location = new System.Drawing.Point(0, 120);
        panelMain.Name = "panelMain";
        panelMain.Size = new System.Drawing.Size(968, 429);
        panelMain.TabIndex = 7;
        panelMain.AutoScroll = true;
        // 
        // tableLayoutPanelMain
        // 
        tableLayoutPanelMain.ColumnCount = 4;
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanelMain.Controls.Add(label2, 1, 1);
        tableLayoutPanelMain.Controls.Add(textBox1, 2, 1);
        tableLayoutPanelMain.Controls.Add(label1, 1, 2);
        tableLayoutPanelMain.Controls.Add(textBox2, 2, 2);
        tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanelMain.Name = "tableLayoutPanelMain";
        tableLayoutPanelMain.RowCount = 4;
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.Size = new System.Drawing.Size(968, 429);
        tableLayoutPanelMain.TabIndex = 0;
        // 
        // panelButtons
        // 
        TableLayoutPanel tableLayoutPanelButtons = new TableLayoutPanel();
        tableLayoutPanelButtons.ColumnCount = 3;
        tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelButtons.RowCount = 1;
        tableLayoutPanelButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanelButtons.Controls.Add(flowLayoutPanelButtons, 1, 0);
        tableLayoutPanelButtons.Dock = DockStyle.Fill;
        
        panelButtons.Controls.Add(tableLayoutPanelButtons);
        panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelButtons.Location = new System.Drawing.Point(0, 549);
        panelButtons.Name = "panelButtons";
        panelButtons.Size = new System.Drawing.Size(968, 120);
        panelButtons.TabIndex = 6;
        // 
        // flowLayoutPanelButtons
        // 
        flowLayoutPanelButtons.AutoSize = true;
        flowLayoutPanelButtons.Controls.Add(button1);
        flowLayoutPanelButtons.Controls.Add(button2);
        flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
        flowLayoutPanelButtons.Location = new System.Drawing.Point(296, 30);
        flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
        flowLayoutPanelButtons.Size = new System.Drawing.Size(375, 56);
        flowLayoutPanelButtons.TabIndex = 0;
        flowLayoutPanelButtons.WrapContents = false;
        flowLayoutPanelButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
        // 
        // LoginForm
        // 
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.MinimumSize = new System.Drawing.Size(600, 500);
        this.ClientSize = new System.Drawing.Size(968, 669);
        this.AcceptButton = this.button1;
        Text = "Ticket Booking System - Login";
        Controls.Add(panelMain);
        Controls.Add(panelButtons);
        Controls.Add(label3);

        panelMain.ResumeLayout(false);
        tableLayoutPanelMain.ResumeLayout(false);
        tableLayoutPanelMain.PerformLayout();
        panelButtons.ResumeLayout(false);
        panelButtons.PerformLayout();
        flowLayoutPanelButtons.ResumeLayout(false);
        flowLayoutPanelButtons.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.MaskedTextBox textBox2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
    private System.Windows.Forms.Panel panelButtons;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;

    #endregion
}