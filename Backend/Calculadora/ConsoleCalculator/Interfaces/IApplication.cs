namespace ConsoleCalculator.Interfaces
{
    public interface IApplication
    {
        void Start();
        public double Calcular(int opcion);
        void ShowMessage(string message);
        string ShowQuestion(string question);

        void ShowHelp();
    }
}
