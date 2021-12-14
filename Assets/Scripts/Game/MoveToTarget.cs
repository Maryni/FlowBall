using System;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    #region Inspector variables
    
    [SerializeField] private float modVelocity;

    #endregion

    #region private variables
    
    private Vector3 targPos;
    private Vector3 targPosEnd;
    private Vector3 direction;
    private float magnitudeDirection;
    private float tempMagnitedeDirection;
    private Rigidbody rig;
    private Vector3 defaultPosition;
    
    #endregion

    #region properties
    
    public Vector3 Direction => direction;
    public Vector3 TargetPosition => targPos;
    public Vector3 TargetPositionEnd => targPosEnd;

    #endregion

    #region Unity functions

    private void Start()
    {
        tempMagnitedeDirection = magnitudeDirection;
        if (rig == null)
        {
            rig = GetComponent<Rigidbody>();
        }

        defaultPosition = transform.position;
    }

    #endregion

    #region public functions
    
    public void Move(bool recalculateMagnitude)
    {
        if (targPos != Vector3.zero && targPosEnd != Vector3.zero)
        {
            SetDirection();
            SetMagnitude(recalculateMagnitude);
            if (magnitudeDirection >= 1)
            {
                UseForce();  
            }
            Debug.Log(magnitudeDirection);
        }
    }
    
    public void UseForce()
    {
        rig.velocity = direction * modVelocity * magnitudeDirection;
    }
    
    /// <summary>
    /// Обнуленте векторов позиций, направления, и ускорения
    /// </summary>
    public void ResetPoints()
    {
        targPos = Vector3.zero;
        targPosEnd = Vector3.zero;
        direction = Vector3.zero;
        rig.velocity = Vector3.zero;
    }

    public void ResetPosition()
    {
        transform.position = defaultPosition;
    }

    public void ChangeMod(int change)
    {
        modVelocity = change; 
    }
    
    public void SetTargetPosition(Vector3 vector)
    {
        targPos = vector;
    }

    public void SetTargetPositionEnd(Vector3 vector)
    {
        targPosEnd = vector;
    }

    public void SetDirection(Vector3 vector)
    {
        direction = vector;
    }
    
    #endregion

    #region private functions

    private void SetDirection()
    {
        direction = (targPos - targPosEnd).normalized;
        direction.y = 0;  
    }

    private void SetMagnitude(bool recalculate)
    {
        if (tempMagnitedeDirection == 0 || recalculate)
        {
            magnitudeDirection = (targPos - targPosEnd).magnitude;  
        }
        //все дальнейшие значения это магические числа для более комфортного геймплея
        if (magnitudeDirection < 1)
        {
            magnitudeDirection = 1;
        }

        if (magnitudeDirection > 3.5f)
        {
            magnitudeDirection /= 2f;
        }
        
        if (magnitudeDirection > 10)
        {
            magnitudeDirection /= 10f;
        }
        
        if (tempMagnitedeDirection != magnitudeDirection)
        {
            tempMagnitedeDirection = magnitudeDirection;
        }
    }

    #endregion
}