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
                Console.Write("              ");
                tarea.ImprimirData();
            }
        }
        Console.WriteLine("\u001B[32m────────────────────────────────────────────────────────────────────────────────────────────────\u001B[0m\n");
    }
    
    public void ImprimirTareas(List<Tarea> listaTareas)
    {
        {
            var list1 = listaTareas;
            foreach (var tarea in list1)
            {
                tarea.ImprimirData();
            }
            Console.WriteLine("");
        }
    }
}