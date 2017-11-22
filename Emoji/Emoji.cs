using System;
using System.Collections.Generic;

namespace Emoji
{
    public class Emoji
    {
        public string Emoticon { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<string> Aliases { get; set; }
        public List<string> Tags { get; set; }
        public string UnicodeVersion { get; set; }
        public string IOSVersion { get; set; }

        public Emoji()
        {
            Emoticon = "";
            Description = "";
            Category = "";
            Aliases = new List<string>();
            Tags = new List<string>();
            UnicodeVersion = "";
            IOSVersion = "";
        }

        private string ListToString(List<string> list)
        {
            string all = "";
            for (int x = 0; x < list.Count; x++)
            {
                all += list[x] + " ";
            }

            return all.Trim().Replace(" ", ", ");
        }

        public override string ToString()
        {
            return "Emoticon: " + Emoticon + "\nDescripiton: " + Description +
                   "\nCategory: " + Category + "\nAliases: [" + ListToString(Aliases)
                   + "]\nTags: ["+ListToString(Tags)+"]\nUnicodeVersion: " + UnicodeVersion + "" +
                   "\nIOSVersion: " + IOSVersion;
        }
    }
}
