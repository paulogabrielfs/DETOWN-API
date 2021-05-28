using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using DETOWN.Domain.Core.Events;

namespace DETOWN.Application.EventSourcedNormalizers
{
    public class NewsHistory
    {
        public static IList<NewsHistoryData> HistoryData {get; set;}

        public static IList<NewsHistoryData> ToJavaScriptNewsHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<NewsHistoryData>();
            NewsHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<NewsHistoryData>();
            var last = new NewsHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new NewsHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Title = string.IsNullOrWhiteSpace(change.Title) || change.Title == last.Title
                        ? ""
                        : change.Title,
                    Header = string.IsNullOrWhiteSpace(change.Header) || change.Header == last.Header
                        ? ""
                        : change.Header,
                    Description = string.IsNullOrWhiteSpace(change.Description) || change.Description == last.Description
                        ? ""
                        : change.Description.Substring(0, 10),
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;

        }

        private static void NewsHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new NewsHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "CustomerRegisteredEvent":
                        values = JsonSerializer.Deserialize<Dictionary<string, string>>(e.Data);
                        slot.Title = values["Title"];
                        slot.Header = values["Header"];
                        slot.Description = values["Description"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "CustomerUpdatedEvent":
                        values = JsonSerializer.Deserialize<Dictionary<string, string>>(e.Data);
                        slot.Title = values["Title"];
                        slot.Header = values["Header"];
                        slot.Description = values["Description"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "CustomerRemovedEvent":
                        values = JsonSerializer.Deserialize<Dictionary<string, string>>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}