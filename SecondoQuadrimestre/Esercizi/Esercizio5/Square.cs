using System;

class Square  {
    private double diagonal;
    private double side;
    private double area;
    private double perimeter;

    public Square(double _diagonal) {
        diagonal = _diagonal;
        side = diagonal / Math.Sqrt(2);
        area = side * side;
        perimeter = side * 4;
    }

    public double getDiagonal() {
        return Math.Round(diagonal, 2);
    }

    public double getSide() {
        return Math.Round(side, 2);
    }

    public double getArea() {
        return Math.Round(area, 2);
    }

    public double getPerimeter() {
        return Math.Round(perimeter, 2);
    }

    public string output() {
	    return "Il quadrato dalla diagonale " + getDiagonal() + " ha lato di lunghezza " + getSide() + " e quindi area di " + getArea() + " e perimetro di " + getPerimeter() + ".";
    }
}