using System.Collections.Generic;
using UnityEngine;

public class AILocomotion : AIBehaviourBase
{
    [SerializeField] private ETeam _aiTeam;
    [SerializeField] private float _maxProjectileDetectionDistance = 2.0f;
    [SerializeField] private float _minProjectileDetectionDistance = 1.0f;
    private List<Transform> _evadableObjects = new List<Transform>();
    private EBehaviourType _behaviourType = EBehaviourType.Passive;
    private Transform _nearestEvadableObject = null;
    private float _dodgeBehaviourPercentaje = 0;

    public EBehaviourType BehaviourType { get => _behaviourType; set => _behaviourType = value; }

    private void Update()
    {
        EvaluateNearestProyectile();
        _aiInputSignal.RotationInputPress((1 - GetDodgePercentage()) * FollowPlayerBehaviour() + GetDodgePercentage() * EvadeProyectilesBehaviour());
    }

    private void EvaluateNearestProyectile()
    {
        if (_evadableObjects.Count == 0)
        {
            _dodgeBehaviourPercentaje = 0.0f;
            _nearestEvadableObject = null;
            return;
        }

        float nearestDistance = Vector2.Distance(_referenceTransform.position, _evadableObjects[0].position);
        float currentDistance = 0.0f;
        _nearestEvadableObject = _evadableObjects[0];

        for (int i = 1; i < _evadableObjects.Count; i++)
        {
            currentDistance = Vector2.Distance(_referenceTransform.position, _evadableObjects[i].position);
            if (currentDistance < nearestDistance)
            {
                nearestDistance = currentDistance;
                _nearestEvadableObject = _evadableObjects[i];
            }
        }

        if (nearestDistance < _minProjectileDetectionDistance)
        {
            nearestDistance = _minProjectileDetectionDistance;
        }
        if (nearestDistance > _maxProjectileDetectionDistance)
        {
            _dodgeBehaviourPercentaje = 0.0f;
        }
        else
        {
            _dodgeBehaviourPercentaje = 1 - ((nearestDistance - _minProjectileDetectionDistance) / (_maxProjectileDetectionDistance - _minProjectileDetectionDistance));
        }
    }

    private float FollowPlayerBehaviour()
    {
        return Vector2.Dot(
            _referenceTransform.right,
            (_playerTransform.position - _referenceTransform.position).normalized
            );
    }

    public float EvadeProyectilesBehaviour()
    {
        if (_nearestEvadableObject == null)
        {
            return 0.0f;
        }
        if (Vector2.Distance(_nearestEvadableObject.position, _referenceTransform.position) > _maxProjectileDetectionDistance)
        {
            return 0.0f;
        }
        return - Vector2.Dot(
            _referenceTransform.right,
            (_nearestEvadableObject.position - _referenceTransform.position).normalized
            );
    }

    private float GetDodgePercentage()
    {
        switch (BehaviourType)
        {
            case EBehaviourType.Passive:
                return _dodgeBehaviourPercentaje;
            case EBehaviourType.Agressive:
                return _dodgeBehaviourPercentaje * 0.7f;
            case EBehaviourType.VeryAgressive:
                return _dodgeBehaviourPercentaje * 0.4f;
            default:
                return _dodgeBehaviourPercentaje;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DamageDealer damageDealer))
        {
            if (damageDealer.Team != _aiTeam)
            {
                _evadableObjects.Add(damageDealer.transform);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_evadableObjects.Contains(collision.transform))
        {
            _evadableObjects.Remove(collision.transform);
        }
    }
}
