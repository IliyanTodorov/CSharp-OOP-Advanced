namespace Scale
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Scale<int> scale = new Scale<int>(122, 133);

            Console.WriteLine(scale.GetHeavier());
        }
    }
}
