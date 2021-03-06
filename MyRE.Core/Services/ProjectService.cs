﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyRE.Core.Models.Data;
using MyRE.Core.Repositories;

namespace MyRE.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectSourceMappingService _projectSourceMapping;
        private readonly ISmartAppService _smartApp;

        public ProjectService(IProjectRepository projectRepository, IProjectSourceMappingService projectSourceMapping, ISmartAppService smartApp)
        {
            _projectRepository = projectRepository;
            _projectSourceMapping = projectSourceMapping;
            _smartApp = smartApp;
        }

        public Task<IEnumerable<Project>> GetUserProjectsAsync(string userId) => _projectRepository.GetUserProjectsAsync(userId);
        public async Task<Project> GetByIdAsync(Guid projectId)
        {
            var proj = await _projectRepository.GetByIdAsync(projectId);
            return proj;
        }

        public async Task<Project> CreateAsync(string name, string description, Guid instanceId)
        {
            var createdLocalProject = await _projectRepository.CreateAsync(name, description, instanceId);
            var instanceProjectUpsertResult = await _smartApp.UpsertProjectAsync(createdLocalProject);
            return createdLocalProject;
        }

        public async Task DeleteAsync(Guid projectId)
        {
            await _projectRepository.DeleteAsync(projectId);
        }

        public async Task<Project> UpdateAsync(Project entity)
        {
            var localPersistResult = await _projectRepository.UpdateAsync(entity);
            var instanceProjectUpsertResult = await _smartApp.UpsertProjectAsync(localPersistResult);

            return localPersistResult;
        }

        public async Task<object> ExecuteAsync(Project entity)
        {
            var result = await _smartApp.ExecuteProjectAsync(entity);
            return result;
        }

        public Task<ProjectSource> GetSource(Guid projectId)
        {
            return _projectRepository.GetSourceById(projectId);
        }
    }
}