using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Walls : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private MoveToTarget moveToTarget;

    #endregion

    #region private variables

    private Vector3 currentDirection;
    private Vector3 reflectedDirection;
    private UnityAction actionOnStartCollision;
    private UnityAction actionOnFinishCollision;

    #endregion

    #region properties

    public Vector3 ReflectedDirection => reflectedDirection;

    #endregion

    #region Unity functions

    private void OnCollisionEnter(Collision collision)
    {
        SetReflectDirection(collision);

    }

    #endregion

    #region public functions

    public void SetCurrentDirection(Vector3 direction)
    {
        currentDirection = direction;
    }

    public void SetActionOnStartCollision(params UnityAction[] action)
    {
        for (int i = 0; i < action.Length; i++)
        {
            actionOnStartCollision += action[i];  
        }
    }
    public void SetActionOnFinishCollision(params UnityAction[] action)
    {
        for (int i = 0; i < action.Length; i++)
        {
            actionOnFinishCollision += action[i];  
        }
        
    }
    
    // public void UseReflectedDirection()
    // {
    //     Debug.Log($"reflectedDirection = {reflectedDirection}");
    //     moveToTarget.SetDirection(reflectedDirection);
    //     moveToTarget.UseForce(); 
    //     // moveToTarget.SetTargetPosition(thisPosition);
    //     // moveToTarget.SetTargetPositionEnd(thisPosition - reflectedDirection);
    //
    // }
    
    #endregion
    
    #region private functions

    private void SetReflectDirection(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        { 
            actionOnStartCollision?.Invoke();
            if (collision.gameObject.name == "Wall1")
            {
                reflectedDirection = Vector3.Reflect(currentDirection, new Vector3(0, 0, -1)); 
            }
            if(collision.gameObject.name == "Wall2")
            {
                reflectedDirection = Vector3.Reflect(currentDirection, new Vector3(0, 0, 1));
            }
            if (collision.gameObject.name == "Wall3")
            {
                reflectedDirection = Vector3.Reflect(currentDirection, new Vector3(-1, 0, 0));
            }
            if (collision.gameObject.name == "Wall4")
            {
                reflectedDirection = Vector3.Reflect(currentDirection, new Vector3(1, 0, 0));
            }
            Debug.Log($"bum, with current direction = {currentDirection}");
            actionOnFinishCollision?.Invoke();    
        }
    }


    #endregion
    
    
}
