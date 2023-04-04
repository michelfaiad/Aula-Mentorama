using System;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
	enum EnemyState
	{
		Stopped,
		Resting,
		Patrolling
	}

	enum PatrolDirection
	{
		Left,
		Right,
		Up,
		Down
	}

	[Serializable]
	struct PatrolData
	{
		public float PatrolDuration;
		public float MoveSpeed;
		public float MoveDirectionDuration;
		public float RestingDuration;
	}

	[SerializeField]
	List<PatrolData> patrolDataList;

	EnemyState currentEnemyState;

	PatrolData currentPatrolData;

	int patrolDataIndex;

	PatrolDirection currentPatrolDirection;

	float startPatrolTime;

	float startRestingTime;

	float directionChangeTime;

	void Start()
	{
		currentEnemyState = EnemyState.Stopped;
		currentPatrolDirection = PatrolDirection.Right;
		directionChangeTime = 0;
		patrolDataIndex = 0;
	}

	void Update()
	{
		switch (currentEnemyState)
		{
			default:
			case EnemyState.Stopped:

				if (Input.GetKeyDown(KeyCode.Space))
				{
					UpdatePatrolData();
					currentEnemyState = EnemyState.Patrolling;
					startPatrolTime = Time.time;
				}

				break;

			case EnemyState.Resting:

				RestRoutine(currentPatrolData);

				break;

			case EnemyState.Patrolling:

				if (Time.time > startPatrolTime + currentPatrolData.PatrolDuration)
				{
					currentEnemyState = EnemyState.Stopped;
					startPatrolTime = 0;
				}
				else
				{
					PatrolRoutine(currentPatrolData);
				}

				break;
		}
	}

	void PatrolRoutine(PatrolData patrolData)
	{
		directionChangeTime += Time.deltaTime;

		switch (currentPatrolDirection)
		{
			case PatrolDirection.Right:

				ChangePatrolDirection(patrolData, PatrolDirection.Up);

				Translate(new Vector3(patrolData.MoveSpeed * Time.deltaTime, 0f, 0f));

				break;

			case PatrolDirection.Up:

				ChangePatrolDirection(patrolData, PatrolDirection.Left);

				Translate(new Vector3(0f, 0f, patrolData.MoveSpeed * Time.deltaTime));

				break;

			case PatrolDirection.Left:

				ChangePatrolDirection(patrolData, PatrolDirection.Down);

				Translate(new Vector3(-patrolData.MoveSpeed * Time.deltaTime, 0f, 0f));

				break;

			case PatrolDirection.Down:

				ChangePatrolDirection(patrolData, PatrolDirection.Right);

				Translate(new Vector3(0f, 0f, -patrolData.MoveSpeed * Time.deltaTime));

				break;
		}
	}

	void RestRoutine(PatrolData patrolData)
	{
		if (Time.time > startRestingTime + patrolData.RestingDuration)
		{
			currentEnemyState = EnemyState.Patrolling;
		}
	}

	void ChangePatrolDirection(PatrolData patrolData, PatrolDirection newPatrolDirection)
	{
		if (directionChangeTime > patrolData.MoveDirectionDuration)
		{
			currentPatrolDirection = newPatrolDirection;
			directionChangeTime = 0;
			startRestingTime = Time.time;
			currentEnemyState = EnemyState.Resting;
		}
	}

	void Translate(Vector3 translation)
	{
		transform.position = transform.position + translation;
	}

	void UpdatePatrolData()
	{
		if (patrolDataList.Count > 0)
		{
			currentPatrolData = patrolDataList[patrolDataIndex++];

			if (patrolDataIndex > patrolDataList.Count - 1) patrolDataIndex = 0;
		}
	}
}
