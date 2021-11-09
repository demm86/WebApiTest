using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Services.Impl
{
    public class TicketServices : ITicketServices
    {

        static readonly string urlRead = ConfigurationManager.AppSettings["ReadFileUrl"];
        static readonly string urlWrite = ConfigurationManager.AppSettings["WriteFileUrl"];
        public void GetFile(string fileName)
        {
            Tickets tmpTickets = new Tickets();
            List<Tickets> lstTickets = new List<Tickets>();
           

            FileServices fileServices = new FileServices();
            string m = fileServices.ReadFile(urlRead, fileName);

            TicketList tmp = new TicketList();

            List<TicketList> lstTicketList = FormatReadJson(m).ToList();
       

         
            fileServices.WriteFile(urlWrite, "outPutGet.txt", FormatWriteJson(lstTicketList));



          //  return lstTicketList;
        }

        public void PostFile(string json)
        {

            FileServices fileServices = new FileServices();

            List<TicketList> lstTicketList = FormatReadJson(json);


            fileServices.WriteFile(urlWrite, "outPutPost.txt", FormatWriteJson(lstTicketList));

        }

        private List<TicketList> FormatReadJson(string json) {

            JsonDocument document = JsonDocument.Parse(json);
            JsonElement root = document.RootElement;
            JsonElement ticketsElement = root.GetProperty("Tickets");

            TicketList tmp = new TicketList();
            List<TicketList> lstTicketList = new List<TicketList>();

            foreach (JsonElement Tickets in ticketsElement.EnumerateArray())
            {
                tmp = new TicketList
                {
                    TicketID = Tickets.GetProperty("id").GetInt16(),
                    Key = Tickets.GetProperty("key").GetString()
                };

                foreach (JsonElement fields in Tickets.GetProperty("fields").EnumerateArray())
                {
                    tmp.AgentName = fields.GetProperty("agentName").GetString();
                    tmp.StartDate = fields.GetProperty("startDate").GetDateTime();
                    tmp.Type = fields.GetProperty("type").GetString();
                    tmp.Priority = fields.GetProperty("priority").GetString();
                    tmp.Company = fields.GetProperty("company").GetString();
                    tmp.Completed = fields.GetProperty("completed").GetBoolean();
                    tmp.TotalDuration = fields.GetProperty("totalDuration").GetInt32();


                    foreach (JsonElement summaryStates in fields.GetProperty("summaryStates").EnumerateArray())
                    {
                        switch (summaryStates.GetProperty("name").GetString())
                        {
                            case "Open":
                                tmp.Open = summaryStates.GetProperty("duration").GetInt32();
                                break;
                            case "In Progress":
                                tmp.InProgress = summaryStates.GetProperty("duration").GetInt32();
                                break;
                            case "Waiting":
                                tmp.Waiting = summaryStates.GetProperty("duration").GetInt32();
                                break;
                            case "Internal Validation":
                                tmp.InternalValidadtion = summaryStates.GetProperty("duration").GetInt32();
                                break;
                        }
                    }

                }
                lstTicketList.Add(tmp);
            }




            return lstTicketList;


        }

        private string FormatWriteJson(List<TicketList> list) {


            StringBuilder sb = new StringBuilder();
            StringBuilder sbTmp = new StringBuilder();
            string title = String.Join(", ", typeof(TicketList).GetProperties().Select(p => p.Name));
            sb.AppendLine(title);

            foreach (TicketList tmpElement in list)
            {

                sb.Append(tmpElement.TicketID + ", ");
                sb.Append(tmpElement.AgentName + ", ");
                sb.Append(tmpElement.StartDate + ", ");
                sb.Append(tmpElement.Type + ", ");
                sb.Append(tmpElement.Priority + ", ");
                sb.Append(tmpElement.Company + ", ");
                sb.Append(tmpElement.Completed + ", ");
                sb.Append(tmpElement.TotalDuration + ", ");
                sb.Append(tmpElement.Open + ", ");
                sb.Append(tmpElement.InProgress + ", ");
                sb.Append(tmpElement.Waiting + ", ");
                sb.AppendLine(tmpElement.InternalValidadtion.ToString());


            }

            return sb.ToString();
        }

    }
}
