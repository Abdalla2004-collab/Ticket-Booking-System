using System.ComponentModel;

namespace LMS;

partial class EditEvent
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
        comboBoxCategory = new System.Windows.Forms.ComboBox();
        button1 = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        textBoxTitle = new System.Windows.Forms.TextBox();
        button2 = new System.Windows.Forms.Button();
        dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
        comboBoxVenue = new System.Windows.Forms.ComboBox();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        label7 = new System.Windows.Forms.Label();
        comboBoxTime = new System.Windows.Forms.ComboBox();
        labelDuration = new System.Windows.Forms.Label();
        comboBoxDuration = new System.Windows.Forms.ComboBox();
        textBoxPrice = new System.Windows.Forms.TextBox();
        textBoxTickets = new System.Windows.Forms.TextBox();
        labelTitle = new System.Windows.Forms.Label();
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
        // labelTitle
        // 
        labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
        labelTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelTitle.Location = new System.Drawing.Point(0, 0);
        labelTitle.Name = "labelTitle";
        labelTitle.Size = new System.Drawing.Size(909, 100);
        labelTitle.TabIndex = 19;
        labelTitle.Text = "Edit Event Details";
        labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        panelMain.Controls.Add(tableLayoutPanelMain);
        panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        panelMain.Location = new System.Drawing.Point(0, 100);
        panelMain.Name = "panelMain";
        panelMain.Size = new System.Drawing.Size(909, 586);
        panelMain.TabIndex = 20;
        panelMain.AutoScroll = true;
        // 
        // tableLayoutPanelMain
        // 
        tableLayoutPanelMain.ColumnCount = 4;
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        tableLayoutPanelMain.Controls.Add(label1, 1, 1);
        tableLayoutPanelMain.Controls.Add(textBoxTitle, 2, 1);
        tableLayoutPanelMain.Controls.Add(label6, 1, 2);
        tableLayoutPanelMain.Controls.Add(dateTimePicker2, 2, 2);
        tableLayoutPanelMain.Controls.Add(label3, 1, 3);
        tableLayoutPanelMain.Controls.Add(comboBoxTime, 2, 3);
        tableLayoutPanelMain.Controls.Add(labelDuration, 1, 4);
        tableLayoutPanelMain.Controls.Add(comboBoxDuration, 2, 4);
        tableLayoutPanelMain.Controls.Add(label2, 1, 5);
        tableLayoutPanelMain.Controls.Add(textBoxPrice, 2, 5);
        tableLayoutPanelMain.Controls.Add(label4, 1, 6);
        tableLayoutPanelMain.Controls.Add(textBoxTickets, 2, 6);
        tableLayoutPanelMain.Controls.Add(label5, 1, 7);
        tableLayoutPanelMain.Controls.Add(comboBoxCategory, 2, 7);
        tableLayoutPanelMain.Controls.Add(label7, 1, 8);
        tableLayoutPanelMain.Controls.Add(comboBoxVenue, 2, 8);
        tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanelMain.Name = "tableLayoutPanelMain";
        tableLayoutPanelMain.RowCount = 10;
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.Size = new System.Drawing.Size(909, 586);
        tableLayoutPanelMain.TabIndex = 0;
        // 
        // label1
        // 
        label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label1.Location = new System.Drawing.Point(3, 43);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(175, 50);
        label1.Text = "Event Name:";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxTitle
        // 
        textBoxTitle.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        textBoxTitle.Location = new System.Drawing.Point(184, 46);
        textBoxTitle.Name = "textBoxTitle";
        textBoxTitle.Size = new System.Drawing.Size(539, 35);
        // 
        // label6
        // 
        label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label6.Location = new System.Drawing.Point(3, 93);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(175, 50);
        label6.Text = "Event Date:";
        label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // dateTimePicker2
        // 
        dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dateTimePicker2.Location = new System.Drawing.Point(184, 96);
        dateTimePicker2.Name = "dateTimePicker2";
        dateTimePicker2.Size = new System.Drawing.Size(539, 35);
        // 
        // label3
        // 
        label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label3.Location = new System.Drawing.Point(3, 143);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(175, 50);
        label3.Text = "Event Time:";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // comboBoxTime
        // 
        comboBoxTime.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        comboBoxTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxTime.FormattingEnabled = true;
        comboBoxTime.Location = new System.Drawing.Point(184, 146);
        comboBoxTime.Name = "comboBoxTime";
        comboBoxTime.Size = new System.Drawing.Size(539, 38);
        // 
        // labelDuration
        // 
        labelDuration.Anchor = System.Windows.Forms.AnchorStyles.Right;
        labelDuration.Location = new System.Drawing.Point(3, 193);
        labelDuration.Name = "labelDuration";
        labelDuration.Size = new System.Drawing.Size(175, 50);
        labelDuration.Text = "Duration:";
        labelDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // comboBoxDuration
        // 
        comboBoxDuration.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        comboBoxDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxDuration.FormattingEnabled = true;
        comboBoxDuration.Location = new System.Drawing.Point(184, 196);
        comboBoxDuration.Name = "comboBoxDuration";
        comboBoxDuration.Size = new System.Drawing.Size(539, 38);
        // 
        // label2
        // 
        label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label2.Location = new System.Drawing.Point(3, 243);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(175, 50);
        label2.Text = "Price:";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxPrice
        // 
        textBoxPrice.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        textBoxPrice.Location = new System.Drawing.Point(184, 246);
        textBoxPrice.Name = "textBoxPrice";
        textBoxPrice.Size = new System.Drawing.Size(539, 35);
        // 
        // label4
        // 
        label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label4.Location = new System.Drawing.Point(3, 293);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(175, 50);
        label4.Text = "Tickets:";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxTickets
        // 
        textBoxTickets.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        textBoxTickets.Location = new System.Drawing.Point(184, 296);
        textBoxTickets.Name = "textBoxTickets";
        textBoxTickets.Size = new System.Drawing.Size(539, 35);
        // 
        // label5
        // 
        label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label5.Location = new System.Drawing.Point(3, 343);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(175, 50);
        label5.Text = "Category:";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // comboBoxCategory
        // 
        comboBoxCategory.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        comboBoxCategory.FormattingEnabled = true;
        comboBoxCategory.Location = new System.Drawing.Point(184, 346);
        comboBoxCategory.Name = "comboBoxCategory";
        comboBoxCategory.Size = new System.Drawing.Size(539, 38);
        // 
        // label7
        // 
        label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label7.Location = new System.Drawing.Point(3, 393);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(175, 50);
        label7.Text = "Venue:";
        label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // comboBoxVenue
        // 
        comboBoxVenue.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        comboBoxVenue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxVenue.FormattingEnabled = true;
        comboBoxVenue.Location = new System.Drawing.Point(184, 396);
        comboBoxVenue.Name = "comboBoxVenue";
        comboBoxVenue.Size = new System.Drawing.Size(539, 38);
        // 
        // panelButtons
        // 
        panelButtons.Controls.Add(flowLayoutPanelButtons);
        panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelButtons.Location = new System.Drawing.Point(0, 686);
        panelButtons.Name = "panelButtons";
        panelButtons.Size = new System.Drawing.Size(909, 120);
        panelButtons.TabIndex = 21;
        // 
        // flowLayoutPanelButtons
        // 
        flowLayoutPanelButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
        flowLayoutPanelButtons.AutoSize = true;
        flowLayoutPanelButtons.Controls.Add(button1);
        flowLayoutPanelButtons.Controls.Add(button2);
        flowLayoutPanelButtons.Location = new System.Drawing.Point(263, 30);
        flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
        flowLayoutPanelButtons.Size = new System.Drawing.Size(382, 60);
        flowLayoutPanelButtons.TabIndex = 0;
        flowLayoutPanelButtons.WrapContents = false;
        // 
        button1.AutoSize = true;
        button1.Location = new System.Drawing.Point(3, 3);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(185, 54);
        button1.TabIndex = 1;
        button1.Text = "Save Changes";
        button1.Click += button1_Click;
        // 
        button2.AutoSize = true;
        button2.Location = new System.Drawing.Point(194, 3);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(185, 54);
        button2.TabIndex = 4;
        button2.Text = "Cancel";
        button2.Click += button2_Click;
        // 
        // EditEvent
        // 
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.MinimumSize = new System.Drawing.Size(1000, 800);
        this.ClientSize = new System.Drawing.Size(909, 806);
        Controls.Add(panelMain);
        Controls.Add(panelButtons);
        Controls.Add(labelTitle);
        this.AcceptButton = this.button1;
        this.CancelButton = this.button2;
        Text = "Event Management - Edit Event";
        panelMain.ResumeLayout(false);
        tableLayoutPanelMain.ResumeLayout(false);
        tableLayoutPanelMain.PerformLayout();
        panelButtons.ResumeLayout(false);
        panelButtons.PerformLayout();
        flowLayoutPanelButtons.ResumeLayout(false);
        flowLayoutPanelButtons.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.ComboBox comboBoxVenue;
    private System.Windows.Forms.TextBox textBoxPrice;
    private System.Windows.Forms.TextBox textBoxTickets;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.DateTimePicker dateTimePicker2;
    private System.Windows.Forms.ComboBox comboBoxCategory;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBoxTitle;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.ComboBox comboBoxTime;
    private System.Windows.Forms.Label labelDuration;
    private System.Windows.Forms.ComboBox comboBoxDuration;
    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
    private System.Windows.Forms.Panel panelButtons;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;

    #endregion
}