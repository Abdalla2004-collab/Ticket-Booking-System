using System.ComponentModel;

namespace LMS;

partial class CustomerDashboard
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
        textBox1 = new System.Windows.Forms.TextBox();
        comboBox1 = new System.Windows.Forms.ComboBox();
        label2 = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        button4 = new System.Windows.Forms.Button();
        buttonEditProfile = new System.Windows.Forms.Button();
        dataGridView1 = new System.Windows.Forms.DataGridView();
        panelNotifications = new System.Windows.Forms.Panel();
        panelGridContainer = new System.Windows.Forms.Panel();
        labelNotificationText = new System.Windows.Forms.Label();
        buttonDismissNotifications = new System.Windows.Forms.Button();
        panelBottom = new System.Windows.Forms.Panel();
        tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
        flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
        panelSearch = new System.Windows.Forms.Panel();
        tableLayoutPanelSearch = new System.Windows.Forms.TableLayoutPanel();
        flowLayoutPanelSearch = new System.Windows.Forms.FlowLayoutPanel();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        panelNotifications.SuspendLayout();
        panelBottom.SuspendLayout();
        tableLayoutPanelButtons.SuspendLayout();
        flowLayoutPanelButtons.SuspendLayout();
        panelSearch.SuspendLayout();
        tableLayoutPanelSearch.SuspendLayout();
        flowLayoutPanelSearch.SuspendLayout();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Dock = System.Windows.Forms.DockStyle.Top;
        label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(0, 0);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(1179, 80);
        label1.TabIndex = 0;
        label1.Text = "Customer Dashboard";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(3, 3);
        textBox1.Name = "textBox1";
        textBox1.PlaceholderText = "Search Events...";
        textBox1.Size = new System.Drawing.Size(300, 35);
        textBox1.TabIndex = 1;
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(416, 3);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(200, 38);
        comboBox1.TabIndex = 2;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new System.Drawing.Point(309, 0);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(101, 30);
        label2.TabIndex = 2;
        label2.Text = "Category:";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(622, 3);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(128, 46);
        button1.TabIndex = 4;
        button1.Text = "Search";
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.AutoSize = true;
        button2.Location = new System.Drawing.Point(3, 3);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(150, 46);
        button2.TabIndex = 5;
        button2.Text = "Book Event";
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.AutoSize = true;
        button3.Location = new System.Drawing.Point(159, 3);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(150, 46);
        button3.TabIndex = 6;
        button3.Text = "My Bookings";
        button3.Click += button3_Click;
        // 
        // button4
        // 
        button4.AutoSize = true;
        button4.Location = new System.Drawing.Point(315, 3);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(110, 46);
        button4.TabIndex = 7;
        button4.Text = "Logout";
        button4.Click += button4_Click_1;
        // 
        // buttonEditProfile
        // 
        buttonEditProfile.AutoSize = true;
        buttonEditProfile.Location = new System.Drawing.Point(431, 3);
        buttonEditProfile.Name = "buttonEditProfile";
        buttonEditProfile.Size = new System.Drawing.Size(110, 46);
        buttonEditProfile.TabIndex = 8;
        buttonEditProfile.Text = "Edit Profile";
        buttonEditProfile.Click += buttonEditProfile_Click;
        // 
        // panelGridContainer
        // 
        panelGridContainer.Controls.Add(dataGridView1);
        panelGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        panelGridContainer.Location = new System.Drawing.Point(0, 260);
        panelGridContainer.Name = "panelGridContainer";
        panelGridContainer.Padding = new System.Windows.Forms.Padding(30);
        panelGridContainer.Size = new System.Drawing.Size(1179, 603);
        panelGridContainer.TabIndex = 23;
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.ColumnHeadersHeight = 40;
        dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridView1.Location = new System.Drawing.Point(20, 20);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowHeadersWidth = 72;
        dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.Size = new System.Drawing.Size(1139, 563);
        dataGridView1.TabIndex = 8;
        dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        // 
        // panelNotifications
        // 
        panelNotifications.BackColor = System.Drawing.Color.FromArgb(((int)((byte)230)), ((int)((byte)243)), ((int)((byte)255)));
        panelNotifications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        panelNotifications.Controls.Add(labelNotificationText);
        panelNotifications.Controls.Add(buttonDismissNotifications);
        panelNotifications.Dock = System.Windows.Forms.DockStyle.Top;
        panelNotifications.Location = new System.Drawing.Point(0, 160);
        panelNotifications.Name = "panelNotifications";
        panelNotifications.Padding = new System.Windows.Forms.Padding(10);
        panelNotifications.Size = new System.Drawing.Size(1179, 100);
        panelNotifications.TabIndex = 20;
        panelNotifications.Visible = false;
        // 
        // labelNotificationText
        // 
        labelNotificationText.Dock = System.Windows.Forms.DockStyle.Fill;
        labelNotificationText.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        labelNotificationText.Location = new System.Drawing.Point(10, 10);
        labelNotificationText.Name = "labelNotificationText";
        labelNotificationText.Size = new System.Drawing.Size(1057, 78);
        labelNotificationText.TabIndex = 0;
        labelNotificationText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // buttonDismissNotifications
        // 
        buttonDismissNotifications.Dock = System.Windows.Forms.DockStyle.Right;
        buttonDismissNotifications.Location = new System.Drawing.Point(1067, 10);
        buttonDismissNotifications.Name = "buttonDismissNotifications";
        buttonDismissNotifications.Size = new System.Drawing.Size(130, 78);
        buttonDismissNotifications.TabIndex = 1;
        buttonDismissNotifications.Text = "Dismiss";
        buttonDismissNotifications.Click += buttonDismissNotifications_Click;
        // 
        // panelBottom
        // 
        panelBottom.Controls.Add(tableLayoutPanelButtons);
        panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelBottom.Location = new System.Drawing.Point(0, 863);
        panelBottom.Name = "panelBottom";
        panelBottom.Size = new System.Drawing.Size(1179, 120);
        panelBottom.TabIndex = 21;
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
        tableLayoutPanelButtons.Size = new System.Drawing.Size(1179, 120);
        tableLayoutPanelButtons.TabIndex = 0;
        // 
        // flowLayoutPanelButtons
        // 
        flowLayoutPanelButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
        flowLayoutPanelButtons.AutoSize = true;
        flowLayoutPanelButtons.Controls.Add(buttonEditProfile);
        flowLayoutPanelButtons.Controls.Add(button2);
        flowLayoutPanelButtons.Controls.Add(button3);
        flowLayoutPanelButtons.Controls.Add(button4);
        flowLayoutPanelButtons.Location = new System.Drawing.Point(324, 34);
        flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
        flowLayoutPanelButtons.Size = new System.Drawing.Size(538, 52);
        flowLayoutPanelButtons.TabIndex = 0;
        flowLayoutPanelButtons.WrapContents = false;
        // 
        // panelSearch
        // 
        panelSearch.Controls.Add(tableLayoutPanelSearch);
        panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
        panelSearch.Location = new System.Drawing.Point(0, 80);
        panelSearch.Name = "panelSearch";
        panelSearch.Size = new System.Drawing.Size(1179, 80);
        panelSearch.TabIndex = 22;
        // 
        // tableLayoutPanelSearch
        // 
        tableLayoutPanelSearch.ColumnCount = 3;
        tableLayoutPanelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        tableLayoutPanelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
        tableLayoutPanelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        tableLayoutPanelSearch.Controls.Add(flowLayoutPanelSearch, 1, 0);
        tableLayoutPanelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelSearch.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanelSearch.Name = "tableLayoutPanelSearch";
        tableLayoutPanelSearch.RowCount = 1;
        tableLayoutPanelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanelSearch.Size = new System.Drawing.Size(1179, 80);
        tableLayoutPanelSearch.TabIndex = 0;
        // 
        // flowLayoutPanelSearch
        // 
        flowLayoutPanelSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
        flowLayoutPanelSearch.AutoSize = true;
        flowLayoutPanelSearch.Controls.Add(textBox1);
        flowLayoutPanelSearch.Controls.Add(label2);
        flowLayoutPanelSearch.Controls.Add(comboBox1);
        flowLayoutPanelSearch.Controls.Add(button1);
        flowLayoutPanelSearch.Location = new System.Drawing.Point(212, 14);
        flowLayoutPanelSearch.Name = "flowLayoutPanelSearch";
        flowLayoutPanelSearch.Size = new System.Drawing.Size(753, 52);
        flowLayoutPanelSearch.TabIndex = 0;
        flowLayoutPanelSearch.WrapContents = false;
        // 
        // CustomerDashboard
        // 
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.MinimumSize = new System.Drawing.Size(1024, 768);
        this.ClientSize = new System.Drawing.Size(1179, 983);
        Controls.Add(panelGridContainer);
        Controls.Add(panelNotifications);
        Controls.Add(panelSearch);
        Controls.Add(label1);
        Controls.Add(panelBottom);
        Text = "Customer Dashboard";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        panelNotifications.ResumeLayout(false);
        panelBottom.ResumeLayout(false);
        tableLayoutPanelButtons.ResumeLayout(false);
        tableLayoutPanelButtons.PerformLayout();
        flowLayoutPanelButtons.ResumeLayout(false);
        flowLayoutPanelButtons.PerformLayout();
        panelSearch.ResumeLayout(false);
        tableLayoutPanelSearch.ResumeLayout(false);
        tableLayoutPanelSearch.PerformLayout();
        flowLayoutPanelSearch.ResumeLayout(false);
        flowLayoutPanelSearch.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button buttonEditProfile;
    private System.Windows.Forms.Panel panelGridContainer;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel panelNotifications;
    private System.Windows.Forms.Label labelNotificationText;
    private System.Windows.Forms.Button buttonDismissNotifications;
    private System.Windows.Forms.Panel panelBottom;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
    private System.Windows.Forms.Panel panelSearch;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSearch;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSearch;

    #endregion
}