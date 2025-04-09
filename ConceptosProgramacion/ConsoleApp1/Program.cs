using System.ComponentModel.Design;
using System.Globalization;

decimal salarioMinimo = 1500000;
decimal horasMensuales = salarioMinimo / 160;  //9.375
decimal dominicales = horasMensuales * 2;

Console.WriteLine("¿Cuál es tu nombre?: ");
string nombreEmpleado = Console.ReadLine();

// VALIDADOR HORAS SEMANALES
int horasTrabajo;
Console.WriteLine("¿Cuántas son tus horas trabajadas a la semana? (0 - 624):");

while (!int.TryParse(Console.ReadLine(), out horasTrabajo) || horasTrabajo < 0 || horasTrabajo > 624)
{
    Console.WriteLine("❌ Valor inválido. Por favor, ingresa un número entero entre 0 y 624:");
}

// PREGUNTA DOMINICAL VALIDADA
Console.WriteLine("¿Trabajaste los domingos? (si/no):");
string preguntaDominical = Console.ReadLine().ToLower();

while (preguntaDominical != "si" && preguntaDominical != "no")
{
    Console.WriteLine("❌ Solo puedes escribir 'si' o 'no'. Intenta otra vez:");
    preguntaDominical = Console.ReadLine().ToLower();
}

if (preguntaDominical == "si")
{
    int horasDominicales;
    Console.WriteLine("¿Cuántas horas dominicales trabajaste? (0 - 96):");

    while (!int.TryParse(Console.ReadLine(), out horasDominicales) || horasDominicales < 0 || horasDominicales > 96 || (horasTrabajo + horasDominicales) > 720)
    {
        Console.WriteLine("❌ Valor inválido. Asegúrate de que la suma total de horas no supere 720.");
        Console.WriteLine("Ingresa las horas dominicales nuevamente:");
    }

    decimal pagodominical = horasDominicales * dominicales;
    decimal pagohoras = horasMensuales * horasTrabajo;
    decimal pagototal = pagohoras + pagodominical;
    pagototal = Math.Max(pagototal, salarioMinimo);

    Console.WriteLine($"\n Informe de nómina para {nombreEmpleado}:");
    Console.WriteLine($"Horas normales: {horasTrabajo} x {horasMensuales} = {pagohoras}");
    Console.WriteLine($"Pago de horas dominicales: {dominicales} x {horasDominicales} = {pagodominical}");
    Console.WriteLine($"Pago Total: {pagototal}");
}
else
{
    decimal pagohoras = horasMensuales * horasTrabajo;
    decimal pagototal = Math.Max(pagohoras, salarioMinimo);

    Console.WriteLine($"\n Informe de nómina para {nombreEmpleado}:");
    Console.WriteLine($"Horas normales: {horasTrabajo} x {horasMensuales} = {pagohoras}");
    Console.WriteLine($"Pago Total: {pagototal}");
}
