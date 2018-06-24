using System;

namespace OtherTypesInOOPHomework
{
    public struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;
        public Location(double latitude, double longitude, Planet planet) : this()
        {
            this.planet = planet;
            Latitude = latitude;
            Longitude = longitude;
        }
        public double Latitude
        {
            get { return this.latitude; }
            private set
            {
                if(value < -90 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("Latitude must be between -90° and 90°");
                }
                this.latitude = value;
            }
        }
        public double Longitude
        {
            get { return this.longitude; }
            private set
            {
                if(value < -180 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("Longitude must be between -180° and 180°");
                }
                this.longitude = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0}, {1} - {2}",  latitude, longitude, planet);
        }
    }
}
