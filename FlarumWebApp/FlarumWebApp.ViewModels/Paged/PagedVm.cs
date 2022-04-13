using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlarumWebApp.ViewModels.Paged
{
    public class PagedVm<T> where T : class
    {
        public PagedVm(IEnumerable<T> data, int pageIndex, int pageSize, int totalPage)
        {
            Data = data;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPage = totalPage;
        }
        public IEnumerable<T> Data { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalPage { get; set; }

    }
}
