using Dapper;
using H2KT.Core.Interfaces.Repository;
using H2KT.Core.Models.Entity;
using H2KT.Core.Models.ServerObject;
using H2KT.Core.Utils;
using System;
using System.Data;
using System.Threading.Tasks;

namespace H2KT.Infrastructure.Repositories
{
    public class DictionaryRepository : BaseRepository<dictionary>, IDictionaryRepository
    {
        #region Constructors
        public DictionaryRepository(INhom2ServiceCollection serviceCollection) : base(serviceCollection)
        {

        }

        #endregion

        #region Methods
        
        /// Thực hiện clone dữ liệu từ điển (có xóa dữ liệu từ điển đích)
        
        /// <param name="sourceDictionaryId"></param>
        /// <param name="destDictionaryId"></param>
        
        public async Task<bool> CloneDictionaryData(Guid sourceDictionaryId, Guid destDictionaryId, IDbTransaction transaction = null)
        {
            var parameters = new DynamicParameters();
            parameters.Add("$SourceDictionaryId", sourceDictionaryId);
            parameters.Add("$DestDictionaryId", destDictionaryId);

            var storeName = "Proc_Dictionary_CloneDictionaryData";
            if (transaction != null)
            {
                _ = await transaction.Connection.ExecuteAsync(
                    sql: storeName,
                    param: parameters,
                    commandType: CommandType.StoredProcedure,
                    transaction: transaction,
                    commandTimeout: ConnectionTimeout);
                return true;
            } 

            using (var connection = await this.CreateConnectionAsync())
            {
                _ = await connection.ExecuteAsync(
                    sql: storeName,
                    param: parameters,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: ConnectionTimeout);
                return true;
            }
        }

        
        /// Thực hiện xóa dữ liệu trong 1 từ điển
public async Task<bool> DeleteDictionaryData(Guid dictionaryId, IDbTransaction transaction = null)
        {
            var parameters = new DynamicParameters();
            parameters.Add("$DictionaryId", dictionaryId);

            var storeName = "Proc_Dictionary_DeleteDictionaryData";
            if (transaction != null)
            {
                _ = await transaction.Connection.ExecuteAsync(
                    sql: storeName,
                    param: parameters,
                    commandType: CommandType.StoredProcedure,
                    transaction: transaction,
                    commandTimeout: ConnectionTimeout);
                return true;
            }

            using (var connection = await this.CreateConnectionAsync())
            {
                _ = await connection.ExecuteAsync(
                    sql: storeName,
                    param: parameters,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: ConnectionTimeout);
                return true;
            }
        }

        

        
        public async Task<bool> TransferDictionaryData(Guid sourceDictionaryId, Guid destDictionaryId, bool isDeleteData, IDbTransaction transaction = null)
        {
            var parameters = new DynamicParameters();
            parameters.Add("$SourceDictionaryId", sourceDictionaryId);
            parameters.Add("$DestDictionaryId", destDictionaryId);
            parameters.Add("$IsDeleteData", isDeleteData);

            var storeName = "Proc_Dictionary_TransferDictionaryData";
            if (transaction != null)
            {
                _ = await transaction.Connection.ExecuteAsync(
                    sql: storeName,
                    param: parameters,
                    commandType: CommandType.StoredProcedure,
                    transaction: transaction,
                    commandTimeout: ConnectionTimeout);
                return true;
            }

            using (var connection = await this.CreateConnectionAsync())
            {
                _ = await connection.ExecuteAsync(
                    sql: storeName,
                    param: parameters,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: ConnectionTimeout);
                return true;
            }
        }

        
        /// Thực hiện lấy số lượng concept, example trong 1 từ điển
public async Task<DictionaryNumberRecord> GetNumberRecord(Guid dictionaryId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("$DictionaryId", dictionaryId);
            // Kết quả đầu ra
            parameters.Add("$NumberConcept", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("$NumberExample", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var storeName = "Proc_Dictionary_GetNumberRecord";
            using (var connection = await this.CreateConnectionAsync())
            {
                _ = await connection.ExecuteAsync(
                    sql: storeName,
                    param: parameters,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: ConnectionTimeout);
            }

            // Trả về kết quả filter
            return new DictionaryNumberRecord
            {
                NumberConcept = parameters.Get<int?>("$NumberConcept"),
                NumberExample = parameters.Get<int?>("$NumberExample"),
            };
        }
        #endregion
    }
}
