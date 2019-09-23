using Newtonsoft.Json.Linq;
using Nexmo.Api.Request;
using Nexmo.Api.Voice;
using NexmoDotnetCodeSnippets.Authentication;

namespace NexmoDotnetCodeSnippets.Senders
{
    public class VoiceSender
    {
        public static Call.CallResponse MakeCall(string TO_NUMBER, string NEXMO_NUMBER)
        {
            var client = FullAuth.GetClient();

            var results = client.Call.Do(new Call.CallCommand
            {
                to = new[]
                {
                    new Call.Endpoint {
                        type = "phone",
                        number = TO_NUMBER
                    }
                },
                from = new Call.Endpoint
                {
                    type = "phone",
                    number = NEXMO_NUMBER
                },
                answer_url = new[]
                {
                    "https://developer.nexmo.com/ncco/tts.json"
                }
            });
            return results;
        }

        public static Call.CallResponse MakeCallWithNCCO(string TO_NUMBER, string NEXMO_NUMBER)
        {
            var client = FullAuth.GetClient();

            var results = client.Call.Do(new Call.CallCommand
            {
                to = new[]
                {
                    new Call.Endpoint {
                        type = "phone",
                        number = TO_NUMBER
                    }
                },
                from = new Call.Endpoint
                {
                    type = "phone",
                    number = NEXMO_NUMBER
                },

                Ncco = CreateNCCO()
            });
            return results;
        }

        private static JArray CreateNCCO()
        {
            dynamic TalkNCCO = new JObject();
            System.Text.StringBuilder sb = new System.Text.StringBuilder("This is a text to speech call from Nexmo. Hey Now Brown Cow");
            for (int i = 0; i < 10; i++)
            {
                sb.AppendFormat(" {0}", i);

            }
            TalkNCCO.action = "talk";
            TalkNCCO.text = sb.ToString();

            dynamic RecordNCCO = new JObject();
            RecordNCCO.action = "record";
            RecordNCCO.eventUrl = new JArray() { "https://29f42c6e.ngrok.io/webhook/recordings" };

            JArray ncco = new JArray();
            ncco.Add(RecordNCCO);
            ncco.Add(TalkNCCO);
            return ncco;
        }

        public static Call.CallResponse GetCall(string UUID)
        {
            var client = FullAuth.GetClient();

            var result = client.Call.Get(UUID);

            return result;
        }

        public static Call.CallResponse MuteCall(string UUID)
        {
            var client = FullAuth.GetClient();

            var result = client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "mute"
            });

            return result;
        }

        public static Call.CallResponse UnmuteCall(string UUID)
        {
            var client = FullAuth.GetClient();

            var result = client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "unmute"
            });

            return result;
        }

        public static Call.CallResponse EarmuffCall(string UUID)
        {
            var client = FullAuth.GetClient();

            var result = client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "earmuff"
            });

            return result;
        }

        public static Call.CallResponse UnearmuffCall(string UUID)
        {
            var client = FullAuth.GetClient();

            var result = client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "unearmuff"
            });

            return result;
        }

        public static Call.CallResponse HangupCall(string UUID)
        {
            var client = FullAuth.GetClient();

            var result = client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "hangup"
            });

            return result;
        }

        public static Call.CallCommandResponse PlayTtsToCall(string UUID)
        {
            var client = FullAuth.GetClient();
            
            var TEXT = "This is a text to speech sample";
            var result = client.Call.BeginTalk(UUID, new Call.TalkCommand
            {
                text = TEXT,
                voice_name = "Kimberly"
            });

            return result;
        }

        public static Call.CallCommandResponse PlayAudioStreamToCall(string UUID)
        {
            var client = FullAuth.GetClient();

            var result = client.Call.BeginStream(UUID, new Call.StreamCommand
            {
                stream_url = new[] { "https://nexmo-community.github.io/ncco-examples/assets/voice_api_audio_streaming.mp3" }
            });

            return result;
        }

        public static Call.CallCommandResponse PlayDTMFToCall(string UUID)
        {
            var client = FullAuth.GetClient();

            var DIGITS = "8675309";

            var result = client.Call.SendDtmf(UUID, new Call.DtmfCommand()
            {
                digits = DIGITS
            });

            return result;
        }

        public static Call.CallResponse TransferCall(string UUID)
        {
            var client = FullAuth.GetClient();

            var result = client.Call.Edit(UUID, new Call.CallEditCommand
            {
                Action = "transfer",
                Destination = new Call.Destination
                {
                    Type = "ncco",
                    Url = new[] { "https://developer.nexmo.com/ncco/transfer.json" }
                }
            });

            return result;
        }

        public static PaginatedResponse<Call.CallList> GetAllCalls()
        {
            var client = FullAuth.GetClient();

            var response = client.Call.List();

            return response;
        }

        public static Call.CallGetRecordingResponse GetRecording(string recordingUrl)
        {
            var client = FullAuth.GetClient();

            var response = client.Call.GetRecording(recordingUrl);

            return response;
        }
    }
}
