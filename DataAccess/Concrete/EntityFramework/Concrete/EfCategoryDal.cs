using Core.DataAccess;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfCategoryDal: EfEntityDal<BookContext,Category>,ICategoryDal
    {
    }
}
