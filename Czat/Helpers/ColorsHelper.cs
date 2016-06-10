using System.Windows.Media;

namespace Czat.Helpers
{
    internal class ColorsHelper
    {
        public static Brush GetBrushFromColor(string hexCode)
        {
            var converter = new BrushConverter();
            return (Brush) converter.ConvertFromString(hexCode);
        }

        public static Brush GetPrimaryColorBrush()
        {
            return GetBrushFromColor("#9C27B0");
        }

        public static Brush GetSecondaryColorBrush()
        {
            return GetBrushFromColor("#009688");
        }

        public static Brush GetBackgroundColorBrush()
        {
            return GetBrushFromColor("#E0E0E0");
        }

        public static Brush GetDarkForegroundColorBrush()
        {
            return Brushes.Black;
        }

        public static Brush GetLightForegroundColorBrush()
        {
            return Brushes.White;
        }
    }
}
