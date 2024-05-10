using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class MediaFile: BaseAuditableEntity
{
    public string Name { get; set; }
    public string Path { get; set; }
    public ulong Size { get; set; }
    
}