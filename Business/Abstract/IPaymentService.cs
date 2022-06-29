using Entities.DTOs;
namespace Business.Abstract
{
    public interface IPaymentService
    {
        List<PaymentListDTO> PaymentList();
        void AddPayment(CreatePaymentDTO createPaymentDTO);
    }
}
