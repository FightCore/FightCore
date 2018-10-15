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

namespace FightCore.Api.Controllers
{
    /// <summary>
    /// Testing controller for interacting with notifications in a simple wa
    /// None of this is meant for release
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkAsync _unitOfWork;

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="hubContext"></param>
        public NotificationController(IUnitOfWorkAsync unitOfWork, INotificationService notificationService, IMapper mapper, IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        /// <summary>
        /// Gets the notification for the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var notif = await _notificationService.FindByIdAsync(id);
            if (notif == null)
                return NotFound();

            return Ok(_mapper.Map<NotificationResultResource>(notif));
        }

        [HttpGet]
        //[Authorize] // Temporary method, should be removed
        public async Task<IActionResult> GetAll()
        {
            var notifs = await _notificationService.GetAllAsync();
            if (notifs == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<NotificationResultResource>>(notifs));
        }

        /// <summary>
        /// Test notification to a specific user. This should not be released
        /// </summary>
        /// <param name="msg">Message</param>
        /// <returns>Returns something</returns>
        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody]NotificationResource notifInput)
        {
            try
            {
                // TODO: Check if notification is appropriate

                // Store the notification
                var notifResult = _mapper.Map<Notification>(notifInput);
                notifResult = await _notificationService.InsertAsync(notifResult);
                await _unitOfWork.SaveChangesAsync();

                // If succeeded in creating notification, broadcast it
                if (notifResult.Id > 0)
                {
                    // Send out the notification
                    var notifBroadcast = _mapper.Map<NotificationResultResource>(notifResult);
                    await _hubContext.Clients.User(notifResult.UserId.ToString()).BroadcastNotification(notifBroadcast);

                    return CreatedAtAction(nameof(this.Get), new { notifBroadcast.Id }, notifBroadcast);
                }
                // Otherwise this is a bad request
                else
                {
                    return BadRequest("Could not create notification");
                }
            }
            catch (Exception e)
            {
                // TODO: Explicitly differentiate whether failed at Notification creation or at broadcasting notification
                return BadRequest(e.ToString());
            }
        }
    }
}