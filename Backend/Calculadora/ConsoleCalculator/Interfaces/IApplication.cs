namespace ConsoleCalculator.Interfaces
{
    public interface IApplication
    {
        void Start();
        void Calcular();
        void ShowMessage(string message);
        string ShowQuestion(string question);

        void ShowHelp();
    }
}
