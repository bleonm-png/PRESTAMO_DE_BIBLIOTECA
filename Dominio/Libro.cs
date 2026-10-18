namespace PrestamosBiblioteca.Dominio;

public sealed class Libro
{
    public Libro(string codigo, string titulo, string autor, int ejemplares)
    {
        Codigo = string.IsNullOrWhiteSpace(codigo) ? throw new ArgumentException("El codigo del libro es obligatorio.") : codigo.Trim();
        Titulo = string.IsNullOrWhiteSpace(titulo) ? throw new ArgumentException("El titulo del libro es obligatorio.") : titulo.Trim();
        Autor = string.IsNullOrWhiteSpace(autor) ? throw new ArgumentException("El autor del libro es obligatorio.") : autor.Trim();
        if (ejemplares <= 0) throw new ArgumentException("Los ejemplares deben ser mayores que cero.");
        Ejemplares = ejemplares;
    }

    public string Codigo { get; }
    public string Titulo { get; }
    public string Autor { get; }
    public int Ejemplares { get; }
}
