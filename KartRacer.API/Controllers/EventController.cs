using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using KartRacer.API.Repositories.Events;
using KartRacer.API.Models.Dto;
using KartRacer.API.Models.Dto;

namespace KartRacer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly ILogger<EventController> _logger;

        public EventController(IEventRepository eventRepository, ILogger<EventController> logger)
        {
            this._eventRepository = eventRepository;
            this._logger = logger;
        }

        // GET: api/event/availableEvents
        [HttpGet("AvailableEvents")]
        public async Task<ActionResult<ResponseDto>> GetAvailableEvents()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var availableEvents = await _eventRepository.GetAvailableEventsAsync();
                resp.Result = availableEvents;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetAvailableEvents)}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/event/entries
        [HttpGet("Entries")]
        public async Task<ActionResult<ResponseDto>> GetEntries()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var availableEvents = await _eventRepository.GetEntriesAsync();
                resp.Result = availableEvents;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetEntries)}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/event/entrySessions
        [HttpGet("EntrySessions")]
        public async Task<ActionResult<ResponseDto>> GetEntrySessionsAsync()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var entrySessions = await _eventRepository.GetEntrySessionsAsync();
                resp = entrySessions;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetEntries)}");
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = $"An error occurred in {nameof(GetEntrySessionsAsync)} - {ex.Message}"
                };
            }
        }

        // GET: api/event/entriesForEvent
        [HttpGet("EntriesForEvent")]
        public async Task<ActionResult<ResponseDto>> GetEntriesForEvent(SingleIntDto evt)
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var entriesForEvent = await _eventRepository.GetEntriesForEventAsync(evt.Id);
                resp.Result = entriesForEvent;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetEntriesForEvent)}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/event/nextEvent
        [HttpGet("NextEvent")]
        public async Task<ActionResult<ResponseDto>> GetNextEvent()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var availableEvents = await _eventRepository.GetNextEventAsync();
                resp.Result = availableEvents;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetNextEvent)}");
                return StatusCode(500, ex.Message);
            }
        }

        // Post: api/event/entry
        [HttpPost("Entry")]
        public async Task<ActionResult<ResponseDto>> CreateEntry(SingleIntDto evt)
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var availableEvents = await _eventRepository.CreateEntryAsync(evt.Id);
                resp.Result = availableEvents;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(CreateEntry)}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/event/recentEventSessions
        [HttpGet("RecentEventSessions")]
        public async Task<ActionResult<ResponseDto>> GetRecentEventSessionsForDriver()
        {
            try
            {
                ResponseDto resp = new ResponseDto();
                var eventSessions = await _eventRepository.GetRecentEventSessionsForDriver();
                resp = eventSessions;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing GET in {nameof(GetRecentEventSessionsForDriver)} - {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
