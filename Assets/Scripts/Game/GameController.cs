using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private float addEnemySpeed;
    [SerializeField] private TakeMousePosition takeMousePosition;
    [SerializeField] private MoveToTarget moveToTarget;
    [SerializeField] private ProtectorAgent protectorAgent;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private LevelChanger levelChanger;
    [SerializeField] private BoxDestroyer boxDestroyer;
    [SerializeField] private Walls wallCollision;
    
    #endregion
    
    #region Unity functions

    private void Awake()
    {
        if (moveToTarget == null)
        {
            moveToTarget = FindObjectOfType<MoveToTarget>();
        }

        if (protectorAgent == null)
        {
            protectorAgent = FindObjectOfType<ProtectorAgent>();
        }

        if (navMeshAgent == null)
        {
            navMeshAgent = protectorAgent.gameObject.GetComponent<NavMeshAgent>();
        }

        if (boxDestroyer == null)
        {
            boxDestroyer = moveToTarget.gameObject.GetComponent<BoxDestroyer>();
        }

        if (wallCollision == null)
        {
            wallCollision = moveToTarget.gameObject.GetComponent<Walls>();
        }
        SetActionsOnStart();
    }

    #endregion

    #region private functions

    private void SetActionsOnStart()
    {
        takeMousePosition.SetCamera(Camera.main);
        takeMousePosition.SetActions(
            ()=>moveToTarget.SetTargetPosition(takeMousePosition.StartPoint),
            ()=>moveToTarget.SetTargetPositionEnd(takeMousePosition.EndPoint),
            ()=>moveToTarget.Move());
        wallCollision.SetActionOnStartCollision(()=>wallCollision.SetCurrentDirection(moveToTarget.Direction));
        wallCollision.SetActionOnFinishCollision(
            ()=>moveToTarget.SetDirection(wallCollision.ReflectedDirection),
            ()=>moveToTarget.UseForce());
        levelChanger.SetAction(
            ()=>boxDestroyer.SetBoxesActive(),
            ()=>navMeshAgent.speed+=addEnemySpeed,
            ()=>protectorAgent.PlayerResetPosition());
        boxDestroyer.SetAction(()=>levelChanger.ChangeLevel());
    }

    #endregion
}
