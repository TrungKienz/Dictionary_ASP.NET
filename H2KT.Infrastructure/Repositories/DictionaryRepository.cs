using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Entity;
using H2KT.Core.Models.ServerObject;
using System;
using System.Data;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Repository
{

    public interface DictionaryRepository: IBaseRepository<dictionary>
    {
        /// <summary>
        /// Thực hiện clone dữ liệu từ điển (có xóa dữ liệu từ điển đích)
        /// </summary>
        /// <param name="sourceDictionaryId"></param>
        /// <param name="destDictionaryId"></param>
        /// <returns></returns>
        Task<bool> CloneDictionaryData(Guid sourceDictionaryId, Guid destDictionaryId, IDbTransaction transaction = null);

        /// <summary>
        /// Thực hiện xóa dữ liệu trong 1 từ điển
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        Task<bool> DeleteDictionaryData(Guid dictionaryId, IDbTransaction transaction = null);

        /// <summary>
        /// Thực hiện copy dữ liệu từ từ điển nguồn và gộp vào dữ liệu ở từ điển đích
        /// </summary>
        /// <param name="sourceDictionaryId"></param>
        /// <param name="destDictionaryId"></param>
        /// <param name="isDeleteData"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<bool> TransferDictionaryData(Guid sourceDictionaryId, Guid destDictionaryId, bool isDeleteData, IDbTransaction transaction = null);

        /// <summary>
        /// Thực hiện lấy số lượng concept, example trong 1 từ điển
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        Task<DictionaryNumberRecord> GetNumberRecord(Guid dictionaryId);
    }
}
