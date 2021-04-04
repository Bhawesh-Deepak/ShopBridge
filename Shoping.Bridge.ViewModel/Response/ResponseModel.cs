using System;
using System.Collections.Generic;

namespace Shoping.Bridge.ViewModel.Response
{
    public class ResponseModel<TEntity> where TEntity : class
    {
        public List<TEntity> models { get; set; }

        public int PageIndex { get; set; }

        public double PageCount { get; set; }
    }
}
