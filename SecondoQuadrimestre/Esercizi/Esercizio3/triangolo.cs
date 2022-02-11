using System;

class Triangle {
	private int perimeter;

	public int getPerimeter() {
		return this.perimeter;
	}

	// Equilatero
	public Triangle(int l) {
		this.perimeter = l * 3;
	}

	public Triangle(int l1, int l2) {
		this.perimeter = l1 + l2 * 2;
	}

	// Scaleno
	public Triangle(int l1, int l2, int l3) {
		this.perimeter = l1 + l2 + l3;
	}
}