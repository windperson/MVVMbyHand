using System;
using System.Collections.Generic;
using System.Text;

namespace LibModel
{
    public class WordConverter
    {
        public static readonly string[] Types = {"Upper", "Lower"};

        private readonly string _converterType;

        public WordConverter(string converterType)
        {
            _converterType = converterType;
        }

        public string Convert(string input)
        {
            var ret = input;

            switch (_converterType)
            {
                case "Upper":
                    ret = input.ToUpper();
                    break;
                case "UpperInvariant":
                    ret = input.ToUpperInvariant();
                    break;
                case "Lower":
                    ret = input.ToLower();
                    break;
                case "LowerInvariant":
                    ret = input.ToLowerInvariant();
                    break;
                default:
                    break;
            }

            return ret;
        }
    }
}
