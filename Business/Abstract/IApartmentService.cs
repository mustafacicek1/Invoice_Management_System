using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IApartmentService
    {
        List<ApartmentListDTO> GetApartments();
        Apartment GetApartment(int apartmentId);
        void Add(CreateApartmentDTO createApartmentDTO);
        void Update(int apartmentId,UpdateApartmentDTO updateApartmentDTO);
        void Delete(int apartmentId);
    }
}
