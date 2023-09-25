using Microsoft.EntityFrameworkCore;

namespace PaymentGetaway.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PaymentRequest> PaymentRequests { get; set; }
        public DbSet<PaymentCompletionRequest> PaymentCompletions { get; set; }
        public DbSet<PaymentCancellationRequest> PaymentCancellations { get; set; }
        public DbSet<RefundRequest> Refunds { get; set; }
        public DbSet<WebhookRequest> Webhooks { get; set; }
        public DbSet<TokenStorageModel> TokenStorages { get; set; }
        public DbSet<PaymentStatusRequest> PaymentStatusRequests { get; set; }
        public DbSet<PaymentCompletionRequest> PaymentCompletionRequests { get; set; }
        public DbSet<PaymentCancellationRequest> PaymentCancellationRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
