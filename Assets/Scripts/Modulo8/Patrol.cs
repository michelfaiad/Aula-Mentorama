using UnityEngine;

public class Patrol : MonoBehaviour
{
	private enum PatrolState
	{
		Idle,
		PatrollingRight,
		PatrollingLeft
	}

	public Move MoveComponent;

	private PatrolData _patrolData;
	private PatrolState _patrolState;
	private PatrolState _lastMoveDirection;

	private float _idleTimer;
	private float _moveTimer;

	private bool _isPatrolling = false;

	public void StartPatrolling(PatrolData patrolData)
	{
		_isPatrolling = true;
		_patrolData = patrolData;

		_idleTimer = 0;
		_moveTimer = 0;

		_patrolState = PatrolState.Idle;
		_lastMoveDirection = PatrolState.PatrollingLeft;
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
				_idleTimer += Time.deltaTime;

				if (_idleTimer >= _patrolData.RestingDuration)
				{
					if (_lastMoveDirection == PatrolState.PatrollingLeft)
					{
						_patrolState = PatrolState.PatrollingRight;
						MoveComponent.Direction = Vector3.right;
					}
					else
					{
						_patrolState = PatrolState.PatrollingLeft;
						MoveComponent.Direction = Vector3.left;
					}

					MoveComponent.Speed = _patrolData.MoveSpeed;
					_idleTimer = 0;
				}

				break;

			case PatrolState.PatrollingRight:
			case PatrolState.PatrollingLeft:
				_moveTimer += Time.deltaTime;

				if (_moveTimer >= _patrolData.MoveDuration)
				{
					_lastMoveDirection = _patrolState;
					_patrolState = PatrolState.Idle;
					_moveTimer = 0;

					MoveComponent.Speed = 0;
				}

				break;
		}
	}

}
