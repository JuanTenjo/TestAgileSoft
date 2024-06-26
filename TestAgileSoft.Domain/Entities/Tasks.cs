﻿namespace TestAgileSoft.Domain.Entities
{
    public class Tasks
    {
        public Guid Id { get; set; } = default;
        public string Name { get; set; } = default!;
        public string Status { get; set; }
        public string Description { get; set; } = default!;
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
