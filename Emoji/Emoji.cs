using System;
using System.Collections.Generic;

namespace Emoji
{
    public class Emoji
    {
        public String Emoticon { get; set; }
        public String Description { get; set; }
        public String Category { get; set; }
        public List<String> Aliases { get; set; }
        public List<String> Tags { get; set; }
        public String Unicode_Version { get; set; }
        public String IOS_Version { get; set; }

        public Emoji()
        {
            Emoticon = "";
            Description = "";
            Category = "";
            Aliases = new List<string>();
            Tags = new List<string>();
            Unicode_Version = "";
            IOS_Version = "";
        }

        private String ListToString(List<String> list)
        {
            String all = "";
            for (int x = 0; x < list.Count; x++)
            {
                all += list[x] + " ";
            }

            return all.Trim().Replace(" ", ", ");
        }

        public override String ToString()
        {
            return "Emoticon: " + Emoticon + "\nDescripiton: " + Description +
                "\nCategory: " + Category + "\nAliases: [" + ListToString(Tags)
                + "]\nUnicode_Version: " + Unicode_Version + "" +
                "\nIOS_Version: " + IOS_Version;
        }
    }
}
