using System;

class Student {
	private double averageGrades;
	private int gradeCount;
	private int lastGrade;
	public string name;

	public void addGrade(int grade) {
		averageGrades = ((averageGrades / gradeCount) + grade) / (gradeCount + 1);
		lastGrade = grade;
		gradeCount++; 
	}

	public int getLastGrade() {
		return lastGrade;
	}

	public double getAverage() {
		return averageGrades;
	}

	public string getName() {
		return name;
	}

	public void editLastGrade(int grade) {
		lastGrade = grade;

		averageGrades = ((averageGrades * gradeCount) - lastGrade + grade) / gradeCount;
	}

	public Student(string name, int[] grades) {
		this.name = name;
		averageGrades = 0;
		for(int i = 0; i < grades.Length; i++ ) {
			averageGrades += grades[i];
		}

		averageGrades /= grades.Length;
		
		lastGrade = grades[grades.Length - 1];

		gradeCount = grades.Length;
	}
}