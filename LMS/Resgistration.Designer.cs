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
        button1.Size = new System.Drawing.Size(185, 55);
        button1.TabIndex = 0;
        button1.Text = "Register";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label1.Location = new System.Drawing.Point(3, 100);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(216, 60);
        label1.TabIndex = 1;
        label1.Text = "Full name";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBox1
        // 
        textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        textBox1.Location = new System.Drawing.Point(225, 100);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(660, 35);
        textBox1.TabIndex = 2;
        // 
        // textBox2
        // 
        textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        textBox2.Location = new System.Drawing.Point(225, 160);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(660, 35);
        textBox2.TabIndex = 3;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label2.Location = new System.Drawing.Point(3, 160);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(216, 60);
        label2.TabIndex = 4;
        label2.Text = "Email";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBox3
        // 
        textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        textBox3.Location = new System.Drawing.Point(225, 220);
        textBox3.Name = "textBox3";
        textBox3.Size = new System.Drawing.Size(660, 35);
        textBox3.TabIndex = 5;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label3.Location = new System.Drawing.Point(3, 220);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(216, 60);
        label3.TabIndex = 6;
        label3.Text = "Password";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label4.Location = new System.Drawing.Point(3, 280);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(216, 60);
        label4.TabIndex = 7;
        label4.Text = "Confirm Password";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBox4
        // 
        textBox4.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        textBox4.Location = new System.Drawing.Point(225, 280);
        textBox4.Name = "textBox4";
        textBox4.Size = new System.Drawing.Size(660, 35);
        textBox4.TabIndex = 8;
        // 
        button2.AutoSize = true;
        button2.Location = new System.Drawing.Point(194, 3);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(185, 55);
        button2.TabIndex = 9;
        button2.Text = "Go back";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // label5
        // 
        label5.Dock = System.Windows.Forms.DockStyle.Top;
        label5.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label5.Location = new System.Drawing.Point(0, 0);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(1110, 100);
        label5.TabIndex = 10;
        label5.Text = "Registration";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // comboBoxRole
        // 
        comboBoxRole.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxRole.FormattingEnabled = true;
        comboBoxRole.Items.AddRange(new object[] { "Organiser", "Customer" });
        comboBoxRole.Location = new System.Drawing.Point(225, 340);
        comboBoxRole.Name = "comboBoxRole";
        comboBoxRole.Size = new System.Drawing.Size(660, 38);
        comboBoxRole.TabIndex = 11;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label6.Location = new System.Drawing.Point(3, 340);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(216, 60);
        label6.TabIndex = 12;
        label6.Text = "Role";
        label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        panelMain.Controls.Add(tableLayoutPanelMain);
        panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        panelMain.Location = new System.Drawing.Point(0, 100);
        panelMain.Name = "panelMain";
        panelMain.Size = new System.Drawing.Size(1110, 612);
        panelMain.TabIndex = 13;
        panelMain.AutoScroll = true;
        // 
        // tableLayoutPanelMain
        // 
        tableLayoutPanelMain.ColumnCount = 4;
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        tableLayoutPanelMain.Controls.Add(label1, 1, 1);
        tableLayoutPanelMain.Controls.Add(textBox1, 2, 1);
        tableLayoutPanelMain.Controls.Add(label2, 1, 2);
        tableLayoutPanelMain.Controls.Add(textBox2, 2, 2);
        tableLayoutPanelMain.Controls.Add(label3, 1, 3);
        tableLayoutPanelMain.Controls.Add(textBox3, 2, 3);
        tableLayoutPanelMain.Controls.Add(label4, 1, 4);
        tableLayoutPanelMain.Controls.Add(textBox4, 2, 4);
        tableLayoutPanelMain.Controls.Add(label6, 1, 5);
        tableLayoutPanelMain.Controls.Add(comboBoxRole, 2, 5);
        tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanelMain.Name = "tableLayoutPanelMain";
        tableLayoutPanelMain.RowCount = 7;
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.Size = new System.Drawing.Size(1110, 612);
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
        panelButtons.Location = new System.Drawing.Point(0, 712);
        panelButtons.Name = "panelButtons";
        panelButtons.Size = new System.Drawing.Size(1110, 120);
        panelButtons.TabIndex = 13;
        // 
        // flowLayoutPanelButtons
        // 
        flowLayoutPanelButtons.AutoSize = true;
        flowLayoutPanelButtons.Controls.Add(button1);
        flowLayoutPanelButtons.Controls.Add(button2);
        flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
        flowLayoutPanelButtons.Location = new System.Drawing.Point(364, 30);
        flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
        flowLayoutPanelButtons.Size = new System.Drawing.Size(382, 61);
        flowLayoutPanelButtons.TabIndex = 0;
        flowLayoutPanelButtons.WrapContents = false;
        flowLayoutPanelButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
        flowLayoutPanelButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
        // 
        // Resgistration
        // 
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.MinimumSize = new System.Drawing.Size(800, 600);
        this.ClientSize = new System.Drawing.Size(1110, 832);
        Controls.Add(panelMain);
        Controls.Add(panelButtons);
        Controls.Add(label5);
        this.AcceptButton = this.button1;
        this.CancelButton = this.button2;
        Text = "Create New Account";
        Load += Resgistration_Load;
        panelMain.ResumeLayout(false);
        tableLayoutPanelMain.ResumeLayout(false);
        tableLayoutPanelMain.PerformLayout();
        panelButtons.ResumeLayout(false);
        panelButtons.PerformLayout();
        flowLayoutPanelButtons.ResumeLayout(false);
        flowLayoutPanelButtons.PerformLayout();
        ResumeLayout(false);
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
    
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
    private System.Windows.Forms.Panel panelButtons;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;

    #endregion
}