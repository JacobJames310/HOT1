using System.ComponentModel.DataAnnotations;

namespace HOT1.Models
{
	public class DistanceConverterModel
	{
		[Required(ErrorMessage = "Please enter a distance in inches.")]
		[Range(1, 500, ErrorMessage = "Distance must be between 1 and 500 inches.")]
		public double DistanceInInches { get; set; }

		public double DistanceInCentimeters { get; set; }
	}
}
