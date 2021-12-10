using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxDestroyer : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] public List<GameObject> boxes;
    [SerializeField] LevelChanger levelChanger;

    #endregion 
    
    #region private variables
    
    private int destroyCount=0;
    private UnityAction actionOnCollision;
    
    #endregion

    #region properties

    public int DestroyCount => destroyCount;

    #endregion



    #region Unity functions

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Box"))
        {
            collision.gameObject.SetActive(false);
            boxes.Add(collision.gameObject);
            destroyCount++;
            if (destroyCount == 3)
            {
                actionOnCollision?.Invoke();
                SetCountZero();
            }
            
        }
    }
    
    #endregion

    #region public functions

    public void SetAction(UnityAction action)
    {
        actionOnCollision = action;
    }
    
    public void SetCountZero()
    {
        destroyCount = 0;
    }

    #endregion
    


    
}
