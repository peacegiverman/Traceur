using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Traceur
{
    class GoogleCalendarHandler
    {
        static string[] Scopes = { CalendarService.Scope.Calendar };
        static string ApplicationName = "Traceur";
        static string calendarId = "primary";

        CalendarService service;

        int colorCount = 0;

        public GoogleCalendarHandler()
        {
            var credential = GetUserCredential();

            // Create Calendar Service.
            service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            colorCount = service.Colors.Get().Execute().Event.Count();
        }

        public void AddTask(Task task)
        {
            //select random color id
            var random = new Random(task.name.GetHashCode());
            var colorId = random.Next(colorCount);

            var endTime = task.startTime.AddHours(1);
            Console.WriteLine("start: " + task.startTime.ToShortTimeString());
            Console.WriteLine("end: " + endTime.ToShortTimeString());

            //create event
            var taskEvent = new Event()
            {
                Summary = task.name,
                Start = new EventDateTime()
                {
                    DateTime = task.startTime
                },
                End = new EventDateTime()
                {
                    DateTime = endTime
                },
                ColorId = "" + colorId
            };

            //save in calendar
            service.Events.Insert(taskEvent, calendarId).Execute();
        }

        public void EndTask(Task task)
        {
            var request = service.Events.List(calendarId);
            request.Q = task.name;
            request.TimeMax = task.startTime + TimeSpan.FromMinutes(1);
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            var events = request.Execute();
            if(events != null && events.Items.Count > 0)
            {
                Console.WriteLine("Found events");

                var taskEvent = events.Items[events.Items.Count - 1];

                var endTime = (task.endTime - task.startTime) > new TimeSpan(0, 1, 0) ? task.endTime : task.startTime.AddMinutes(1);

                taskEvent.End = new EventDateTime()
                {
                    DateTime = endTime
                };

                service.Events.Update(taskEvent, calendarId, taskEvent.Id).Execute();
            }
        }

        private UserCredential GetUserCredential()
        {
            UserCredential credential;

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment
                  .SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                   GoogleClientSecrets.Load(stream).Secrets,
                  Scopes,
                  "user",
                  CancellationToken.None,
                  new FileDataStore(credPath, true)).Result;
            }

            return credential;
        }
    }
}
