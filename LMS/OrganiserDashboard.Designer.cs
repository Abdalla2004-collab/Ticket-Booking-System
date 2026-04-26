using System.ComponentModel;

namespace LMS;

partial class OrganiserDashboard
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
        labelWelcome = new System.Windows.Forms.Label();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        buttonEditProfile = new System.Windows.Forms.Button();
        buttonEditEvent = new System.Windows.Forms.Button();
        dataGridViewEvents = new System.Windows.Forms.DataGridView();
        btnCancelEvent = new System.Windows.Forms.Button();
        btnStats = new System.Windows.Forms.Button();
        panelNotifications = new System.Windows.Forms.Panel();
        labelNotificationText = new System.Windows.Forms.Label();
        buttonDismissNotifications = new System.Windows.Forms.Button();
        panelBottom = new System.Windows.Forms.Panel();
        tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
        flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
        panelGridContainer = new System.Windows.Forms.Panel();
        ((System.ComponentModel.ISupportInitialize)dataGridViewEvents).BeginInit();
        panelNotifications.SuspendLayout();
        panelBottom.SuspendLayout();
        tableLayoutPanelButtons.SuspendLayout();
        flowLayoutPanelButtons.SuspendLayout();
        SuspendLayout();
        // 
        // labelWelcome
        // 
        labelWelcome.Dock = System.Windows.Forms.DockStyle.Top;
        labelWelcome.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelWelcome.Location = new System.Drawing.Point(0, 0);
        labelWelcome.Name = "labelWelcome";
        labelWelcome.Size = new System.Drawing.Size(1304, 100);
        labelWelcome.TabIndex = 0;
        labelWelcome.Text = "Organiser Dashboard";
        labelWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // panelNotifications
        // 
        panelNotifications.BackColor = System.Drawing.Color.FromArgb(((int)((byte)230)), ((int)((byte)243)), ((int)((byte)255)));
        panelNotifications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        panelNotifications.Controls.Add(labelNotificationText);
        panelNotifications.Controls.Add(buttonDismissNotifications);
        panelNotifications.Dock = System.Windows.Forms.DockStyle.Top;
        panelNotifications.Location = new System.Drawing.Point(0, 100);
        panelNotifications.Name = "panelNotifications";
        panelNotifications.Padding = new System.Windows.Forms.Padding(10);
        panelNotifications.Size = new System.Drawing.Size(1304, 100);
        panelNotifications.TabIndex = 20;
        panelNotifications.Visible = false;
        // 
        // labelNotificationText
        // 
        labelNotificationText.Dock = System.Windows.Forms.DockStyle.Fill;
        labelNotificationText.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        labelNotificationText.Location = new System.Drawing.Point(10, 10);
        labelNotificationText.Name = "labelNotificationText";
        labelNotificationText.Size = new System.Drawing.Size(1182, 78);
        labelNotificationText.TabIndex = 0;
        labelNotificationText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // buttonDismissNotifications
        // 
        buttonDismissNotifications.Dock = System.Windows.Forms.DockStyle.Right;
        buttonDismissNotifications.Location = new System.Drawing.Point(1192, 10);
        buttonDismissNotifications.Name = "buttonDismissNotifications";
        buttonDismissNotifications.Size = new System.Drawing.Size(130, 78);
        buttonDismissNotifications.TabIndex = 1;
        buttonDismissNotifications.Text = "Dismiss";
        buttonDismissNotifications.Click += buttonDismissNotifications_Click;
        // 
        // panelGridContainer
        // 
        panelGridContainer.Controls.Add(dataGridViewEvents);
        panelGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        panelGridContainer.Location = new System.Drawing.Point(0, 200);
        panelGridContainer.Name = "panelGridContainer";
        panelGridContainer.Padding = new System.Windows.Forms.Padding(30);
        panelGridContainer.Size = new System.Drawing.Size(1304, 609);
        panelGridContainer.TabIndex = 22;
        // 
        // dataGridViewEvents
        // 
        dataGridViewEvents.AllowUserToAddRows = false;
        dataGridViewEvents.AllowUserToDeleteRows = false;
        dataGridViewEvents.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridViewEvents.Location = new System.Drawing.Point(20, 20);
        dataGridViewEvents.Name = "dataGridViewEvents";
        dataGridViewEvents.ReadOnly = true;
        dataGridViewEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dataGridViewEvents.Size = new System.Drawing.Size(1264, 569);
        dataGridViewEvents.TabIndex = 7;
        // 
        // panelBottom
        // 
        panelBottom.Controls.Add(tableLayoutPanelButtons);
        panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelBottom.Location = new System.Drawing.Point(0, 809);
        panelBottom.Name = "panelBottom";
        panelBottom.Size = new System.Drawing.Size(1304, 200);
        panelBottom.TabIndex = 21;
        // 
        // tableLayoutPanelButtons
        // 
        tableLayoutPanelButtons.ColumnCount = 3;
        tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
        tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
        tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
        tableLayoutPanelButtons.Controls.Add(flowLayoutPanelButtons, 1, 0);
        tableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelButtons.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
        tableLayoutPanelButtons.RowCount = 1;
        tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanelButtons.Size = new System.Drawing.Size(1304, 200);
        tableLayoutPanelButtons.TabIndex = 0;
        // 
        // flowLayoutPanelButtons
        // 
        flowLayoutPanelButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
        flowLayoutPanelButtons.AutoSize = true;
        flowLayoutPanelButtons.Controls.Add(btnStats);
        flowLayoutPanelButtons.Controls.Add(btnCancelEvent);
        flowLayoutPanelButtons.Controls.Add(button2);
        flowLayoutPanelButtons.Controls.Add(buttonEditEvent);
        flowLayoutPanelButtons.Controls.Add(buttonEditProfile);
        flowLayoutPanelButtons.Controls.Add(button3);
        flowLayoutPanelButtons.Location = new System.Drawing.Point(112, 72);
        flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
        flowLayoutPanelButtons.Size = new System.Drawing.Size(1080, 56);
        flowLayoutPanelButtons.TabIndex = 0;
        flowLayoutPanelButtons.WrapContents = false;
        // 
        // btnStats
        // 
        btnStats.Location = new System.Drawing.Point(3, 3);
        btnStats.Name = "btnStats";
        btnStats.Size = new System.Drawing.Size(150, 50);
        btnStats.TabIndex = 8;
        btnStats.Text = "Statistics";
        btnStats.Click += BtnStats_Click;
        // 
        // btnCancelEvent
        // 
        btnCancelEvent.Location = new System.Drawing.Point(159, 3);
        btnCancelEvent.Name = "btnCancelEvent";
        btnCancelEvent.Size = new System.Drawing.Size(180, 50);
        btnCancelEvent.TabIndex = 9;
        btnCancelEvent.Text = "Cancel Event";
        btnCancelEvent.Click += BtnCancelEvent_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(345, 3);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(180, 50);
        button2.TabIndex = 2;
        button2.Text = "Create Event";
        button2.Click += button2_Click;
        // 
        // buttonEditEvent
        // 
        buttonEditEvent.Location = new System.Drawing.Point(531, 3);
        buttonEditEvent.Name = "buttonEditEvent";
        buttonEditEvent.Size = new System.Drawing.Size(180, 50);
        buttonEditEvent.TabIndex = 6;
        buttonEditEvent.Text = "Edit Event";
        buttonEditEvent.Click += buttonEditEvent_Click;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(717, 3);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(150, 50);
        button3.TabIndex = 3;
        button3.Text = "Logout";
        button3.Click += button3_Click;
        // 
        // buttonEditProfile
        // 
        buttonEditProfile.Location = new System.Drawing.Point(873, 3);
        buttonEditProfile.Name = "buttonEditProfile";
        buttonEditProfile.Size = new System.Drawing.Size(150, 50);
        buttonEditProfile.TabIndex = 10;
        buttonEditProfile.Text = "Edit Profile";
        buttonEditProfile.Click += buttonEditProfile_Click;
        // 
        // OrganiserDashboard
        // 
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.MinimumSize = new System.Drawing.Size(1200, 800);
        this.ClientSize = new System.Drawing.Size(1304, 1009);
        Controls.Add(panelGridContainer);
        Controls.Add(panelNotifications);
        Controls.Add(labelWelcome);
        Controls.Add(panelBottom);
        Text = "Organiser Dashboard";
        ((System.ComponentModel.ISupportInitialize)dataGridViewEvents).EndInit();
        panelNotifications.ResumeLayout(false);
        panelBottom.ResumeLayout(false);
        tableLayoutPanelButtons.ResumeLayout(false);
        tableLayoutPanelButtons.PerformLayout();
        flowLayoutPanelButtons.ResumeLayout(false);
        flowLayoutPanelButtons.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button buttonEditEvent;
    private System.Windows.Forms.DataGridView dataGridViewEvents;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button buttonEditProfile;
    private System.Windows.Forms.Label labelWelcome;
    private System.Windows.Forms.Panel panelNotifications;
    private System.Windows.Forms.Label labelNotificationText;
    private System.Windows.Forms.Button buttonDismissNotifications;
    private System.Windows.Forms.Panel panelBottom;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
    private System.Windows.Forms.Button btnStats;
    private System.Windows.Forms.Button btnCancelEvent;
    private System.Windows.Forms.Panel panelGridContainer;

    #endregion
}