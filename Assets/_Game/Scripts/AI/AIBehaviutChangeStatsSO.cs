using UnityEngine;

[CreateAssetMenu(fileName = "AI BehaviourChange Stats", menuName = "ScriptableObjects/System/AI/New beaviour Stats", order = 1)]

public class AIBehaviutChangeStatsSO : ScriptableObject
{
    [SerializeField] private float passiveBehaviourPercentaje = 0.33f;
    [SerializeField] private float agressiveBehaviourPercentaje = 0.33f;
    [SerializeField] private float veryAgressiveBehaviourPercentaje = 0.33f;

    public float PassiveBehaviourPercentaje { get => passiveBehaviourPercentaje;}
    public float AgressiveBehaviourPercentaje { get => agressiveBehaviourPercentaje;}
    public float VeryAgressiveBehaviourPercentaje { get => veryAgressiveBehaviourPercentaje;}
}
