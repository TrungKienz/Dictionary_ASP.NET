﻿using Dapper;
using H2KT.Core.Interfaces.Repository;
using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Entity;
using H2KT.Core.Utils;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace H2KT.Infrastructure.Repositories
{
    public class ConceptRepository : BaseRepository<concept>, IConceptRepository
    {
        #region Constructors
        public ConceptRepository(INhom2ServiceCollection serviceCollection) : base(serviceCollection)
        {

        }

        #endregion

        #region Methods
        
        /// Thực hiện lấy danh sách concept trong từ điển mà khớp với xâu tìm kiếm của người dùng
        
        
        /// <param name="isSearchSoundex"></param>
        
        public async Task<List<Concept>> SearchConcept(string searchKey, string dictionaryId, bool? isSearchSoundex)
        {
            using (var connection = await this.CreateConnectionAsync())
            {
                var parameters = new DynamicParameters();
                parameters.Add("$SearchKey", searchKey);
                parameters.Add("$DictionaryId", dictionaryId);
                parameters.Add("$IsSearchSoundex", isSearchSoundex);

                var res = await connection.QueryAsync<concept>(
                    sql: "Proc_Concept_SearchConcept",
                    param: parameters,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: ConnectionTimeout);

                if(res != null)
                {
                    return this.ServiceCollection.Mapper.Map<List<Concept>>(res);
                }

                return new List<Concept>();
            }
        }
        #endregion

    }
}
