using Gcsb.Connect.SAP.Domain.GenerateInterfaceDtos;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute
{
    public class CounterChargeDisputeOutput
    {
        public List<NotificationError> Notifications { get; set; }
        public List<GeneratedInterface> GeneratedInterfaces { get; set; }

        public CounterChargeDisputeOutput(List<NotificationError> notifications, List<GeneratedInterface> generatedInterfaces)
        {
            Notifications = notifications;
            GeneratedInterfaces = generatedInterfaces;
        }
    }
}