namespace ConsoleApp19
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    // Клас Дерево
    public class Дерево
    {
        public string Порода { get; set; }
        public double Ціна { get; set; }

        public Дерево(string порода, double ціна)
        {
            Порода = порода;
            Ціна = ціна;
        }

        public override string ToString()
        {
            return $"{Порода} ({Ціна} грн)";
        }
    }

    // Клас колекції дерев з реалізацією IEnumerable
    public class КолекціяДерев : IEnumerable<Дерево>
    {
        private List<Дерево> дерева = new List<Дерево>();

        public void ДодатиДерево(Дерево дерево)
        {
            дерева.Add(дерево);
        }

        public IEnumerator<Дерево> GetEnumerator()
        {
            return дерева.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Створення колекції дерев
            КолекціяДерев колекція = new КолекціяДерев();
            колекція.ДодатиДерево(new Дерево("Дуб", 500));
            колекція.ДодатиДерево(new Дерево("Береза", 300));
            колекція.ДодатиДерево(new Дерево("Сосна", 400));
            колекція.ДодатиДерево(new Дерево("Ялина", 350));

            // Сортування дерев за ціною
            List<Дерево> відсортованіДерева = new List<Дерево>(колекція);
            відсортованіДерева.Sort((x, y) => x.Ціна.CompareTo(y.Ціна));

            // Виведення відсортованих дерев на консоль
            Console.WriteLine("Список порід дерев, впорядкований за ціною:");
            foreach (var дерево in відсортованіДерева)
            {
                Console.WriteLine(дерево);
            }
        }
    }

}
