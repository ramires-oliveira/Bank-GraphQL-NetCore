﻿using BankGraphQL.DTO.Request.User;
using BankGraphQL.DTO.Response.User;

namespace BankGraphQL.DTO.Handlers.Interface.User
{
    public interface IGetByIdUserHandler
    {
        UserResponse Execute(GetByIdUserRequest request);

    }
}
