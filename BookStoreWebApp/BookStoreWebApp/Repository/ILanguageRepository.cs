using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreWebApp.Model;

namespace BookStoreWebApp.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}