namespace Buckets.Enums
{
    public class BillClassification
    {
        public enum BillType
        {
            //---PRIMARY---//
            Sustenance, //food and water, vitamins, and certain medications
            Shelter, //rent, mortgage, property taxes, maintenance, insurance as required by law
            Clothing, //basics only
            Transportation, //fuel, maintenance, rental, lease, loan payment, bus pass, rideshare, insurance as required by law, registration, rented parking (if unreasonable to avoid)
            TradeTools, //expenses required to earn
            Utilities, //basics only: water, heat/air per climate, trash/sewer
            Communications, //stamps? services: phone/internet
            //---PRIMARY---//


            //---SECONDARY---//
            Medical, //other medical expenditures: insurance premiums, preventative maintenance, 
            Insurance, //not required by law or health
            //---SECONDARY---//


            //---TERTIARY---//
            Entertainment, //Netflix, Spotify, magazines, games
            Fashion, //clothing, makeup, 
            Restaurants,
            Lawyer, //?

            //---TERTIARY---//


            //---FRIVOLOUS---//
            SubscriptionBoxes,
            SeasonTickets,
            RecreationalStuff
            //---FRIVOLOUS---//
        }
    }
}
