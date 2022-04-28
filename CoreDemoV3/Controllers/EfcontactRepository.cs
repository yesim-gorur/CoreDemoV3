using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace CoreDemoV3.Controllers
{
    public class EfcontactRepository : GenericRepository<Contact>, IContactDal
    {
    }
}