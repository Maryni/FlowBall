using UnityEngine;
using UnityEngine.AI;

public class ProtectorAgent : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Transform player;
    [SerializeField] public Vector3 playerCheckPosition;
    [SerializeField] public Vector3 agentCheckPosition;
    [SerializeField] private MoveToTarget moveToTarget;

    #endregion

    #region Unity functions
    
    private void Start()
    {
        playerCheckPosition = player.position;
        agentCheckPosition = transform.position;
    }
    private void FixedUpdate()
    {
        Protection();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="Ball")
        {
            collision.gameObject.transform.Translate(playerCheckPosition);
            PlayerResetPosition();
        }  
    }
    
    #endregion

    #region public functions

    public void PlayerResetPosition()
    {
        moveToTarget.ResetPoints();
        player.position = playerCheckPosition;
        transform.position = agentCheckPosition;
    }

    #endregion

    #region private functions

    private void Protection()
    {
        navMeshAgent.destination = player.transform.position; 
    }

    #endregion



}
