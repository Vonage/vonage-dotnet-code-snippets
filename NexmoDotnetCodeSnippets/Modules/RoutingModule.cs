using Nancy;
using Nancy.Extensions;
using Nexmo.Api.Voice.EventWebhooks;
using Nexmo.Api.Voice.Nccos;
using Nexmo.Api.Voice.Nccos.Endpoints;
using System.Diagnostics;
using System.Text;

namespace NexmoDotnetCodeSnippets.Modules
{
    public class RoutingModule : NancyModule
    {
        public static string SiteBase { get; set; } = "Add_site_base_here";

        public enum RoutingMode
        {
            DTMF,
            Inbound,
            Conference,
            Connect,
            Recording,
            RecordingConversation,
            RecordingMessage,
            RecordingSplitAudio
        }

        public static RoutingMode Mode { get; set; }      

        public RoutingModule()
        {
            Get("/webhook/answer", x => { return OnAnswer(); });
            Post("/webhook/event", x => { return OnEvent(); });
            Post("/webhook/dtmf", x => { return GetDTMFInput(); });
            Post("/webhook/record", x => { return OnRecordComplete(); });
        }

        private Response OnAnswer()
        {
            switch (Mode)
            {
                case RoutingMode.DTMF:
                    return OnAnswerDtmf();
                case RoutingMode.Conference:
                    return OnAnswerConference();
                case RoutingMode.Connect:
                    return OnAnswerConnect();
                case RoutingMode.Inbound:
                    return OnAnswerInboundCall();
                case RoutingMode.Recording:
                    return OnAnswerRecording();
                case RoutingMode.RecordingConversation:
                    return OnAnswerRecordConversation();
                case RoutingMode.RecordingMessage:
                    return OnAnswerRecordMessage();
                case RoutingMode.RecordingSplitAudio:
                    return OnAnswerRecordingSplitAudio();
                default:
                    return HttpStatusCode.NoContent;

            }
        }

        private Response OnEvent()
        {
            
            var body = Request.Body.AsString();
            var e = EventBase.ParseEvent(body);
            Debug.WriteLine(e.ToString());
            return Request.Query["status"];
        }

        private Response OnAnswerDtmf()
        {
            var talkAction = new TalkAction()
            {
                Text = "Hello. Please Press Any Key To continue"
            };

            var inputAction = new InputAction()
            {
                MaxDigits = "1",
                TimeOut = "6",
                EventUrl = new [] {$"{SiteBase}/webhook/dtmf"}
            };

            var ncco = new Ncco(talkAction, inputAction);
            return ncco.ToString();
        }

        private Response OnAnswerConference()
        {
            var talkNcco = new TalkAction()
            {
                Text = "Hello. You will now be added to the conference call.",
                VoiceName = "Emma"
            };

            var conferenceNcco = new ConversationAction()
            {
                Name = "conference-call"
            };

            var ncco = new Ncco(talkNcco, conferenceNcco);

            return ncco.ToString();
        }

        private Response OnAnswerInboundCall()
        {
            string number = Request.Query["from"].Value;
            var talkAction = new TalkAction()
            {
                Text = ("Thank you for calling from " + string.Join(" ", number.ToCharArray())),
                VoiceName = "Kimberly"
            };
            var ncco = new Ncco(talkAction);
            return ncco.ToString();
        }

        private Response OnAnswerRecording()
        {
            var recordAction = new RecordAction()
            {
                EventUrl = new [] { $"{SiteBase}/webhook/record" }
            };

            var sb = new StringBuilder("Hello - we are now recording this call I will now count to 10 ");
            for (int i = 1; i <= 10; i++)
            {
                sb.Append(i + " ");
            }

            var talkAction = new TalkAction()
            {
                Text = sb.ToString()
            };
            var ncco = new Ncco(recordAction, talkAction);

            return ncco.ToString();
        }

        private string OnRecordComplete()
        {
            var recordEvent = EventBase.ParseEvent(Request.Body.AsString()) as Record;
            if (recordEvent != null)
            {
                Debug.WriteLine($"Recording URL: {recordEvent.RecordingUrl}");
            }

            var talkAction = new TalkAction()
            {
                Text = "Thank you for calling in the recording is now finished, have a nice day",
                VoiceName = "Kimberly"
            };

            var ncco = new Ncco(talkAction);

            return ncco.ToString();
        }

        private Response OnAnswerConnect()
        {
            var talkAction = new TalkAction()
            {
                Text ="Thank you for calling",
                VoiceName = "Kimberly"
            };
            var phoneEndpoint = new PhoneEndpoint()
            {
                Number = "TO_NUMBER"
            };
            var connectAction = new ConnectAction()
            {
                From = Request.Query.from.Value,
                Endpoint = new[] {phoneEndpoint}
            };

            var ncco = new Ncco(talkAction, connectAction);
            return ncco.ToString();
        }

        private Response GetDTMFInput()
        {
            var input = EventBase.ParseEvent(Request.Body.AsString()) as Input;

            var talkNcco = new TalkAction();

            if (input != null)
            {
                talkNcco.Text = $"You pressed {input.Dtmf}";
            }
            else
            {
                talkNcco.Text = "No input received";
            }

            var ncco = new Ncco(talkNcco);

            return ncco.ToString();
        }

        private Response OnAnswerRecordConversation()
        {
            var talkAction = new TalkAction()
            {
                Text= "Thank you for calling. You will now be joined into the conference",
                VoiceName = "Kimberly"

            };

            var conversationAction = new ConversationAction()
            {
                Name ="A_Conference",
                Record = "True",
                EventMethod = "POST",
                EventUrl = new []{ $"{SiteBase}/webhook/record" }
            };
            var ncco = new Ncco(talkAction,conversationAction);

            return ncco.ToString();

        }

        private Response OnAnswerRecordMessage()
        {
            var talkAction = new TalkAction()
            {
                Text = "Please leave a message after the tone, then press pound."
            };

            var recordAction = new RecordAction()
            {
                EndOnKey = "#",
                BeepStart = "True",
                EventUrl = new[] { $"{SiteBase}/webhook/record" }
            };

            var secondTalkAction = new TalkAction()
            {
                Text = "Thank you for your message. Goodbye"
            };
            
            var ncco = new Ncco(talkAction,recordAction,secondTalkAction);

            return ncco.ToString();
        }

        private Response OnAnswerRecordingSplitAudio()
        {
            string TO_NUMBER = "TO_NUMBER";
            string NEXMO_NUMBER = "NEXMO_NUMBER";

            var recordAction = new RecordAction()
            {
                Split="conversation",
                Channels=2,
                EventUrl = new []{ $"{SiteBase}/webhook/record" }
            };
            var phoneEndpoint = new PhoneEndpoint()
            {
                Number = TO_NUMBER
            };
            var connectAction = new ConnectAction()
            {
                From = NEXMO_NUMBER,
                Endpoint = new [] { phoneEndpoint }
            };

            var ncco = new Ncco(recordAction, connectAction);
            return ncco.ToString();
        }
    }
}
