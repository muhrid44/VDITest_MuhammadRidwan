using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Net;
using System.Reflection;
using VDITest_MuhammadRidwan._1._Data.IRepository;
using VDITest_MuhammadRidwan._2._Services.IService;
using VDITest_MuhammadRidwan.Models;

namespace VDITest_MuhammadRidwan._2._Services.Service
{
    public class MemberService : IMemberService
    {
        IMemberRepository _memberRepository;
        IWebHostEnvironment _webHostEnvironment;

        public MemberService(IMemberRepository memberRepository, IWebHostEnvironment webHostEnvironment)
        {
            _memberRepository = memberRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<MemberModel>> GetAll()
        {
            return await _memberRepository.GetAll();
        }
        public async Task<MemberModel> GetById(int id)
        {
            var result =  await _memberRepository.GetById(id);
                
            return result;
        }
        public async Task Create(MemberModel model)
        {
            if (model.avatarFile != null)
            {
                string folderUrl = "avatar\\/";
                folderUrl += Guid.NewGuid().ToString() + model.avatarFile.FileName;
                model.AvatarUrl = "/" + folderUrl;
                model.FileName = model.avatarFile.FileName;
                string serverUrl = Path.Combine(_webHostEnvironment.WebRootPath, folderUrl);
                await model.avatarFile.CopyToAsync(new FileStream(serverUrl, FileMode.Create));
            }

            await _memberRepository.Create(model);
        }

        public async Task Update(MemberModel model)
        {
            if (model.avatarFile != null)
            {
                string folderUrl = "avatar\\/";
                folderUrl += Guid.NewGuid().ToString() + model.avatarFile.FileName;
                model.AvatarUrl = "/" + folderUrl;
                model.FileName = model.avatarFile.FileName;
                string serverUrl = Path.Combine(_webHostEnvironment.WebRootPath, folderUrl);
                await model.avatarFile.CopyToAsync(new FileStream(serverUrl, FileMode.Create));
                await _memberRepository.Update(model);

            }
            else
            {
                await _memberRepository.UpdateWithoutChangeAvatar(model);
            }

        }
        public async Task DeleteById(int id)
        {
            await _memberRepository.DeleteById(id);
        }
    }
}
