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
            }
            else if (control is TextBox || control is MaskedTextBox)
            {
                control.BackColor = WhiteColor;
                control.ForeColor = TextBlack;
                control.Font = DefaultFont;
                control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                
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
                dgv.BackgroundColor = WhiteColor;
                dgv.BorderStyle = BorderStyle.FixedSingle;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryBlue;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = WhiteColor;
                dgv.ColumnHeadersDefaultCellStyle.Font = BoldFont;
                dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                dgv.RowHeadersVisible = false;
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(153, 204, 255);
                dgv.DefaultCellStyle.SelectionForeColor = TextBlack;
                dgv.EnableHeadersVisualStyles = false;
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                
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
