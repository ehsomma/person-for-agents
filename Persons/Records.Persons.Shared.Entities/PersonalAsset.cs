namespace Records.Persons.Shared.Entities;

/// <summary>
/// Bienes personales de una persona.
/// </summary>
public class PersonalAsset
{
    #region Properties

    /// <summary>Identificador de la entidad.</summary>
    public int Id { get; init; } // Autoincrement.

    /// <summary>Tipo de bien (Mueble, Inmueble).</summary>
    public string Type { get; set; }

    /// <summary>Descripción del bien.</summary>
    public string Description { get; set; }

    /// <summary>Valor del bien.</summary>
    public decimal Value { get; set; }

    #endregion
}
