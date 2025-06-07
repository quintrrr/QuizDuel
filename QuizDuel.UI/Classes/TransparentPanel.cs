namespace QuizDuel.UI.Classes
{
    public class TransparentPanel : Panel
    {
        public Color FillColor { get; set; } = Color.FromArgb(204, 78, 185, 229);

        public TransparentPanel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using var brush = new SolidBrush(FillColor);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
            base.OnPaint(e);
        }
    }
}
