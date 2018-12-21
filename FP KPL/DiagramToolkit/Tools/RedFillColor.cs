using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit.Tools
{
    public partial class RedFillColor : Component
    {
        public RedFillColor()
        {
            InitializeComponent();
        }

        public RedFillColor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
