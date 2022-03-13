using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.CORE.Exceptions
{
    /// <summary>
    /// Xử lý các Exception
    /// CreateBy: TTThiep(01/01/2022)
    /// </summary>
    public class ValidateException : Exception
    {
        IDictionary Validate = new Dictionary<string, object>();

        public ValidateException(object data)
        {
            this.Validate.Add("data", data);
        }

        public override string Message
        {
            get
            {
                return "Dữ liệu không hợp lệ vui, lòng kiểm tra lại";
            }
        }

        public override IDictionary Data
        {
            get { return this.Validate; }
        }
    }
}
