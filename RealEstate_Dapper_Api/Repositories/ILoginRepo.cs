﻿using RealEstate_Dapper_Api.Models;

namespace RealEstate_Dapper_Api.Repositories
{
    public interface ILoginRepo
    {
        string LoginMethod(Login p);

    }
}
