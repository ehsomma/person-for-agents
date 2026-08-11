namespace Records.Shared.Entities;

/// <summary>
/// Represents an error with a code and description.
/// </summary>
public class MyError
{
    /// <summary>Gets or sets the numeric code associated with the current instance.</summary>
    public int Code { get; set; }

    /// <summary>Gets or sets the description identifier for the entity.</summary>
    public string? Description { get; set; }
}
