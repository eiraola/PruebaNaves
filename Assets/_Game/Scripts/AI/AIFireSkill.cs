using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFireSkill : AIBehaviourBase
{
    [SerializeField] private float _shootStartAngle = 90f;

    private void Update()
    {
        UseFireSkill();
    }

    public void UseFireSkill()
    {
        if (Vector2.Angle(-_referenceTransform.up, (_playerTransform.position - _referenceTransform.position).normalized) <= _shootStartAngle)
        {
            _aiInputSignal.FireInputPress();
        }
    }
}
