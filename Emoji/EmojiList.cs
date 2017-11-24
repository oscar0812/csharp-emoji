using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Emoji
{
    public class EmojiList
    {
        private List<Emoji> MainList { get; set; }
        private EmojiQuery EmojiQuery { get; set; }

        public EmojiList()
        {
            Start(null);
        }

        private EmojiList(List<Emoji> list)
        {
            Start(list);
        }

        // only called when class is instantiated
        private void Start(List<Emoji> list)
        {
            // set the fields once, so no extra work is done later
            if (list == null)
                MainList = JsonConvert.DeserializeObject<List<Emoji>>
                    (File.ReadAllText(@"emojis.json"));
            else
                MainList = list;

            EmojiQuery = new EmojiQuery(MainList);

        }

        public List<Emoji> GetAllEmojis()
        {
            return MainList;
        }

        public EmojiList SearchByDescription(string desc)
        {
            List<Emoji> l = EmojiQuery.SearchBy("Description", desc);
            return new EmojiList(l);
        }

        public EmojiList SearchByCategory(string cat)
        {
            List<Emoji> l =  EmojiQuery.SearchBy("Category", cat);
            return new EmojiList(l);
        }
        
        public EmojiList SearchByAlias(string alias)
        {
            List<Emoji> l =  EmojiQuery.SearchBy("Aliases", alias);
            return new EmojiList(l);
        }
        
        public EmojiList SearchByTag(string tag)
        {
            List<Emoji> l =  EmojiQuery.SearchBy("Tags", tag);
            return new EmojiList(l);
        }

        public EmojiList SearchByVersion(double v)
        {
            List<Emoji> u = EmojiQuery.SearchBy("unicodeversion", v+"");
            List<Emoji> i = EmojiQuery.SearchBy("iosversion", v+"");

            u.AddRange(i);
            return new EmojiList(u);
        }

        public static void PrintList(List<Emoji> list)
        {
            foreach (var e in list)
            {
                Console.WriteLine(e);
            }

        }

        public static void PrintList(EmojiList list)
        {
            PrintList(list.GetAllEmojis());
        }
    }
}