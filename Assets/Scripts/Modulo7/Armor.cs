using UnityEngine;

public class Armor
{
	public string Name { get; private set; }
	public int Resistance { get; private set; }

	public Armor(string name, int resistance)
	{
		Name = name;
		Resistance = resistance;
	}

	public void DecreaseResistance()
	{
		Resistance--;
		Debug.Log($"A resistencia da {Name} diminuiu para {Resistance}.");
	}
}
