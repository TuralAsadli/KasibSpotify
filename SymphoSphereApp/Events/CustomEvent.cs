using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.Events
{
    public class CustomEvent : EventArgs
    {
        public IconButton IconButton { get; }

        public CustomEvent(IconButton iconButton)
        {
            IconButton = iconButton;
            
        }
    }
}
