namespace DunmmyBackend
{
    public class LatitudeLongitude
    {
        public LatitudeLongitude(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }

        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}