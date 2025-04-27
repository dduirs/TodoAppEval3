// Crea un programa que permita gestionar tareas personales.
// - TODO: ID. será único para cada tarea.
class Program
{
    public static void Main(string[] args)
    {
        Operaciones operaciones = new Operaciones();
        ManipularListaTareas manipularLista = new ManipularListaTareas();
        Tarea tarea;
        List<Tarea> listaTareas = [];
        List<Tarea> listaImportada = [];
        bool appActivo = true;
        int idAsignada = 10;
        int tareaCount = 0; // los id empezan por 10 para que puedas eliminar las tareas del menu directamente.
        do
        {
            Console.WriteLine("  ───────── MENÚ ────────");
            Console.WriteLine(" - \u001B[32mCrear tarea:\u001B[0m          1");
            Console.WriteLine(" - \u001B[32mBuscar tareas:\u001B[0m");
            Console.WriteLine("           personal:     2 / p");
            Console.WriteLine("            trabajo:     3 / t");
            Console.WriteLine("               ocio:     4 / o");
            Console.WriteLine(" - \u001B[33mEliminar tarea:");
            Console.WriteLine("      escribe el id.\u001B[0m  o  5");
            Console.WriteLine(" - \u001B[32m Exportar tareas:\u001B[0m     6");
            Console.WriteLine(" - \u001B[32m Importar tareas:\u001B[0m     7");
            Console.WriteLine(" -           ~  Salir:   8");
            Console.WriteLine("  ───────────────────────");

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
            int idTareaBuscada = -1;
            if (seleccionInt > 9)
            {
                idTareaBuscada = seleccionInt;
                seleccionInt = 5; // saltar a caso 5 -> "Eliminar tarea por ID"
            }
            switch (seleccionInt)
            {
                case 1:
                    Console.WriteLine("\u001B[32m  Creando una tarea nueva:\u001B[0m\n");
                    Console.Write("   # Elige el tipo de la tarea (\u001B[32mp\u001B[0m = personal, \u001B[32mt\u001B[0m = trabajo, \u001B[32mo\u001B[0m = ocio): \u001B[32m");
                    tarea = new Tarea();
                    tarea.CrearTarea(idAsignada);
                    listaTareas.Add(tarea);
                    tareaCount++;
                    idAsignada++;
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
                    if (idTareaBuscada > 0)
                    {
                        try
                        {
                            tarea = listaTareas.Find(t => t.Id == idTareaBuscada);
                            if (listaTareas.Remove(tarea))
                            {
                                // listaTareas = manipularLista.EliminarTarea(listaTareas, idTareaBuscada);
                                Console.WriteLine("\n   ──\u001B[33m────────────────────\u001B[0m");
                                Console.WriteLine("      Tarea " + idTareaBuscada + " eliminada.");
                                Console.WriteLine("   ──\u001B[33m────────────────────\u001B[0m\n");
                                tareaCount--;
                                idAsignada = tareaCount + 10;
                            }
                            else
                            {
                                Console.WriteLine("     \u001B[33mEl id no existe.\u001B[0m Intentar de nuevo.\n");
                            }
                        }
                        catch (NullReferenceException e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                        }
                    }
                    else
                    {
                        do
                        {
                            Console.WriteLine("     Escribe el id de la tarea que quieres eliminar: ");
                            seleccion = Console.ReadLine();
                            int.TryParse(seleccion, out idTareaBuscada);
                            if (idTareaBuscada > -1 && idTareaBuscada < 10)
                            {
                                Console.WriteLine("     \u001B[33mEl id no existe.\u001B[0m Intentar de nuevo, o escribe -1 para salir.");
                            }
                            else
                            {
                                tarea = listaTareas.Find(t => t.Id == idTareaBuscada);
                                if (listaTareas.Remove(tarea))
                                {
                                    // listaTareas = manipularLista.EliminarTarea(listaTareas, idTareaBuscada);
                                    Console.WriteLine("\n   ──\u001B[33m────────────────────\u001B[0m");
                                    Console.WriteLine("      Tarea " + idTareaBuscada + " eliminada.");
                                    Console.WriteLine("   ──\u001B[33m────────────────────\u001B[0m\n");
                                    tareaCount--;
                                }
                                else
                                {
                                    Console.WriteLine("     \u001B[33mEl id no existe.\u001B[0m Intentar de nuevo.");
                                }
                            }
                        } while (idTareaBuscada > -1 && idTareaBuscada < 10);
                        if (idTareaBuscada < 0)
                        {
                            Console.WriteLine("     Cargando menú ...");
                            break;
                        }
                        // EliminarTarea por id (seleccionInt)
                        // Console.WriteLine("\n   ──\u001B[33m────────────────────\u001B[0m");
                        // Console.WriteLine("      Tarea " + idTareaBuscada + " eliminada.");
                        // Console.WriteLine("   ──\u001B[33m────────────────────\u001B[0m\n");
                    }
                    break;
                case 6:
                    File.WriteAllText("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/tareas.txt", String.Empty);
                    if (listaTareas.Count() < 1)
                    {
                        Console.WriteLine("         \u001B[33mNo existe ninguna tarea para exportar.\u001B[0m\n");
                    }
                    else
                    {
                        // operaciones.ObtenerInformacion("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/tareas.txt");
                        // bool borrar = true;

                        // listaImportada = operaciones.ImportarTareas("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/tareas.txt");
                        // var i = listaImportada.Count();
                        // // if (listaImportada.Count() == 0){
                        // while (i > 0)
                        // {
                        //     operaciones.ExportarTareas("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/tareas.txt", listaTareas[0], false);
                        //     i--;
                        // }

                        foreach (var todo in listaTareas)
                        {
                            operaciones.ExportarTareas("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/tareas.txt", todo, true);
                        }
                        Console.WriteLine("         Las tareas (" + listaTareas.Count() + ") se han exportado correctamente.\n");

                        // foreach (var todo in listaTareas)
                        // {
                        //     operaciones.ExportarTareas("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/tareas.txt", todo, true);
                        // }
                        // Console.WriteLine("         Las tareas (" + listaTareas.Count() + ") se han exportado correctamente.\n");
                    }
                    break;
                case 7:
                    listaTareas.Clear();
                    listaImportada = operaciones.ImportarTareas("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/tareas.txt");
                    if (listaImportada.Count() == 0)
                    {
                        Console.WriteLine("         \u001B[33mNo existen tareas para importar.\u001B[0m\n");
                    }
                    else
                    {
                        Console.WriteLine("         Habían listaTareas.Count() =" + listaTareas.Count() + " tareas.\n");
                        Console.WriteLine("         Habían tareaCount =" + tareaCount + " tareas.\n");

                        // tareaCount = tareaCount + listaImportada.Count();
                        // idAsignada = tareaCount + 11;
                        manipularLista.ImprimirTareas(listaImportada);
                        // foreach (Tarea tareaNueva in listaImportada)
                        // {
                        //     listaTareas.Add(tareaNueva);
                        // }
                        Console.WriteLine("         Ahora hay " + tareaCount + " tareas activas.\n");
                        Console.WriteLine("         Ahora hay  idAsignada:" + idAsignada + ".\n");

                        Console.WriteLine("         Hay listaTareas.Count() =" + listaTareas.Count() + " tareas.\n");

                        Console.WriteLine("         Las siguentes tareas (" + listaImportada.Count() + ") se han importado correctamente: ");
                        Tarea tempTarea2;
                        // int count = 1;
                        // List<Tarea> listaTemp = new List<Tarea>();
                        // var i = listaTareas.Count();
                        List<Tarea> paraEliminar = new List<Tarea>();
                        for (int i = listaTareas.Count(); i > 0; i--)
                        {
                            Console.WriteLine(" i =" + i);
                            Console.WriteLine("listaTareas[i-1].Id =" + listaTareas[i - 1].Id);
                            tempTarea2 = listaTareas.Find(t => t.Id == listaTareas[i - 1].Id);
                            Console.WriteLine("tempTarea2.Id =" + tempTarea2.Id);
                            paraEliminar.Add(tempTarea2);
                            // listaTareas.Remove(tempTarea2);
                        }
                        foreach (Tarea eliminarT in paraEliminar)
                        {
                            tempTarea2 = eliminarT;
                            if (listaTareas.Remove(eliminarT))
                            {
                                Console.WriteLine("         " + tempTarea2.Id + " repetida eliminada.\n");
                            }
                            else
                            {
                                Console.WriteLine("         NOT eliminada " + tempTarea2.Id + ".\n");
                            }

                        }
                        foreach (Tarea tareaNueva in listaImportada)
                        {
                            listaTareas.Add(tareaNueva);
                            tareaCount ++;
                            idAsignada = tareaCount + 11;
                        }
                        // bool borrar = true;
                        // var i = listaTareas.Count();
                        // while (i > 0)
                        // {
                        //     i--;
                        // }
                        // borrar = false;
                        // foreach (var todo in listaTareas)
                        // {
                        //     operaciones.ExportarTareas("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/tareas.txt", todo, false);
                        //     operaciones.ExportarTareas("C:/Users/davo_/Documents/GitHub/TodoAppEval3/TodoAppEval3/tareas.txt", todo, true);
                        // }
                        // Console.WriteLine("         Las tareas (" + listaTareas.Count() + ") se han exportado correctamente.\n");
                    }
                    Console.WriteLine("\nTareas que quedan en la listaTareas");
                    manipularLista.ImprimirTareas(listaImportada);

                    Console.WriteLine("         Hay listaTareas.Count() =" + listaTareas.Count() + " tareas.\n");
                    break;
                case 8:
                    Console.WriteLine("     Adios amigo.");
                    appActivo = false;
                    break;
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