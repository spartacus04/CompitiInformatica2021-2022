using System;

class Triangle {
	private int side1;
	private int side2;
	private int side3;

	public int getPerimeter() {
		return side1 + side2 + side3;
	}

	public int getSide1() {
		return side1;
	}

	public int getSide2() {
		return side2;
	}

	public int getSide3() {
		return side3;
	}

	// Equilatero
	public Triangle(int l) {
		this.side1 = l;
		this.side2 = l;
		this.side3 = l;
	}

	public Triangle(int l1, int l2) {
		this.side1 = l1;
		this.side2 = l2;
		this.side3 = l1;
	}

	// Scaleno
	public Triangle(int l1, int l2, int l3) {
		this.side1 = l1;
		this.side2 = l2;
		this.side3 = l3;
	}
}