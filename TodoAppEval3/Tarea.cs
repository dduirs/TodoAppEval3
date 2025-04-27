public class Tarea
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public Tipo? tipo;
    public bool? Prioridad { get; set; }

    public Tarea(int id, string nombre, string descripcion, Tipo tipo, bool prioridad)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Descripcion = descripcion;
        this.tipo = tipo;
        this.Prioridad = prioridad;
    }

    public Tarea()
    {
    }
    public Tarea(int id, Tipo tipo)
    {
        this.Id = id;
        if ((int)tipo == 111)
        {
            tipo = Tipo.ocio;
        }
        else if ((int)tipo == 112)
        {
            tipo = Tipo.personal;
        }
        else if ((int)tipo == 116)
        {
            tipo = Tipo.trabajo;
        }
        this.tipo = tipo;
    }

    public String ExportarData()
    {
        return this.Id + "," + this.Nombre + "," + this.Descripcion + "," + this.tipo + "," + this.Prioridad;
    }

    public void ImprimirData()
    {
        Console.Write("ID: \u001B[32m" + this.Id + "\u001B[0m   Nombre: \u001B[32m" + this.Nombre + "\u001B[0m   Descripción: \u001B[32m" + this.Descripcion + "\u001B[0m   Tipo: \u001B[32m" + this.tipo + "\u001B[0m   Prioridad: \u001B[32m");
        if ((bool)this.Prioridad)
        {
            Console.WriteLine("sí\u001B[0m");
        }
        else
        {
            Console.WriteLine("no\u001B[0m");
        }
    }

    public void CrearTarea(int id)
    {
        string? input;
        Tipo tipo;
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

        if ((int)tipo == 111)
        {
            tipo = Tipo.ocio;
        }
        else if ((int)tipo == 112)
        {
            tipo = Tipo.personal;
        }
        else if ((int)tipo == 116)
        {
            tipo = Tipo.trabajo;
        }
        this.tipo = tipo;

        Console.Write("\u001B[0m   # \u001B[32mEscribe el nombre de la tarea: \u001B[0m");
        input = Console.ReadLine();
        this.Nombre = input;

        Console.Write("   # Escribe la descripción de la tarea: \u001B[32m");
        input = Console.ReadLine();
        this.Descripcion = input;

        Console.Write("\u001B[0m   # \u001B[32mEscribe si la tarea es prioridad (s o n): \u001B[0m");
        input = Console.ReadLine();
        if (input == "s")
        {
            this.Prioridad = true;
        }
        else
        {
            this.Prioridad = false;
        }
        this.Id = id;
    }
   
}