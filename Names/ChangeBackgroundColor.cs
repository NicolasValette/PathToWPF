
using System.Windows.Media;

namespace Names
{

    public static class ChangeBackgroundColor
    {
        public enum Mode
        {
            Add,
            Substract
        }

        private static Color AddColor(Color colorCheck, Color oldColor)
        {
            return Color.Add(colorCheck, oldColor);
        }
        private static Color SubstractColor(Color colorCheck, Color oldColor)
        {
            return Color.Subtract(oldColor, colorCheck);
        }

        public static SolidColorBrush ChangeColor(string r)
        {
            return new((Color)ColorConverter.ConvertFromString(r));
        }

        public static SolidColorBrush ChangeColor(Color _colorCheck, Color _oldColor, bool isAdd)
        {
            Color c = isAdd ? AddColor(_colorCheck, _oldColor) : SubstractColor(_oldColor, _colorCheck);
            c.A = byte.MaxValue;
            return new SolidColorBrush(c);
        }
    }
}
