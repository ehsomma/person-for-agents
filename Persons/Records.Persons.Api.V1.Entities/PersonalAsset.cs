namespace Records.Persons.Api.V1.Entities;

/// <summary>
/// Bienes personales de una persona.
/// </summary>
public class PersonalAsset
{
    #region Properties

    /// <summary>Tipo de bien (Mueble, Inmueble).</summary>
    public string? Type { get; set; }

    /// <summary>Descripción del bien.</summary>
    public string? Description { get; set; }

    /// <summary>Valor del bien.</summary>
    public decimal Value { get; set; }

    #endregion
}
