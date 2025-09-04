using ERMS_Project.DTOs;
using ERMS_Project.DTOs.Employee;

namespace ERMS_Project.Interfaces
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<GetProjectsDTO>> GetProjects();
        public Task<IEnumerable<GetProjectsDTO>> GetProjectsById(int accountId);
        public Task<IEnumerable<CountOfProjectDTO>> GetProjectCount();
        public Task<ResponseClass> DeleteProjects(ProjectDTO project);
        public Task<ProjectDTO> GetProject(int ProjectId);
        public Task<ResponseClass> AddProject(ProjectDTO projects);
        public Task<ResponseClass> UpdateProject(ProjectDTO projects, int projectId);
    }
}
