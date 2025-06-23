using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoPadariaApp.Properties.Style
{
    public static class ThemeColor
    {
        public static Dictionary<string, string> ColorList = new Dictionary<string, string>
        {
            { "Encomendas", "#008080" },
            { "Produtos", "#B71C46" },
            { "Stock", "#9C27B0" },
            { "Fornecedores", "#0094BC" },
            { "Funcionarios", "#EA4833" },
            { "Logs", "#8BC240" },
        };

        public static Color ChangeColorBrightness(Color color, double correctionFactor) 
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;
            
            if (correctionFactor < 0) 
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            } 
            else 
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
