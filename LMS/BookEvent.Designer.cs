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
        textBoxDiscountCode = new System.Windows.Forms.TextBox();
        buttonApplyDiscount = new System.Windows.Forms.Button();
        labelDiscountStatus = new System.Windows.Forms.Label();
        labelSubtotal = new System.Windows.Forms.Label();
        labelDiscountAmount = new System.Windows.Forms.Label();
        panelMain = new System.Windows.Forms.Panel();
        tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
        panelButtons = new System.Windows.Forms.Panel();
        flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
        panelMain.SuspendLayout();
        tableLayoutPanelMain.SuspendLayout();
        panelButtons.SuspendLayout();
        flowLayoutPanelButtons.SuspendLayout();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Dock = System.Windows.Forms.DockStyle.Top;
        label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(0, 0);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(800, 100);
        label1.TabIndex = 0;
        label1.Text = "Book Your Event";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label2
        // 
        label2.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
        label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
        label2.Location = new System.Drawing.Point(163, 45);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(474, 40);
        label2.TabIndex = 0;
        label2.Text = "Event Title";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label3
        // 
        label3.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
        label3.Location = new System.Drawing.Point(163, 95);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(474, 40);
        label3.TabIndex = 1;
        label3.Text = "Event Date & Time";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label4
        // 
        label4.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
        label4.Location = new System.Drawing.Point(163, 145);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(474, 60);
        label4.TabIndex = 2;
        label4.Text = "Venue Address";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new System.Drawing.Point(3, 7);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(120, 35);
        label5.TabIndex = 3;
        label5.Text = "Quantity:";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // button1
        // 
        button1.AutoSize = true;
        button1.Location = new System.Drawing.Point(3, 3);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(200, 55);
        button1.TabIndex = 5;
        button1.Text = "Confirm";
        button1.Click += button1_Click;
        // 
        // button3
        // 
        button3.AutoSize = true;
        button3.Location = new System.Drawing.Point(149, 3);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(140, 55);
        button3.TabIndex = 7;
        button3.Text = "Cancel";
        button3.Click += button3_Click_1;
        // 
        // numericUpDown1
        // 
        numericUpDown1.Location = new System.Drawing.Point(129, 3);
        numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numericUpDown1.Name = "numericUpDown1";
        numericUpDown1.Size = new System.Drawing.Size(127, 35);
        numericUpDown1.TabIndex = 8;
        numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
        numericUpDown1.ReadOnly = true;
        // 
        // textBoxDiscountCode
        // 
        textBoxDiscountCode.Anchor = System.Windows.Forms.AnchorStyles.None;
        textBoxDiscountCode.Location = new System.Drawing.Point(265, 297);
        textBoxDiscountCode.Name = "textBoxDiscountCode";
        textBoxDiscountCode.PlaceholderText = "Discount Code";
        textBoxDiscountCode.Size = new System.Drawing.Size(270, 35);
        textBoxDiscountCode.TabIndex = 9;
        // 
        // buttonApplyDiscount
        // 
        buttonApplyDiscount.AutoSize = true;
        buttonApplyDiscount.Location = new System.Drawing.Point(643, 293);
        buttonApplyDiscount.Name = "buttonApplyDiscount";
        buttonApplyDiscount.Size = new System.Drawing.Size(120, 55);
        buttonApplyDiscount.TabIndex = 10;
        buttonApplyDiscount.Text = "Apply";
        buttonApplyDiscount.Click += buttonApplyDiscount_Click;
        // 
        // labelDiscountStatus
        // 
        labelDiscountStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
        labelDiscountStatus.Location = new System.Drawing.Point(163, 345);
        labelDiscountStatus.Name = "labelDiscountStatus";
        labelDiscountStatus.Size = new System.Drawing.Size(474, 50);
        labelDiscountStatus.TabIndex = 11;
        labelDiscountStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // labelSubtotal
        // 
        labelSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
        labelSubtotal.Location = new System.Drawing.Point(163, 385);
        labelSubtotal.Name = "labelSubtotal";
        labelSubtotal.Size = new System.Drawing.Size(474, 50);
        labelSubtotal.TabIndex = 12;
        labelSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // labelDiscountAmount
        // 
        labelDiscountAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
        labelDiscountAmount.Location = new System.Drawing.Point(163, 425);
        labelDiscountAmount.Name = "labelDiscountAmount";
        labelDiscountAmount.Size = new System.Drawing.Size(474, 50);
        labelDiscountAmount.TabIndex = 13;
        labelDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // panelMain
        // 
        panelMain.AutoScroll = true;
        panelMain.Controls.Add(tableLayoutPanelMain);
        panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        panelMain.Location = new System.Drawing.Point(0, 100);
        panelMain.Name = "panelMain";
        panelMain.Size = new System.Drawing.Size(800, 500);
        panelMain.TabIndex = 14;
        // 
        // tableLayoutPanelMain
        // 
        tableLayoutPanelMain.ColumnCount = 3;
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        FlowLayoutPanel flowLayoutPanelQty = new FlowLayoutPanel();
        flowLayoutPanelQty.AutoSize = true;
        flowLayoutPanelQty.Anchor = AnchorStyles.None;
        flowLayoutPanelQty.Controls.Add(label5);
        flowLayoutPanelQty.Controls.Add(numericUpDown1);
        flowLayoutPanelQty.WrapContents = false;
        
        tableLayoutPanelMain.Controls.Add(label2, 1, 1);
        tableLayoutPanelMain.Controls.Add(label3, 1, 2);
        tableLayoutPanelMain.Controls.Add(label4, 1, 3);
        tableLayoutPanelMain.Controls.Add(flowLayoutPanelQty, 1, 4);
        tableLayoutPanelMain.Controls.Add(textBoxDiscountCode, 1, 5);
        tableLayoutPanelMain.Controls.Add(buttonApplyDiscount, 2, 5);
        tableLayoutPanelMain.Controls.Add(labelDiscountStatus, 1, 6);
        tableLayoutPanelMain.Controls.Add(labelSubtotal, 1, 7);
        tableLayoutPanelMain.Controls.Add(labelDiscountAmount, 1, 8);
        tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanelMain.Name = "tableLayoutPanelMain";
        tableLayoutPanelMain.RowCount = 11;
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.Size = new System.Drawing.Size(800, 500);
        tableLayoutPanelMain.TabIndex = 0;
        // 
        // panelButtons
        // 
        panelButtons.Controls.Add(flowLayoutPanelButtons);
        panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelButtons.Location = new System.Drawing.Point(0, 600);
        panelButtons.Name = "panelButtons";
        panelButtons.Size = new System.Drawing.Size(800, 120);
        panelButtons.TabIndex = 15;
        // 
        // flowLayoutPanelButtons
        // 
        flowLayoutPanelButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
        flowLayoutPanelButtons.AutoSize = true;
        flowLayoutPanelButtons.Controls.Add(button1);
        flowLayoutPanelButtons.Controls.Add(button3);
        flowLayoutPanelButtons.Location = new System.Drawing.Point(254, 30);
        flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
        flowLayoutPanelButtons.Size = new System.Drawing.Size(292, 56);
        flowLayoutPanelButtons.TabIndex = 0;
        flowLayoutPanelButtons.WrapContents = false;
        // 
        // BookEvent
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 720);
        Controls.Add(panelMain);
        Controls.Add(panelButtons);
        Controls.Add(label1);
        MinimumSize = new System.Drawing.Size(600, 600);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Book Event";
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
        panelMain.ResumeLayout(false);
        tableLayoutPanelMain.ResumeLayout(false);
        tableLayoutPanelMain.PerformLayout();
        panelButtons.ResumeLayout(false);
        panelButtons.PerformLayout();
        flowLayoutPanelButtons.ResumeLayout(false);
        flowLayoutPanelButtons.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBoxDiscountCode;
    private System.Windows.Forms.Button buttonApplyDiscount;
    private System.Windows.Forms.Label labelDiscountStatus;
    private System.Windows.Forms.Label labelSubtotal;
    private System.Windows.Forms.Label labelDiscountAmount;
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
    private System.Windows.Forms.Panel panelButtons;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;

    #endregion
}