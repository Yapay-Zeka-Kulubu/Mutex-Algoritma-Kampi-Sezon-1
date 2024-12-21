using libraryApp.backend.Entity;

namespace libraryApp.backend.Repository.Abstract
{
    public interface ILoanRequestRepository
    {
        IQueryable<LoanRequest> GetAllLoanRequests {  get; }
        Task<LoanRequest> GetLoanRequestById(int id);
        Task AddLoanRequest(LoanRequest loanRequest);
        Task UpdateLoanRequest(LoanRequest loanRequest);
        Task DeleteLoanRequest(int id);
        Task<LoanRequest?> GetLoanRequestByUserAndBook(int userId, int bookId);
    }
}
