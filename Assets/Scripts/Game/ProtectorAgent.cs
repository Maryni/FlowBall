using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.XR.WSA.Input;

public class ProtectorAgent : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private Transform player;

    #endregion

    #region private variables

    private NavMeshAgent navMeshAgent;
    private Vector3 agentDefaultPosition;
    private UnityAction actionOnCollision;

    #endregion

    #region Unity functions
    
    private void Start()
    {
        if (navMeshAgent == null)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        agentDefaultPosition = transform.position;
    }
    private void FixedUpdate()
    {
        Protection();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<MoveToTarget>())
        {
            LevelResetPosition();
        }  
    }
    
    #endregion

    #region public functions

    public void LevelResetPosition()
    {
        actionOnCollision?.Invoke();
        transform.position = agentDefaultPosition;
    }

    public void SetPlayerTransform(Transform transformPlayer)
    {
        player = transformPlayer;
    }

    public void SetActionOnCollision(params UnityAction[] actions)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actionOnCollision += actions[i]; 
        }
    }
    #endregion

    #region private functions

    private void Protection()
    {
        navMeshAgent.destination = player.transform.position; 
    }

    #endregion



}
