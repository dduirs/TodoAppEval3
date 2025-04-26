public class ManipularListaTareas
{

    public void SortTareas(List<Tarea> listaTareas, Tipo tipo)
    {
        Console.WriteLine("\u001B[32m────────────────────────────────────────────────────────────────────────────────────────────────\u001B[0m");
        var list1 = listaTareas;
        foreach (var tarea in list1)
        {
            if (tarea.tipo == tipo)
            {
                tarea.ImprimirData();
            }
        }
        Console.WriteLine("\u001B[32m────────────────────────────────────────────────────────────────────────────────────────────────\u001B[0m\n");
    }

    public List<Tarea> EliminarTarea(List<Tarea> listaTareas, int id)
    {
        Console.WriteLine("\u001B[33m────────────────────────────────────────────────────────────────────────────────────────────────\u001B[0m");
        var list1 = listaTareas;

        foreach (var tarea in list1)
        {
            if (tarea.Id == id)
            {
                tarea.ImprimirData();
                list1.Remove(tarea);
                // listaTareas.removeif(new Predicate<tarea>());
            }
        }
        Console.WriteLine("\u001B[33m────────────────────────────────────────────────────────────────────────────────────────────────\u001B[0m\n");
        return listaTareas;
    }

    // public void ImprimirTareas(List<Tarea> listaTareas)
    // {
    //     {
    //         var list1 = listaTareas;
    //         foreach (var tarea in list1)
    //         {
    //             tarea.ImprimirData();
    //         }
    //     }
    // }

}

