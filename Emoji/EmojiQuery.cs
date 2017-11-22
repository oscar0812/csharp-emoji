using System;
using System.Collections.Generic;
using System.Linq;

namespace Emoji
{
    public class EmojiQuery
    {
        private readonly string DESCRIPTION = "D:";
        private readonly string CATEGORY = "C:";
        private readonly string ALIAS = "A:";
        private readonly string TAG = "T:";

        private List<Emoji> EmojiList { get; }
        private Dictionary<string, List<Emoji>> _dictionary { get; }

        public EmojiQuery(List<Emoji> emojiList)
        {
            EmojiList = emojiList;
            _dictionary = new Dictionary<string, List<Emoji>>();
        }

        public List<Emoji> SearchByDescription(string desc)
        {
            desc = desc.ToLower();
            var search = DESCRIPTION + desc;
            if (_dictionary.ContainsKey(search))
            {
                return _dictionary[search];
            }
            var list = EmojiList.Where(emoji => (desc == ""  && emoji.Description == desc) 
                                                || emoji.Description != "" && desc != "" && 
                                                emoji.Description.ToLower().Contains(desc)).ToList();

            _dictionary.Add(search, list);
            return list;
        }

        public List<Emoji> SearchByCategory(string cat)
        {
            cat = cat.ToLower();
            var search = CATEGORY + cat;
            if (_dictionary.ContainsKey(search))
            {
                return _dictionary[search];
            }
            var list = EmojiList.Where(emoji => (cat == "" && emoji.Category == cat) || 
                                                emoji.Category != "" && cat != "" 
                                                && emoji.Category.ToLower().Contains(cat)).ToList();

            _dictionary.Add(search, list);
            return list;
        }

        public List<Emoji> SearchByAlias(string alias)
        {
            alias = alias.ToLower();
            var search = ALIAS + alias;
            if (_dictionary.ContainsKey(search))
            {
                return _dictionary[search];
            }
            
            var list = EmojiList.Where
                (emoji => emoji.Aliases.Any(a => (alias == "" && emoji.Aliases.Count == 0) || 
                                                 (alias != "" && a.ToLower().Contains(alias)))).ToList();

            _dictionary.Add(search, list);
            return list;
        }
        
        public List<Emoji> SearchByTag(string tags)
        {
            tags = tags.ToLower();
            var search = TAG + tags;
            if (_dictionary.ContainsKey(search))
            {
                return _dictionary[search];
            }
            var list = EmojiList.Where(emoji => emoji.Tags.Any(t => tags != "" && t.ToLower().Contains(tags)) || 
                                                tags == "" && emoji.Tags.Count == 0).ToList();

            _dictionary.Add(search, list);
            return list;
        }
    }
}