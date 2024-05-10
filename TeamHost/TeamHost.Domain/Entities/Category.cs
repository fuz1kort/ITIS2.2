using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class Category: BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Game> Games { get; set; }
}