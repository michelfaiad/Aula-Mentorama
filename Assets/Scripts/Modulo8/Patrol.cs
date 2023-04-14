using UnityEngine;

public class Patrol : MonoBehaviour
{
	public enum PatrolState
	{
		Idle,
		PatrolRight,
		PatrolLeft,
		PatrolUp,
		PatrolDown
	}

	public Move MoveComponent;

	private PatrolData _patrolData;
	private PatrolState _patrolState;
	private PatrolState _nextPatrolState;

	private float _idleTimer;

	private bool _isPatrolling = false;

	public void StartPatrolling(PatrolData patrolData)
	{
		_isPatrolling = true;
		_patrolData = patrolData;

		_idleTimer = 0;

		_patrolState = PatrolState.PatrolRight;
	}

	public void StopPatrolling()
	{
		MoveComponent.Direction = Vector3.zero;
		MoveComponent.Speed = 0;

		_isPatrolling = false;
	}

	private void Update()
	{
		if (!_isPatrolling) return;

		switch (_patrolState)
		{
			default:
			case PatrolState.Idle:

				MoveInDirection(Vector3.zero, 0f);
				IdleRest();

				break;

			case PatrolState.PatrolRight:

				MoveInDirection(Vector3.right, _patrolData.MoveSpeed);

				break;

			case PatrolState.PatrolLeft:

				MoveInDirection(Vector3.left, _patrolData.MoveSpeed);

				break;

			case PatrolState.PatrolUp:

				MoveInDirection(Vector3.forward, _patrolData.MoveSpeed);

				break;

			case PatrolState.PatrolDown:

				MoveInDirection(Vector3.back, _patrolData.MoveSpeed);

				break;
		}
	}

	private void IdleRest()
	{
		_idleTimer += Time.deltaTime;

		if (_idleTimer >= _patrolData.RestingDuration)
		{
			_patrolState = _nextPatrolState;
			_idleTimer = 0;
		}
	}

	private void MoveInDirection(Vector3 direction, float speed)
	{
		MoveComponent.Direction = direction;
		MoveComponent.Speed = speed;
	}

	private void OnTriggerEnter(Collider other)
	{
		_patrolState = PatrolState.Idle;
		_nextPatrolState = other.GetComponent<TriggerController>().GetNewState();
	}

}
