namespace _12122022_delegate_linq
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Func<String, String> upp = str => str.ToUpper();
            Action<int> select = x => Console.WriteLine(x);
            Predicate<int> selec = Check;

            string[] words = { "orange", "apple", "Article", "elephant" };
            IEnumerable<String> aWords = words.Select(upp);
            foreach (String word in aWords)
                Console.WriteLine(word);

            //List<String> list = new List<string>(words);
            //list.ForEach();

            int[] pred_test = { 1, 2, 4, 5, 6, 10 };
            var pred_answr = Array.FindAll(pred_test, selec);
            foreach (int i in pred_answr)
                Console.WriteLine(i);



            Firm frm = new Firm();
            foreach (var f in frm.FindMostPayed())
                Console.WriteLine(f.ToString());   
        }

        public static bool Check(int x)
        {
            return x % 5 == 0;
        }
    }
}