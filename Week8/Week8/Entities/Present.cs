using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Abstractions;

namespace Week8.Entities
{
    public class Present : Toy
    {
        public SolidBrush PresentColor1 { get; private set; }
        public SolidBrush PresentColor2 { get; private set; }
        public Present(Color Color1, Color Color2)
        {
            PresentColor1 = new SolidBrush(Color1);
            PresentColor2 = new SolidBrush(Color2);

        }
        protected override void DrawImage(Graphics g)
        {
            g.FillRectangle(PresentColor1, 0, 0, this.Width, this.Height);
            g.FillRectangle(PresentColor2, 0, (this.Height / 5) * 2, this.Width, this.Height / 5);
            g.FillRectangle(PresentColor2, (this.Width / 5) * 2, 0, this.Width / 5, this.Height);

        }
    }
}
