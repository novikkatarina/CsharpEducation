Task10.Stack<int> stack = new Task10.Stack<int>(10);

stack.Push(1);
stack.Push(2);
stack.Push(3);
Console.WriteLine(stack.Peek());
stack.Pop();
Console.WriteLine(stack.Peek());
