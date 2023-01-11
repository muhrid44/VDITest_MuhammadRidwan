using VDITest_MuhammadRidwan.Models;

namespace VDITest_MuhammadRidwan._2._Services.IService
{
    public interface IMemberService
    {
        Task<List<MemberModel>> GetAll();
        Task<MemberModel> GetById(int id);
        Task Create(MemberModel model);
        Task Update(MemberModel model);
        Task DeleteById(int id);
    }
}
