namespace InventoryManagement.Domain.Shared;

public class AuditableEntity
{
	public string? CreatedBy { get; set; }
	public DateTime CreatedDate { get; set; }
	public string? LastModifiedBy { get; set; }
	public DateTime LastModifiedDate { get; set; }
	public bool Active { get; set; }
}

