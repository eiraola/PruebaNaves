using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoostSkill : AIBehaviourBase
{
    [SerializeField] private float _minBurstDistance = 1.0f;
    [SerializeField] private float _minBurstAngle = 25f;

    private void Update()
    {
        UseBoostSkill();
    }

    private void UseBoostSkill()
    {
        if (Vector2.Angle(-_referenceTransform.up, (_playerTransform.position - _referenceTransform.position).normalized) <= _minBurstAngle 
            && Vector2.Distance(_playerTransform.position, _referenceTransform.position) > _minBurstDistance)
        {
            _aiInputSignal.BoostInputPress();
        }
    }
}
