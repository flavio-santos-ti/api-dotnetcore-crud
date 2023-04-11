using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Domain.Result;

public class ResultValidationError
{
    public bool Successed { get; init; } = false;
    public string Name { get; set; }
    public string Message { get; set; }
    public List<ResultValidationItemError> Errors { get; set; }
}
