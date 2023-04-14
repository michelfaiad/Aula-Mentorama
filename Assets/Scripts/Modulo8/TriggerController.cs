using UnityEngine;

public class TriggerController : MonoBehaviour
{
	[SerializeField] Patrol.PatrolState _newState;

	public Patrol.PatrolState GetNewState()
	{
		return _newState;
	}

}
