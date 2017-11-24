using System;
using System.Collections.Generic;

namespace Emoji
{
    public class EmojiQuery
    {
        private List<Emoji> Emojis { get; }
        private readonly Dictionary<string, List<Emoji>> _dictionary = new Dictionary<string, List<Emoji>>();

        public EmojiQuery(List<Emoji> emojis)
        {
            Emojis = emojis;
            foreach (var emoji in emojis)
            {
                var descr = emoji.Description;
                var cate = emoji.Category;
                var unicode = emoji.UnicodeVersion;
                var ios = emoji.IOSVersion;
                var aliases = emoji.Aliases;
                var tags = emoji.Tags;

                add("D-", descr, emoji);
                add("C-", cate, emoji);
                add("U-", unicode, emoji);
                add("I-", ios, emoji);

                foreach (var str in aliases)
                {
                    add("A-", str, emoji);
                }

                foreach (var str in tags)
                {
                    add("T-", str, emoji);
                }
            }
        } //  end of constructor

        private void add(string id, string item, Emoji emoji)
        {
            if (!_dictionary.ContainsKey(id + item))
            {
                _dictionary[id + item] = new List<Emoji> {emoji};
            }
            else
            {
                _dictionary[id + item].Add(emoji);
            }
        }

        public List<Emoji> SearchBy(string field, string searchThis)
        {
            searchThis = searchThis.ToLower();
            var searchKey = field.ToUpper()[0] + "-" + searchThis;

            return _dictionary.ContainsKey(searchKey)
                ? _dictionary[searchKey]
                : SearchList(field.ToUpper(), searchThis);
        }

        private List<Emoji> SearchList(string field, string searchThis)
        {
            var list = new List<Emoji>();
            foreach (var e in Emojis)
            {
                var item = e.GetField(field);
                switch (item)
                {
                    case string _:
                        if (((string) item).ToLower().Contains(searchThis.ToLower()))
                        {
                            list.Add(e);
                            add(field[0] + "-", searchThis, e);
                        }
                        break;
                    case List<string> _:
                        if (field[0] == 'A' && e.AliasContains(searchThis) ||
                            (field[0] == 'T' && e.TagContains(searchThis)))
                        {
                            list.Add(e);
                            add(field[0] + "-", searchThis, e);
                        }
                        break;
                }
            }

            return list;
        }
    }
}