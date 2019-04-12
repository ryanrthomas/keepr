using System;
using System.Collections.Generic;
using System.Data;
using keepr.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Vault> GetAll()
        {
            return _db.Query<Vault>("SELECT * FROM vaults");
        }

        public Vault GetById(int Id)
        {
            return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @Id", new { Id });
        }

        public Vault CreateVault(Vault vault)
        {
            try
            {
                int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaults (name, vaultId)
                    VALUES (@Name, @VaultId);
                    SELECT LAST_INSERT_ID()
                ", vault);
                vault.Id = id;
                return vault;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Vault EditVault(int id, Vault editedVault)
        {
            try
            {
                string query = @"
                UPDATE vaults SET
                    name = @editedVault.Name,
                    vaultId = @editedVault.VaultId
                WHERE id = @id
                SELECT * FROM vaults WHERE id = @id;
                ";
                return _db.QueryFirstOrDefault<Vault>(query, new { id, editedVault });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<Keep> GetKeeps(int id)
        {
            return _db.Query<Keep>("SELECT * FROM keeps WHERE vaultId = @id", new { id });
        }

        public bool Delete(int id)
        {
            int success = _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
            return success > 0;
        }
    }
}