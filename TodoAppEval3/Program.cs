// Crea un programa que permita gestionar tareas personales.

// - TODO: ID. será único para cada tarea.
//3. - Eliminar tarea por id.
//5. - Importar tareas: se guardarán en la lista que gestiona la app las tareas ubicadas en el
//                    fichero tareas.txt.
class Program
{
    public static void Main(string[] args)
    {
        Operaciones operaciones = new Operaciones();
        ManipularListaTareas manipularLista = new ManipularListaTareas();
        Tarea tarea;
        List<Tarea> listaTareas = [];
        bool appActivo = true;
        int idTarea = 10; // los id empezan por 10 para que puedas eliminar las tareas del menu directamente.
        do
        {
            Console.WriteLine("  ───────── MENÚ ────────");
            Console.WriteLine(" - \u001B[32mCrear tarea:\u001B[0m          1");
            Console.WriteLine(" - \u001B[32mBuscar tareas:\u001B[0m");
            Console.WriteLine("            personal:    2 / p");
            Console.WriteLine("            trabajo:     3 / t");
            Console.WriteLine("               ocio:     4 / o");
            Console.WriteLine(" - \u001B[33mEliminar tarea:");
            Console.WriteLine("      escribe el id.\u001B[0m  o  5");
            Console.WriteLine(" - \u001B[32mGestionar ficheros:\u001B[0m   6");
            Console.WriteLine(" -           ~  Salir:   7");
            Console.WriteLine("  ──────────────────────── ");

            string? seleccion;
            int seleccionInt;
            seleccion = Console.ReadLine();
            if (seleccion == "p" | seleccion == "t" | seleccion == "o")
            {
                if (seleccion == "p")
                {
                    seleccionInt = 2;
                }
                else if (seleccion == "t")
                {
                    seleccionInt = 3;
                }
                else
                {
                    seleccionInt = 4;
                }
            }
            else
            {
                int.TryParse(seleccion, out seleccionInt);
            }
            int tareaID = -1;
            if (seleccionInt > 7 && seleccionInt < 10)
            {
                seleccionInt = 8;
            }
            if (seleccionInt > 9)
            {
                tareaID = seleccionInt;
                seleccionInt = 5; // saltar a caso 5 -> "Eliminar tarea por ID"
            }
            switch (seleccionInt)
            {
                case 1:
                    Console.WriteLine("\u001B[32m  Creando una tarea nueva:\u001B[0m\n");
                    string? input;
                    Tipo tipo;
                    Console.Write("   # Elige el tipo de la tarea (\u001B[32mp\u001B[0m = personal, \u001B[32mt\u001B[0m = trabajo, \u001B[32mo\u001B[0m = ocio): \u001B[32m");
                    bool tipoValida;
                    do
                    {
                        tipo = (Tipo)Console.Read();
                        if ((int)tipo == 111 || (int)tipo == 112 || (int)tipo == 116)
                        {
                            tipoValida = true;
                        }
                        else
                        {
                            Console.WriteLine("\u001B[33mLa entrada no es válida.\u001B[0m Las opciones son: \u001B[32mp\u001B[0m = personal, \u001B[32mt\u001B[0m = trabajo, \u001B[32mo\u001B[0m = ocio.");
                            tipoValida = false;
                        }
                        Console.ReadLine();
                    }
                    while (!tipoValida);
                    // tipo = (Tipo)inputInt;
                    tarea = new Tarea(idTarea, tipo);

                    Console.Write("\u001B[0m   # \u001B[32mEscribe el nombre de la tarea: \u001B[0m");
                    input = Console.ReadLine();
                    tarea.Nombre = input;

                    Console.Write("   # Escribe la descripción de la tarea: \u001B[32m");
                    input = Console.ReadLine();
                    tarea.Descripcion = input;

                    Console.Write("\u001B[0m   # \u001B[32mEscribe si la tarea es prioridad (s o n): \u001B[0m");
                    input = Console.ReadLine();
                    if (input == "s")
                    {
                        tarea.Prioridad = true;
                    }
                    else
                    {
                        tarea.Prioridad = false;
                    }

                    listaTareas.Add(tarea);
                    idTarea++;
                    Console.WriteLine("\n─────────────\u001B[32m────────────────────────────────────────────────────────────────────────────────────\u001B[0m");
                    Console.Write("\u001B[32mTAREA CREADA:  \u001B[0m");
                    tarea.ImprimirData();
                    Console.WriteLine("─────────────\u001B[32m────────────────────────────────────────────────────────────────────────────────────\u001B[0m\n");
                    break;
                case 2:
                    Console.WriteLine("\u001B[32m  Tareas\u001B[0m PERSONALES:");
                    manipularLista.SortTareas(listaTareas, Tipo.personal);
                    break;
                case 3:
                    Console.WriteLine("\u001B[32m  Tareas\u001B[0m de TRABAJO:");
                    manipularLista.SortTareas(listaTareas, Tipo.trabajo);
                    break;
                case 4:
                    Console.WriteLine("\u001B[32m  Tareas\u001B[0m de OCIO:");
                    manipularLista.SortTareas(listaTareas, Tipo.ocio);
                    break;
                case 5:
                    if (tareaID > 0)
                    {
                        listaTareas = manipularLista.EliminarTarea(listaTareas, tareaID);
                        Console.WriteLine("\n   ──\u001B[33m────────────────────\u001B[0m");
                        Console.WriteLine("      Tarea " + tareaID + " eliminada.");
                        Console.WriteLine("   ──\u001B[33m────────────────────\u001B[0m\n");
                    }
                    else
                    {
                        do
                        {
                            Console.WriteLine("     Escribe el id de la tarea que quieres eliminar: ");
                            seleccion = Console.ReadLine();
                            int.TryParse(seleccion, out tareaID);
                            if (tareaID > -1 && tareaID < 10)
                            {
                                Console.WriteLine("     \u001B[33mEl id no existe.\u001B[0m Intentar de nuevo, o escribe -1 para salir.");
                            }
                        } while (tareaID > -1 && tareaID < 10);
                        if (tareaID < 0)
                        {
                            Console.WriteLine("     Cargando menú ...");
                            break;
                        }
                        // EliminarTarea por id (seleccionInt)
                        Console.WriteLine("\n   ──\u001B[33m────────────────────\u001B[0m");
                        Console.WriteLine("      Tarea " + tareaID + " eliminada.");
                        Console.WriteLine("   ──\u001B[33m────────────────────\u001B[0m\n");
                    }
                    break;
                case 6:
                    Console.WriteLine("         Gestionar ficheros " + seleccionInt + "");
                    foreach (var todo in listaTareas)
                    {
                        operaciones.ExportarTareas("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/tareas.txt", todo);
                    }
                    Console.WriteLine("         Las tareas (" + listaTareas.Count() + ") se han exportado correctamente");
                    break;
                case 7:
                    Console.WriteLine("     Adios amigo.");
                    appActivo = false;
                    break;
                // case 8:
                    // manipularLista.ImprimirTareas(listaTareas);
                    // break;
                default:
                    Console.WriteLine("     \u001B[33mLa selección no es válida.\u001B[0m\n     Intentar de nuevo.\n");
                    break;
            }
        } while (appActivo);

        // Console.WriteLine("Trabajo con ficheros");
        // Console.WriteLine("OperacionesFicheros class initialized.");
        // Operaciones operaciones = new Operaciones();
        // // operaciones.ObtenerInformacion("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/tareas.txt");
        // // operaciones.EscribirFichero("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/tareas.txt");
        // // operaciones.LeerFichero("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/tareas.txt");
        // operaciones.ExportarUsuarios("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/tareas.txt");
    }

}

// Console.WriteLine("  ~~~~~~~~~ Menú ~~~~~~~~~");
// Console.WriteLine(" - \u001B[32mCrear\u001B[0m tarea:          1");
// Console.WriteLine(" - \u001B[32mBuscar\u001B[0m por:");
// // Console.WriteLine(" (por tipo)");
// Console.WriteLine("            personal:     2 / p");
// Console.WriteLine("            Trabajo:     3 / t");
// Console.WriteLine("               Ocio:     4 / o");
// Console.WriteLine(" - \u001B[33mEliminar\u001B[0m:");
// Console.WriteLine("            por\u001B[33m id\u001B[0m   o   5");
// Console.WriteLine(" - \u001B[32mGestionar:\u001B[0m");
// Console.WriteLine("          ficheros:      6");
// Console.WriteLine(" - Salir de la app:      7");
// Console.WriteLine("  ~~~~~~~~~~~~~~~~~~~~~~~~ ");