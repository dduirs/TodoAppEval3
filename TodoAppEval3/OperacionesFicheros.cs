using System.Reflection;

public class Operaciones
{
    public void ObtenerInformacion(String ruta)
    {
        // Console.WriteLine("Leyendo el fichero: " + ruta);
        // Console.WriteLine("Ultima acceso: " + File.GetLastAccessTime(ruta));
        // Console.WriteLine("Existe: " + File.Exists(ruta));
        if (!File.Exists(ruta))
        {
            File.Create(ruta);
            Console.WriteLine("El fichero no existe, se ha creado");
        }
        else
        {
            FileInfo fileInfo = new FileInfo(ruta);
            Console.WriteLine("Nombre: " + fileInfo.Name);
            Console.WriteLine("Tamaño: " + fileInfo.Length);
            Console.WriteLine("Directorio: " + fileInfo.DirectoryName);
            Console.WriteLine("Extensión: " + fileInfo.Extension);
            Console.WriteLine("Creado: " + fileInfo.CreationTime);
            Console.WriteLine("Ultima modificación: " + fileInfo.LastWriteTime);
            Console.WriteLine("Ultimo acceso: " + fileInfo.LastAccessTime);
            Console.WriteLine("Atributos: " + fileInfo.Attributes);
            Console.WriteLine("Es un directorio: " + fileInfo.Attributes.HasFlag(FileAttributes.Directory));
            Console.WriteLine("Es un fichero: " + fileInfo.Attributes.HasFlag(FileAttributes.Normal));
            Console.WriteLine("Es un fichero oculto: " + fileInfo.Attributes.HasFlag(FileAttributes.Hidden));
            Console.WriteLine("Es un fichero de sistema: " + fileInfo.Attributes.HasFlag(FileAttributes.System));
            Console.WriteLine("Es un fichero de solo lectura: " + fileInfo.Attributes.HasFlag(FileAttributes.ReadOnly));
            Console.WriteLine("Es un fichero de archivo: " + fileInfo.Attributes.HasFlag(FileAttributes.Archive));
            Console.WriteLine("Es un fichero de dispositivo: " + fileInfo.Attributes.HasFlag(FileAttributes.Device));
            Console.WriteLine("Es un fichero de temporal: " + fileInfo.Attributes.HasFlag(FileAttributes.Temporary));
            Console.WriteLine("Es un fichero de comprimido: " + fileInfo.Attributes.HasFlag(FileAttributes.Compressed));
            Console.WriteLine("Es un fichero de encriptado: " + fileInfo.Attributes.HasFlag(FileAttributes.Encrypted));
        }
    }

    public void EscribirFichero(String ruta)
    {
        FileStream fileStream = new FileStream(ruta, FileMode.Append);
        StreamWriter streamWriter = new StreamWriter(fileStream);
        streamWriter.WriteLine("\nHola, soy un fichero de texto");
        streamWriter.WriteLine(123);
        streamWriter.Close();
    }

    public void LeerFichero(String ruta)
    {
        // FileStream fileStream = new FileStream(ruta, FileMode.Open);
        // StreamReader streamReader = new StreamReader(fileStream);

        FileStream? fileStream = null;
        StreamReader? streamReader = null;

        try
        {
            fileStream = new FileStream(ruta, FileMode.Open);
            streamReader = new StreamReader(fileStream);

            String? linea = null;
            while ((linea = streamReader.ReadLine()) != null)
            {
                Console.WriteLine(linea);
                // streamReader.ReadLine();
            }
            streamReader.Close();
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("El fichero no existe");
            Console.WriteLine("Exception: " + e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine("Error en la entrada/salida");
            Console.WriteLine("Exception: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            try
            {
                fileStream?.Close();
                streamReader?.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Error al cerrar el fichero " + e.Message);
            }
        }
    }

    // public List<Tarea> listTareas;

    // public Operaciones()
    // {
    //     listTareas = new List<Tarea>();
    //     // listTareas.Add();
    // }

    public void ExportarTareas(String path, Tarea tarea)
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

            // foreach (var tarea in listTareas)
            // {
            streamWriter.WriteLine(tarea.ExportarData());
            // }
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

    public void ImportarTareas(String path, )
    {
        FileStream? fileStream = null;
        StreamReader? streamReader = null;
        try
        {
            fileStream = new FileStream(path, FileMode.Open);
            streamReader = new StreamReader(fileStream);

            String? linea = null;
            while ((linea = streamReader.ReadLine()) != null)
            {
                Console.WriteLine(linea);
                // streamReader.ReadLine();
            }
            streamReader.Close();

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

    }

    //     public void ImportarUsuarios(String path)
    //     {
    //         if (!File.Exists(path))
    //         {
    //             Console.WriteLine("Fichero no existe.");
    //         }
    //         else
    //         {
    //             // FileStream? fileStream = null;
    //             StreamReader? streamReader = null;
    //             String? linea = null;      
    //             String? nombre, apellido, correo, telefono = null;
    //             Usuario? usuario1 = null;
    //             try
    //             {
    //                 // fileStream = new FileStream(path, FileMode.Append);
    //                 // streamReader = new StreamReader(fileStream);
    //                 while ((linea = streamReader.ReadLine()) != null)
    //                 {
    //                     // usuario1 = new Usuario();                    Console.WriteLine(linea);
    //                     nombre, apellido, correo, telefono = linea.Split(",");
    //                     // streamReader.ReadLine();
    //                 }
    //                 streamReader.Close();

    //                 foreach (var usuario in listUsuarios)
    //                 {
    //                     streamReader.ReadLine(usuario.ImportarDato());
    //                 }
    //             }
    //             catch (FileNotFoundException e)
    //             {
    //                 Console.WriteLine("Error: " + e.Message);
    //             }
    //             catch (IOException e)
    //             {
    //                 Console.WriteLine("Error: " + e.Message);
    //             }
    //             finally
    //             {
    //                 try
    //                 {
    //                     streamReader?.Close();
    //                     // fileStream?.Close();
    //                 }
    //                 catch (Exception e)
    //                 {
    //                     Console.WriteLine("Error: " + e.Message);
    //                 }
    //             }
    //         }
    //     }
    // }

}


