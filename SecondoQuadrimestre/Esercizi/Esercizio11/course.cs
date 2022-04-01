using System;
using System.Collections.Generic;

class Course {
	public string Name { get; set; }
	public int Hours { get; set; }
	public string  TeacherName { get; set; }
	public List<string> Participants { get; set; }

	public Course(string name, int hours, string teacherName) {
		this.Name = name;
		this.Hours = hours;
		this.TeacherName = teacherName;
	}

	public void addParticipant(string participant) {
		this.Participants.Add(participant);
	}

	public int getNumberOfParticipants() {
		return this.Participants.Count;
	}

	public string getParticipats() {
		return string.Join(", ", this.Participants);
	}
}