namespace ExamWork_Dictionary
{
    public class Program
    {
        private static UserDictionary MyDict  = new UserDictionary("none"); 
        static void Main()
        {
            var myDict = new UserDictionary("Ru-eng");
            myDict.Add("Картошка", "potato");
            myDict.Add("Картошка", "potato");
            myDict.Add("Семь", "seven");
            myDict.Add("Сумасшедший", "crazy");
            myDict.Add("Крутой", "cool");
            myDict.Add("Длинный", "long");
            myDict.Add("Водить", "drive");
            myDict.Add("Мама", ["mother", "mommy", "mum"]);
            myDict.Add("Папа", ["father", "daddy", "dad"]);

            myDict.Show();
            while (true)
            {
                Menu();
            }
        }

        public static void Menu()
        {
            Console.Clear();
            string menu_txt = "\t\t\t\tMenu:\n" +
                              "\t\t1.Create a new dictionary.\n" +
                              "\t\t2.Add words\\translations to dictionary.\n" +
                              "\t\t3.Replace words\\translations in dictionary.\n" +
                              "\t\t4.Remove words\\translations in dictionary.\n" +
                              "\t\t5.Find translations for the word.\n" +
                              "\t\t6.Save word to file.\n" +
                              "\t\t7.Exit.";

            string path = @".\\dictionary.txt";
            var dictFile = new FileInfo(path);
            Console.WriteLine(menu_txt);
            int.TryParse(Console.ReadLine(), out int action);
            switch (action)
            {
                case 1:
                    Console.WriteLine("What type of dict do you want to create? Enter in format ru-eng\\eng-ru: ");
                    string type = Console.ReadLine();

                    File.Create(path);
                    
                    MyDict = new UserDictionary((type == null) ? "ru-eng" : type);

                    Console.WriteLine("Successully created a new dictionary.");
                    return;
                case 2:
                    string text = "\t\t\t\tMenu:\n" +
                                       "\t\t1.Add word.\n" +
                                       "\t\t2.Add translation.\n" +
                                       "\t\t3.Back.";
                    Console.WriteLine(text);
                    int.TryParse(Console.ReadLine(), out int add);
                    switch (add)
                    {
                        case 1:
                            Console.Write("Enter word, that you want to add: ");
                            string word = Console.ReadLine();
                            Console.Write("Enter translations to your word.\nIf there are more than one translation just divide them with space: ");
                            string[] translations = Console.ReadLine().Split(' ');
                            if (translations.Count() == 1)
                            {
                                MyDict.Add(word, translations[0]);
                                Console.WriteLine("Word successfully added to your dictionary!");
                            }
                            else if (translations.Count() > 1)
                            {
                                List<string> lst = new List<string>(translations);
                                MyDict.Add(word, lst);
                                Console.WriteLine("Word successfully added to your dictionary!");
                            }
                            else
                            {
                                Console.WriteLine("We can't save your word without translations. Try again: ");
                                Console.Write("Enter translations to your word.\nIf there are more than one translation just divide them with space: ");
                                string[] translationsSecondChance = Console.ReadLine().Split(' ');
                                if (translationsSecondChance.Count() == 1)
                                {
                                    MyDict.Add(word, translationsSecondChance[0]);
                                    Console.WriteLine("Word successfully added to your dictionary!");
                                }
                                else if (translationsSecondChance.Count() > 1)
                                {
                                    List<string> lst = new List<string>(translationsSecondChance);
                                    MyDict.Add(word, lst);
                                    Console.WriteLine("Word successfully added to your dictionary!");
                                }
                                else
                                {
                                    Console.WriteLine("Cannot initialize a word with no translations!");
                                }
                            }
                            return;
                        case 2:
                            Console.Write("Enter a word which you want to add a translation to: ");
                            word = Console.ReadLine();
                            Console.Write("Enter a translation you want to add: ");
                            string translation = Console.ReadLine();
                            MyDict.Add(word, translation);
                            return;
                    }

                    return;
            default:
                Console.WriteLine("\nUnknown command, please enter a number between 1 and 6 to work with dictionaries, or enter 7 if you want to finish the work with program.\n");
                return;
            }

        }

        public static void Case2()
        {
            string text = "\t\t\t\tMenu:\n" +
                              "\t\t1.Add word.\n" +
                              "\t\t2.Add translation.\n" +
                              "\t\t3.Back.";
            Console.WriteLine(text);
            int.TryParse(Console.ReadLine(), out int add);
            switch (add)
            {
                case 1:
                    Console.Write("Enter word, that you want to add: ");
                    string word = Console.ReadLine();
                    Console.Write("Enter translations to your word.\nIf there are more than one translation just divide them with space: ");
                    string[] translations = Console.ReadLine().Split(' ');
                    if (translations.Count() == 1)
                    {
                        MyDict.Add(word, translations[0]);
                        Console.WriteLine("Word successfully added to your dictionary!");
                    }
                    else if (translations.Count() > 1)
                    {
                        List<string> lst = new List<string>(translations);
                        MyDict.Add(word, lst);
                        Console.WriteLine("Word successfully added to your dictionary!");
                    }
                    else
                    {
                        Console.WriteLine("We can't save your word without translations. Try again: ");
                        Console.Write("Enter translations to your word.\nIf there are more than one translation just divide them with space: ");
                        string[] translationsSecondChance = Console.ReadLine().Split(' ');
                        if (translationsSecondChance.Count() == 1)
                        {
                            MyDict.Add(word, translationsSecondChance[0]);
                            Console.WriteLine("Word successfully added to your dictionary!");
                        }
                        else if (translationsSecondChance.Count() > 1)
                        {
                            List<string> lst = new List<string>(translationsSecondChance);
                            MyDict.Add(word, lst);
                            Console.WriteLine("Word successfully added to your dictionary!");
                        }
                        else
                        {
                            Console.WriteLine("Cannot initialize a word with no translations!");
                        }
                    }
                    return;
                case 2:
                    Console.Write("Enter a word which you want to add a translation to: ");
                    word = Console.ReadLine();
                    Console.Write("Enter a translation you want to add: ");
                    string translation = Console.ReadLine();
                    MyDict.Add(word, translation);
                    return;
            }
        }
        public static void SaveToFile(Word w)
        {
            Console.WriteLine("Enter the name of the file, to where you want to save your translations: ");
            string name = Console.ReadLine();
            if (name == null) 
                name = "myTranslation";

            var newF = new FileInfo($"ExamWork_Dictionary\\{name}.txt");

            string wordInfo = $"{w.GetSelf()} ";
            foreach (var t in w.GetTranslations())
            {
                wordInfo += t + ", ";
            }

            var writer = newF.AppendText();
            writer.WriteLine(wordInfo);
        }


    }
}
