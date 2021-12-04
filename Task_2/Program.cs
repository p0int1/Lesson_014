using System;
using System.Collections;

//Используя Visual Studio, создайте проект по шаблону Console Application.  
//Создайте коллекцию MyList<T>. Реализуйте в простейшем приближении возможность использования 
//ее  экземпляра  аналогично  экземпляру  класса  List<T>.  Минимально  требуемый  интерфейс 
//взаимодействия  с  экземпляром, должен  включать  метод  добавления  элемента, индексатор  для 
//получения  значения  элемента  по  указанному  индексу  и  свойство  только  для  чтения  для  получения 
//общего  количества  элементов.  Реализуйте  возможность  перебора  элементов  коллекции  в  цикле foreach.

namespace Task_2
{
    class MyList<T> : IEnumerable
    {
        T[] elements; int length = 0;
        public int Count { get { return length; } }

        public void Add(T el)
        {
            Array.Resize(ref elements, length + 1);
            elements[elements.Length - 1] = el;
            length = elements.Length;
        }

        public T this[int index] { get { return elements[index]; } }

        // Указатель текущей позиции элемента в массиве.
        int position = -1;

        // Реализация интерфейса - IEnumerable.
        public IEnumerator GetEnumerator()
        {
            while (true)
            {
                if (position < length - 1)
                {
                    position++;
                    yield return elements[position];
                }
                else
                {
                    position = -1;
                    yield break;  // Выход из цикла.       
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> number = new MyList<int>();
            number.Add(13);
            number.Add(14);
            number.Add(17);
            number.Add(22);
            number.Add(37);
            number.Add(55);
            Console.WriteLine($"Элемент под индексом 0: {number[0]}");
            Console.WriteLine($"Количество элементов в массиве: {number.Count}");
            Console.WriteLine("Вывод всех элементов:");

            foreach (var item in number)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("Нажмите клавишу для выхода..");
            Console.ReadKey();
        }
    }
}
