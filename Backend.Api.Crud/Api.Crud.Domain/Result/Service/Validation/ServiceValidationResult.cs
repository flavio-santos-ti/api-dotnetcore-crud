﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Domain.Result.Service.Validation;

public class ServiceValidationResult
{
    public string PropertyName { get; set; }
    public string ErrorMessage { get; set; }
}
