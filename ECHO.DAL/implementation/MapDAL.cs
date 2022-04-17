using Dapper;
using ECHO.DAL.interfaces;
using ECHO.MODEL.Configuration;
using ECHO.MODEL.Entity;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


namespace ECHODAL.implementation {
    public class MapDAL : DataBaseDAO, IMapDAL {

        private string _defaultSelect;
        private string _defaultInsert;
        private string _defaultDelete;

        public MapDAL(Connect connect) : base(connect, "Map") {
            _defaultSelect = @"select * from echo.t_ecmap where 1=1";
            _defaultInsert = @"insert into echo.t_ecmap (nm_mapea, dt_inicio_map, nm_fantasia) VALUES(@NOMEMAPEA, @DATAINICIOMAP, @NOMEFASNTASIA)";
            _defaultDelete = @"DELETE from echo.t_ecmap where cd_mapea = @IDMAPEAMENTO";
        }

        public async Task<IEnumerable<Mapeamento>> GetAllMap() {
            using (IDbConnection con = DbConnection) {
                if (con.State != ConnectionState.Open)
                    con.Open();
                return await con.QueryAsync<Mapeamento>(this._defaultSelect);
            }
        }

        public async Task<IEnumerable<Mapeamento>> GetOneMap(int idMap) {
            using (IDbConnection con = DbConnection) {
                if (con.State != ConnectionState.Open)
                    con.Open();
                var param = new {
                    IDMAPEA = idMap
                };
                return await con.QueryAsync<Mapeamento>(this._defaultSelect + "and cd_mapea = @IDMAPEA", param);
            }
        }

        public async Task InsertMap(Mapeamento InsertMap) {
            ///Assemble String and send it to the bank, making the insertion
            var param = new {
                DATAINICIOMAP = InsertMap.dt_inicio_map,
                NOMEFASNTASIA = InsertMap.nm_fantasia,
                NOMEMAPEA = InsertMap.nm_mapea,
            };
            await base.ExecuteQuerySingle<int>(this._defaultInsert, param);
        }

        public async Task Delete(int IdMap) {
            ///Assemble String and send it to the bank, making the insertion
            var param = new {
                IDMAPEAMENTO = IdMap,
            };
            await base.ExecuteQuery<int>(this._defaultDelete, param);
        }
    }

}
