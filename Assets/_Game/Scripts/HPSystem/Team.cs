using UnityEngine;

public class Team : MonoBehaviour
{
    [SerializeField] private ETeam _teamID = 0;
    public ETeam TeamID { get => _teamID;}
}
