using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Model
{
    public class ResponseModel<TEntity> where TEntity : class
    {
        public List<TEntity> models { get; set; }

        public int PageIndex { get; set; }

        public double PageCount { get; set; }
    }
}
