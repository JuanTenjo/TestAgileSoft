using System.ComponentModel.DataAnnotations.Schema;

namespace TestAgileSoft.Domain.Entities
{
    public class Tasks
    {
        public Guid Id { get; set; } = default;
        public string Name { get; set; } = default!;
        public bool Status { get; set; }
        public string Description { get; set; } = default!;
        public string UserId { get; set; }
        public User User { get; set; }

        [NotMapped]
        public DateTime CreatedOn { get; set; }
        [NotMapped]
        public DateTime LastModifiedOn { get; set; }
    }
}
