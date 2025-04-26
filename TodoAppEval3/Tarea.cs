//1. - Crear tareas: se pedirá el nombre, descripción, tipo (personal, trabajo, ocio) y prioridad de la tarea
//                                                      (^ necesario utilizar un Enum por los tipos)
// - El id se asignará automáticamente y será único para cada tarea.
// - La prioridad es un booleano.
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
    public Tarea(int id, Tipo tipo){
        this.Id = id;
        if((int)tipo == 111){
            tipo = Tipo.ocio;
        }else if((int)tipo == 112){
            tipo = Tipo.personal;
        }else if((int)tipo == 116){
            tipo = Tipo.trabajo;
        }
        this.tipo = tipo;
    }

    public String ExportarData()
    {
        return "ID: " + this.Id + "   Nombre: " + this.Nombre + "   Descripción: " + this.Descripcion + "   Tipo: " + this.tipo + "   Prioridad: " + this.Prioridad;
    }

    public void ImprimirData()
    {
        Console.Write("ID: \u001B[32m" + this.Id + "\u001B[0m   Nombre: \u001B[32m" + this.Nombre + "\u001B[0m   Descripción: \u001B[32m" + this.Descripcion + "\u001B[0m   Tipo: \u001B[32m" + this.tipo + "\u001B[0m   Prioridad: \u001B[32m");
        if((bool)this.Prioridad){
        Console.WriteLine("sí\u001B[0m");
            }else{
        Console.WriteLine("no\u001B[0m");
            } 
    }

}