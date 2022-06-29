using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InvoiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void AddInvoice(CreateInvoiceDTO createInvoiceDTO)
        {
            //adding invoce for all users
            var invoice = _mapper.Map<Invoice>(createInvoiceDTO);
            var users = _unitOfWork.Users.GetAll();
            foreach (var user in users)
            {
                _unitOfWork.Invoices.Add(new Invoice {
                
                    InvoicePrice =invoice.InvoicePrice,
                    DuesPrice =invoice.DuesPrice,
                    Month = invoice.Month,
                    UserId = user.Id
                });
            }
            _unitOfWork.SaveChanges();
        }

        public List<InvoceListDTO> GetDebtList()
        {
            var debts = _unitOfWork.Invoices.GetAll(x => x.Payments.Count == 0, x => x.User);
            var vm = _mapper.Map<List<InvoceListDTO>>(debts);
            return vm;
        }

        public List<InvoceListDTO> GetInvocesByUserId(int userId)
        {
            var invoces = _unitOfWork.Invoices.GetAll(x=>x.UserId==userId && x.Payments.Count==0 ,x=>x.User);
            return _mapper.Map<List<InvoceListDTO>>(invoces);
        }

        public Invoice GetInvoice(int invoiceId)
        {
            return _unitOfWork.Invoices.Get(x => x.Id == invoiceId);
        }
    }
}
