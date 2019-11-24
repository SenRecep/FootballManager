using FootBallManager.Entities.Concrete;
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
        int Adressid { get; set; }
        bool IsAdmin { get; set; }
    }
}
