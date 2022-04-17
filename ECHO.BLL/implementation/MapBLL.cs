using ECHO.BLL.interfaces;
using ECHO.DAL.interfaces;
using ECHO.MODEL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECHO.BLL.implementation {
    public class MapBLL : IMapBLL {

        private IMapDAL _mapDAL;

        public MapBLL(IMapDAL mapDAL) {
            _mapDAL = mapDAL;
        }

        public async Task<IEnumerable<Mapeamento>> GetAllMap() {
            return await _mapDAL.GetAllMap();
        }

        public async Task<IEnumerable<Mapeamento>> GetOneMap(int idMap) {
            return await _mapDAL.GetOneMap(idMap);
        }

        public async Task InsertMap(List<Mapeamento> mapea) {
            try {
                ///Compares whether the start time of the log is greater than the current time with one hour reduction.
                if (mapea.Count >= 1) {
                    foreach (Mapeamento x in mapea) {
                        await _mapDAL.InsertMap(x);
                    }
                }
            }
            catch (Exception e) {
                throw new Exception(e.ToString());
            }
        }

        public async Task DeleteMap(int idMap) {
            await _mapDAL.Delete(idMap);
        }
    }
}
