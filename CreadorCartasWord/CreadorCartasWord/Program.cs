// Ruta al archivo de la plantilla (asegúrate de que esta ruta sea correcta)
 /*
using CreadorCartasWord;

string templatePath = @"C:\Users\DELL\Desktop\Plantilla\PlantillaPrueba.docx";

// Ruta donde se guardará el archivo nuevo generado
string outputPath = @"C:\Users\DELL\Desktop\Documentos o Cartas\A3.docx";

// Diccionario con los datos que quieres insertar en la plantilla
var datos = new Dictionary<string, string>
        {
            { "NOMBRE", "José Pérez" },
            { "NUMERO_CUENTA", "1234567890" },
            { "FECHA", DateTime.Now.ToString("dd/MM/yyyy") }
        };

// Llamar al método que rellena la plantilla con los datos y genera el documento final
ManejadorPlantillasWord.RellenadorPlantilla(templatePath, outputPath, datos);

Console.WriteLine("Documento generado correctamente en " + outputPath);
*/

using CreadorCartasWord;

string filePath = @"C:\Users\DELL\Desktop\proyecto eduardo.xlsx";

// Llamar al método para obtener los datos del archivo Excel
Dictionary<string, List<string>> datosEstudiantes =ExtracionDataExcel.ObtenerDatosDeExcel(filePath);

// Ejemplo de cómo imprimir los datos del diccionario
Console.WriteLine($"Matricula\tNombre\tPadre\t Madre\t Sigerd\t " +
                    $"nace\tLugar\t Aula\tfecha \tSexo \t");
foreach (var entry in datosEstudiantes)
{
    Console.Write($"{entry.Key}\t\t"); // Console.WriteLine($"Matrícula: {entry.Key}, Datos: {entry.Value}");
   for (int i = 0; i < entry.Value.Count; i++)
    {
        string cadena = entry.Value[i].ToString();
        Console.Write($"{!String.IsNullOrEmpty(cadena)}\t");
    }
   Console.Write("\n");
}


