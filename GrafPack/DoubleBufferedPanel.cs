using System.Windows.Forms;

namespace GrafPack
{
    class DoubleBufferedPanel : Panel
    {
        //https://gregback.net/double-buffered-panels-in-c.html
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.OptimizedDoubleBuffer | 
                ControlStyles.UserPaint, true);
        }
    }
}
