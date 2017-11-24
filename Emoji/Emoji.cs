using System;
using System.Collections.Generic;
using System.Linq;

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

        protected Emoji()
        {
            Emoticon = "";
            Description = "";
            Category = "";
            Aliases = new List<string>();
            Tags = new List<string>();
            UnicodeVersion = "";
            IOSVersion = "";
        }
        
        private static string ListToString(IEnumerable<string> list)
        {
            var all = list.Aggregate("", (current, t) => current + (t + " "));

            return all.Trim().Replace(" ", ", ");
        }
        
        // useful for querying
        public object GetField(string field)
        {
            switch (field)
            {
                case "DESCRIPTION":
                    return Description;
                case "CATEGORY":
                    return Category;
                case "ALIASES":
                    return Aliases;
                case "TAGS":
                    return Tags;
                case "UNICODEVERSION":
                    return UnicodeVersion;
                case "IOSVERSION":
                    return IOSVersion;
                default:
                    return Description;
            }
        }

        public bool TagContains(string str)
        {
            if (str == "")
            {
                return Tags.Count == 0;
            }
            return Tags.Any(s => s.ToLower().Contains(str.ToLower()));
        }
        
        public bool AliasContains(string str)
        {
            if (str == "")
            {
                return Aliases.Count == 0;
            }
            return Aliases.Any(s => s.ToLower().Contains(str.ToLower()));
        }

        public override string ToString()
        {
            return "{ Emoticon: " + Emoticon + ", Descripiton: " + Description +
                   ", Category: " + Category + ", Aliases: [" + ListToString(Aliases)
                   + "], Tags: ["+ListToString(Tags)+"], UnicodeVersion: " + UnicodeVersion +
                   ", IOSVersion: " + IOSVersion+" }";
        }
    }
}
