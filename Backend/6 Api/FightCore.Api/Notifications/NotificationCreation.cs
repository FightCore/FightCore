using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Notifications;
using FightCore.Api.Resources.Notifications;
using FightCore.Models;
using FightCore.Repositories.Patterns;
using FightCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FightCore.Api.Notifications
{
    /// <summary>
    /// Helper class to create and push notifications
    /// </summary>
    public class NotificationCreation
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkAsync _unitOfWork;

        public NotificationCreation(IUnitOfWorkAsync unitOfWork, INotificationService notificationService, IMapper mapper, IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        /// <summary>
        /// Creates and broadcasts a single notification
        /// </summary>
        /// <param name="userId">User this notification is for</param>
        /// <param name="title">Title of the notification</param>
        /// <param name="content">Content of the notification</param>
        /// <param name="routeLink">Relative url that this notification should lead to</param>
        /// <param name="isImportant">True if this notification is important</param>
        /// <returns>Notification result if successful, otherwise null</returns>
        public async Task<NotificationResultResource> CreateNotification(int userId, string title, string content, string routeLink, bool isImportant)
        {
            NotificationResource notifInput = new NotificationResource
            {
                UserId = userId,
                Title = title,
                Content = content,
                RouteLink = routeLink,
                IsImportant = isImportant
            };
            return await CreateNotification(notifInput);
        }

        /// <summary>
        /// Creates and broadcasts a single notification
        /// </summary>
        /// <param name="notifInput">Notification to create and broadcast</param>
        /// <returns>Notification result if successful, otherwise null</returns>
        public async Task<NotificationResultResource> CreateNotification(NotificationResource notifInput)
        {
            // Store the notification
            var notifResult = _mapper.Map<Notification>(notifInput);
            notifResult.CreatedDate = DateTime.Now;
            notifResult = await _notificationService.InsertAsync(notifResult);
            await _unitOfWork.SaveChangesAsync();

            // If succeeded in creating notification, broadcast it
            if (notifResult.Id > 0)
            {
                // Send out the notification
                var notifBroadcast = _mapper.Map<NotificationResultResource>(notifResult);
                await _hubContext.Clients.User(notifResult.UserId.ToString()).BroadcastNotification(notifBroadcast);

                return notifBroadcast;
            }
            // Otherwise this is a bad request
            else
            {
                return null;
            }
        }
    }
}
