// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Internal.Resources
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Rest;
    using Rest.Azure.OData;
    using Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for PolicyDefinitionsOperations.
    /// </summary>
    public static partial class PolicyDefinitionsOperationsExtensions
    {
            /// <summary>
            /// Creates or updates a policy definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='policyDefinitionName'>
            /// The name of the policy definition to create.
            /// </param>
            /// <param name='parameters'>
            /// The policy definition properties.
            /// </param>
            public static PolicyDefinition CreateOrUpdate(this IPolicyDefinitionsOperations operations, string policyDefinitionName, PolicyDefinition parameters)
            {
                return Task.Factory.StartNew(s => ((IPolicyDefinitionsOperations)s).CreateOrUpdateAsync(policyDefinitionName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates a policy definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='policyDefinitionName'>
            /// The name of the policy definition to create.
            /// </param>
            /// <param name='parameters'>
            /// The policy definition properties.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PolicyDefinition> CreateOrUpdateAsync(this IPolicyDefinitionsOperations operations, string policyDefinitionName, PolicyDefinition parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(policyDefinitionName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes a policy definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='policyDefinitionName'>
            /// The name of the policy definition to delete.
            /// </param>
            public static void Delete(this IPolicyDefinitionsOperations operations, string policyDefinitionName)
            {
                Task.Factory.StartNew(s => ((IPolicyDefinitionsOperations)s).DeleteAsync(policyDefinitionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes a policy definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='policyDefinitionName'>
            /// The name of the policy definition to delete.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IPolicyDefinitionsOperations operations, string policyDefinitionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(policyDefinitionName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Gets the policy definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='policyDefinitionName'>
            /// The name of the policy definition to get.
            /// </param>
            public static PolicyDefinition Get(this IPolicyDefinitionsOperations operations, string policyDefinitionName)
            {
                return Task.Factory.StartNew(s => ((IPolicyDefinitionsOperations)s).GetAsync(policyDefinitionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the policy definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='policyDefinitionName'>
            /// The name of the policy definition to get.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PolicyDefinition> GetAsync(this IPolicyDefinitionsOperations operations, string policyDefinitionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(policyDefinitionName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets all the policy definitions for a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            public static IPage<PolicyDefinition> List(this IPolicyDefinitionsOperations operations, ODataQuery<PolicyDefinition> odataQuery = default(ODataQuery<PolicyDefinition>))
            {
                return Task.Factory.StartNew(s => ((IPolicyDefinitionsOperations)s).ListAsync(odataQuery), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the policy definitions for a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<PolicyDefinition>> ListAsync(this IPolicyDefinitionsOperations operations, ODataQuery<PolicyDefinition> odataQuery = default(ODataQuery<PolicyDefinition>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(odataQuery, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets all the policy definitions for a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<PolicyDefinition> ListNext(this IPolicyDefinitionsOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IPolicyDefinitionsOperations)s).ListNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the policy definitions for a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<PolicyDefinition>> ListNextAsync(this IPolicyDefinitionsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
