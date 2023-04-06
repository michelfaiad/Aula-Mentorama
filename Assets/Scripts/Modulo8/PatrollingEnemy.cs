using UnityEngine;

public partial class PatrollingEnemy : MonoBehaviour
{
	private enum EnemyState
	{
		Stopped,
		Patrolling1,
		Patrolling2
	}

	public Patrol PatrolComponent;

	[SerializeField]
	private PatrolData _patrolData1;

	[SerializeField]
	private PatrolData _patrolData2;

	private EnemyState _currentEnemyState;

	PatrolData currentPatrolData;

	int patrolDataIndex;

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

				if (Input.GetKeyDown(KeyCode.Alpha1))
				{
					PatrolComponent.StartPatrolling(_patrolData1);
					_currentEnemyState = EnemyState.Patrolling1;
				}
				else if (Input.GetKeyDown(KeyCode.Alpha2))
				{
					PatrolComponent.StartPatrolling(_patrolData2);
					_currentEnemyState = EnemyState.Patrolling2;
				}

				break;

			case EnemyState.Patrolling1:
			case EnemyState.Patrolling2:

				if (Input.GetKeyDown(KeyCode.Space))
				{
					PatrolComponent.StopPatrolling();
					_currentEnemyState = EnemyState.Stopped;
				}

				break;
		}
	}

}
