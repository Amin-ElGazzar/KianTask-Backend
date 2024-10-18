namespace Kian.Entities;

public class BaseModel<T>
{
    public T Id { get; set; }
    public DateTime? CreateDate { get; set; } = DateTime.Now;
    public DateTime? LastUpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
}
