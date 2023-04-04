using UnityEngine;

public class Character
{
	public string Name { get; private set; }
	public int Life { get; private set; }
	public Weapon Weapon { get; private set; }
	public Armor Armor { get; private set; }

	public bool IsAlive { get => Life > 0; }

	public Character(string name, int life, Weapon weapon, Armor armor)
	{
		Name = name;
		Life = life;
		Weapon = weapon;
		Armor = armor;
	}

	public void Attack(Character other)
	{
		if (!CheckAlive()) return;

		if (!other.IsAlive)
		{
			Debug.Log($"{other.Name} já está morto.");
			return;
		}

		if (!HasWeapon()) return;

		Debug.Log($"{Name} atacou {other.Name} com sua {Weapon.Name}.");
		other.DealDamage(Weapon.Damage);

	}

	public void SharpenWeapon()
	{
		if (!CheckAlive()) return;

		if (!HasWeapon()) return;

		Debug.Log($"{Name} afiou sua {Weapon.Name}.");
		Weapon.Sharpen();
	}

	public void UnequipWeapon()
	{
		if (!CheckAlive()) return;

		if (!HasWeapon()) return;

		Debug.Log($"{Name} desequipou sua {Weapon.Name}.");
		Weapon = null;
	}

	public void EquipWeapon(Weapon weapon)
	{
		if (!CheckAlive()) return;

		if (HasWeapon())
		{
			Debug.Log($"{Name} já tem uma arma.");
		}
		else
		{
			Weapon = weapon;
			Debug.Log($"{Name} equipou uma {Weapon.Name} (Dano: {Weapon.Damage} - Rank: {Weapon.Rank}).");
		}
	}

	public void UnequipArmor()
	{
		if (!CheckAlive()) return;

		if (!HasArmor()) return;

		Debug.Log($"{Name} desequipou sua {Armor.Name}.");
		Armor = null;
	}

	public void EquipArmor(Armor armor)
	{
		if (!CheckAlive()) return;

		if (HasArmor())
		{
			Debug.Log($"{Name} já tem uma armadura.");
		}
		else
		{
			Armor = armor;
			Debug.Log($"{Name} equipou uma {Armor.Name} (Resistance: {Armor.Resistance}).");
		}
	}

	private void DealDamage(int ammount)
	{
		if (HasArmor())
		{
			Debug.Log($"{Armor.Name} protegeu {Name}.");
			Armor.DecreaseResistance();
			if (Armor.Resistance <= 0) UnequipArmor();
			return;
		}

		Life -= ammount;

		Debug.Log($"{Name} tomou {ammount} de dano.\n" +
			$"Vida atual de {Name}: {Life}");

		CheckAlive();
	}

	private bool CheckAlive()
	{
		if (!IsAlive)
		{
			Debug.Log($"{Name} está morto.");
		}

		return IsAlive;
	}

	private bool HasWeapon()
	{
		if (Weapon == null)
		{
			Debug.Log($"{Name} não tem uma arma.");
		}

		return Weapon != null;
	}

	private bool HasArmor()
	{
		if (Armor == null)
		{
			Debug.Log($"{Name} não tem uma armadura.");
		}

		return Armor != null;
	}

}
