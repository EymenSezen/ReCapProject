using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.GuidHelper
{
    public class GuidHelperManager
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();   //unique namae
        }
    }
}
