// Entender y manejar los objetos

// Crea un programa que permita gestionar tareas personales.
//  MENU:
// Generar y gestionar las listas
//1. - Crear tareas: se pedirá el nombre, descripción, tipo (persona, trabajo, ocio) y prioridad de la tarea
//                                                      (^ necesario utilizar un Enum por los tipos)
// - El id se asignará automáticamente y será único para cada tarea.
// - La prioridad es un booleano.

//2. - Buscar tareas por tipo(persona, trabajo, ocio): se mostrarán todas las tareas de dicho tipo.

//3. - Eliminar tarea por id.

// Leer y Escribir ficheros:
//4. - Exportar todas las tareas a "tareas.txt": se generará un fichero llamado tareas.txt

//  en cada fila aparecerá el id, nombre, descripción, tipo y prioridad

//5. - Importar tareas: se guardarán en la lista que gestiona la app las tareas ubicadas en el
//                    fichero tareas.txt.
class Program
{
    public static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");
        // // TodoAppEval3\Program.cs
        // File file = new File("TodoAppEval3/Program.cs");
        // // FileStream
        // StreamReader sr = new StreamReader("TodoAppEval3/Program.cs");
        // sr.ReadLine();
        bool appActivo = true;
        do
        {
            // Console.WriteLine("  ~~~~~~~~~ Menú ~~~~~~~~~");
            // Console.WriteLine(" - \u001B[32mCrear\u001B[0m tarea:          1");
            // Console.WriteLine(" - \u001B[32mBuscar\u001B[0m por:");
            // // Console.WriteLine(" (por tipo)");
            // Console.WriteLine("            Persona:     2 / p");
            // Console.WriteLine("            Trabajo:     3 / t");
            // Console.WriteLine("               Ocio:     4 / o");
            // Console.WriteLine(" - \u001B[33mEliminar\u001B[0m:");
            // Console.WriteLine("            por\u001B[33m id\u001B[0m   o   5");
            // Console.WriteLine(" - \u001B[32mGestionar:\u001B[0m");
            // Console.WriteLine("          ficheros:      6");
            // Console.WriteLine(" - Salir de la app:      7");
            // Console.WriteLine("  ~~~~~~~~~~~~~~~~~~~~~~~~ ");

            Console.WriteLine("  ~~~~~~~~~ Menú ~~~~~~~~~");
            Console.WriteLine(" - \u001B[32mCrear tarea:\u001B[0m          1");
            Console.WriteLine(" - \u001B[32mBuscar tareas:\u001B[0m");
            // Console.WriteLine(" (por tipo)");
            Console.WriteLine("            persona:     2 / p");
            Console.WriteLine("            trabajo:     3 / t");
            Console.WriteLine("               ocio:     4 / o");
            Console.WriteLine(" - \u001B[33mEliminar tarea:");
            Console.WriteLine("      escribe la id\u001B[0m   o  5");
            Console.WriteLine(" - \u001B[32mGestionar ficheros:\u001B[0m   6");
            Console.WriteLine(" -           ~  Salir:   7");
            Console.WriteLine("  ~~~~~~~~~~~~~~~~~~~~~~~~ ");

            string? eleccion;
            int eleccionInt;
            eleccion = Console.ReadLine();
            if (eleccion == "p" | eleccion == "t" | eleccion == "o")
            {
                if (eleccion == "p")
                {
                    eleccionInt = 2;
                }
                else if (eleccion == "t")
                {
                    eleccionInt = 3;
                }
                else
                {
                    eleccionInt = 4;
                }
            }
            else
            {
                int.TryParse(eleccion, out eleccionInt);
            }
            int tareaID = -1;
            if (eleccionInt > 7 && eleccionInt < 10)
            {
                eleccionInt = 8;
            }
            if (eleccionInt > 9)
            {
                tareaID = eleccionInt;
                eleccionInt = 5; // saltar a caso 5 -> "Eliminar tarea por ID"
            }
            switch (eleccionInt)
            {
                case 1:
                    Console.WriteLine("         Crear tarea  " + eleccionInt + "");
                    break;
                case 2:
                    Console.WriteLine("         Buscar tareas tipo PERSONA  " + eleccionInt + "");
                    break;
                case 3:
                    Console.WriteLine("         Buscar tareas tipo TRABAJO  " + eleccionInt + "");
                    break;
                case 4:
                    Console.WriteLine("         Buscar tareas tipo OCIO " + eleccionInt + "");
                    break;
                case 5:
                    if (tareaID > 0)
                    {
                        // EliminarTarea por id (tareaID)
                        Console.WriteLine("         Tarea " + tareaID + " eliminada.");
                    }
                    else
                    {
                        do
                        {
                            Console.WriteLine("     Escribe la id de la tarea que quieres elimiar: ");
                            eleccion = Console.ReadLine();
                            int.TryParse(eleccion, out tareaID);
                            if (tareaID > -1 && tareaID < 10)
                            {
                                Console.WriteLine("     \u001B[33mLa id no existe.\u001B[0m Intentar de nuevo, o escribe -1 para salir.");
                            }
                        } while (tareaID > -1 && tareaID < 10);
                        if (tareaID < 0)
                        {
                            Console.WriteLine("     Cargando menú ...");
                            break;
                        }
                        // EliminarTarea por id (eleccionInt)
                        Console.WriteLine("         Tarea " + tareaID + " eliminada.");
                    }
                    break;
                case 6:
                    Console.WriteLine("         Gestionar ficheros " + eleccionInt + "");
                    // do
                    // {
                    //     Console.WriteLine("Exportar todas las tareas a");
                    //     Console.WriteLine("Menú: ");
                    // } while ()
                    break;
                case 7:
                    Console.WriteLine("     Adios amigo.");
                    appActivo = false;
                    break;
                // case 0:
                //     Console.WriteLine("elección no es valida");
                //     break;
                case 8:
                default:
                    Console.WriteLine("     \u001B[33mLa elección no es válida.\u001B[0m\n     Intentar de nuevo.");
                    break;
            }
            Console.WriteLine(" |||||||||||||||||||||||||||||||||||||||\n");
        } while (appActivo);

        // Console.WriteLine("Trabajo con ficheros");
        // Console.WriteLine("OperacionesFicheros class initialized.");
        // Operaciones operaciones = new Operaciones();
        // // operaciones.ObtenerInformacion("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/escritura.txt");
        // // operaciones.EscribirFichero("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/escritura.txt");
        // // operaciones.LeerFichero("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/escritura.txt");
        // operaciones.ExportarUsuarios("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/usuarios.txt");
    }

}
