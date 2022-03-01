using System;

class Terrain {
	private string id;
	private int extension;
	private int buildablePercentage;
	private double annuityPerSquareMeter;

	#region getters/setters
	public string Id {
		get { return id; }
		set { id = value; }
	}

	public int Extension {
		get { return extension; }
		set { extension = value > 0 ? value : 1; }
	}

	public int BuildablePercentage {
		get { return buildablePercentage; }
		set { buildablePercentage = value < 0 || value > 100 ? 60 : value; }
	}

	public double AnnuityPerSquareMeter {
		get { return annuityPerSquareMeter; }
		set { annuityPerSquareMeter = value < 0 ? 10 : value; }
	}

	#endregion

	#region constructors
	public Terrain(string id, int extension, int buildablePercentage, double annuity) {
		this.Id = id;
		this.Extension = extension;
		this.BuildablePercentage = buildablePercentage;
		this.AnnuityPerSquareMeter = annuity;
	}

	#endregion

	#region methods/functions
	public string toString() {
		return "Terreno: " + id + "\tEstensione: " + extension + "m2\tPercentule Edificabile: " + buildablePercentage + "%\tRendita per metro quadro: " + annuityPerSquareMeter + "€/m2";
	}

	public double getTotalAnnuity() {
		return extension * annuityPerSquareMeter;
	}

	public double buildableMeters() {
		return extension * buildablePercentage / 100;
	}

	#endregion

}