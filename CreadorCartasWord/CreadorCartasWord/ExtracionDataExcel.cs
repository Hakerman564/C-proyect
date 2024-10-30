using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace CreadorCartasWord
{
    internal class ExtracionDataExcel
    {
        public static Dictionary<string, List<string>> ObtenerDatosDeExcel(string filePath)
        {
            // Crear un diccionario para almacenar los datos
            Dictionary<string, List<string>> datosEstudiantes = new Dictionary<string, List<string>>();

            // Abrir el archivo Excel

            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(fileStream); // Para archivos .xlsx
                    ISheet sheet = workbook.GetSheetAt(1); // Obtener la segunda hoja

                    // Obtener la primera fila que contiene los nombres de las columnas
                    IRow headerRow = sheet.GetRow(0);
                    ICell cell = headerRow.GetCell(0);

                    if (cell == null)
                    {
                        throw new ArgumentException("La Tabla Esta fuera de alcanse");
                    }

                    foreach (var Casilla in headerRow.Cells)
                    {
                        if (string.IsNullOrWhiteSpace(Casilla.ToString()))
                        {
                            throw new ArgumentException("Hay Casillas vacias en el titulo");
                        }
                    }


                    int cellCount = headerRow.LastCellNum; // Número de columnas
                    Console.WriteLine(cellCount);
                    Console.WriteLine(sheet.PhysicalNumberOfRows);
                    // Recorrer cada fila de datos (comenzando desde la segunda fila)
                    for (int row = 1; row < sheet.PhysicalNumberOfRows; row++)
                    {
                        IRow currentRow = sheet.GetRow(row);
                        if (currentRow != null)
                        {
                            // Obtener la matrícula de la columna 0 (puedes cambiar esto según tu archivo)
                            string matricula = currentRow.GetCell(0)?.ToString();

                            if (!string.IsNullOrWhiteSpace(matricula))
                            {
                                // Crear una lista para almacenar los valores de las columnas
                                List<string> registro = new List<string>();

                                // Recorrer cada celda de la fila y agregarla a la lista
                                for (int col = 1; col < cellCount; col++) // Empezamos en 1 para evitar la columna de matrícula
                                {
                                    string valor = currentRow.GetCell(col)?.ToString(); // Valor de la celda
                                    registro.Add(valor); // Añadir el valor a la lista
                                }

                                // Agregar el registro al diccionario usando la matrícula como clave
                                datosEstudiantes[matricula] = registro;
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("El archivo está siendo usado por otro proceso: " + ex.Message);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }


            // Retornar el diccionario con los datos
            return datosEstudiantes;
        }
    }
}

/*public class RegistroDinamico
{
    private Dictionary<string, object> _valores = new Dictionary<string, object>();

    // Agregar un campo a través del nombre de la columna
    public void AgregarCampo(string nombreColumna, object valor)
    {
        _valores[nombreColumna] = valor;
    }

    // Obtener un campo según su nombre
    public object ObtenerCampo(string nombreColumna)
    {
        return _valores.ContainsKey(nombreColumna) ? _valores[nombreColumna] : null;
    }

    // Método opcional para mostrar todos los campos y valores
    public override string ToString()
    {
        string resultado = "";
        foreach (var kvp in _valores)
        {
            resultado += $"{kvp.Key}: {kvp.Value}, ";
        }
        return resultado.TrimEnd(',', ' ');
    }
}*/