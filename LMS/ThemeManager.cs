using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LMS
{
    public static class ThemeManager
    {
        // ─── Core Palette (Light) ────────────────────────────────────
        private static readonly Color Background     = Color.FromArgb(245, 247, 252);   // Soft blue-grey
        private static readonly Color Surface        = Color.White;                       // Cards / panels
        private static readonly Color SurfaceVariant = Color.FromArgb(238, 240, 248);   // Input backgrounds
        private static readonly Color BorderColor    = Color.FromArgb(210, 215, 225);   // Subtle border
        private static readonly Color BorderFocus    = Color.FromArgb(180, 188, 205);   // Focused border

        // ─── Accent Colours ──────────────────────────────────────────
        private static readonly Color AccentBlue     = Color.FromArgb(66, 112, 245);    // Primary action
        private static readonly Color AccentHover    = Color.FromArgb(52, 94, 215);     // Button hover
        private static readonly Color AccentPressed  = Color.FromArgb(40, 78, 185);     // Button press
        private static readonly Color AccentTeal     = Color.FromArgb(14, 150, 150);    // Titles
        private static readonly Color AccentGreen    = Color.FromArgb(34, 170, 80);     // Success
        private static readonly Color AccentRed      = Color.FromArgb(220, 60, 80);     // Danger
        private static readonly Color AccentRedHover = Color.FromArgb(195, 45, 65);     // Danger hover
        private static readonly Color AccentOrange   = Color.FromArgb(235, 150, 30);    // Warning / notification

        // ─── Text ────────────────────────────────────────────────────
        private static readonly Color TextPrimary    = Color.FromArgb(28, 32, 48);      // Near black
        private static readonly Color TextSecondary  = Color.FromArgb(100, 110, 130);   // Muted
        private static readonly Color TextOnAccent   = Color.White;                      // On buttons

        // ─── Notification ────────────────────────────────────────────
        private static readonly Color NotifyBg       = Color.FromArgb(255, 248, 235);   // Warm light
        private static readonly Color NotifyAccent   = Color.FromArgb(235, 150, 30);    // Left bar

        // ─── DataGridView ────────────────────────────────────────────
        private static readonly Color GridHeader     = Color.FromArgb(240, 242, 248);   // Header bg
        private static readonly Color GridHeaderText = Color.FromArgb(50, 60, 85);      // Header text
        private static readonly Color GridAltRow     = Color.FromArgb(249, 250, 253);   // Alt row
        private static readonly Color GridSelection  = Color.FromArgb(220, 230, 255);   // Selected
        private static readonly Color GridLine       = Color.FromArgb(230, 233, 240);   // Lines

        // ─── Tab ─────────────────────────────────────────────────────
        private static readonly Color TabBg          = Color.FromArgb(235, 238, 245);   // Unselected tab
        private static readonly Color TabSelected    = Color.White;                      // Selected tab
        private static readonly Color TabText        = Color.FromArgb(100, 110, 130);   // Unselected text
        private static readonly Color TabActiveText  = Color.FromArgb(66, 112, 245);    // Selected text

        // ─── Fonts ───────────────────────────────────────────────────
        private static readonly Font DefaultFont     = new Font("Segoe UI", 10F, FontStyle.Regular);
        private static readonly Font BoldFont        = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        private static readonly Font TitleFont       = new Font("Segoe UI", 16F, FontStyle.Bold);
        private static readonly Font InputFontLarge  = new Font("Segoe UI", 12F, FontStyle.Regular);
        private static readonly Font LabelFontLarge  = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

        private const int BtnRadius = 7;

        // ═══════════════════════════════════════════════════════════════
        //  PUBLIC ENTRY POINTS
        // ═══════════════════════════════════════════════════════════════

        public static void ApplyTheme(Form form)
        {
            form.BackColor = Background;
            form.ForeColor = TextPrimary;
            form.Font = DefaultFont;
            form.StartPosition = FormStartPosition.CenterScreen;

            string formType = form.GetType().Name;
            if (formType != "LoginForm" && formType != "Resgistration")
                form.WindowState = FormWindowState.Maximized;

            foreach (Control control in form.Controls)
                ApplyControlTheme(control);
        }

        public static void ApplyLargeTheme(Form form)
        {
            ApplyTheme(form);
            ScaleControls(form, 1.15f);
        }

        // ═══════════════════════════════════════════════════════════════
        //  SCALE HELPER
        // ═══════════════════════════════════════════════════════════════

        private static void ScaleControls(Control parent, float factor)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Label lbl && lbl.Font.Size < 16)
                    lbl.Font = new Font(lbl.Font.FontFamily, lbl.Font.Size * factor, lbl.Font.Style);
                else if (control is TextBox || control is MaskedTextBox || control is ComboBox || control is Button)
                    control.Font = new Font(control.Font.FontFamily, control.Font.Size * factor, control.Font.Style);

                if (control.HasChildren)
                    ScaleControls(control, factor);
            }
        }

        // ═══════════════════════════════════════════════════════════════
        //  RECURSIVE CONTROL THEMING
        // ═══════════════════════════════════════════════════════════════

        private static void ApplyControlTheme(Control control)
        {
            if (control is Button btn)
                StyleButton(btn);
            else if (control is ComboBox cb)
            {
                cb.BackColor = Surface;
                cb.ForeColor = TextPrimary;
                cb.Font = DefaultFont;
            }
            else if (control is TextBox tb)
            {
                tb.BackColor = Surface;
                tb.ForeColor = TextPrimary;
                tb.Font = DefaultFont;
                tb.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (control is MaskedTextBox mtb)
            {
                mtb.BackColor = Surface;
                mtb.ForeColor = TextPrimary;
                mtb.Font = DefaultFont;
            }
            else if (control is NumericUpDown nud)
            {
                nud.BackColor = Surface;
                nud.ForeColor = TextPrimary;
                nud.Font = DefaultFont;
                nud.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (control is DateTimePicker dtp)
            {
                dtp.CalendarMonthBackground = Surface;
                dtp.CalendarForeColor = TextPrimary;
                dtp.Font = DefaultFont;
            }
            else if (control is Label lbl)
                StyleLabel(lbl);
            else if (control is DataGridView dgv)
                StyleDataGridView(dgv);
            else if (control is TabControl tc)
                StyleTabControl(tc);
            else if (control is Panel pnl)
                StylePanel(pnl);
            else if (control is FlowLayoutPanel flp)
                flp.BackColor = Color.Transparent;
            else if (control is TableLayoutPanel tlp)
                tlp.BackColor = Color.Transparent;

            foreach (Control child in control.Controls)
                ApplyControlTheme(child);
        }

        // ═══════════════════════════════════════════════════════════════
        //  STYLE METHODS
        // ═══════════════════════════════════════════════════════════════

        private static void StyleButton(Button btn)
        {
            bool isDanger = IsDangerButton(btn);
            Color bg    = isDanger ? AccentRed : AccentBlue;
            Color hover = isDanger ? AccentRedHover : AccentHover;
            Color press = isDanger ? Color.FromArgb(170, 35, 55) : AccentPressed;

            btn.BackColor = bg;
            btn.ForeColor = TextOnAccent;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = hover;
            btn.FlatAppearance.MouseDownBackColor = press;
            btn.Font = BoldFont;
            btn.Cursor = Cursors.Hand;
            btn.Padding = new Padding(12, 6, 12, 6);
            
            // Respect designer-set fixed sizes for large buttons (like the Apply button)
            if (btn.AutoSize || btn.Height < 40)
            {
                btn.AutoSize = true;
                btn.AutoSizeMode = AutoSizeMode.GrowOnly;
            }

            // Rounded corners
            ApplyRoundedRegion(btn);
            btn.Resize += (s, e) => ApplyRoundedRegion(btn);
        }

        private static void ApplyRoundedRegion(Control c)
        {
            if (c.Width > 0 && c.Height > 0)
            {
                var path = CreateRoundedRect(new Rectangle(0, 0, c.Width, c.Height), BtnRadius);
                c.Region = new Region(path);
            }
        }

        private static bool IsDangerButton(Button btn)
        {
            string t = (btn.Text ?? "").ToLowerInvariant();
            return t.Contains("delete") || t.Contains("reject")
                || t.Contains("cancel") || t.Contains("logout")
                || t.Contains("dismiss") || t.Contains("close")
                || t.Contains("go back");
        }

        private static void StyleLabel(Label lbl)
        {
            lbl.BackColor = Color.Transparent;

            if (lbl.Font.Size >= 20)
                lbl.ForeColor = AccentTeal;                         // Big titles
            else if (lbl.Font.Size > 13)
            {
                lbl.ForeColor = AccentBlue;                         // Sub-titles
                lbl.Font = new Font("Segoe UI Semibold", lbl.Font.Size, FontStyle.Bold);
            }
            else
                lbl.ForeColor = TextSecondary;                      // Body labels
        }

        private static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Surface;
            dgv.GridColor = GridLine;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = GridHeader;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = GridHeaderText;
            dgv.ColumnHeadersDefaultCellStyle.Font = BoldFont;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 4, 6, 4);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 56;

            dgv.DefaultCellStyle.BackColor = Surface;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.Font = DefaultFont;
            dgv.DefaultCellStyle.SelectionBackColor = GridSelection;
            dgv.DefaultCellStyle.SelectionForeColor = TextPrimary;
            dgv.DefaultCellStyle.Padding = new Padding(6, 4, 6, 4);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = GridAltRow;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;

            EnableDoubleBuffered(dgv);
        }

        private static void StyleTabControl(TabControl tc)
        {
            tc.DrawMode = TabDrawMode.OwnerDrawFixed;
            tc.SizeMode = TabSizeMode.Normal;
            tc.Padding = new Point(20, 6);

            tc.DrawItem -= TabControl_DrawItem;
            tc.DrawItem += TabControl_DrawItem;

            foreach (TabPage tp in tc.TabPages)
            {
                tp.BackColor = Background;
                tp.ForeColor = TextPrimary;
                tp.Font = DefaultFont;
            }
        }

        private static void TabControl_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (sender is not TabControl tc) return;

            bool isSelected = tc.SelectedIndex == e.Index;
            Rectangle rect = tc.GetTabRect(e.Index);

            using (var bg = new SolidBrush(isSelected ? TabSelected : TabBg))
                e.Graphics.FillRectangle(bg, rect);

            if (isSelected)
            {
                using (var accent = new SolidBrush(AccentBlue))
                    e.Graphics.FillRectangle(accent, rect.Left + 4, rect.Bottom - 3, rect.Width - 8, 3);
            }

            Color textCol = isSelected ? TabActiveText : TabText;
            TextRenderer.DrawText(e.Graphics, tc.TabPages[e.Index].Text, BoldFont, rect, textCol,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private static void StylePanel(Panel pnl)
        {
            string name = (pnl.Name ?? "").ToLowerInvariant();

            if (name.Contains("notification"))
            {
                pnl.BackColor = NotifyBg;
                pnl.BorderStyle = BorderStyle.None;
                pnl.Padding = new Padding(14);
                pnl.Paint -= NotifyPaint;
                pnl.Paint += NotifyPaint;
            }
            else if (name.Contains("grid"))
            {
                pnl.BackColor = Surface;
            }
            else if (name.Contains("bottom") || name.Contains("button"))
                pnl.BackColor = SurfaceVariant;
            else
                pnl.BackColor = Color.Transparent;
        }

        private static void NotifyPaint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel pnl)
                using (var b = new SolidBrush(NotifyAccent))
                    e.Graphics.FillRectangle(b, 0, 0, 4, pnl.Height);
        }

        // ═══════════════════════════════════════════════════════════════
        //  HELPERS
        // ═══════════════════════════════════════════════════════════════

        private static GraphicsPath CreateRoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var gp = new GraphicsPath();
            gp.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            gp.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            gp.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            gp.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            gp.CloseFigure();
            return gp;
        }

        public static void EnableDoubleBuffered(DataGridView dgv)
        {
            var property = typeof(DataGridView).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            property?.SetValue(dgv, true, null);
        }
    }
}
