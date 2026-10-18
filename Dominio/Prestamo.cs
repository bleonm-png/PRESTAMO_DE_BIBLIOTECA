namespace PrestamosBiblioteca.Dominio;

public sealed class Prestamo
{
    public Prestamo(int lectorId, int libroId, DateTime fechaPrestamo, DateTime fechaLimite, DateTime? fechaDevolucion = null)
    {
        if (lectorId <= 0) throw new ArgumentException("Debe seleccionar un lector.");
        if (libroId <= 0) throw new ArgumentException("Debe seleccionar un libro.");
        if (fechaLimite.Date < fechaPrestamo.Date)
            throw new ArgumentException("La fecha limite no puede ser anterior a la fecha de prestamo.");
        if (fechaDevolucion.HasValue && fechaDevolucion.Value.Date < fechaPrestamo.Date)
            throw new ArgumentException("La fecha de devolucion no puede ser anterior a la fecha de prestamo.");
        LectorId = lectorId;
        LibroId = libroId;
        FechaPrestamo = fechaPrestamo.Date;
        FechaLimite = fechaLimite.Date;
        FechaDevolucion = fechaDevolucion?.Date;
    }

    public int Id { get; set; }
    public int LectorId { get; }
    public int LibroId { get; }
    public DateTime FechaPrestamo { get; }
    public DateTime FechaLimite { get; }
    public DateTime? FechaDevolucion { get; }
    public bool EstaActivo => !FechaDevolucion.HasValue;
}
