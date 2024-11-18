using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Response
{
  public class BaseResponse
  {
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }
  }
  public class BaseResponse<T>
  {
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
    public T Value { get; set; }
  }
}
