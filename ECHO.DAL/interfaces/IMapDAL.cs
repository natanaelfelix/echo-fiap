using ECHO.MODEL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECHO.DAL.interfaces {
    public interface IMapDAL {

        Task<IEnumerable<Mapeamento>> GetAllMap();
        Task<IEnumerable<Mapeamento>> GetOneMap(int idMap);
        Task Delete(int IdMap);
        Task InsertMap(Mapeamento mapea);
    }
}
