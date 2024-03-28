using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.Start();
        }
    }

    enum MenuComand
    {
        AddBook = 1,
        DeleteBook = 2,
        FindBook = 3,
        Exit = 4
    }

    class Menu
    {
        public void Start()
        {
            Library library = new Library();

            bool isActive = true;

            MenuComand menuComand;

            while (isActive)
            {
                Console.Clear();
                Console.WriteLine("Библиотека\n");

                library.ShowAll();

                Console.WriteLine($"{(int)MenuComand.AddBook}) Добавить книгу\n" +
                                  $"{(int)MenuComand.DeleteBook}) Убрать книгу\n" +
                                  $"{(int)MenuComand.FindBook}) Найти по параметру\n" +
                                  $"{(int)MenuComand.Exit}) Выход\n");

                menuComand = (MenuComand)GetUserInput();

                switch (menuComand)
                {
                    case MenuComand.AddBook:
                        library.Add();
                        break;

                    case MenuComand.DeleteBook:
                        library.Remove();
                        break;

                    case MenuComand.FindBook:
                        library.Find();
                        break;

                    case MenuComand.Exit:
                        isActive = false;
                        break;

                    default:
                        Console.WriteLine("Не верная команда.");
                        break;
                }

                Console.WriteLine("Для продолжения нажмите любую клавишу . . .");
                Console.ReadKey();
            }
        }

        private int GetUserInput()
        {
            int result = 0;

            int.TryParse(Console.ReadLine(), out result);

            return result;
        }
    }

    class Library
    {
        private List<Book> _books = new List<Book>();

        public Library()
        {
            _books.Add(new Book("Клуб самоубийц", "Роберт Льюис Стивенсон", 2021, "Детектив", "978-5-17-116914-5"));
            _books.Add(new Book("Портрет Дориана Грея", "Уайльд Оскар", 2021, "Фентези", "978-5-17-099056-6"));
            _books.Add(new Book("Песнь пророка", "Линч Пол", 2024, "Роман", "978-5-389-24737-6"));
            _books.Add(new Book("Дюна", "Фрэнк Герберт", 2022, "Фентези", "978-5-17-151432-7"));
        }

        public void ShowAll()
        {
            Console.WriteLine("Полный список книг: ");

            for (int i = 0; i < _books.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_books[i].Author}: \"{_books[i].Title}\", {_books[i].Year}, {_books[i].Genre}, {_books[i].ISBN}");
            }

            Console.WriteLine();
        }

        public void Add()
        {
            int year;

            string title;
            string author;
            string genre;
            string isbn;

            title = UserEnterLine("Введите название книги: ");
            author = UserEnterLine("Введите автора книги: ");
            year = UserEnterNumber("Введите год издания книги: ");
            genre = UserEnterLine("Введите жанр: ");
            isbn = UserEnterLine("ISBN: ");

            _books.Add(new Book(title, author, year, genre, isbn));

            Console.Write("Книга добавлена.");
        }

        public void Remove()
        {
            int index = UserEnterNumber("Введите иномер книги для удаления: ") - 1;

            if (index <= _books.Count)
            {
                _books.RemoveAt(index);

                Console.WriteLine("Книга удалена.");
            }
            else
            {
                Console.WriteLine("Такого номера нет.");
            }
        }

        public void Find()
        {
            Book book = EnterFoundBook();

            if (book != null)
            {
                Console.WriteLine("Найденные книги:\n");

                foreach (Book _oneBook in _books)
                {
                    if (book.IsEqual(_oneBook))
                    {
                        _oneBook.Show();
                    }
                }
            }
        }

        private Book EnterFoundBook()
        {
            const int MenuFindByAuthor = 1;
            const int MenuFindByTitle = 2;
            const int MenuFindByYear = 3;
            const int MenuFindByGenre = 4;
            const int MenuFindByIsbn = 5;

            int userInput = 0;
            int year = 0;

            string author = string.Empty;
            string title = string.Empty;
            string genre = string.Empty;
            string isbn = string.Empty;

            Book book = null;

            userInput = UserEnterNumber($"{MenuFindByAuthor}) Поиск по автору\n" +
                                        $"{MenuFindByTitle}) Поиск по названию\n" +
                                        $"{MenuFindByYear}) Поиск по году издания\n" +
                                        $"{MenuFindByGenre}) Поиск по жанру\n" +
                                        $"{MenuFindByIsbn}) Поиск по ISBN\n" +
                                        "Для выхода нажми любую другую клавишу\n");

            switch (userInput)
            {
                case MenuFindByAuthor:
                    author = UserEnterLine($"Введите автора книги для поиска: ").ToLower();
                    break;

                case MenuFindByTitle:
                    title = UserEnterLine("Введите название книги для поиска: ").ToLower();
                    break;

                case MenuFindByYear:
                    year = UserEnterNumber("Введите год издания книги для поиска: ");
                    break;

                case MenuFindByGenre:
                    genre = UserEnterLine("Введите жанр книги для поиска: ").ToLower();
                    break;

                case MenuFindByIsbn:
                    isbn = UserEnterLine("Введите ISBN книги для поиска: ").ToLower();
                    break;

                default:
                    Console.WriteLine("Выход из поиска.\n");
                    break;
            }

            book = new Book(title, author, year, genre, isbn);

            return book;
        }

        private string UserEnterLine(string title)
        {
            Console.Write(title);

            return Console.ReadLine();
        }

        private int UserEnterNumber(string title)
        {
            int number = 0;

            Console.Write(title);

            int.TryParse(Console.ReadLine(), out number);

            return number;
        }
    }

    class Book
    {
        public Book(string title, string author, int year, string genre, string isbn)
        {
            Title = title;
            Author = author;
            Year = year;
            Genre = genre;
            ISBN = isbn;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
        public string Genre { get; private set; }
        public string ISBN { get; private set; }

        public bool IsEqual(Book other)
        {
            return (string.IsNullOrEmpty(Title) == false && other.Title.ToLower().IndexOf(Title) != -1)
                    || (string.IsNullOrEmpty(Author) == false && other.Author.ToLower().IndexOf(Author) != -1)
                    || other.Year.Equals(Year)
                    || (string.IsNullOrEmpty(Genre) == false && other.Genre.ToLower().IndexOf(Genre) != -1)
                    || (string.IsNullOrEmpty(ISBN) == false && other.ISBN.ToLower().IndexOf(ISBN) != -1);
        }

        public void Show()
        {
            Console.WriteLine($"{Author}: \"{Title}\", {Year}, {Genre}, {ISBN}");
        }
    }
}
