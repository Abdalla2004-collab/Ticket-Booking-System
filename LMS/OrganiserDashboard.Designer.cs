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
        Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        buttonEditEvent = new System.Windows.Forms.Button();
        dataGridViewEvents = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)dataGridViewEvents).BeginInit();
        SuspendLayout();
        // 
        // labelWelcome
        // 
        labelWelcome.Font = new System.Drawing.Font("Segoe UI", 14.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelWelcome.Location = new System.Drawing.Point(351, 47);
        labelWelcome.Name = "labelWelcome";
        labelWelcome.Size = new System.Drawing.Size(545, 91);
        labelWelcome.TabIndex = 0;
        labelWelcome.Text = "Welcome Text";
        labelWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(561, 729);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(229, 57);
        button2.TabIndex = 2;
        button2.Text = "Add events";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(561, 923);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(229, 57);
        button3.TabIndex = 3;
        button3.Text = "Logout";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // Column1
        // 
        Column1.HeaderText = "Column1";
        Column1.MinimumWidth = 9;
        Column1.Name = "Column1";
        Column1.ReadOnly = true;
        Column1.Width = 175;
        // 
        // Column2
        // 
        Column2.HeaderText = "Column2";
        Column2.MinimumWidth = 9;
        Column2.Name = "Column2";
        Column2.ReadOnly = true;
        Column2.Width = 175;
        // 
        // Column3
        // 
        Column3.HeaderText = "Column3";
        Column3.MinimumWidth = 9;
        Column3.Name = "Column3";
        Column3.ReadOnly = true;
        Column3.Width = 175;
        // 
        // buttonEditEvent
        // 
        buttonEditEvent.Location = new System.Drawing.Point(561, 823);
        buttonEditEvent.Name = "buttonEditEvent";
        buttonEditEvent.Size = new System.Drawing.Size(229, 57);
        buttonEditEvent.TabIndex = 6;
        buttonEditEvent.Text = "Edit event";
        buttonEditEvent.UseVisualStyleBackColor = true;
        buttonEditEvent.Click += buttonEditEvent_Click;
        // 
        // dataGridViewEvents
        // 
        dataGridViewEvents.AllowUserToAddRows = false;
        dataGridViewEvents.AllowUserToDeleteRows = false;
        dataGridViewEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewEvents.Location = new System.Drawing.Point(84, 182);
        dataGridViewEvents.Name = "dataGridViewEvents";
        dataGridViewEvents.ReadOnly = true;
        dataGridViewEvents.RowHeadersWidth = 72;
        dataGridViewEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dataGridViewEvents.Size = new System.Drawing.Size(1159, 416);
        dataGridViewEvents.TabIndex = 7;
        // 
        // OrganiserDashboard
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1304, 1009);
        Controls.Add(dataGridViewEvents);
        Controls.Add(buttonEditEvent);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(labelWelcome);
        Text = "OrganiserDashboard";
        ((System.ComponentModel.ISupportInitialize)dataGridViewEvents).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button buttonEditEvent;

    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;

    private System.Windows.Forms.DataGridView dataGridViewEvents;

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Label labelWelcome;

    #endregion
}