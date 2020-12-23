using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PDH.Services.Infastructures
{
    public interface iAppService
    {
        Task GetOption(int mnuSelected);
     }
}
