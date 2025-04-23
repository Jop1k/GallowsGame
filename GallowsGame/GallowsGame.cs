using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    class GallowsGame
    {
        private const int MaxErrors = 6;
        private readonly string[] Words = File.ReadAllText("Words.txt").ToLower().Split(' ');
        private int _errors = 0;
        private string _searchWord = String.Empty;
        private string _encryptedWord = String.Empty;

        public void PlayGame()
        {
            _errors = 0;
            _searchWord = GetRandomWord();
            _encryptedWord = EncryptedWord(_searchWord);

            Console.Clear();
            Console.WriteLine("Слово загадано!");
            while (true)
            {
                PrintGallows(_errors);
                Console.WriteLine($"Оставшееся число попыток: {MaxErrors - _errors}");
                Console.WriteLine($"Зашифрованное слово: {_encryptedWord}");
                Console.Write("Предполагаемая буква из этого слова: ");

                char userLetter;
                while (true)
                {
                    string s = Console.ReadLine().ToLower();
                    if(s.Length == 1)
                    {
                        userLetter = s[0];
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введите 1 букву");
                    }
                }

                    Console.Clear();

                if (SearchLetterInSearchWord(userLetter))
                {
                    if (_searchWord == _encryptedWord)
                    {
                        Console.WriteLine($"Вы сумели угадать все буквы слова \"{_searchWord}\"");
                        PrintGallows(_errors);
                        Console.WriteLine("Вы победили!");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Вы угадали!");
                    }
                }
                else
                {
                    if (++_errors >= MaxErrors)
                    {
                        Console.WriteLine($"Вы истратили все попытки так и не сумев угадать слово \"{_searchWord}\"");
                        PrintGallows(_errors);
                        Console.WriteLine("YOU DIED");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Вы не угадали :(");
                    }
                }

            }
        }
        private bool SearchLetterInSearchWord(char letter)
        {
            bool flag = false;

            if (_searchWord.Contains(letter))
            {
                flag = true;
                ChangeLetterInEncryptedWord(letter);
            }

            return flag;
        }
        private void ChangeLetterInEncryptedWord(char letter)
        {
            var copyEncryptedWord = new StringBuilder(_encryptedWord);

            int cntIndex = 0;
            foreach (char ch in _searchWord)
            {
                if (letter == ch)
                {
                    copyEncryptedWord[cntIndex] = letter;
                }
                cntIndex++;
            }

            _encryptedWord = copyEncryptedWord.ToString();
        }
        private string GetRandomWord()
        {
            var random = new Random();
            return Words[random.Next(0, Words.Length)];
        }
        private string EncryptedWord(string word)
        {
            string encryptedWord = String.Empty;

            foreach (char x in word)
            {
                encryptedWord += "*";
            }

            return encryptedWord;
        }
        private void PrintGallows(int phase)
        {
            switch (phase)
            {
                case 0:
                    Console.WriteLine(@"











                        ");
                    break;
                case 1:
                    Console.WriteLine(@"








|
|
=============
                        ");
                    break;
                case 2:
                    Console.WriteLine(@"




|
|
|
|
|
|
=============
                        ");
                    break;
                case 3:
                    Console.WriteLine(@"
 ___
/
|
|
|
|
|
|
|
|
=============
                        ");
                    break;
                case 4:
                    Console.WriteLine(@"
 ________
/
|
|
|
|
|
|
|
|
=============
                        ");
                    break;
                case 5:
                    Console.WriteLine(@"
 ________
/      |
|      |
|      |
|
|
|
|
|
|
=============
                        ");
                    break;
                case 6:
                    Console.WriteLine(@"
 ________
/      |
|      |
|      |
|      O
|     /|\
|      |
|     / \
|
|
=============
                        ");
                    break;
            }
        }
    }
}
