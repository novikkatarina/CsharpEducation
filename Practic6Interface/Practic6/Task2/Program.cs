using Task2;

// IClonable
// 1. Создайте класс "Person" с полями "Name" и "Age". Реализуйте интерфейс IClonable
// для этого класса, используя глубокое копирование.

Person p = new Person("Mnkx", 15, new Company("TYu"));

p.Clone();
