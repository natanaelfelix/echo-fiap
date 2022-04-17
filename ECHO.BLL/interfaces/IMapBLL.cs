using ECHO.MODEL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECHO.BLL.interfaces {
    public interface IMapBLL {

        Task<IEnumerable<Mapeamento>> GetAllMap();
        Task<IEnumerable<Mapeamento>> GetOneMap(int idMap);
        Task DeleteMap(int idMap);
        Task InsertMap(List<Mapeamento> mapea);
    }
}
