namespace HelloWorld.App
{
    public interface ISomeGuy
    {
        string talk();
    }

    public class SomeGuy : ISomeGuy
    {
        public string talk()
        {
            return "Hello, World!";
        }
    }
}