﻿using Camunda.Api.Client.ProcessDefinition;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.UserTask
{
    internal interface IUserTaskRestService
    {
        [Get("/task/{id}")]
        Task<UserTaskInfo> Get(string id, CancellationToken cancellationToken = default);

        [Post("/task")]
        Task<List<UserTaskInfo>> GetList([Body] TaskQuery query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Post("/task/count")]
        Task<CountResult> GetListCount([Body] TaskQuery query, CancellationToken cancellationToken = default);

        [Get("/task/{id}/form")]
        Task<FormInfo> GetForm(string id, CancellationToken cancellationToken = default);

        [Post("/task/{id}/complete")]
        Task CompleteTask(string id, [Body] CompleteTask completeTask, CancellationToken cancellationToken = default);

        [Post("/task/{id}/complete")]
        Task<Dictionary<string, VariableValue>> CompleteTaskAndFetchVariables(string id, [Body] CompleteTask completeTask, CancellationToken cancellationToken = default);

        [Post("/task/{id}/resolve")]
        Task ResolveTask(string id, [Body] ResolveTask resolveTask, CancellationToken cancellationToken = default);

        [Post("/task/{id}/submit-form")]
        Task SubmitFormTask(string id, [Body] CompleteTask completeTask, CancellationToken cancellationToken = default);

        [Post("/task/{id}/submit-form")]
        Task<Dictionary<string, VariableValue>> SubmitFormTaskAndFetchVariables(string id, [Body] CompleteTask completeTask, CancellationToken cancellationToken = default);

        [Get("/task/{id}/rendered-form")]
        Task<string> GetRenderedForm(string id, CancellationToken cancellationToken = default);

        [Post("/task/{id}/claim")]
        Task ClaimTask(string id, [Body] UserInfo user, CancellationToken cancellationToken = default);

        [Post("/task/{id}/assignee")]
        Task SetAssignee(string id, [Body] UserInfo user, CancellationToken cancellationToken = default);

        [Post("/task/{id}/unclaim")]
        Task UnclaimTask(string id, CancellationToken cancellationToken = default);

        [Post("/task/{id}/delegate")]
        Task DelegateTask(string id, [Body] UserInfo user, CancellationToken cancellationToken = default);

        [Delete("/task/{id}")]
        Task DeleteTask(string id, CancellationToken cancellationToken = default);

        [Get("/task/{id}/form-variables")]
        Task<Dictionary<string, VariableValue>> GetFormVariables(string id, string variableNames, bool deserializeValues = true, CancellationToken cancellationToken = default);

        [Post("/task/create")]
        Task CreateTask([Body] UserTask task, CancellationToken cancellationToken = default);

        [Put("/task/{id}")]
        Task UpdateTask(string id, [Body] UserTask task, CancellationToken cancellationToken = default);

        [Get("/task/{id}/comment")]
        Task<List<CommentInfo>> GetComments(string id, CancellationToken cancellationToken = default);

        [Get("/task/{id}/comment/{commentId}")]
        Task<CommentInfo> GetComment(string id, string commentId, CancellationToken cancellationToken = default);

        [Post("/task/{id}/comment/create")]
        Task<CommentInfo> CreateComment(string id, [Body] Comment comment, CancellationToken cancellationToken = default);


        [Get("/task/{id}/attachment")]
        Task<List<AttachmentInfo>> GetAttachments(string id, CancellationToken cancellationToken = default);

        [Get("/task/{id}/attachment/{attachmentId}")]
        Task<AttachmentInfo> GetAttachment(string id, string attachmentId, CancellationToken cancellationToken = default);

        [Get("/task/{id}/attachment/{attachmentId}/data")]
        Task<HttpResponseMessage> GetAttachmentData(string id, string attachmentId, CancellationToken cancellationToken = default);

        [Delete("/task/{id}/attachment/{attachmentId}")]
        Task DeleteAttachment(string id, string attachmentId, CancellationToken cancellationToken = default);

        [Post("/task/{id}/attachment/create"), Multipart]
        Task<AttachmentInfo> AddAttachment(string id, 
            PlainTextContent attachmentName, PlainTextContent attachmentDescription, PlainTextContent attachmentType, PlainTextContent url,
            AttachmentContent content, CancellationToken cancellationToken = default);

        #region Identity Link

        [Get("/task/{id}/identity-links")]
        Task<List<IdentityLink>> GetIdentityLinks(string id, string type, CancellationToken cancellationToken = default);

        [Post("/task/{id}/identity-links")]
        Task AddIdentityLink(string id, [Body] IdentityLink identityLink, CancellationToken cancellationToken = default);

        [Post("/task/{id}/identity-links/delete")]
        Task DeleteIdentityLink(string id, [Body] IdentityLink identityLink, CancellationToken cancellationToken = default);

        #endregion

        #region Variables

        [Delete("/task/{id}/variables/{varName}")]
        Task DeleteVariable(string id, string varName, CancellationToken cancellationToken = default);

        [Get("/task/{id}/variables/{varName}")]
        Task<VariableValue> GetVariable(string id, string varName, bool deserializeValue = true, CancellationToken cancellationToken = default);

        [Get("/task/{id}/variables")]
        Task<Dictionary<string, VariableValue>> GetVariables(string id, bool deserializeValues = true, CancellationToken cancellationToken = default);

        [Get("/task/{id}/variables/{varName}/data")]
        Task<HttpResponseMessage> GetBinaryVariable(string id, string varName, CancellationToken cancellationToken = default);

        [Post("/task/{id}/variables/{varName}/data"), Multipart]
        Task SetBinaryVariable(string id, string varName, BinaryDataContent data, ValueTypeContent valueType, CancellationToken cancellationToken = default);

        [Post("/task/{id}/variables")]
        Task ModifyVariables(string id, PatchVariables patch, CancellationToken cancellationToken = default);

        [Put("/task/{id}/variables/{varName}")]
        Task PutVariable(string id, string varName, [Body] VariableValue variable, CancellationToken cancellationToken = default);

        #endregion

        #region Local Variables

        [Delete("/task/{id}/localVariables/{varName}")]
        Task DeleteLocalVariable(string id, string varName, CancellationToken cancellationToken = default);

        [Get("/task/{id}/localVariables/{varName}")]
        Task<VariableValue> GetLocalVariable(string id, string varName, bool deserializeValue = true, CancellationToken cancellationToken = default);

        [Get("/task/{id}/localVariables")]
        Task<Dictionary<string, VariableValue>> GetLocalVariables(string id, bool deserializeValues = true, CancellationToken cancellationToken = default);

        [Get("/task/{id}/localVariables/{varName}/data")]
        Task<HttpResponseMessage> GetBinaryLocalVariable(string id, string varName, CancellationToken cancellationToken = default);

        [Post("/task/{id}/localVariables/{varName}/data"), Multipart]
        Task SetBinaryLocalVariable(string id, string varName, BinaryDataContent data, ValueTypeContent valueType, CancellationToken cancellationToken = default);

        [Post("/task/{id}/localVariables")]
        Task ModifyLocalVariables(string id, PatchVariables patch, CancellationToken cancellationToken = default);

        [Put("/task/{id}/localVariables/{varName}")]
        Task PutLocalVariable(string id, string varName, [Body] VariableValue variable, CancellationToken cancellationToken = default);

        #endregion

        #region Report

        [Get("/task/report/candidate-group-count")]
        Task<List<TaskCountByCandidateGroupResult>> GetTaskCountByCandidateGroup(CancellationToken cancellationToken = default);

        #endregion
    }
}
