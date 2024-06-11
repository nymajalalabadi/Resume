using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Common
{
    public class BasePaging<T>
    {
        public BasePaging()
        {
            PageId = 1;
            TakeEntity = 5;
            HowManyShowPageAfterAndBefore = 5;
            Entities = new List<T>();
        }

        public int PageId { get; set; }

        public int PageCount { get; set; }

        public int AllEntitiesCount { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }

        public int TakeEntity { get; set; }

        public int SkipEntity { get; set; }

        public int HowManyShowPageAfterAndBefore { get; set; }

        public List<T> Entities { get; set; }


        public PagingViewModel GetCurrentPaging()
        {
            return new PagingViewModel
            {
                EndPage = this.EndPage,
                PageId = this.PageId,
                StartPage = this.StartPage,
                PageCount = this.PageCount
            };
        }


        public async Task<BasePaging<T>> Paging(IQueryable<T> queryable)
        {
            TakeEntity = TakeEntity;

            var allEntitiesCount = queryable.Count();

            var pageCount = 0;

            try
            {
                pageCount = Convert.ToInt32(Math.Ceiling(allEntitiesCount / (double)TakeEntity));
            }
            catch (Exception)
            {

            }

            PageId = PageId > pageCount ? pageCount : PageId;
            if (PageId <= 0) PageId = 1;
            AllEntitiesCount = allEntitiesCount;
            HowManyShowPageAfterAndBefore = HowManyShowPageAfterAndBefore;
            SkipEntity = (PageId - 1) * TakeEntity;
            StartPage = PageId - HowManyShowPageAfterAndBefore <= 0 ? 1 : PageId - HowManyShowPageAfterAndBefore;
            EndPage = PageId + HowManyShowPageAfterAndBefore > pageCount ? pageCount : PageId + HowManyShowPageAfterAndBefore;
            PageCount = pageCount;
            Entities = await Task.Run(() => queryable.Skip(SkipEntity).Take(TakeEntity).ToList());

            return this;
        }


        public BasePaging<T> Paging()
        {
            var allEntitiesCount = Entities.Count;

            var pageCount = 0;
            try
            {
                pageCount = Convert.ToInt32(Math.Ceiling(allEntitiesCount / (double)TakeEntity));
            }
            catch (Exception)
            {

            }

            PageId = PageId > pageCount ? pageCount : PageId;
            if (PageId <= 0) PageId = 1;
            AllEntitiesCount = allEntitiesCount;
            HowManyShowPageAfterAndBefore = HowManyShowPageAfterAndBefore;
            StartPage = PageId - HowManyShowPageAfterAndBefore <= 0 ? 1 : PageId - HowManyShowPageAfterAndBefore;
            EndPage = PageId + HowManyShowPageAfterAndBefore > pageCount ? pageCount : PageId + HowManyShowPageAfterAndBefore;
            PageCount = pageCount;
            return this;
        }
    }

    public class PagingViewModel
    {
        public int PageId { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }

        public int PageCount { get; set; }
    }

}
