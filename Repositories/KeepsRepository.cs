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
                    INSERT INTO keeps (id, name, description, img, userId, isPrivate, views, shares, keeps)
                    VALUES (@Id, @Name, @Description, @Img, @UserId, @IsPrivate, @Views, @Shares, @Keeps);
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

        public Keep EditKeep(Keep editedKeep)
        {
            try
            {
                string query = @"
                UPDATE keeps SET
                    name = @Name, views = @Views, shares = @Shares, keeps = @Keeps
                WHERE id = @id;
                SELECT * FROM keeps WHERE id = @Id AND userId = @UserId;
                ";
                _db.QueryFirstOrDefault<Keep>(query, editedKeep);
                return editedKeep;

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