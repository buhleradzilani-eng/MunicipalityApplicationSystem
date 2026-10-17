using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalityApplicationSystem
{
    internal static class MunicipalityTheme
    {
        public static readonly Color Orange = Color.FromArgb(201, 109, 45);
        public static readonly Color OrangeDark = Color.FromArgb(166, 78, 28);
        public static readonly Color Brown = Color.FromArgb(139, 94, 60);
        public static readonly Color DarkBrown = Color.FromArgb(74, 48, 36);
        public static readonly Color Cream = Color.FromArgb(255, 248, 240);
        public static readonly Color SoftCream = Color.FromArgb(250, 242, 232);
        public static readonly Color White = Color.White;
        public static readonly Color Text = Color.FromArgb(65, 48, 38);
        public static readonly Color Muted = Color.FromArgb(125, 109, 98);
        public static readonly Color Border = Color.FromArgb(232, 218, 204);
        public static readonly Color Green = Color.FromArgb(59, 125, 92);
        public static readonly Color Blue = Color.FromArgb(75, 113, 150);

        public static Font MakeFont(float size, FontStyle style = FontStyle.Regular)
        {
            string family = FontFamily.Families.Any(f => f.Name.Equals(
                "Poppins", System.StringComparison.OrdinalIgnoreCase))
                ? "Poppins"
                : "Segoe UI";

            return new Font(family, size, style, GraphicsUnit.Point);
        }

        public static void StyleButton(Button button, bool primary = true)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = primary ? Orange : SoftCream;
            button.ForeColor = primary ? White : DarkBrown;
            button.Font = MakeFont(9.5f, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.Height = System.Math.Max(button.Height, 36);
            button.UseVisualStyleBackColor = false;
        }

        public static void StyleInput(Control control)
        {
            control.Font = MakeFont(9.5f);
            control.BackColor = White;
            control.ForeColor = Text;
        }

        public static void StyleForm(Form form)
        {
            form.BackColor = Cream;
            form.ForeColor = Text;
            form.Font = MakeFont(9.5f);
            form.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
