using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using AutoMapper;

using FightCore.Api.Notifications;
using FightCore.Api.Resources.Notifications;
using FightCore.Models;
using FightCore.Repositories.Patterns;
using FightCore.Resources.Controllers.Shared;
using FightCore.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace FightCore.Api.Controllers.V1
{
    /// <inheritdoc />
    /// <summary>
    /// Handles notification interactions for a user
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        /// <inheritdoc />
        public NotificationsController(IConfiguration configuration, IUnitOfWorkAsync unitOfWork, INotificationService notificationService, IMapper mapper, IHubContext<NotifyHub, ITypedHubClient> hubContext, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
            _mapper = mapper;
            _hubContext = hubContext;
            _userManager = userManager;
        }

        /// <summary>
        /// Gets notifications for current user, one page at a time, 20 notifications per page
        /// </summary>
        /// <param name="pageNumber">Page number to get. 1 is first page</param>
        /// <returns>
        /// 200 with a page of notifications
        /// 400 if page number is out of range (less than 1 or greater than total number of pages)
        /// </returns>
        [HttpGet("{pageNumber}")]
        [Authorize]
        public async Task<IActionResult> Get(int pageNumber = 1)
        {
            NotificationsResource result;

            // Quick check on page number, must start at 1
            if (pageNumber < 1)
            {
                return BadRequest("Page number must start at 1");
            }

            // Get current user's id
            int.TryParse(_userManager.GetUserId(User), out var userId);

            // Get count of notifications for user
            var totalNotifications = await _notificationService.GetNotificationsCountAsync(userId);
            if (totalNotifications == 0)
            {
                result = new NotificationsResource
                {
                    TotalNotifications = totalNotifications,
                    CurrentPage = pageNumber,
                    Notifications = new List<NotificationResultResource>()
                };
                return Ok(result);
            }

            // If pageNumber is outside range, bad request. No point in trying to grab notifications
            int.TryParse(_configuration["NotificationsPageSize"], out var pageSize);
            if ((pageNumber - 1) * pageSize > totalNotifications)
            {
                return BadRequest("Page number is outside range");
            }

            // Finally get current page of notifications and return it to the user
            var notifications = _notificationService.GetNotificationsForUser(userId, pageSize, pageNumber);
            result = new NotificationsResource
            {
                TotalNotifications = totalNotifications,
                CurrentPage = pageNumber,
                Notifications = _mapper.Map<List<NotificationResultResource>>(notifications)
            };
            return Ok(result);
        }

        /// <summary>
        /// Marks all unread notifications for user as read
        /// </summary>
        /// <returns>200 if all notifications marked as read</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MarkAllUnreadRead()
        {
            // Get current user's id
            int.TryParse(_userManager.GetUserId(User), out var userId);

            // Mark all of their notifications as read
            await _notificationService.MarkAllUnreadReadAsync(userId);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Marks a single notification as read
        /// </summary>
        /// <param name="notificationId">Notification to mark as read</param>
        /// <response code="200">notification successfully marked as read</response>
        /// <response code="400">can't find notification by id or if notification already marked as read</response>
        /// <response code="405">notification is not for current user</response>
        /// <returns>An awaitable task.</returns>
        [HttpPost("{notificationId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> MarkRead(int notificationId)
        {
            // If invalid id...
            if (notificationId < 1)
            {
                return BadRequest(ApiResources.BadId);
            }

            // Get intended notification
            var notification = await _notificationService.FindByIdAsync(notificationId);

            // Get current user's id
            int.TryParse(_userManager.GetUserId(User), out var userId);

            // If notif not for current user...
            if (notification.UserId != userId)
            {
                return Unauthorized();
            }

            // If already read, nothing more to do
            if (notification.ReadDate != null)
            {
                return BadRequest("Notification already read");
            }

            // Finally, mark the notification as read
            notification.ReadDate = DateTime.Now;
            _notificationService.Update(notification);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}