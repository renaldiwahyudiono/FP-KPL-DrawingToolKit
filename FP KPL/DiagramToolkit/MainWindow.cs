using DiagramToolkit.Commands;
using DiagramToolkit.MenuItems;
using DiagramToolkit.ToolbarItems;
using DiagramToolkit.Tools;
using System.Diagnostics;
using System.Windows.Forms;

namespace DiagramToolkit
{
    public partial class MainWindow : Form
    {
        private IToolbox toolbox;
        private IEditor editor;
        private IToolbar toolbar;
        private IMenubar menubar;

        public MainWindow()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            Debug.WriteLine("Initializing UI objects.");

            #region Editor and Canvas

            Debug.WriteLine("Loading canvas...");
            this.editor = new DefaultEditor();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.editor);

            ICanvas canvas2 = new DefaultCanvas();
            canvas2.Name = "Layer";
            this.editor.AddCanvas(canvas2);

            #endregion

            #region Commands

            //BlackCanvasBgCommand blackCanvasBgCmd = new BlackCanvasBgCommand(this.canvas);
            //WhiteCanvasBgCommand whiteCanvasBgCmd = new WhiteCanvasBgCommand(this.canvas);

            #endregion

            #region Toolbox

            // Initializing toolbox
            Debug.WriteLine("Loading toolbox...");
            this.toolbox = new DefaultToolbox();
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add((Control)this.toolbox);
            this.editor.Toolbox = toolbox;

            #endregion

            #region Tools

            // Initializing tools
            Debug.WriteLine("Loading tools...");
            this.toolbox.AddTool(new SelectionTool());
            this.toolbox.AddSeparator();
            this.toolbox.AddTool(new LineTool());
            this.toolbox.AddTool(new RectangleTool());
            this.toolbox.AddTool(new TextTool());
            this.toolbox.ToolSelected += Toolbox_ToolSelected;
            this.toolbox.AddTool(new RedFillColor());
            this.toolbox.AddTool(new BlueFillColor());
            this.toolbox.AddTool(new GreenFillColor());
            this.toolbox.AddTool(new RedBorderColor());
            this.toolbox.AddTool(new BlueBorderColor());
            this.toolbox.AddTool(new GreenBorderColor());

            #endregion

        }

        private void Toolbox_ToolSelected(ITool tool)
        {
            if (this.editor != null)
            {
                Debug.WriteLine("Tool " + tool.Name + " is selected");
                ICanvas canvas = this.editor.GetSelectedCanvas();
                canvas.SetActiveTool(tool);
                tool.TargetCanvas = canvas;
            }
        }
    }
}
