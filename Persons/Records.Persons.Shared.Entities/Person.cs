namespace Records.Persons.Shared.Entities;

/// <summary>
/// Representa una persona.
/// </summary>
public class Person
{
    #region Constructor

    /// <summary>Inicializa una nueva instancia de la clase <see cref="Person"/>.</summary>
    public Person()
    {
        this.PersonalAssets = new List<PersonalAsset>();
    }

    #endregion

    #region Properties

    /// <summary>Identificador de la entidad.</summary>
    public int Id { get; init; }

    /// <summary>Apellido y nombre/s.</summary>
    public string? FullName { get; init; }

    /// <summary>Dirección de correo electrónico.</summary>
    public string? Email { get; init; }

    /// <summary>The phone number.</summary>
    public string? Phone { get; init; }

    /// <summary>Género ("Male, Female, Other").</summary>
    public string? Gender { get; init; }

    /// <summary>La fecha de nacimiento.</summary>
    public DateTime? Birthdate { get; init; }

    /// <summary>Una <see cref="Address"/> of the person.</summary>
    public Address? Address { get; init; }

    /// <summary>Lista de <see cref="PersonalAsset"/>.</summary>
    public IList<PersonalAsset>? PersonalAssets { get; init; }

    /// <summary>Fecha de creación de este registro (UTC).</summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>Fecha de la última modificación de este registro (UTC).</summary>
    public DateTime UpdatedAt { get; set; }

    #endregion
}
