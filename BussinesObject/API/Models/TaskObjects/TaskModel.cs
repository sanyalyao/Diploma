using Newtonsoft.Json;

namespace BussinesObject.API.Models.TaskObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TaskModel
    {
        public Attributes? attributes { get; set; }
        public string? Id { get; set; }
        public string? WhoId { get; set; }
        public string? WhatId { get; set; }
        public string? Subject { get; set; }
        public object? ActivityDate { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public bool? IsHighPriority { get; set; }
        public string? OwnerId { get; set; }
        public object? Description { get; set; }
        public bool? IsDeleted { get; set; }
        public string? AccountId { get; set; }
        public bool? IsClosed { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedById { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedById { get; set; }
        public DateTime? SystemModstamp { get; set; }
        public bool? IsArchived { get; set; }
        public object? CallDurationInSeconds { get; set; }
        public object? CallType { get; set; }
        public object? CallDisposition { get; set; }
        public object? CallObject { get; set; }
        public object? ReminderDateTime { get; set; }
        public bool? IsReminderSet { get; set; }
        public object? RecurrenceActivityId { get; set; }
        public bool? IsRecurrence { get; set; }
        public object? RecurrenceStartDateOnly { get; set; }
        public object? RecurrenceEndDateOnly { get; set; }
        public object? RecurrenceTimeZoneSidKey { get; set; }
        public object? RecurrenceType { get; set; }
        public object? RecurrenceInterval { get; set; }
        public object? RecurrenceDayOfWeekMask { get; set; }
        public object? RecurrenceDayOfMonth { get; set; }
        public object? RecurrenceInstance { get; set; }
        public object? RecurrenceMonthOfYear { get; set; }
        public object? RecurrenceRegeneratedType { get; set; }
        public string? TaskSubtype { get; set; }
        public object? CompletedDateTime { get; set; }
    }
}
