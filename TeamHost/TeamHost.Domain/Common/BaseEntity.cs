using System.ComponentModel.DataAnnotations.Schema;
using TeamHost.Domain.Common.Interfaces;

namespace TeamHost.Domain.Common;

public abstract class BaseEntity : IEntity
{
    public int Id { get; set; }
}