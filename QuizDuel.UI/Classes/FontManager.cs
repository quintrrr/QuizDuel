using System.Drawing.Text;
using System.Reflection;

public class FontManager
{
    private static PrivateFontCollection? _fonts;

    public static Font GetCustomFont(float size, FontStyle style = FontStyle.Regular)
    {
        if (_fonts == null)
        {
            _fonts = new PrivateFontCollection();

            var fontStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("QuizDuel.UI.Resources.Fonts.MOLOKO.ttf");

            if (fontStream is null)
                throw new FileNotFoundException("Не найден шрифт MOLOKO.ttf в ресурсах.");

            byte[] fontData = new byte[fontStream.Length];
            fontStream.Read(fontData, 0, (int)fontStream.Length);

            unsafe
            {
                fixed (byte* pFontData = fontData)
                {
                    _fonts.AddMemoryFont((IntPtr)pFontData, fontData.Length);
                }
            }
        }

        return new Font(_fonts.Families[0], size * 1.33f, style);
    }
}