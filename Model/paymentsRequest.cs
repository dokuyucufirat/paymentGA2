using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PaymentGetaway.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        public string PaymentId { get; set; }
    }

    public class CreditCardInfo
    {
        [Required]
        [StringLength(16, MinimumLength = 13)]
        public string CardNumber { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?(([0-9]{4}|[0-9]{2})$)", ErrorMessage = "Geçersiz son kullanma tarihi")]
        public string CardExpiry { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 3)]
        public string CardCVC { get; set; }
    }



    public enum PaymentStatus
    {
        Pending,
        Successful,
        Failed
    }

    public class PaymentRequest : BaseModel
    {
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public PaymentStatus Status { get; set; }
    }

    public class PaymentCompletionRequest : BaseModel
    {
        public int PaymentRequestId { get; set; }
        public PaymentRequest RelatedPaymentRequest { get; set; }
        public string ConfirmationCode { get; set; }
    }

    public class PaymentCancellationRequest : BaseModel
    {
        // Ek özellikler eklenebilir.
    }

    public class RefundRequest : BaseModel
    {
        public decimal Amount { get; set; }
    }

    public class PaymentStatusRequest : BaseModel
    {
        // Ek özellikler eklenebilir.
    }

    public class WebhookRequest : BaseModel
    {
        public string EventType { get; set; }
    }

    public class TokenizationRequest : BaseModel
    {
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public PaymentStatus Status { get; set; }
        public CreditCardInfo CardInfo { get; set; }
        public string Token { get; set; } 

    }


    public class TokenStorageModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Token { get; set; }

        // Eğer tarih/saat bilgisini saklamak isterseniz ekleyebilirsiniz
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
