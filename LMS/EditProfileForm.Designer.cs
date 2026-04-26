using System.ComponentModel;

namespace LMS
{
    partial class EditProfileForm
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelConfirm = new System.Windows.Forms.Label();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            
            this.panelMain.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.SuspendLayout();

            // labelTitle
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(800, 100);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Edit Account Details";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // panelMain
            this.panelMain.Controls.Add(this.tableLayoutPanel);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 100);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 400);
            this.panelMain.TabIndex = 1;

            // tableLayoutPanel
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Controls.Add(this.labelName, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.textBoxName, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.labelEmail, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.textBoxEmail, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.labelPassword, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.textBoxPassword, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.labelConfirm, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.textBoxConfirmPassword, 2, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 400);
            this.tableLayoutPanel.TabIndex = 0;

            // labelName
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(100, 90);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(130, 25);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Full Name:";

            // textBoxName
            this.textBoxName.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.textBoxName.Location = new System.Drawing.Point(325, 90);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(390, 30);
            this.textBoxName.TabIndex = 1;

            // labelEmail
            this.labelEmail.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(100, 150);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(130, 25);
            this.labelEmail.TabIndex = 2;
            this.labelEmail.Text = "Email Address:";

            // textBoxEmail
            this.textBoxEmail.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.textBoxEmail.Location = new System.Drawing.Point(325, 150);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(390, 30);
            this.textBoxEmail.TabIndex = 3;

            // labelPassword
            this.labelPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(100, 210);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(130, 25);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "New Password:";

            // textBoxPassword
            this.textBoxPassword.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.textBoxPassword.Location = new System.Drawing.Point(325, 210);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '●';
            this.textBoxPassword.Size = new System.Drawing.Size(390, 30);
            this.textBoxPassword.TabIndex = 5;

            // labelConfirm
            this.labelConfirm.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelConfirm.AutoSize = true;
            this.labelConfirm.Location = new System.Drawing.Point(100, 270);
            this.labelConfirm.Name = "labelConfirm";
            this.labelConfirm.Size = new System.Drawing.Size(130, 25);
            this.labelConfirm.TabIndex = 6;
            this.labelConfirm.Text = "Confirm Pwd:";

            // textBoxConfirmPassword
            this.textBoxConfirmPassword.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(325, 270);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.PasswordChar = '●';
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(390, 30);
            this.textBoxConfirmPassword.TabIndex = 7;

            // flowLayoutPanelButtons
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.Controls.Add(this.buttonSave);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonCancel);
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(0, 500);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(800, 100);
            this.flowLayoutPanelButtons.TabIndex = 2;
            this.flowLayoutPanelButtons.WrapContents = false;
            this.flowLayoutPanelButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            // Center buttons in flow layout
            this.flowLayoutPanelButtons.Anchor = System.Windows.Forms.AnchorStyles.None;

            // buttonSave
            this.buttonSave.Location = new System.Drawing.Point(200, 20);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(180, 50);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save Changes";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            // buttonCancel
            this.buttonCancel.Location = new System.Drawing.Point(400, 20);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(180, 50);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);

            // Extra centering for buttons panel
            TableLayoutPanel buttonTable = new TableLayoutPanel();
            buttonTable.ColumnCount = 3;
            buttonTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            buttonTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonTable.RowCount = 1;
            buttonTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            buttonTable.Controls.Add(this.flowLayoutPanelButtons, 1, 0);
            buttonTable.Dock = DockStyle.Bottom;
            buttonTable.Height = 120;

            // EditProfileForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(buttonTable);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Account Details";
            this.panelMain.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelConfirm;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
    }
}
