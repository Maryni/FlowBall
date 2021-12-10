using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private TakeMousePosition takeMousePosition;
    [SerializeField] private MoveToTarget moveToTarget;
    [SerializeField] private ProtectorAgent protectorAgent;
    [SerializeField] private LevelChanger levelChanger;
    [SerializeField] private BoxDestroyer boxDestroyer;
    
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

        if (boxDestroyer == null)
        {
            boxDestroyer = moveToTarget.gameObject.GetComponent<BoxDestroyer>();
        }
        SetActionsOnStart();
    }

    #endregion

    #region private functions

    private void SetActionsOnStart()
    {
        takeMousePosition.SetCamera(Camera.main);
        levelChanger.SetAction(()=>protectorAgent.PlayerResetPosition());
        boxDestroyer.SetAction(()=>levelChanger.ChangeLevel());
    }

    #endregion
}
