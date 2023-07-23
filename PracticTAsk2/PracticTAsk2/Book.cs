namespace PracticTAsk2
{
    // Создай класс "Книга" с полями "Название" и "Автор". Реализуй два конструктора:
    // один с параметрами для инициализации полей, другой без параметров, который
    // будет устанавливать значения по умолчанию.
    // 5. Создай класс "Книга" с полями "Название" и "Автор". Реализуй два конструктора:
    // один с параметрами для инициализации полей, другой без параметров, который
    // будет устанавливать значения по умолчанию. Расширь класс "Книга" из
    //     предыдущего задания, добавив поле "Год издания". Реализуй цепочку
    // конструкторов так, чтобы можно было создавать объекты класса "Книга" с
    //     указанием только названия, названия и автора, или всех трех полей.

    // 11. Создай класс "Книга" с полями "Название" и "Автор". Напиши метод, который будет
    // принимать объект класса "Книга" и возвращать информацию о книге в виде строки.

    public class Book
    {
        public string author;
        public string name;
        public string yearPublication;

        public Book(string name, string author)
        {
            this.author = author;
            this.name = name;
        }

        public Book()
        {
            author = "no name";
            name = "no name";
        }

        public Book(string name)
        {
            this.name = "no name";
        }

        public Book(string name, string author, string yearPublication)
        {
            this.name = name;
            this.author = author;
            this.yearPublication = yearPublication;
        }

        public string GetInfo()
        {
            return ($"{name} {author}");
        }
    }
}