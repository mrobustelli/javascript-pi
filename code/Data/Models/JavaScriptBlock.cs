using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaScriptPI.Helpers.Models
{
    public class JavaScriptBlock
    {
        public enum ViewModeValue
        {
            All = 0
            , ViewOnly = 1
            , EditOnly = 2
        }

        public int ArtifactID { get; set; }
        public String Text { get; set; }
        public ViewModeValue ViewMode { get; set; }
        
}
}
