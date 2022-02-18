using System;

class Team {
	private string name;
	private int[] gamesResults;

	public Team(string name, int wonGames, int lostGames, int tiedGames) {
		this.name = name;
		this.gamesResults = new int[3];
		this.gamesResults[0] = wonGames;
		this.gamesResults[1] = lostGames;
		this.gamesResults[2] = tiedGames;
	}

	public string getName() {
		return this.name;
	}

	public int getWonGames() {
		return this.gamesResults[0];
	}

	public int getLostGames() {
		return this.gamesResults[1];
	}

	public int getTiedGames() {
		return this.gamesResults[2];
	}

	public int getPoints() {
		return this.gamesResults[0] * 3 + this.gamesResults[2];
	}

	public void reset() {
		this.gamesResults[0] = 0;
		this.gamesResults[1] = 0;
		this.gamesResults[2] = 0;
	}

	public void addGameResult(int result) {
		this.gamesResults[result]++;
	}

	public int getGameResult(int result) {
		return this.gamesResults[result];
	}

	public string output() {
		return "Squadra " + this.name + ": " + this.gamesResults[0] + "-" + this.gamesResults[1] + "-" + this.gamesResults[2] + " (" + this.getPoints() + " punti)";
	}
}