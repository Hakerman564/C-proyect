using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


namespace CreadorCartasWord
{
    internal class ManejadorPlantillasWord
    {
        // Método para rellenar una plantilla con datos y generar un nuevo archivo
        public static void RellenadorPlantilla(string DireccionPlantilla, string DireccionSalida, Dictionary<string, string> data)
        {
            // Copiar la plantilla para generar un nuevo documento
            // true final es para sobreescribir
            File.Copy(DireccionPlantilla, DireccionSalida, true);

            // WordprocessingDocument es una clase que representa un documento word 
            // y el metodo open es quien crea la verdadera instancia del archivo
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(DireccionSalida, true))
            {
                // Recorrer todos los párrafos del documento
                // MainDocumentPart.Document hace enfasis al la data del docuemnto 
                // descendats se usa principalmente para devolver una coleccion de parrafos
                foreach (var paragraph in wordDoc.MainDocumentPart.Document.Descendants<Paragraph>())
                {
                    foreach (var text in paragraph.Descendants<Text>())
                    {
                        foreach (var entry in data)
                        {
                            // Si el texto contiene una etiqueta, la reemplaza
                            if (text.Text.Contains($"{{{entry.Key}}}"))
                            {
                                // Reemplazar la etiqueta por su valor en el diccionario
                                text.Text = text.Text.Replace($"{{{entry.Key}}}", entry.Value);
                            }
                        }
                    }
                }

                // Guardar los cambios en el documento
                wordDoc.MainDocumentPart.Document.Save();
            }
        }
    }
}
