using UnityEngine;

public class Program : MonoBehaviour
{
	private Character _player1;
	private Character _player2;

	void Start()
	{
		var sword = new Weapon("Sword", 8);
		var plate = new Armor("Breast Plate", 3);
		_player1 = new Orc("Growl", 100, sword, plate);

		var dagger = new Weapon("Dagger", 6);
		var complete = new Armor("Complete Armor", 6);
		_player2 = new Elf("Ana", 90, dagger, complete);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			_player1.Attack(_player2);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			_player1.SharpenWeapon();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			_player1.UnequipWeapon();
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			_player1.EquipWeapon(new Weapon("Arma", Random.Range(5, 10)));
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			_player1.UnequipArmor();
		}
		if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			_player1.EquipArmor(new Armor("Armadura", Random.Range(1, 5)));
		}
		if (Input.GetKeyDown(KeyCode.Alpha7))
		{
			_player1.Provoke();
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			_player2.Attack(_player1);
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			_player2.SharpenWeapon();
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			_player2.UnequipWeapon();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			_player2.EquipWeapon(new Weapon("Arma", Random.Range(5, 10)));
		}
		if (Input.GetKeyDown(KeyCode.T))
		{
			_player2.UnequipArmor();
		}
		if (Input.GetKeyDown(KeyCode.Y))
		{
			_player2.EquipArmor(new Armor("Armadura", Random.Range(1, 5)));
		}
		if (Input.GetKeyDown(KeyCode.U))
		{
			_player2.Provoke();
		}
	}
}
