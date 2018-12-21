
using System;
using System.Drawing;
using System.Windows.Forms;
using DiagramToolkit.Shapes;

namespace DiagramToolkit.Tools
{
    public class GreenFillColor : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedObj;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public GreenFillColor()
        {
            this.Name = "Green Fill Color";
            this.ToolTipText = "Green Fill Color";
            this.Image = IconSet.bounding_box;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedObj = canvas.GetObjectAt(e.X, e.Y);
                if (selectedObj is Rectangles)
                {
                    selectedObj.brush = Brushes.Green;
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {

        }

        public void ToolHotKeysDown(object sender, Keys e)
        {

        }
    }
}
