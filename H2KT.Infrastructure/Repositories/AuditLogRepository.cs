using Dapper;
using H2KT.Core.Interfaces.Repository;
using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Entity;
using H2KT.Core.Models.ServerObject;
using H2KT.Core.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace H2KT.Infrastructure.Repositories
{
    public class AuditLogRepository : BaseRepository<audit_log>, IAuditLogRepository
    {
        #region Constructors
        public AuditLogRepository(INhom2ServiceCollection serviceCollection) : base(serviceCollection)
        {

        }

        #endregion

        #region Methods

        
        /// Lấy danh sách lịch sử truy cập (lọc và phân trang)
        
        /// <param name="searchFilter"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        
        public async Task<FilterResult<AuditLog>> GetLogsByFilter(string userId, string searchFilter, 
            int? pageIndex, int? pageSize, DateTime? dateFrom, DateTime? dateTo)
        {
            // Thiết lập các tham số
            var parameters = new DynamicParameters();
            parameters.Add("$UserId", userId);
            parameters.Add("$SearchFilter", searchFilter);
            parameters.Add("$PageIndex", pageIndex);
            parameters.Add("$PageSize", pageSize);
            parameters.Add("$DateFrom", dateFrom);
            parameters.Add("$DateTo", dateTo);


            // Kết quả đầu ra
            parameters.Add("$TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("$TotalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);

            IEnumerable<audit_log> res; 
            using (var connection = await this.CreateConnectionAsync())
            {
                res = await connection.QueryAsync<audit_log>(
                    sql: $"Proc_Log_GetLogsFilterPaging",
                    param: parameters,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: ConnectionTimeout);
            }

            // Trả về kết quả filter
            return new FilterResult<AuditLog>
            {
                TotalPages = parameters.Get<int?>("$TotalPage"),
                TotalRecords = parameters.Get<int?>("$TotalRecord"),
                Data = res != null ? this.ServiceCollection.Mapper.Map<IEnumerable<AuditLog>>(res) : null
            };
        }
        #endregion

    }
}
