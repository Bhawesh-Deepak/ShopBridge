using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Core.Entity.Common
{
    /// <summary>
    /// Enum which is used in method return type
    /// </summary>
    public enum ResponseMessage
    {
        Added,
        Deleted,
        Updated,
        NotFound,
        ExceptionOccured
    }
}
