namespace IdentityServiceDomain.Interface
{
    public interface IHasDeletionTime
    {
        public DateTime? DeletionTime { get; }
    }
}
