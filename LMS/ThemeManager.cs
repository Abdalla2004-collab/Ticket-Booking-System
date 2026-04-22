using System;
using System.Drawing;
using System.Windows.Forms;

namespace LMS
{
    public static class ThemeManager
    {
        private static readonly Color PrimaryBlue = Color.FromArgb(0, 122, 204);
        private static readonly Color BackgroundGrey = Color.FromArgb(240, 240, 240);
        private static readonly Color WhiteColor = Color.White;
        private static readonly Color TextBlack = Color.Black;
        private static readonly Font DefaultFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        private static readonly Font BoldFont = new Font("Segoe UI", 10F, FontStyle.Bold);
        private static readonly Font TitleFont = new Font("Segoe UI", 16F, FontStyle.Bold);
        private static readonly Font InputFontLarge = new Font("Segoe UI", 12F, FontStyle.Regular);
        private static readonly Font LabelFontLarge = new Font("Segoe UI", 12F, FontStyle.Bold);

        public static void ApplyTheme(Form form)
        {
            form.BackColor = BackgroundGrey;
            form.ForeColor = TextBlack;
            form.Font = DefaultFont;
            form.StartPosition = FormStartPosition.CenterScreen;
            foreach (Control control in form.Controls)
            {
                ApplyControlTheme(control);
            }
        }

        public static void ApplyLargeTheme(Form form)
        {
            ApplyTheme(form);
            ScaleControls(form, 1.2f);
        }

        private static void ScaleControls(Control parent, float factor)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Label lbl && lbl.Font.Size < 16)
                {
                    lbl.Font = new Font(lbl.Font.FontFamily, lbl.Font.Size * factor, lbl.Font.Style);
                }
                else if (control is TextBox || control is MaskedTextBox || control is ComboBox || control is Button)
                {
                    control.Font = new Font(control.Font.FontFamily, control.Font.Size * factor, control.Font.Style);
                }
                
                if (control.HasChildren)
                {
                    ScaleControls(control, factor);
                }
            }
        }

        private static void ApplyControlTheme(Control control)
        {
            if (control is Button btn)
            {
                btn.BackColor = PrimaryBlue;
                btn.ForeColor = WhiteColor;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = BoldFont;
                btn.Cursor = Cursors.Hand;
                btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(0, 102, 204);
                btn.MouseLeave += (s, e) => btn.BackColor = PrimaryBlue;
            }
            else if (control is ComboBox cb)
            {
                cb.BackColor = Color.White;
                cb.ForeColor = TextBlack;
                cb.Font = DefaultFont;
                cb.FlatStyle = FlatStyle.Flat;
                cb.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else if (control is TextBox || control is MaskedTextBox)
            {
                control.BackColor = WhiteColor;
                control.ForeColor = TextBlack;
                control.Font = DefaultFont;
                
                if (control is TextBox tb)
                {
                    tb.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            else if (control is Label lbl)
            {
                lbl.BackColor = Color.Transparent;
                if (lbl.Font.Size > 14)
                {
                    lbl.ForeColor = PrimaryBlue;
                    lbl.Font = TitleFont;
                }
                else
                {
                    lbl.ForeColor = TextBlack;
                }
            }
            else if (control is DataGridView dgv)
            {
                dgv.GridColor = Color.LightGray;
                dgv.BorderStyle = BorderStyle.None;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.ReadOnly = true;
                dgv.AllowUserToAddRows = false;
                dgv.MultiSelect = false;
                dgv.BackgroundColor = WhiteColor;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryBlue;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = WhiteColor;
                dgv.ColumnHeadersDefaultCellStyle.Font = BoldFont;
                dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                dgv.RowHeadersVisible = false;
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(153, 204, 255);
                dgv.DefaultCellStyle.SelectionForeColor = TextBlack;
                dgv.EnableHeadersVisualStyles = false;
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                // Allow the designer-set Dock property to persist
                // dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgv.GridColor = Color.LightGray;

                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            foreach (Control child in control.Controls)
            {
                ApplyControlTheme(child);
            }
        }
    }
}
