using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Letter
    {
        public string Character { get; set; }
        public HighlightColor HighlightColor { get; set; }

        public Letter()
        {
            
        }

        public Letter(string character, HighlightColor highlightColor)
        {
            Character = character;
            HighlightColor = highlightColor;
        }
    }
}
