using UnityEngine;

public class Move : MonoBehaviour
{
	public float Speed;
	public Vector3 Direction;

	void Update()
	{
		Translate(Direction * Speed * Time.deltaTime);
	}

	void Translate(Vector3 translation)
	{
		transform.position = transform.position + translation;
	}
}
