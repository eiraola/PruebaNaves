using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBehaviourBase : MonoBehaviour
{
    const string TAG_PLAYER = "Player";

    [SerializeField] protected PlayerInputSignalSO _aiInputSignal;
    [SerializeField] protected GameObject _parentGameObject;
    [SerializeField] protected Transform _referenceTransform;
    protected Transform _playerTransform;
    protected virtual void Start()
    {
        LocatePlayer();
    }

    protected virtual void LocatePlayer()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(TAG_PLAYER);
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != _parentGameObject)
            {
                _playerTransform = gameObjects[i].transform;
            }
        }
    }
}
