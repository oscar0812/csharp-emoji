using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Emoji
{
    class Program
    {
        static void Main(string[] args)
        {
            EmojiList list = new EmojiList();
            EmojiList.PrintList(list.SearchByDescription("c").SearchByDescription("sm").
                SearchByDescription("face").SearchByCategory("people"));
            Console.WriteLine("DONE");
        }
    }
}