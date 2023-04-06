using UnityEngine;

public class Elf : Character
{
	public Elf(string name, int life, Weapon weapon, Armor armor) : base(name, life, weapon, armor)
	{
	}

	public override void Provoke()
	{
		Debug.Log("Ser inferior! Prepare-se para morrer!!");
	}
}
