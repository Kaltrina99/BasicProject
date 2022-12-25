using Microsoft.Extensions.Options;
using Models;
using Models.DataAccess;
using Models.DTO;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BaseClassRepository : IBaseClassRepository
    {
        private readonly BaseRepository baseRepo;
        public BaseClassRepository(IOptions<DatabaseSettings> dbOptions)
        {
            DatabaseSettings dbSettings = dbOptions.Value;
            baseRepo = new BaseRepository(dbSettings.DefaultConnection);
        }
        public void CreateBase(BaseClassDTO baseClass)
        {
            try
            {
                using (var con = baseRepo.GetConnection())
                {
                    using (var cmd = new SqlCommand("dbo.CreateBase", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@name", baseClass.Name);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<BaseClass> GetAll()
        {
            try
            {
                using (var con = baseRepo.GetConnection())
                {
                    using (var cmd = new SqlCommand("dbo.GetAll", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var reader = cmd.ExecuteReader();

                        var items = new List<BaseClass>();
                        while (reader.Read())
                        {
                            var item = new BaseClass();
                            item.ID = int.Parse(reader["ID"].ToString());
                            item.Name = reader["Name"].ToString();
                            item.Active = bool.Parse(reader["Active"].ToString());
                           
                            items.Add(item);
                        }
                        con.Close();
                        return items;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
