using UnityEngine;
using UnityEngine.AI;

public class ProtectorAgent : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Transform player;
    [SerializeField] public Vector3 playerCheckPosition;
    [SerializeField] public Vector3 agentCheckPosition;
    [SerializeField] MoveToTarget moveToTarget;
    private void Start()
    {
        playerCheckPosition = player.position;
        agentCheckPosition = transform.position;
    }
    private void FixedUpdate()
    {
        Protecioon();
    }
    void Protecioon()
    {
        navMeshAgent.destination = player.transform.position; 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="Ball")
        {
            collision.gameObject.transform.Translate(playerCheckPosition);
            PlayerResetPosition();
        }  
    }
    public void PlayerResetPosition()
    {
        moveToTarget.ResetPoints();
        player.position = playerCheckPosition;
        transform.position = agentCheckPosition;
    }
}
