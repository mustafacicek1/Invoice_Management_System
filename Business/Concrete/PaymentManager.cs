using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PaymentManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddPayment(CreatePaymentDTO createPaymentDTO)
        {
            var payment = _mapper.Map<Payment>(createPaymentDTO);
            _unitOfWork.Payments.Add(payment);
            _unitOfWork.SaveChanges();
        }

        public List<PaymentListDTO> PaymentList()
        {
            var payments = _unitOfWork.Payments.GetAll(null, x => x.Invoice, x => x.User);
            var vm = _mapper.Map<List<PaymentListDTO>>(payments);
            return vm;
        }
    }
}
