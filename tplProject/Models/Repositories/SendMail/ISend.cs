using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tplProject.Models.Repositories.SendMail
{
    public interface ISend
    {
        public void SendMail(string YourEmail, string YourSubject, String YourName, String Comments);
    }
}
