//1. - Crear tareas: se pedirá el nombre, descripción, tipo (persona, trabajo, ocio) y prioridad de la tarea
//                                                      (^ necesario utilizar un Enum por los tipos)
// - El id se asignará automáticamente y será único para cada tarea.
// - La prioridad es un booleano.
class Tarea
{
    public int id { get; set; }

    public string nombre { get; set; }
    public string descripcion { get; set; }
    private Tipo tipo;
    public bool prioridad { get; set; }


    public Tarea(int id, string nombre, string descripcion, Tipo tipo, bool prioridad)
    {
        this.id = id;
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.tipo = tipo;
        this.prioridad = prioridad;
    }
    // public Tarea(){

    // }

    public String ExportarDato()
    {
        return nombre + "," + descripcion + "," + tipo + "," + prioridad;
    }

}