using System.ComponentModel.DataAnnotations;
using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class Country: BaseAuditableEntity
{
    /// <summary>
    /// Числовой код страны
    /// </summary>
    public int Code { get; set; }
    
    /// <summary>
    /// Короткое имя страны
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Полное имя страны
    /// </summary>
    public string FullName { get; set; }
    
    /// <summary>
    /// 2-х буквенный код
    /// </summary>
    [StringLength(2)]
    public string Alpha2 { get; set; }
    
    /// <summary>
    /// 3-ч буквенный код
    /// </summary>
    [StringLength(3)]
    public string Alpha3 { get; set; }
    
    /// <summary>
    /// Список всех developers
    /// </summary>
    public virtual List<Developer> Developers { get; set; }
}