using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ExamWork_Dictionary
{
    public class UserDictionary : IMyDictionary
    {
        private List<Word> Words = new List<Word>();
        public string Type { get; set; }

        public UserDictionary(string type)
        {
            Type = type;
        }

        public void Add(string word, string translation)
        {
            foreach (var w in Words)
            {
                if (w == word)
                {
                    foreach (var t in w.GetTranslations())
                    {
                        if (t.ToLower() == translation.ToLower())
                        {
                            Console.WriteLine("Word already exists with such translation");
                            return;
                        }
                    }
                    w.AddTranslation(translation);
                }
            }
            var item = new Word(word, translation);
            Words.Add(item);
        }

        public void Add(string word, List<string> translations)
        {
            foreach (var w in Words)
            {
                if (w == word)
                {
                    foreach (var t in w.GetTranslations())
                    {
                        foreach (var new_t in translations)
                        {
                            if (t.ToLower() == new_t.ToLower())
                            {
                                translations.Remove(new_t);
                            }
                        }

                    }
                }
            }
            if (translations.Count != 0)
            {
                var item = new Word(word, translations);
                Words.Add(item);
            }
            else
            {
                Console.WriteLine("Word already exists with such translations");
            }
        }

        public void Clear()
        {
            Words.Clear();
        }


        public void Remove(string word)
        {
            foreach (var w in Words)
            {
                if (w == word)
                    Words.Remove(w);
            }
        }

        public void RemoveTranslation(string word, string translation)
        {
            foreach (var w in Words)
            {
                if (w == word)
                {
                    foreach (var t in w.GetTranslations())
                    {
                        if (t == translation)
                        {
                            w.RemoveTranslation(t);
                        }
                    }
                }
            }
        }

        public void ReplaceWord(string word, string replacement)
        {
            foreach (var w in Words)
            {
                if (w == word)
                    w.SetSelf(replacement);
            }
        }

        public void ReplaceTranslation(string word, string translation, string replacement)
        {
            foreach (var w in Words)
            {
                if (w == word)
                {
                    var transl_lst = w.GetTranslations();
                    for (int i = 0; i < transl_lst.Count; i++)
                    {
                        if (transl_lst[i] == translation)
                        {
                            transl_lst[i] = replacement;
                        }
                    }
                }
            }
        }


        public void Find(string word)
        {
            foreach (var w in Words)
            {
                if (w == word)
                {
                    Console.Write($"Translations for the word {w}: ");

                    foreach (var t in w.GetTranslations()) 
                        Console.Write(t + ", ");

                    Console.WriteLine();
                }
            }
        }
        
        public void Show()
        {
            foreach(var w in Words)
            {
                Console.Write($"{w} - ");

                foreach(var t in w.GetTranslations())
                    Console.Write(t + ", ");

                Console.WriteLine();
            }
        }
    }
    
    interface IMyDictionary
    {
        public void Add(string word, string translation);
        public void Add(string word, List<string> translations);
        public void Clear();
        public void Remove(string word);
        public void RemoveTranslation(string word, string translation);
        public void ReplaceWord(string word, string replacement);
        public void ReplaceTranslation(string word,string translation, string replacement);
        public void Find(string word);
        public void Show();
    }
}
