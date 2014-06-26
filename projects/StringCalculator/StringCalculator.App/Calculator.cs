namespace StringCalculator.App
{
    public interface ICalculator
    {
        int add(string input);
    }

    public class Calculator : ICalculator
    {
        public int add(string input)
        {
            return -1;
        }
    }
}