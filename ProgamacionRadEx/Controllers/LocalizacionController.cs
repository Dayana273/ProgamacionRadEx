using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgamacionRadEx.Controllers
{

    public class LocalizacionController
    {
        readonly SQLiteAsyncConnection _Connection;
        public LocalizacionController(string DBPath)
        {
            _Connection = new SQLiteAsyncConnection(DBPath);
            _Connection.CreateTableAsync<Models.Personas>();

        }
        public Task<int> SaveGeo(Models.Personas posicion)
        {
            if (posicion.id != 0)
                return _Connection.UpdateAsync(posicion);
            else
                return _Connection.InsertAsync(posicion);
        }

        // READ one
        public Task<Models.Personas> GetLocalizaciones(int pid)
        {
            return _Connection.Table<Models.Personas>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }


        public Task<List<Models.Personas>> GetlistLocalizaciones()
        {
            return _Connection.Table<Models.Personas>().ToListAsync();
        }

        public Task<int> DeleteLocalizaciones(Models.Personas posicion)
        {
            //delete
            return _Connection.DeleteAsync(posicion);
        }



    }
}


