namespace Data.Models
{
    public abstract class CmAbstract
    {

        public DateTime? CreateDate { get; set; }

        public string? CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
