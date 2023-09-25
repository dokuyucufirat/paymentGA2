using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PaymentGetaway.Models;

namespace PaymentGetaway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Initiate")]
        public IActionResult InitiatePayment([FromBody] TokenizationRequest tokenizationRequest)
        {
            if (tokenizationRequest == null || tokenizationRequest.Amount <= 0)
            {
                return BadRequest("Geçersiz ödeme bilgisi.");
            }

            // Kart bilgilerinin doğrudan işlenmesini kaldırdık. Bunun yerine token kullanılmalıdır.

            PaymentRequest paymentRequest = new PaymentRequest
            {
                Amount = tokenizationRequest.Amount,
                PaymentMethod = tokenizationRequest.PaymentMethod,
                Status = PaymentStatus.Pending,
                PaymentId = tokenizationRequest.PaymentId
            };

            // Ödeme talebini kaydet
            _context.PaymentRequests.Add(paymentRequest);
            _context.SaveChanges();

            return Ok($"Ödeme başlatıldı. Miktar: {paymentRequest.Amount} - Ödeme Yöntemi: {paymentRequest.PaymentMethod}");
        }



        [HttpPost("Complete")]
        public IActionResult CompletePayment([FromBody] PaymentCompletionRequest completionRequest)
        {
            _context.PaymentCompletions.Add(completionRequest); // Tamamlama talebi ekleniyor.
            _context.SaveChanges(); // Değişiklikler kaydediliyor.

            return Ok("Ödeme tamamlandı.");
        }

        [HttpPost("Cancel")]
        public IActionResult CancelPayment([FromBody] PaymentCancellationRequest cancellationRequest)
        {
            _context.PaymentCancellations.Add(cancellationRequest); // İptal talebi ekleniyor.
            _context.SaveChanges(); // Değişiklikler kaydediliyor.

            return Ok("Ödeme iptal edildi.");
        }

        [HttpPost("Refund")]
        public IActionResult RefundPayment([FromBody] RefundRequest refundRequest)
        {
            _context.Refunds.Add(refundRequest); // Geri ödeme talebi ekleniyor.
            _context.SaveChanges(); // Değişiklikler kaydediliyor.

            return Ok("Geri ödeme yapıldı.");
        }

        [HttpGet("Status/{paymentId}")]
        public IActionResult CheckPaymentStatus(int paymentId)
        {
            var payment = _context.PaymentRequests.Find(paymentId); // Ödeme talebi sorgulanıyor.

            if (payment == null)
            {
                return NotFound(new { Message = "Ödeme bulunamadı." });
            }

            return Ok(new { Message = $"Ödeme durumu: {payment.Status}" });
        }

        [HttpPost("Webhook")]
        public IActionResult HandleWebhook([FromBody] WebhookRequest webhookRequest)
        {
            _context.Webhooks.Add(webhookRequest); // Webhook talebi ekleniyor.
            _context.SaveChanges(); // Değişiklikler kaydediliyor.

            return Ok("Webhook başarılı bir şekilde işlendi.");
        }

        [HttpPost("Tokenize")]
        public IActionResult TokenizePaymentInfo([FromBody] TokenizationRequest tokenizationRequest)
        {
            // Kredi kartı bilgilerini doğrudan işlemek yerine, bu metodun yalnızca token almak için kullanılmasını sağlayın.
            // Bu kod, örnek olarak kalmalıdır ve gerçek uygulamada kullanılmamalıdır.

            return Ok(new { Token = tokenizationRequest.Token });
        }
    }
}


