using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PrivateNewsLetterManager : IPrivateNewsLetterService
    {
        IPrivateNewsLetterDal _privateNewsLetterDal;

        public PrivateNewsLetterManager(IPrivateNewsLetterDal privateNewsLetterDal)
        {
            _privateNewsLetterDal = privateNewsLetterDal;
        }

        public void AddPrivateNewsLetter(PrivateNewsLetter privateNewsLetter)
        {
            _privateNewsLetterDal.Insert(privateNewsLetter);
        }
    }
}
