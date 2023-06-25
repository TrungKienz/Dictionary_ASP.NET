﻿using Dapper;
using H2KT.Core.Interfaces.Repository;
using H2KT.Core.Models.Entity;
using H2KT.Core.Utils;
using System.Data;
using System.Threading.Tasks;

namespace H2KT.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<user>, IUserRepository
    {
        #region Constructors
        public UserRepository(INhom2ServiceCollection serviceCollection) : base(serviceCollection)
        {

        }

        #endregion

        #region Methods

        
        /// Thực hiện khởi tạo dữ liệu tài khoản khi tài khoản được kích hoạt
        
        /// <param name="userId"></param>
        
        public async Task<bool> CreateActivatedAccountData(string userId)
        {
            using (var connection = await this.CreateConnectionAsync())
            {
                var parameters = new DynamicParameters();
                parameters.Add("$UserId", userId);
                var res = await connection.ExecuteAsync(
                    sql: $"Proc_Account_CreateActivatedAccountData",
                    param: parameters,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: ConnectionTimeout);
                return true;
            }
        }
        #endregion

    }
}
