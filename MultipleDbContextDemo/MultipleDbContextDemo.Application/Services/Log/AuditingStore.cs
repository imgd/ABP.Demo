using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Auditing;

namespace MultipleDbContextDemo.Application
{
    /// <summary>
    /// Implements <see cref="IAuditingStore"/> to save auditing informations to database.
    /// </summary>
    public class AuditingStore : IAuditingStore, ITransientDependency
    {
        //private readonly IRepository<AuditLog, long> _auditLogRepository;

        private readonly IRepository<AuditLog> _auditLogRepository;

        /// <summary>
        /// Creates  a new <see cref="AuditingStore"/>.
        /// </summary>
        public AuditingStore(IRepository<AuditLog> auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public Task SaveAsync(AuditInfo auditInfo)
        {
            return _auditLogRepository.InsertAsync(AuditLog.CreateFromAuditInfo(auditInfo));
        }
    }
}