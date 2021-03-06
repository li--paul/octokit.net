﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Octokit
{
    /// <summary>
    /// A client for GitHub's Repository Deployment Statuses API.
    /// Gets and creates Deployment Statuses.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/repos/deployments/">Repository Deployment Statuses API documentation</a> for more information.
    /// </remarks>
    public class DeploymentStatusClient : ApiClient, IDeploymentStatusClient
    {
        public DeploymentStatusClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
        }

        /// <summary>
        /// Gets all the statuses for the given deployment. Any user with pull access to a repository can
        /// view deployments.
        /// </summary>
        /// <remarks>
        /// http://developer.github.com/v3/repos/deployments/#list-deployment-statuses
        /// </remarks>
        /// <param name="owner">The owner of the repository.</param>
        /// <param name="name">The name of the repository.</param>
        /// <param name="deploymentId">The id of the deployment.</param>
        public Task<IReadOnlyList<DeploymentStatus>> GetAll(string owner, string name, int deploymentId)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");

            return GetAll(owner, name, deploymentId, ApiOptions.None);
        }

        /// <summary>
        /// Gets all the statuses for the given deployment. Any user with pull access to a repository can
        /// view deployments.
        /// </summary>
        /// <remarks>
        /// http://developer.github.com/v3/repos/deployments/#list-deployment-statuses
        /// </remarks>
        /// <param name="repositoryId">The Id of the repository.</param>
        /// <param name="deploymentId">The id of the deployment.</param>
        public Task<IReadOnlyList<DeploymentStatus>> GetAll(int repositoryId, int deploymentId)
        {
            return GetAll(repositoryId, deploymentId, ApiOptions.None);
        }

        /// <summary>
        /// Gets all the statuses for the given deployment. Any user with pull access to a repository can
        /// view deployments.
        /// </summary>
        /// <remarks>
        /// http://developer.github.com/v3/repos/deployments/#list-deployment-statuses
        /// </remarks>
        /// <param name="owner">The owner of the repository.</param>
        /// <param name="name">The name of the repository.</param>
        /// <param name="deploymentId">The id of the deployment.</param>
        /// <param name="options">Options for changing the API response</param>
        public Task<IReadOnlyList<DeploymentStatus>> GetAll(string owner, string name, int deploymentId, ApiOptions options)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");
            Ensure.ArgumentNotNull(options, "options");

            return ApiConnection.GetAll<DeploymentStatus>(ApiUrls.DeploymentStatuses(owner, name, deploymentId), 
                                                          null,
                                                          AcceptHeaders.DeploymentApiPreview,
                                                          options);
        }

        /// <summary>
        /// Gets all the statuses for the given deployment. Any user with pull access to a repository can
        /// view deployments.
        /// </summary>
        /// <remarks>
        /// http://developer.github.com/v3/repos/deployments/#list-deployment-statuses
        /// </remarks>
        /// <param name="repositoryId">The Id of the repository.</param>
        /// <param name="deploymentId">The id of the deployment.</param>
        /// <param name="options">Options for changing the API response</param>
        public Task<IReadOnlyList<DeploymentStatus>> GetAll(int repositoryId, int deploymentId, ApiOptions options)
        {
            Ensure.ArgumentNotNull(options, "options");

            return ApiConnection.GetAll<DeploymentStatus>(ApiUrls.DeploymentStatuses(repositoryId, deploymentId), options);
        }

        /// <summary>
        /// Creates a new status for the given deployment. Users with push access can create deployment
        /// statuses for a given deployment.
        /// </summary>
        /// <remarks>
        /// http://developer.github.com/v3/repos/deployments/#create-a-deployment-status
        /// </remarks>
        /// <param name="owner">The owner of the repository.</param>
        /// <param name="name">The name of the repository.</param>
        /// <param name="deploymentId">The id of the deployment.</param>
        /// <param name="newDeploymentStatus">The new deployment status to create.</param>
        public Task<DeploymentStatus> Create(string owner, string name, int deploymentId, NewDeploymentStatus newDeploymentStatus)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");
            Ensure.ArgumentNotNull(newDeploymentStatus, "newDeploymentStatus");

            return ApiConnection.Post<DeploymentStatus>(ApiUrls.DeploymentStatuses(owner, name, deploymentId),
                                                        newDeploymentStatus,
                                                        AcceptHeaders.DeploymentApiPreview);
        }

        /// <summary>
        /// Creates a new status for the given deployment. Users with push access can create deployment
        /// statuses for a given deployment.
        /// </summary>
        /// <remarks>
        /// http://developer.github.com/v3/repos/deployments/#create-a-deployment-status
        /// </remarks>
        /// <param name="repositoryId">The Id of the repository.</param>
        /// <param name="deploymentId">The id of the deployment.</param>
        /// <param name="newDeploymentStatus">The new deployment status to create.</param>
        public Task<DeploymentStatus> Create(int repositoryId, int deploymentId, NewDeploymentStatus newDeploymentStatus)
        {
            Ensure.ArgumentNotNull(newDeploymentStatus, "newDeploymentStatus");

            return ApiConnection.Post<DeploymentStatus>(ApiUrls.DeploymentStatuses(repositoryId, deploymentId),
                                                        newDeploymentStatus);
        }
    }
}
