using System.ComponentModel;

namespace LMS;

partial class MyBookings
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
        dataGridView1 = new System.Windows.Forms.DataGridView();
        labelTitle = new System.Windows.Forms.Label();
        panelBottom = new System.Windows.Forms.Panel();
        tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
        flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
        panelGridContainer = new System.Windows.Forms.Panel();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        panelBottom.SuspendLayout();
        tableLayoutPanelButtons.SuspendLayout();
        flowLayoutPanelButtons.SuspendLayout();
        SuspendLayout();
        // 
        // labelTitle
        // 
        labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
        labelTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelTitle.Location = new System.Drawing.Point(0, 0);
        labelTitle.Name = "labelTitle";
        labelTitle.Size = new System.Drawing.Size(1031, 100);
        labelTitle.TabIndex = 3;
        labelTitle.Text = "My Bookings";
        labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // panelGridContainer
        // 
        panelGridContainer.Controls.Add(dataGridView1);
        panelGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        panelGridContainer.Location = new System.Drawing.Point(0, 100);
        panelGridContainer.Name = "panelGridContainer";
        panelGridContainer.Padding = new System.Windows.Forms.Padding(20);
        panelGridContainer.Size = new System.Drawing.Size(1031, 630);
        panelGridContainer.TabIndex = 22;
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridView1.Location = new System.Drawing.Point(20, 20);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.Size = new System.Drawing.Size(991, 590);
        dataGridView1.TabIndex = 2;
        // 
        // panelBottom
        // 
        panelBottom.Controls.Add(tableLayoutPanelButtons);
        panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelBottom.Location = new System.Drawing.Point(0, 730);
        panelBottom.Name = "panelBottom";
        panelBottom.Size = new System.Drawing.Size(1031, 120);
        panelBottom.TabIndex = 4;
        // 
        // tableLayoutPanelButtons
        // 
        tableLayoutPanelButtons.ColumnCount = 3;
        tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
        tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        tableLayoutPanelButtons.Controls.Add(flowLayoutPanelButtons, 1, 0);
        tableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelButtons.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
        tableLayoutPanelButtons.RowCount = 1;
        tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanelButtons.Size = new System.Drawing.Size(1031, 120);
        tableLayoutPanelButtons.TabIndex = 0;
        // 
        // flowLayoutPanelButtons
        // 
        flowLayoutPanelButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
        flowLayoutPanelButtons.AutoSize = true;
        flowLayoutPanelButtons.Controls.Add(button2);
        flowLayoutPanelButtons.Controls.Add(button1);
        flowLayoutPanelButtons.Location = new System.Drawing.Point(344, 33);
        flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
        flowLayoutPanelButtons.Size = new System.Drawing.Size(342, 54);
        flowLayoutPanelButtons.TabIndex = 0;
        flowLayoutPanelButtons.WrapContents = false;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(181, 3);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(158, 48);
        button1.TabIndex = 0;
        button1.Text = "Close";
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(3, 3);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(172, 48);
        button2.TabIndex = 1;
        button2.Text = "Cancel Booking";
        button2.Click += button2_Click;
        // 
        // MyBookings
        // 
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.MinimumSize = new System.Drawing.Size(1024, 768);
        this.ClientSize = new System.Drawing.Size(1031, 850);
        Controls.Add(panelGridContainer);
        Controls.Add(panelBottom);
        Controls.Add(labelTitle);
        Text = "My Bookings";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        panelBottom.ResumeLayout(false);
        tableLayoutPanelButtons.ResumeLayout(false);
        tableLayoutPanelButtons.PerformLayout();
        flowLayoutPanelButtons.ResumeLayout(false);
        flowLayoutPanelButtons.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Panel panelBottom;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
    private System.Windows.Forms.Panel panelGridContainer;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;

    #endregion
}