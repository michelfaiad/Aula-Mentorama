using UnityEngine;

public partial class PatrollingEnemy : MonoBehaviour
{
	private enum EnemyState
	{
		Stopped,
		Patrolling
	}

	public Patrol PatrolComponent;

	[SerializeField]
	private PatrolData _patrolData;

	private EnemyState _currentEnemyState;

	void Start()
	{
		_currentEnemyState = EnemyState.Stopped;
	}

	void Update()
	{
		switch (_currentEnemyState)
		{
			default:
			case EnemyState.Stopped:

				if (Input.GetKeyDown(KeyCode.Space))
				{
					PatrolComponent.StartPatrolling(_patrolData);
					_currentEnemyState = EnemyState.Patrolling;
				}

				break;

			case EnemyState.Patrolling:

				break;
		}
	}

}
