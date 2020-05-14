using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Translator.Models
{
    public class Translator
    {
        public readonly Dictionary<string, string> _dictionary;

        public Translator(string path)
        {
            _dictionary = ReadDict(path);
        }

        private Dictionary<string, string> ReadDict(string inputName)
        {
            var dict = new Dictionary<string, string>();
            using (var input = new StreamReader(inputName))
            {
                string line = null;

                while ((line = input.ReadLine()) != null)
                {
                    var words = line.Split("=");
                    dict.Add(words[0], words[1]);
                }
            }

            return dict;
        }

        public string Transalte(string searchWord)
        {

            if (_dictionary.ContainsKey(searchWord))
            {
                return _dictionary.FirstOrDefault(x => x.Key == searchWord).Value;
            }
            else if (_dictionary.ContainsValue(searchWord))
            {
                return _dictionary.FirstOrDefault(x => x.Value == searchWord).Key;
            }

            return String.Empty;
        }
    }
}
