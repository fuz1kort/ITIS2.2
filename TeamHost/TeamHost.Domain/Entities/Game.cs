using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class Game : BaseAuditableEntity
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public List<MediaFile> MediaFiles { get; set; }
    public string Description { get; set; }
    public float Rating { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Platform { get; set; }
    public int DeveloperId { get; set; }
    public Developer Developer { get; set; }
    public virtual List<Category> Categories { get; set; }
}