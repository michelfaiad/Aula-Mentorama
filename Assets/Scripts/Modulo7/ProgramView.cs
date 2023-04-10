using TMPro;
using UnityEngine;

public class ProgramView : MonoBehaviour
{
	[SerializeField] Program program;

	[Header("Player 1 interface")]
	[SerializeField] TextMeshProUGUI p1Name;
	[SerializeField] TextMeshProUGUI p1Weapon;
	[SerializeField] TextMeshProUGUI p1Damage;
	[SerializeField] TextMeshProUGUI p1Armor;
	[SerializeField] TextMeshProUGUI p1Resistance;
	[SerializeField] TextMeshProUGUI p1Life;
	[SerializeField] TextMeshProUGUI p1Alive;

	[Header("Player 2 interface")]
	[SerializeField] TextMeshProUGUI p2Name;
	[SerializeField] TextMeshProUGUI p2Weapon;
	[SerializeField] TextMeshProUGUI p2Damage;
	[SerializeField] TextMeshProUGUI p2Armor;
	[SerializeField] TextMeshProUGUI p2Resistance;
	[SerializeField] TextMeshProUGUI p2Life;
	[SerializeField] TextMeshProUGUI p2Alive;

	void Start()
	{
		program.OnStartGame += StartGameEventHandler;
		program.OnPlayer1StatusChange += Player1StatusChangeEventHandler;
		program.OnPlayer2StatusChange += Player2StatusChangeEventHandler;
	}

	private void StartGameEventHandler(Character player1, Character player2)
	{
		p1Name.text = $"Name: {player1.Name}";
		p1Weapon.text = $"Weapon: {player1.Weapon.Name}";
		p1Damage.text = $"Damage: {player1.Weapon.Damage}";
		p1Armor.text = $"Armor: {player1.Armor.Name}";
		p1Resistance.text = $"Resistance: {player1.Armor.Resistance}";
		p1Life.text = $"Life: {player1.Life}";
		p1Alive.text = "Alive";

		p2Name.text = $"Name: {player2.Name}";
		p2Weapon.text = $"Weapon: {player2.Weapon.Name}";
		p2Damage.text = $"Damage: {player2.Weapon.Damage}";
		p2Armor.text = $"Armor: {player2.Armor.Name}";
		p2Resistance.text = $"Resistance: {player2.Armor.Resistance}";
		p2Life.text = $"Life: {player2.Life}";
		p2Alive.text = "Alive";
	}

	private void Player1StatusChangeEventHandler(Character player)
	{
		p1Name.text = $"Name: {player.Name}";
		p1Weapon.text = $"Weapon: {(player.Weapon != null ? player.Weapon.Name : "No Weapon")}";
		p1Damage.text = $"Damage: {(player.Weapon != null ? player.Weapon.Damage : 0)}";
		p1Armor.text = $"Armor: {(player.Armor != null ? player.Armor.Name : "No Armor")}";
		p1Resistance.text = $"Resistance: {(player.Armor != null ? player.Armor.Resistance : 0)}";
		p1Life.text = $"Life: {player.Life}";
		p1Alive.text = player.IsAlive ? "Alive" : "Dead";
	}

	private void Player2StatusChangeEventHandler(Character player)
	{
		p2Name.text = $"Name: {player.Name}";
		p2Weapon.text = $"Weapon: {(player.Weapon != null ? player.Weapon.Name : "No Weapon")}";
		p2Damage.text = $"Damage: {(player.Weapon != null ? player.Weapon.Damage : 0)}";
		p2Armor.text = $"Armor: {(player.Armor != null ? player.Armor.Name : "No Armor")}";
		p2Resistance.text = $"Resistance: {(player.Armor != null ? player.Armor.Resistance : 0)}";
		p2Life.text = $"Life: {player.Life}";
		p2Alive.text = player.IsAlive ? "Alive" : "Dead";
	}
}
