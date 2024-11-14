namespace синхронізація_потоків
{
    internal class Program
    {
        private static int start;

        class BankAccount
        {
            public static object Locker = new object();
            public int funds = 300;

            public void Withdraw(object obj)
            {
                int value = (int)obj;

                Monitor.Enter(Locker);

                try
                {
                    Console.WriteLine($"Sum for withdraw  {value}");
                    funds -= value;
                    Console.WriteLine($"Withdraw was successful (Account balance: {funds})");
                }
                finally
                {
                    Monitor.Exit(Locker);
                }
            }
        }

        struct ArrAndStartEnd
        {
            public int[] arr;
            public int start;
            public int end;
        }
        public static int result = 0;
        public static void Сalculate(object? obj)
        {
            ArrAndStartEnd value = (ArrAndStartEnd)obj;
            int Sum1 = 0;

            // Обчислюємо часткову суму для діапазону, який обробляє цей потік
            for (int i = value.start; i < value.end; i++)
            {
                Sum1 += value.arr[i];
            }

            // Додаємо часткову суму до спільної змінної result
            Interlocked.Add(ref result, Sum1);
        }

        public static int visitorCount = 0;
        public static void Increment()
        {
            Interlocked.Increment(ref visitorCount);
        }
      static void Main(string[] args)
        {
            ////task 1
            //BankAccount account = new BankAccount();

            //Thread[] threads = new Thread[3];
            //for (int i = 0; i < threads.Length; i++) {
            //    threads[i] = new Thread(account.Withdraw);
            //    threads[i].Start(100);
            //}

            //foreach (var thread in threads)
            //{
            //    thread.Join();
            //}
            ////task 2
            //int[] numbers = new int[90];
            //Random random = new Random();
            //for (int i = 0; i < numbers.Length; i++) { 
            //    numbers[i] = random.Next(1,100);
            //}
            //Thread[] threads = new Thread[3];
            //int partSize = numbers.Length / threads.Length;

            //for (int i = 0; i < threads.Length; i++)
            //{

            //    int start = i * partSize;
            //    int end = (i == threads.Length - 1) ? numbers.Length : start + partSize;

            //    ArrAndStartEnd values = new ArrAndStartEnd
            //    {
            //        arr = numbers,
            //        start = start,
            //        end = end
            //    };
            //    threads[i] = new Thread(Сalculate);
            //    threads[i].Start(values);
            //}

            //foreach (var thread in threads)
            //{
            //    thread.Join();
            //}

            //Console.WriteLine($"Total result: {result}");

            ////task 3
            //Thread[] threads = new Thread[7];
            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i] = new Thread(Increment);
            //    threads[i].Start();
            //}

            //foreach (var thread in threads)
            //{
            //    thread.Join();
            //}

            //Console.WriteLine($"Total visits: {visitorCount}");
        }
    }
}