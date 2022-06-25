using Business.Abstract;
using Business.Aspects.Authorization;
using Business.Costants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Transaction;
using Core.Aspects.Validation;
using Core.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BookValidator))]
        [CacheRemoveAspect("IBookService.Get")]
        public IResult Add(Book book)
        {

            IResult result = BusinessRules.Run(CheckBookName(book.BookName));
            if (result!=null)
            {
                return result;
            }
            _bookDal.Add(book);
            return new SuccessResult(Messages.AddBookMessage);
        }

        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult(Messages.RemoveBookMessage);
        }
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll());
        }
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Book>> GetByCategoryId(int id)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b=>b.CategoryId==id));
        }
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Book>> GetByUnitPriceRange(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b=>b.UnitPrice<=max && b.UnitPrice>=min));
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BookValidator))]
        [CacheRemoveAspect("IBookService.Get")]
        public IResult Update(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult(Messages.UpdateBookMessage);
        }
        [TransactionScopeAspect]
        public IResult TransactionalTest(Book book)
        {
            _bookDal.Add(book);
            _bookDal.Update(book);
            return new SuccessResult("Başarıyla güncellendi.");
        }
        private IResult CheckBookName(string bookName)
        {
            var result = _bookDal.GetAll(b=>b.BookName==bookName).Any();
            if (result)
            {
                return new ErrorResult(Messages.NotUnique);
            }
            return new SuccessResult();
        }

    }
}
