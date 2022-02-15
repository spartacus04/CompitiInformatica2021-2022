using System;

class Circle {
	private double Radius { get; set; }
	private double Area { get; set; }
	private double Circumference { get; set; }

	public Circle(double radius) {
		Radius = radius;
		Area = Math.PI * Math.Pow(Radius, 2);
		Circumference = 2 * Math.PI * Radius;
	}

	public double GetArea() {
		return Area;
	}

	public double GetCircumference() {
		return Circumference;
	}
	
	public double GetRadious() {
		return Radius;
	}

	public string Output() {
		return "Il cerchio con raggio " + Radius + " ha come area " + Math.Round(Area, 2) + " e come circonferenza " + Math.Round(Circumference, 2);
	}
}