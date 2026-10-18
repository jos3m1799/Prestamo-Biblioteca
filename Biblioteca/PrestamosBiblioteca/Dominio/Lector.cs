namespace PrestamosBiblioteca.Dominio;

internal class Lector : Persona
{
    public int Id { get; set; }
    public string Codigo { get; set; }

    public Lector(string codigo, string nombre, string correo, string telefono)
        : base(nombre, correo, telefono)
    {
        Codigo = codigo;
    }

    public override string ObtenerInformacion()
    {
        return $"[LECTOR] Código: {Codigo} | Nombre: {Nombre} | Correo: {Correo} | Tel: {Telefono}";
    }
}