using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAuction
{
    
    [HubName("hitCounter")]
    public class HitCounterHub : Hub
    {

        private static int _hitCount = 0;
        public void RecordHit()
        {
            _hitCount += 1;
            this.Clients.All.onHitRecorded(_hitCount);

        }

    }
}