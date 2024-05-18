
using Tune_Star.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tune_Star.BLL.Interfaces
{
    public interface ILangReadService
    {
        List<Language> languageList();
    }
}
