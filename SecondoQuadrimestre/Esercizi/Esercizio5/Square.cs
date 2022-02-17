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
        return diagonal;
    }

    public double getSide() {
        return side;
    }

    public double getArea() {
        return area;
    }

    public double getPerimeter() {
        return perimeter;
    }

    public string output() {
	    return "Il quadrato dalla diagonale " + diagonal + " ha lato di lunghezza " + Math.Round(side, 2) + " e quindi area di " + Math.Round(area, 2) + " e perimetro di " + Math.Round(perimeter, 2) + ".";
    }
}