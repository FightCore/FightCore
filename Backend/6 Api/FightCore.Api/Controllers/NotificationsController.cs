using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Notifications;
using FightCore.Api.Resources.Notifications;
using FightCore.Models;
using FightCore.Repositories.Patterns;
using FightCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;


namespace FightCore.Api.SignalRTesting
{
    /// <summary>
    /// Temporary testing api for notifications
    /// This comment should NOT make it to merge phase
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="hubContext"></param>
        public NotificationsController(IUnitOfWorkAsync unitOfWork, INotificationService notificationService, IMapper mapper, IHubContext<NotifyHub, ITypedHubClient> hubContext, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
            _mapper = mapper;
            _hubContext = hubContext;
            _userManager = userManager;
        }

        /// <summary>
        /// Gets notifications for current user, one page at a time. Page size is currently 20
        /// </summary>
        /// <param name="pageNumber">Page number to get. 1 is first page</param>
        /// <returns></returns>
        [HttpGet("{pageNumber}")]
        [Authorize]
        public async Task<IActionResult> Get(int pageNumber)
        {
            NotificationsResource result;

            // Quick check on page number, must start at 1
            if (pageNumber < 1)
                return BadRequest("Page number must start at 1");

            // Get current user's id
            int userId;
            string userIdAsString = _userManager.GetUserId(User);
            if (userIdAsString == null || userIdAsString == "")
            {
                return BadRequest("Couldn't find authenticated user's id");
            }
            if (!Int32.TryParse(userIdAsString, out userId))
            {
                return BadRequest("Somehow failed to convert user's id to number");
            }

            // Get count of notifications for user
            int totalNotifs = _notificationService.GetNotificationCount(userId);
            if (totalNotifs < 0)
            {
                return BadRequest("Couldn't get total number of notifications for user");
            }
            else if (totalNotifs == 0)
            {
                result = new NotificationsResource
                {
                    TotalNotifications = totalNotifs,
                    CurrentPage = pageNumber,
                    Notifications = new List<NotificationResultResource>()
                };
                return Ok(result);
            }

            // If pageNumber is outside range, bad request. No point in trying to grab notifications
            if ((pageNumber - 1) * 20 > totalNotifs)
            {
                return BadRequest("Page number is outside range");
            }

            // Finally get current page of notifications and return it to the user
            var notifications = _notificationService.GetNotificationsForUser(userId, pageNumber);
            result = new NotificationsResource
            {
                TotalNotifications = totalNotifs,
                CurrentPage = pageNumber,
                Notifications = _mapper.Map<List<NotificationResultResource>>(notifications)
            };
            return Ok(result);
        }

        /// <summary>
        /// Marks all unread notifications for user as read
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MarkAllUnreadRead()
        {
            // Get current user's id
            int userId;
            string userIdAsString = _userManager.GetUserId(User);
            if (userIdAsString == null || userIdAsString == "")
            {
                return BadRequest("Couldn't find authenticated user's id");
            }
            if (!Int32.TryParse(userIdAsString, out userId))
            {
                return BadRequest("Somehow failed to convert user's id to number");
            }

            // Mark all of their notifications as read
            _notificationService.MarkAllUnreadRead(userId);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Marks a single notification as read
        /// </summary>
        /// <param name="notifId">Notification to mark as read</param>
        /// <returns></returns>
        [HttpPost("{notifId}")]
        [Authorize]
        public async Task<IActionResult> MarkRead(int notifId)
        {
            // Get intended notification
            var notif = await _notificationService.FindByIdAsync(notifId);
            // If invalid id...
            if (notif.Id < 1) return BadRequest("Bad id");

            // Get current user's id
            int userId;
            string userIdAsString = _userManager.GetUserId(User);
            if (userIdAsString == null || userIdAsString == "")
            {
                return BadRequest("Couldn't find authenticated user's id");
            }
            if (!Int32.TryParse(userIdAsString, out userId))
            {
                return BadRequest("Somehow failed to convert user's id to number");
            }
            // If notif not for current user...
            if (notif.UserId != userId) return Unauthorized();

            // If already read, nothing more to do
            if (notif.ReadDate != null) return BadRequest("Notification already read");

            // Finally, mark the notification as read
            notif.ReadDate = DateTime.Now;
            _notificationService.Update(notif);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}