﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Domain.Result.Service;

public class ServiceResult
{
    public bool Successed { get; set; }
    public string Name { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }

}
