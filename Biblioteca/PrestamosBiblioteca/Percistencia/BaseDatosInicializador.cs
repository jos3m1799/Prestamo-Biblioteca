using Microsoft.Data.Sqlite;

namespace PrestamosBiblioteca.Persistencia;

internal static class BaseDatosInicializador
{
    public static void Inicializar(string cadenaConexion)
    {
        using var conexion = new SqliteConnection(cadenaConexion);
        conexion.Open();

        using var comando = conexion.CreateCommand();
        comando.CommandText = @"
            PRAGMA foreign_keys = ON;

            CREATE TABLE IF NOT EXISTS Lectores (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Codigo TEXT NOT NULL UNIQUE,
                Nombre TEXT NOT NULL,
                Correo TEXT NOT NULL,
                Telefono TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Libros (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Codigo TEXT NOT NULL UNIQUE,
                Titulo TEXT NOT NULL,
                Autor TEXT NOT NULL,
                Ejemplares INTEGER NOT NULL CHECK(Ejemplares >= 0)
            );

            CREATE TABLE IF NOT EXISTS Prestamos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                LectorId INTEGER NOT NULL,
                LibroId INTEGER NOT NULL,
                FechaPrestamo TEXT NOT NULL,
                FechaLimite TEXT NOT NULL,
                FechaDevolucion TEXT NULL,
                FOREIGN KEY (LectorId) REFERENCES Lectores(Id) ON DELETE CASCADE,
                FOREIGN KEY (LibroId) REFERENCES Libros(Id) ON DELETE CASCADE
            );
        ";
        comando.ExecuteNonQuery();
    }
}