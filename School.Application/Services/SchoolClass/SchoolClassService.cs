using AutoMapper;
using Cabanoss.Core.Repositories.Impl;
using School.Application.Model.SchoolClassModels;

namespace School.Application.Services.SchoolClass
{
    public class SchoolClassService : ISchoolClassService
    {
        private IBaseRepository<WebAPI.Domain.Entities.SchoolClass> _baseRepository;
        private IMapper _mapper;

        public SchoolClassService(IBaseRepository<WebAPI.Domain.Entities.SchoolClass> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        async Task<WebAPI.Domain.Entities.SchoolClass> GetClass(string classId)
        {
            var student = await _baseRepository.ReadAsync(id => id.Id.ToString() == classId);
            return student;
        }

        public async Task CreateAsync(SchoolClassDto classDto)
        {
            var schoolClass = _mapper.Map<WebAPI.Domain.Entities.SchoolClass>(classDto);
            await _baseRepository.CreateAsync(schoolClass);
        }
        public async Task<WebAPI.Domain.Entities.SchoolClass> ReadAsync(string classId)
        {
            return await GetClass(classId);
        }

        public async Task UpdateAsync(SchoolClassDto classDto, string classId)
        {
            var classToUpdate = await GetClass(classId);
            classToUpdate.ClassName = classDto.ClassName;
            await _baseRepository.UpdateAsync(classToUpdate);
        }

        public async Task DeleteAsync(string classId)
        {
            await _baseRepository.DeleteAsync(await GetClass(classId));
        }

        public async Task<List<WebAPI.Domain.Entities.SchoolClass>> ReadAllAsync()
        {
            return await _baseRepository.ReadAllAsync();

        }
    }
}
