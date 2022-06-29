using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ApartmentManager : IApartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ApartmentManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(CreateApartmentDTO createApartmentDTO)
        {
            var apartment = _mapper.Map<Apartment>(createApartmentDTO);
            _unitOfWork.Apartments.Add(apartment);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int apartmentId)
        {
            var apartment = _unitOfWork.Apartments.Get(x => x.Id == apartmentId);
            _unitOfWork.Apartments.Delete(apartment);
            _unitOfWork.SaveChanges();
        }

        public Apartment GetApartment(int apartmentId)
        {
            var apartment = _unitOfWork.Apartments.Get(x => x.Id == apartmentId);
            return apartment;
        }

        public List<ApartmentListDTO> GetApartments()
        {
            var apartments = _unitOfWork.Apartments.GetAll(null,x=>x.User);
            return _mapper.Map<List<ApartmentListDTO>>(apartments);
        }

        public void Update(int apartmentId, UpdateApartmentDTO updateApartmentDTO)
        {
            var apartment = _unitOfWork.Apartments.Get(x => x.Id == apartmentId);
            apartment.Blok = updateApartmentDTO.Blok;
            apartment.Type = updateApartmentDTO.Type;
            apartment.ApartmentNo = updateApartmentDTO.ApartmentNo;
            apartment.UserId = updateApartmentDTO.UserId;
            apartment.IsEmpty = updateApartmentDTO.IsEmpty;
            apartment.FloorNumber = updateApartmentDTO.FloorNumber;
            _unitOfWork.SaveChanges();
        }
    }
}
