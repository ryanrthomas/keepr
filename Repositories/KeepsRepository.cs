using System;
using System.Collections.Generic;
using System.Data;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;
        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Keep> GetAll()
        {
            return _db.Query<Keep>("SELECT * FROM keeps");
        }

        public Keep GetById(int Id)
        {
            return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @Id", new { Id });
        }

        public Keep CreateKeep(Keep keep)
        {
            try
            {
                int id = _db.ExecuteScalar<int>(@"
                INSERT INTO keeps (name, keepId)
                    VALUES (@Name, @KeepId);
                    SELECT LAST_INSERT_ID()
                ", keep);
                keep.Id = id;
                return keep;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Keep EditKeep(int id, Keep editedKeep)
        {
            try
            {
                string query = @"
                UPDATE keeps SET
                    name = @editedKeep.Name,
                    teamId = @editedKeep.KeepId
                WHERE id = @id
                SELECT * FROM keeps WHERE id = @id;
                ";
                return _db.QueryFirstOrDefault<Keep>(query, new { id, editedKeep });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool Delete(int id)
        {
            int success = _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
            return success > 0;
        }
    }
}