namespace PrestamosBiblioteca.Dominio;

internal abstract class Persona
{
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }

    protected Persona(string nombre, string correo, string telefono)
    {
        Nombre = nombre;
        Correo = correo;
        Telefono = telefono;
    }

    public abstract string ObtenerInformacion();
}