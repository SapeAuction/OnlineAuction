///<reference.js>
var AuctionSales = (function () {
    //Private variables
    var _load = function () {
    };

    var _ValidateNPlaceBid = function (auctionId) {

        var divBid = $('div[id=' + auctionId + ']');
        var newBidPrice = $(divBid).find('#newBidPrice').val();
        newBidPrice = parseFloat(newBidPrice).toFixed(2);
        var validationPanel = $(divBid).find('#ValidationMessage');
        var oldBidPrice = $(divBid).find('#oldBidPrice').val();
        oldBidPrice = parseFloat(oldBidPrice).toFixed(2);

        if (isNaN(newBidPrice)) {

            validationPanel.html("<i>Please enter valid Bid amount.");
            return false;
        }

        if (newBidPrice < oldBidPrice) {

            validationPanel.html("<i>Please enter higher than current Bid amount.");
            return false;
        }

        return true;
    };

    //Public methods
    return {
        Load: _load,
        ValidateNPlaceBid: _ValidateNPlaceBid
    };
})();
