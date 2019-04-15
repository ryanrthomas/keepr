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
        public List<Keep> GetAll()
        {
            return _db.Query<Keep>("SELECT * FROM keeps").AsList();
        }

        public Keep GetById(int id)
        {
            return _db.QueryFirstOrDefault<Keep>(@"
            SELECT * FROM keeps WHERE id = @id", new { id });
        }

        public Keep CreateKeep(Keep keep)
        {
            try
            {
                int id = _db.ExecuteScalar<int>(@"
                INSERT INTO keeps (name) VALUES (@name);
                SELECT LAST_INSERT_ID()", keep);
                keep.Id = id;
                return keep;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public Keep EditKeep(int id, Keep editedKeep, string userId)
        {
            try
            {
                string query = @"
                UPDATE keeps SET
                    name = @editedKeep.Name,
                    keepId = @editedKeep.KeepId
                WHERE id = @id
                SELECT * FROM keeps WHERE id = @id AND userId = @userId;
                ";
                return _db.QueryFirstOrDefault<Keep>(query, new { id, editedKeep, userId });
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