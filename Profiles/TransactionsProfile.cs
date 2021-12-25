using AutoMapper;
using LauToken.DTO;
using LauToken;
using LauToken.Models;

namespace LauToken.Profiles
{

    public class TransactionsProfile : Profile
    {

        public TransactionsProfile()
        {
            CreateMap<JoinedTransactionSource, TransactionReadDTO>();
            CreateMap<TransactionCreateDTO, Transaction>();
        }
    }
}