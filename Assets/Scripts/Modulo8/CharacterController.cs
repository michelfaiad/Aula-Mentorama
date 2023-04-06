using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public Move MoveComponent;

	void Start()
	{
		MoveComponent.Direction = Vector3.zero;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			MoveComponent.Direction = Vector3.left;
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			MoveComponent.Direction = Vector3.right;
		}
		else if (Input.GetKeyDown(KeyCode.W))
		{
			MoveComponent.Direction = Vector3.forward;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			MoveComponent.Direction = Vector3.back;
		}
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			MoveComponent.Direction = Vector3.zero;
		}
	}
}
