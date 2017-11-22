using System;
using System.Collections.Generic;

namespace Emoji
{
    public class HashTable
    {
        // only house should have a collision
        public readonly UInt64 TABLE_LENGTH = 27449; // 81799
        public List<Emoji>[] TABLE;

        public HashTable()
        {
            TABLE = new List<Emoji>[TABLE_LENGTH];
        }

        public void Add(Emoji emoji){
            if(string.IsNullOrEmpty(emoji.Description)){
                return;
            }
            UInt64 index = Hash2(emoji.Description);
            if(TABLE[index] == null){
                //Console.WriteLine("FIRST ONE HERE");
                TABLE[index] = new List<Emoji>();
                TABLE[index].Add(emoji);
            }
            else{
                Console.WriteLine("COLLISION: \nDESC: " + emoji.Description);
            }
        }

        public Boolean Delete(String key){
            return true;
        }

        private long Hash(string str)
        {
            long h = 18287;
            foreach (char c in str)
            {
                h = h * 101 + c + str.GetHashCode();
            }
            // mod by table size to make sure it hits it
            //return Math.Abs( h % TABLE_LENGTH );
            return h;
        }

        static UInt64 Hash2(string read)
        {
            UInt64 hashedValue = 3074457345618258791ul;
            for (int i = 0; i < read.Length; i++)
            {
                hashedValue += read[i];
                hashedValue *= 3074457345618258799ul;
            }
            return hashedValue;
        }
    }
}
