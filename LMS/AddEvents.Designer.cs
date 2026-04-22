using System.ComponentModel;

namespace LMS;

partial class AddEvents
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
        buttonBack = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        labelOrganiser = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        textBoxTitle = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        textBoxTickets = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        textBoxPrice = new System.Windows.Forms.TextBox();
        price = new System.Windows.Forms.Label();
        comboBoxVenue = new System.Windows.Forms.ComboBox();
        label6 = new System.Windows.Forms.Label();
        comboBoxCategory = new System.Windows.Forms.ComboBox();
        label7 = new System.Windows.Forms.Label();
        dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
        comboBoxTime = new System.Windows.Forms.ComboBox();
        comboBoxDuration = new System.Windows.Forms.ComboBox();
        label5 = new System.Windows.Forms.Label();
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
        // labelOrganiser
        // 
        labelOrganiser.Dock = System.Windows.Forms.DockStyle.Top;
        labelOrganiser.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelOrganiser.Location = new System.Drawing.Point(0, 0);
        labelOrganiser.Name = "labelOrganiser";
        labelOrganiser.Size = new System.Drawing.Size(1300, 100);
        labelOrganiser.TabIndex = 2;
        labelOrganiser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        labelOrganiser.AutoEllipsis = true;
        // 
        panelMain.Controls.Add(tableLayoutPanelMain);
        panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        panelMain.Location = new System.Drawing.Point(0, 100);
        panelMain.Name = "panelMain";
        panelMain.Size = new System.Drawing.Size(1300, 883);
        panelMain.TabIndex = 23;
        panelMain.AutoScroll = true;
        // 
        // tableLayoutPanelMain
        // 
        tableLayoutPanelMain.ColumnCount = 4;
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        tableLayoutPanelMain.Controls.Add(label2, 1, 1);
        tableLayoutPanelMain.Controls.Add(textBoxTitle, 2, 1);
        tableLayoutPanelMain.Controls.Add(label3, 1, 2);
        tableLayoutPanelMain.Controls.Add(dateTimePicker2, 2, 2);
        tableLayoutPanelMain.Controls.Add(label4, 1, 3);
        tableLayoutPanelMain.Controls.Add(comboBoxTime, 2, 3);
        tableLayoutPanelMain.Controls.Add(label5, 1, 4);
        tableLayoutPanelMain.Controls.Add(comboBoxDuration, 2, 4);
        tableLayoutPanelMain.Controls.Add(label1, 1, 5);
        tableLayoutPanelMain.Controls.Add(textBoxTickets, 2, 5);
        tableLayoutPanelMain.Controls.Add(price, 1, 6);
        tableLayoutPanelMain.Controls.Add(textBoxPrice, 2, 6);
        tableLayoutPanelMain.Controls.Add(label6, 1, 7);
        tableLayoutPanelMain.Controls.Add(comboBoxVenue, 2, 7);
        tableLayoutPanelMain.Controls.Add(label7, 1, 8);
        tableLayoutPanelMain.Controls.Add(comboBoxCategory, 2, 8);
        tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanelMain.Name = "tableLayoutPanelMain";
        tableLayoutPanelMain.RowCount = 10;
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.Size = new System.Drawing.Size(1300, 883);
        tableLayoutPanelMain.TabIndex = 0;
        // 
        // label2
        // 
        label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label2.Location = new System.Drawing.Point(3, 191);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(254, 50);
        label2.Text = "Event Name:";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxTitle
        // 
        textBoxTitle.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        textBoxTitle.Location = new System.Drawing.Point(263, 194);
        textBoxTitle.Name = "textBoxTitle";
        textBoxTitle.Size = new System.Drawing.Size(774, 35);
        // 
        // label3
        // 
        label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label3.Location = new System.Drawing.Point(3, 241);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(254, 50);
        label3.Text = "Date:";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // dateTimePicker2
        // 
        dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dateTimePicker2.Location = new System.Drawing.Point(263, 244);
        dateTimePicker2.Name = "dateTimePicker2";
        dateTimePicker2.Size = new System.Drawing.Size(774, 35);
        // 
        // label4
        // 
        label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label4.Location = new System.Drawing.Point(3, 291);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(254, 50);
        label4.Text = "Time:";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // comboBoxTime
        // 
        comboBoxTime.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        comboBoxTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxTime.FormattingEnabled = true;
        comboBoxTime.Location = new System.Drawing.Point(263, 294);
        comboBoxTime.Name = "comboBoxTime";
        comboBoxTime.Size = new System.Drawing.Size(774, 38);
        // 
        // label5
        // 
        label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label5.Location = new System.Drawing.Point(3, 341);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(254, 50);
        label5.Text = "Duration:";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // comboBoxDuration
        // 
        comboBoxDuration.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        comboBoxDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxDuration.FormattingEnabled = true;
        comboBoxDuration.Location = new System.Drawing.Point(263, 344);
        comboBoxDuration.Name = "comboBoxDuration";
        comboBoxDuration.Size = new System.Drawing.Size(774, 38);
        // 
        // label1
        // 
        label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label1.Location = new System.Drawing.Point(3, 391);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(254, 50);
        label1.Text = "Tickets:";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxTickets
        // 
        textBoxTickets.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        textBoxTickets.Location = new System.Drawing.Point(263, 394);
        textBoxTickets.Name = "textBoxTickets";
        textBoxTickets.Size = new System.Drawing.Size(774, 35);
        // 
        // price
        // 
        price.Anchor = System.Windows.Forms.AnchorStyles.Right;
        price.Location = new System.Drawing.Point(3, 441);
        price.Name = "price";
        price.Size = new System.Drawing.Size(254, 50);
        price.Text = "Price:";
        price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxPrice
        // 
        textBoxPrice.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        textBoxPrice.Location = new System.Drawing.Point(263, 444);
        textBoxPrice.Name = "textBoxPrice";
        textBoxPrice.Size = new System.Drawing.Size(774, 35);
        // 
        // label6
        // 
        label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label6.Location = new System.Drawing.Point(3, 491);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(254, 50);
        label6.Text = "Venue:";
        label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // comboBoxVenue
        // 
        comboBoxVenue.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        comboBoxVenue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxVenue.FormattingEnabled = true;
        comboBoxVenue.Location = new System.Drawing.Point(263, 494);
        comboBoxVenue.Name = "comboBoxVenue";
        comboBoxVenue.Size = new System.Drawing.Size(774, 38);
        // 
        // label7
        // 
        label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
        label7.Location = new System.Drawing.Point(3, 541);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(254, 50);
        label7.Text = "Category:";
        label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // comboBoxCategory
        // 
        comboBoxCategory.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        comboBoxCategory.FormattingEnabled = true;
        comboBoxCategory.Location = new System.Drawing.Point(263, 544);
        comboBoxCategory.Name = "comboBoxCategory";
        comboBoxCategory.Size = new System.Drawing.Size(774, 38);
        // 
        // panelButtons
        // 
        panelButtons.Controls.Add(flowLayoutPanelButtons);
        panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelButtons.Location = new System.Drawing.Point(0, 983);
        panelButtons.Name = "panelButtons";
        panelButtons.Size = new System.Drawing.Size(1300, 120);
        panelButtons.TabIndex = 24;
        // 
        // flowLayoutPanelButtons
        // 
        flowLayoutPanelButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
        flowLayoutPanelButtons.AutoSize = true;
        flowLayoutPanelButtons.Controls.Add(button2);
        flowLayoutPanelButtons.Controls.Add(buttonBack);
        flowLayoutPanelButtons.Location = new System.Drawing.Point(435, 30);
        flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
        flowLayoutPanelButtons.Size = new System.Drawing.Size(430, 62);
        flowLayoutPanelButtons.TabIndex = 0;
        flowLayoutPanelButtons.WrapContents = false;
        // 
        buttonBack.AutoSize = true;
        buttonBack.Location = new System.Drawing.Point(218, 3);
        buttonBack.Name = "buttonBack";
        buttonBack.Size = new System.Drawing.Size(209, 56);
        buttonBack.TabIndex = 0;
        buttonBack.Text = "Close";
        buttonBack.Click += buttonBack_Click_1;
        // 
        button2.AutoSize = true;
        button2.Location = new System.Drawing.Point(3, 3);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(209, 56);
        button2.TabIndex = 1;
        button2.Text = "Add Event";
        button2.Click += button2_Click;
        // 
        // AddEvents
        // 
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.MinimumSize = new System.Drawing.Size(1000, 800);
        this.ClientSize = new System.Drawing.Size(1300, 1103);
        Controls.Add(panelMain);
        Controls.Add(panelButtons);
        Controls.Add(labelOrganiser);
        this.AcceptButton = this.button2;
        this.CancelButton = this.buttonBack;
        Text = "Event Management - Add New Event";
        panelMain.ResumeLayout(false);
        tableLayoutPanelMain.ResumeLayout(false);
        tableLayoutPanelMain.PerformLayout();
        panelButtons.ResumeLayout(false);
        panelButtons.PerformLayout();
        flowLayoutPanelButtons.ResumeLayout(false);
        flowLayoutPanelButtons.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.ComboBox comboBoxDuration;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.DateTimePicker dateTimePicker2;
    private System.Windows.Forms.ComboBox comboBoxTime;
    private System.Windows.Forms.ComboBox comboBoxCategory;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox comboBoxVenue;
    private System.Windows.Forms.TextBox textBoxPrice;
    private System.Windows.Forms.Label price;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBoxTickets;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBoxTitle;
    private System.Windows.Forms.Button buttonBack;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Label labelOrganiser;
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
    private System.Windows.Forms.Panel panelButtons;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;

    #endregion
}