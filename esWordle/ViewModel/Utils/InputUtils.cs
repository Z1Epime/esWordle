using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esWordle.ViewModel.Utils
{
    public enum InputTry
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
    }

    public static class InputTryExtensions
    {
        /// <summary>
        /// Returns the next enumeration value of the <see cref="InputTry"/> enumeration.
        /// </summary>
        public static InputTry Next(this InputTry source)
        {
            InputTry[] values = Enum.GetValues<InputTry>();

            int index = Array.IndexOf(values, source) + 1;

            return (index == values.Length) ? values[0] : values[index];
        }
    }

    public class Input
    {
        public const int Length = 5;

        public InputTry Try { get; set; }
        public Word Word { get; set; }
    }
}
