namespace PracticTask1;

public class Animal
{
    // 25. Создайте класс Animal. Добавьте в него свойства, соответствующие атрибутам
    //     животных (кличка, голос, предпочитаемая еда и тд). Создайте несколько
    // экземпляров класса Animal, соответствующие разным животным.
    //     a. Добавьте в класс Animal конструктор с параметрами, которые соответствуют
    // созданным свойствам.
    //     b. Сделайте все свойства только для чтения.

    public string Name { get; }
    public string Voice { get; }
    public string Food { get; }
    public string Toy { get; }

    public Animal(string name, string voice, string food, string toy)
    {
        this.Name = name;
        this.Voice = voice;
        this.Toy = toy;
        this.Food = food;
    }
}