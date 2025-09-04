using System.Data;
using Dapper;
using ERMS_Project.Constants;
using ERMS_Project.DTOs;
using ERMS_Project.DTOs.Employee;
using ERMS_Project.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERMS_Project.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IDapperContext _context;

        public ProjectRepository(IDapperContext context)
        {
            _context = context;
        }
        public Task<ProjectDTO> GetProject(int ProjectId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CountOfProjectDTO>> GetProjectCount()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetProjectsDTO>> GetProjects()
        {
            var parameters = new DynamicParameters();
            parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_GET);

            using (var connection = _context.CreateConnection())
            {
                var projects = await connection.QueryAsync<GetProjectsDTO>(APIConstants.PROJECT_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
                return projects.ToList();
            }
        }

        public Task<IEnumerable<GetProjectsDTO>> GetProjectsById(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseClass> AddProject(ProjectDTO projects)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseClass> DeleteProjects(ProjectDTO project)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseClass> UpdateProject(ProjectDTO projects, int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
