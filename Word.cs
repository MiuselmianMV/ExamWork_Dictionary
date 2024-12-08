using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork_Dictionary
{
    public class Word
    {
        private string Self {  get; set; }

        private List<string> Translations = new List<string>();

        public Word(string self, string translation)
        {
            Self = self;
            Translations.Add(translation);
        }

        public Word(string self, List<string> translations)
        {
            Self = self;
            translations.ForEach(t => Translations.Add(t));
        }

        public string GetSelf() {  return Self; }
        public void SetSelf(string self) { Self = self; }
        public List<string> GetTranslations() {  return Translations; }

        public void AddTranslation(string translation)
        {
            Translations.Add(translation);
        }

        public void RemoveTranslation(string translation)
        {
            if (Translations[0] == Translations.Last())
                throw new Exception("Cannot delete the last translation of the word! ");
            else 
                Translations.Remove(translation);
        }

        public static bool operator == (Word left, Word right)
        {
            return left.Self == right.Self;
        }

        public static bool operator != (Word left, Word right)
        {
            return !(left == right);
        }

        public static bool operator ==(Word left, string right)
        {
            return left.Self == right;
        }
        public override string ToString()
        {
            return $"{Self}";
        }

        public static bool operator !=(Word left, string right)
        {
            return !(left.Self == right);
        }

        public static bool operator ==(string left, Word right)
        {
            return left == right.Self;
        }

        public static bool operator !=(string left, Word right)
        {
            return !(left == right.Self);
        }

    }
}
