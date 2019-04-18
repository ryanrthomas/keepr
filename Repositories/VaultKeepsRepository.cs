using System;
using System.Collections.Generic;
using System.Data;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;
        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }
        public List<VaultKeep> GetAll()
        {
            return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps").AsList();
        }

        public VaultKeep GetById(int id)
        {
            return _db.QueryFirstOrDefault<VaultKeep>(@"
            SELECT * FROM  WHERE id = @id", new { id });
        }

        public VaultKeep CreateKeep(VaultKeep vaultKeep)
        {
            try
            {
                int id = _db.ExecuteScalar<int>(@"
                INSERT INTO  (name) VALUES (@name);
                SELECT LAST_INSERT_ID()", vaultKeep);
                vaultKeep.Id = id;
                return vaultKeep;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public VaultKeep EditVaultKeep(int id, VaultKeep editedVaultKeep)
        {
            try
            {
                string query = @"
                UPDATE  SET
                    name = @editedVaultKeep.Name,
                    teamId = @editedVaultKeep.VaultKeepId
                WHERE id = @id
                SELECT * FROM  WHERE id = @id;
                ";
                return _db.QueryFirstOrDefault<VaultKeep>(query, new { id, editedVaultKeep });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool Delete(int id)
        {
            int success = _db.Execute("DELETE FROM  WHERE id = @id", new { id });
            return success > 0;
        }
    }
}