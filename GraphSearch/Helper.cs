using System;

namespace GraphSearch
{
	public class Helper
	{
		public static double distFrom(double lat1, double lng1, double lat2, double lng2)
		{
			const double earthRadius = 6371000; //meters
			double dLat = ConvertDegreesToRadians(lat2 - lat1);
			double dLng = ConvertDegreesToRadians(lng2 - lng1);
			double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
				Math.Cos(ConvertDegreesToRadians(lat1)) * Math.Cos(ConvertDegreesToRadians(lat2)) *
				Math.Sin(dLng / 2) * Math.Sin(dLng / 2);
			double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

			return earthRadius * c;
		}

		private static double ConvertDegreesToRadians(double degrees)
		{
			double radians = (Math.PI / 180) * degrees;
			return (radians);
		}
	}
}

