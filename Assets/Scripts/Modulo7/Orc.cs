using UnityEngine;

public class Orc : Character
{
	public Orc(string name, int life, Weapon weapon, Armor armor) : base(name, life, weapon, armor)
	{
	}

	public override void Provoke()
	{
		Debug.Log("Growwwwwwlllllllll!!!!.");
	}
}
