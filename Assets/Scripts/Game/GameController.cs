using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private float addEnemySpeed;
    private TakeMousePosition takeMousePosition;
    private MoveToTarget moveToTarget;
    private ProtectorAgent protectorAgent;
    private NavMeshAgent navMeshAgent;
    private LevelChanger levelChanger;
    private BoxDestroyer boxDestroyer;
    private Walls wallCollision;
    private GameObject blueBox;
    
    #endregion
    
    #region Unity functions

    private void Awake()
    {
        if (levelChanger == null)
        {
            levelChanger = GetComponent<LevelChanger>();
        }

        if (takeMousePosition == null)
        {
            takeMousePosition = GetComponent<TakeMousePosition>();
        }
        
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

        if (blueBox == null)
        {
            blueBox = FindObjectOfType<FindMe>().gameObject;
        }
        SetActionsOnStart();
    }

    #endregion

    #region private functions

    private void SetActionsOnStart()
    {
        takeMousePosition.SetCamera(Camera.main);
        takeMousePosition.SetBlueBox(blueBox);
        protectorAgent.SetPlayerTransform(moveToTarget.transform);
        protectorAgent.SetActionOnCollision(
            ()=>moveToTarget.ResetPoints(),
            () =>moveToTarget.ResetPosition());
        takeMousePosition.SetActions(
            ()=>moveToTarget.SetTargetPosition(moveToTarget.gameObject.transform.position),
            ()=>moveToTarget.SetTargetPositionEnd(takeMousePosition.EndPoint),
            ()=>moveToTarget.Move(true));
        wallCollision.SetActionsOnStartCollision(()=>wallCollision.SetCurrentDirection(moveToTarget.Direction));
        wallCollision.SetActionsOnFinishCollision(
            ()=>moveToTarget.SetDirection(-wallCollision.ReflectedDirection),
            ()=>moveToTarget.UseForce());
        levelChanger.SetActions(
            ()=>boxDestroyer.SetBoxesActive(),
            ()=>navMeshAgent.speed+=addEnemySpeed,
            ()=>protectorAgent.LevelResetPosition());
        boxDestroyer.SetActionOnAllCollision(()=>moveToTarget.Move(false));
        boxDestroyer.SetActionOnThirdCollision(()=>levelChanger.ChangeLevel());
    }

    #endregion
}
