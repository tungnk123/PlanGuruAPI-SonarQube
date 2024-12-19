using Domain.Entities.WikiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.WikiEntities
{
    public class Contribution : BaseEntity<Guid>
    {
        public Guid WikiId { get; set; }
        public Wiki Wiki { get; set; }
        public List<ContentSection> ContentSections { get; set; } = new();
        public ContributionStatus Status { get; set; } = ContributionStatus.Pending;
        public string? RejectionReason { get; set; }
        public Guid ContributorId { get; set; }
        public User Contributor { get; set; }
    }

    public enum ContributionStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
