﻿using SmartAccounting.EventBus;
using System.Text.Json.Serialization;

namespace SmartAccounting.Notification.API.Application.IntegrationEvents
{
    internal record DocumentSuccessfullyAnalyzedIntegrationEvent : IntegrationEvent
    {
        [JsonPropertyName("userId")]
        public string UserId { get; init; }
        [JsonPropertyName("invoiceId")]
        public string InvoiceId { get; init; }
    }
}
