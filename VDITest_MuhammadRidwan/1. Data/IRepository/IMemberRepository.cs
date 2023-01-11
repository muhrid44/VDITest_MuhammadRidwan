using VDITest_MuhammadRidwan.Models;

namespace VDITest_MuhammadRidwan._1._Data.IRepository
{
    public interface IMemberRepository
    {
        Task<List<MemberModel>> GetAll();
        Task<MemberModel> GetById(int id);
        Task Create(MemberModel model);
        Task Update(MemberModel model);
        Task DeleteById(int id);
    }
}
