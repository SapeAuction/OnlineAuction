﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entity;

namespace Auction.Sevices
{

    //Buyer
    public interface IBidService
    {
        BidParticipantInformation GetBidParticipantInformationById(int userId);
        IEnumerable<BidParticipantInformation> GetAllBidParticipantInformation();
        int CreateBidParticipantInformation(BidParticipantInformation bidParticipantInformationEntity);
        bool UpdateBidParticipantInformation(BidParticipantInformation userEntity);
        bool DeleteBidParticipantInformation(BidParticipantInformation bidParticipantInformationEntity);
    }
}