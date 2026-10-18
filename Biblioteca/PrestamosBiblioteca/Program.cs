using PrestamosBiblioteca.Aplicacion;
using PrestamosBiblioteca.Persistencia;

namespace PrestamosBiblioteca;

internal class Program
{
    private static void Main(string[] args)
    {
        string cadenaConexion = "Data Source=biblioteca.db;";

        // Inicializa la base de datos y crea las tablas si no existen
        BaseDatosInicializador.Inicializar(cadenaConexion);

        // Instancia el repositorio con la cadena de conexión
        var repositorio = new RepositorioBiblioteca(cadenaConexion);
        
        // Pasa el repositorio al menú e inicia la aplicación
        var menu = new MenuBiblioteca(repositorio);
        menu.Ejecutar();
    }
}