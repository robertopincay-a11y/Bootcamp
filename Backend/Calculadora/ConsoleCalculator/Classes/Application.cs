using ConsoleCalculator.Interfaces;
using ConsoleCalculator.Models;
using System.Drawing;
using System.Windows.Input;

namespace ConsoleCalculator.Classes
{
    public class Application(string name, string version) : IApplication
    {
        private List<Opcion> _opciones = [];

        private void InitMenu()
        {
            _opciones.Add(new Opcion() { 
                Id=1,
                Description="Suma",
                Usage="<addition>",
                Return = "Resultado:<addition>"
            }
            );
            _opciones.Add(new Opcion()
            {
                Id = 1,
                Description = "Resta",
                Usage = "<subtraction>",
                Return = "Resultado:<subtraction>"
            }
           );
            _opciones.Add(new Opcion()
            {
                Id = 1,
                Description = "Multiplicacion",
                Usage = "<multiplication>",
                Return = "Resultado:<multiplication>"
            }
           );
            _opciones.Add(new Opcion()
            {
                Id = 1,
                Description = "Division",
                Usage = "<division>",
                Return = "Resultado:<division>"
            }
           );
        }
        public void Calcular()
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine($"Message: {message}");
        }
        public string ShowQuestion(string question)
        {
            ShowMessage(question);

            return Console.ReadLine();
        }
        public void ShowHelp()
        {
            var message = $"""
                ---------------------------------

                {name} {version}

                ---------------------------------

                Comandos:
                {string.Join("\n", _opciones.Select((cmd) => $"{cmd.Id}. {cmd.Description}\n{cmd.Usage}\n{cmd.Return}"))}

                ---------------------------------
                """;
            Console.WriteLine(message);
        }
        public void Start()
        {
            InitMenu();
            while (true)
            {
                try
                {
                    var inputId = Convert.ToInt32(ShowQuestion("Seleccione una opción: "));
                    var argumento = ShowQuestion("");

                    if (string.IsNullOrEmpty(argumento)) {
                        throw new ArgumentNullException();
                    }



                }
                catch (Exception)
                {

                    ShowMessage("EL argumento es invalido");
                }

            }
        }
    }
}
