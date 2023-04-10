using System;
using UnityEngine;

public class Program : MonoBehaviour
{
	public event Action<Character> OnPlayer1StatusChange;
	public event Action<Character> OnPlayer2StatusChange;

	private Character _player1;
	private Character _player2;

	void Start()
	{
		var sword = new Weapon("Sword", 8);
		var plate = new Armor("Breast Plate", 3);
		_player1 = new Orc("Growl", 100, sword, plate);

		OnPlayer1StatusChange?.Invoke(_player1);

		var dagger = new Weapon("Dagger", 6);
		var complete = new Armor("Complete Armor", 6);
		_player2 = new Elf("Ana", 90, dagger, complete);

		OnPlayer2StatusChange?.Invoke(_player2);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			_player1.Attack(_player2);
			OnPlayer2StatusChange?.Invoke(_player2);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			_player1.SharpenWeapon();
			OnPlayer1StatusChange?.Invoke(_player1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			_player1.UnequipWeapon();
			OnPlayer1StatusChange?.Invoke(_player1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			_player1.EquipWeapon(new Weapon("Arma", UnityEngine.Random.Range(5, 10)));
			OnPlayer1StatusChange?.Invoke(_player1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			_player1.UnequipArmor();
			OnPlayer1StatusChange?.Invoke(_player1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			_player1.EquipArmor(new Armor("Armadura", UnityEngine.Random.Range(1, 5)));
			OnPlayer1StatusChange?.Invoke(_player1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha7))
		{
			_player1.Provoke();
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			_player2.Attack(_player1);
			OnPlayer1StatusChange?.Invoke(_player1);
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			_player2.SharpenWeapon();
			OnPlayer2StatusChange?.Invoke(_player2);
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			_player2.UnequipWeapon();
			OnPlayer2StatusChange?.Invoke(_player2);
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			_player2.EquipWeapon(new Weapon("Arma", UnityEngine.Random.Range(5, 10)));
			OnPlayer2StatusChange?.Invoke(_player2);
		}
		if (Input.GetKeyDown(KeyCode.T))
		{
			_player2.UnequipArmor();
			OnPlayer2StatusChange?.Invoke(_player2);
		}
		if (Input.GetKeyDown(KeyCode.Y))
		{
			_player2.EquipArmor(new Armor("Armadura", UnityEngine.Random.Range(1, 5)));
			OnPlayer2StatusChange?.Invoke(_player2);
		}
		if (Input.GetKeyDown(KeyCode.U))
		{
			_player2.Provoke();
		}
	}
}
