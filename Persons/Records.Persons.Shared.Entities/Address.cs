namespace Records.Persons.Shared.Entities;

/// <summary>
/// Datos de una dirección postal.
/// </summary>
public class Address
{
    #region Properties

    /// <summary>Identificador de la entidad.</summary>
    public int Id { get; init; }

    /// <summary>Datos de la calle (línea 1).</summary>
    public string? StreetLine1 { get; init; }

    /// <summary>Datos de la calle (línea 2).</summary>
    public string? StreetLine2 { get; init; }

    /// <summary>Nombre de la ciudad.</summary>
    public string? City { get; init; }

    /// <summary>Nombre del estado o privincia.</summary>
    public string? State { get; init; }

    /// <summary>Nombre del país.</summary>
    public string? Country { get; init; }

    #endregion
}
