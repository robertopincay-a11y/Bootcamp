using ConsoleCalculator.Interfaces;
using ConsoleCalculator.Models;

namespace ConsoleCalculator.Classes
{
    public class Application(string name, string version) : IApplication
    {
        private List<Opcion> _opciones = [];

        private void InitMenu()
        {
            _opciones.Add(new Opcion()
            {
                Id = 1,
                Description = "Suma"

            }
            );
            _opciones.Add(new Opcion()
            {
                Id = 2,
                Description = "Resta"

            }
           );
            _opciones.Add(new Opcion()
            {
                Id = 3,
                Description = "Multiplicacion"

            }
           );
            _opciones.Add(new Opcion()
            {
                Id = 4,
                Description = "Division"

            }
           );
        }
        public double Calcular(int opcion)
        {
            Console.Write("Ingrese el primer numero: ");
            double num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Ingresa el segundo numero: ");
            double num2 = Convert.ToInt32(Console.ReadLine());
            double resultado = 0;

            switch (opcion)
            {
                case 1:
                    resultado = num1 + num2;
                    break;
                case 2:
                    resultado = num1 - num2;
                    break;
                case 3:
                    resultado = num1 * num2;
                    break;
                case 4:
                    resultado = num1 / num2;
                    break;

            }
            return resultado;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine($"{message}");
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

                Menu:
                {string.Join("\n", _opciones.Select((cmd) => $"{cmd.Id}. {cmd.Description}"))}

                ---------------------------------
                """;
            Console.WriteLine(message);
        }
        public void Start()
        {
            InitMenu();
            while (true)
            {
                ShowHelp();
                try
                {
                    var inputId = Convert.ToInt32(ShowQuestion("Seleccione una opción: "));

                    var findOption = _opciones.Where((cmd) => cmd.Id == inputId).FirstOrDefault();

                    if (findOption is null)
                    {
                        throw new Exception("Opcion no encontrada");
                    }

                    if (findOption.Id == inputId)
                    {
                        var resultado = Calcular(inputId);
                        Console.WriteLine("El resultado es: " + resultado);

                    }


                }

                catch (FormatException)
                {
                    ShowMessage("No está utilizando un formato adecuado. Agrege una opción correcta");
                }
                catch (Exception)
                {

                    ShowMessage("EL argumento es invalido");
                }

            }
        }
    }
}
