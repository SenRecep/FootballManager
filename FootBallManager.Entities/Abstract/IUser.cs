using FootBallManager.Entities.Concrete;
using FootballManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.Abstract
{
    public interface IUser
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        Adress Adress { get; set; }
        int? Adressid { get; set; }
        string TagName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        bool IsAdmin { get; set; }

        Team Team { get; set; }
        int? Teamid { get; set; }

    }
}
