using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Emoji
{
    class Program
    {
        List<Emoji> EmojiList { get; set; }
        public List<string> EmoticonList { get; set; }
        List<string> CategoryList { get; set; }
        List<List<string>> AliasList { get; set; }
        List<List<string>> TagsList { get; set; }
        List<Double> UnicodeVList { get; set; }
        List<Double> IOSVList { get; set; }

        public List<Emoji> GetAllEmojis()
        {
            if (EmojiList == null)
            {
                // set the fields once, so no extra work is done later
                EmojiList = JsonConvert.DeserializeObject<List<Emoji>>
                                       (File.ReadAllText(@"emojis.json"));

                EmoticonList = new List<string>();
                CategoryList = new List<string>();
                AliasList = new List<List<string>>();
                TagsList = new List<List<string>>();
                UnicodeVList = new List<double>();
                IOSVList = new List<double>();

                foreach (Emoji emoji in EmojiList)
                {
                    EmoticonList.Add(emoji.Emoticon);
                    CategoryList.Add(emoji.Category);
                    AliasList.Add(emoji.Aliases);
                    TagsList.Add(emoji.Tags);

                    if (!string.IsNullOrEmpty(emoji.Unicode_Version))
                        UnicodeVList.Add(Double.Parse(emoji.Unicode_Version));

                    if (!string.IsNullOrEmpty(emoji.IOS_Version))
                        IOSVList.Add(Double.Parse(emoji.IOS_Version));

                }

            }
            return EmojiList;
        }

        public static void PrintList(List<string> list)
        {
            for (int x = 0; x < list.Count; x++)
            {
                Console.WriteLine(list[x]);
            }

        }


        static void Main(string[] args)
        {
            Program program = new Program();
            List<Emoji> emojis = program.GetAllEmojis();

            IEnumerable<Emoji> emojiQuery =
            from emoji in emojis
            where emoji.Description.Contains("h")
            select emoji;
            
            foreach (Emoji emoji in emojiQuery)
            {
                try
                {
                    Console.WriteLine("{0}, {1}",
                                      emoji.Emoticon, emoji.Description);
                }catch(Exception e){
                    Console.WriteLine(e);
                }
            }
        }
    }
}
