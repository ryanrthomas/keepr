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
            return _db.Query<VaultKeep>("SELECT * FROM vaultKeeps").AsList();
        }

        public VaultKeep GetById(int vaultId, string userId)
        {
            return _db.QueryFirstOrDefault<VaultKeep>(@"
             SELECT * FROM vaultkeeps vk
             INNER JOIN keeps k ON k.id = vk.keepId 
             WHERE (vaultId = @vaultId AND vk.userId = @userId)
             ", new {vaultId, userId}); 

        }

        public VaultKeep CreateVaultKeep(VaultKeep vaultKeep)
        {
            try
            {
                int id = _db.ExecuteScalar<int>(@"
                    INSERT INTO vaultKeeps(vaultId, keepId, userId)
                    VALUES(@VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID()
                ", vaultKeep);
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
                    vaultKeepId = @editedVaultKeep.VaultKeepId
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