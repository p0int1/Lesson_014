using System;
using System.Collections;

//Используя Visual Studio, создайте проект по шаблону Console Application.  
//Создайте  коллекцию  MyDictionary<TKey, TValue>.  Реализуйте  в  простейшем  приближении 
//возможность  использования  ее  экземпляра  аналогично  экземпляру  класса  Dictionary<TKey, TValue>. 
//Минимально  требуемый  интерфейс  взаимодействия  с  экземпляром, должен  включать  метод 
//добавления элемента, индексатор для получения значения элемента по указанному индексу и свойство 
//только  для  чтения  для  получения  общего  количества  элементов.  Реализуйте  возможность  перебора 
//элементов коллекции в цикле foreach. 

namespace Task_3
{
    class MyDictionary<TKey, TValue> : IEnumerable
    {
        TKey[] keys;
        TValue[] elements;
        int length = 0;

        public int Count { get { return length; } }

        public void Add(TKey ind, TValue el)
        {
            Array.Resize(ref keys, Count + 1);
            Array.Resize(ref elements, Count + 1);
            keys[elements.Length - 1] = ind;
            elements[elements.Length - 1] = el;
            length++;
        }

        public TValue this[TKey index]
        {
            get
            {
                int i = Array.IndexOf(keys, index);
                if (i == -1)
                    return default(TValue);
                else
                    return elements[i];
            }
        }

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
                    yield return keys[position] + ":" + elements[position];
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
            var words = new MyDictionary<string, string>();
            words.Add("книга", "book");
            words.Add("ручка", "pen");
            words.Add("солнце", "sun");
            words.Add("яблоко", "apple");
            words.Add("стол", "table");

            foreach (var item in words)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Нажмите клавишу для выхода..");
            Console.ReadKey();
        }
    }
}
