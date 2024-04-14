using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniExample.Model.Wrapper
{
    public class MyResponse<T>
    {
        public MyResponse()
        {
        }
        public MyResponse(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
    public class MyPagedResponse<T> : MyResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public MyPagedResponse(T data, int pageNumber, int pageSize, int totaRecord)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalRecords = totaRecord;
            this.TotalPages = (int)Math.Ceiling((double)totaRecord / (double)pageSize);
            this.Data = data;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
        }
    }
   
}
