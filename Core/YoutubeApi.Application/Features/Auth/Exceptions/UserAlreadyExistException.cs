﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exceptions
{
    public partial class UserAlreadyExistException : BaseExceptions
    {
        public UserAlreadyExistException() : base("Böyle bir kullanıcı zaten var") { }
       
    }
}
