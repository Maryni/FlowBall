using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxDestroyer : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private List<GameObject> boxes;

    #endregion 
    
    #region private variables
    
    private int destroyCount=0;
    /// <summary>
    /// But before third collision
    /// </summary>
    private UnityAction actionOnAllCollision;
    private UnityAction actionOnThirdCollision;

    
    #endregion

    #region properties

    public int DestroyCount => destroyCount;
    public List<GameObject> Boxes => boxes;

    #endregion

    #region Unity functions

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<DestructableBox>())
        {
            collision.gameObject.SetActive(false);
            boxes.Add(collision.gameObject);
            destroyCount++;
            actionOnAllCollision?.Invoke();
            if (destroyCount == 3)
            {
                actionOnThirdCollision?.Invoke();
                SetCountZero();
            }
        }
    }
    
    #endregion

    #region public functions

    public void SetActionOnAllCollision(params UnityAction[] actions)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actionOnAllCollision += actions[i];
        }
    }
    public void SetActionOnThirdCollision(UnityAction action)
    {
        actionOnThirdCollision += action;
    }

    public void SetBoxesActive()
    {
        for (int i = 0; i < boxes.Count; i++)
        {
            boxes[i].SetActive(true);
        }
    }
    
    public void SetCountZero()
    {
        destroyCount = 0;
    }

    #endregion
    


    
}
