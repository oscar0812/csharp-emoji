using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Emoji
{
    class Program
    {
        private List<Emoji> EmojiList { get; set; }
        private EmojiQuery EmojiQuery { get; set; }

        public Program()
        {
            Start();
        }

        // only called when class is instantiated
        void Start()
        {
            // set the fields once, so no extra work is done later
            EmojiList = JsonConvert.DeserializeObject<List<Emoji>>
                (File.ReadAllText(@"emojis.json"));

            EmojiQuery = new EmojiQuery(EmojiList);

        }

        public List<Emoji> GetAllEmojis()
        {
            return EmojiList;
        }

        public List<Emoji> SearchByDescription(string desc)
        {
            return EmojiQuery.SearchByDescription(desc);
        }

        public List<Emoji> SearchByCategory(string cat)
        {
            return EmojiQuery.SearchByCategory(cat);
        }
        
        public List<Emoji> SearchByAlias(string alias)
        {
            return EmojiQuery.SearchByAlias(alias);
        }
        
        public List<Emoji> SearchByTag(string alias)
        {
            return EmojiQuery.SearchByTag(alias);
        }

        public static void PrintList(List<Emoji> list)
        {
            foreach (var e in list)
            {
                Console.WriteLine(e);
            }

        }

        static void Main(string[] args)
        {
            var program = new Program();
            PrintList(program.SearchByCategory("Activity"));
            PrintList(program.SearchByCategory("Activity"));
        }
    }
}