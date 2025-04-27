public class Operaciones
{
    public void ExportarTareas(String path, Tarea tarea, bool append)
    {
        if (!File.Exists(path))
        {
            File.Create(path);
        }
        FileStream? fileStream = null;
        StreamWriter? streamWriter = null;

        try
        {
            fileStream = new FileStream(path, FileMode.Append);
            streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(tarea.ExportarData());
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        finally
        {
            try
            {
                streamWriter?.Close();
                fileStream?.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }

    public List<Tarea> ImportarTareas(String path)
    {
        List<Tarea> listaImportada = new List<Tarea>();
        FileStream? fileStream = null;
        StreamReader? streamReader = null;
        try
        {
            String[]? tareaData;
            String? linea = null;

            fileStream = new FileStream(path, FileMode.Open);
            streamReader = new StreamReader(fileStream);

            Tarea tarea;
            int idTarea = -1;
            Tipo tipo = Tipo.personal;
            bool prioridad = true;

            while ((linea = streamReader.ReadLine()) != null)
            {
                tareaData = linea.Split(",");
                int x = 1;
                foreach (var i in tareaData)
                {
                    if (x == 1)
                    {
                        int.TryParse(i, out idTarea);
                    }
                    else if (x == 4)
                    {
                        if (i == "trabajo")
                        {
                            tipo = Tipo.trabajo;
                        }
                        if (i == "personal")
                        {
                            tipo = Tipo.personal;
                        }
                        if (i == "ocio")
                        {
                            tipo = Tipo.ocio;
                        }
                    }
                    else if (x == 5)
                    {
                        if (i == "True" || i == "true")
                        {
                            prioridad = true;
                        }
                        else
                        {
                            prioridad = false;
                        }
                    }
                    x++;
                }
                tarea = new Tarea(idTarea, tareaData[1], tareaData[2], tipo, prioridad);
                listaImportada.Add(tarea);
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        finally
        {
            try
            {
                streamReader?.Close();
                fileStream?.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        return listaImportada;
    }
}