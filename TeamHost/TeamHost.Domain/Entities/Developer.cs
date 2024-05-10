using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class Developer: BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public virtual List<Game> Games { get; set; }
}