using System;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    #region Inspector variables
    
    [SerializeField] private float modVelocity; 
    
    [SerializeField] private bool moveSecondVar;

    #endregion

    #region private variables
    
    [SerializeField]private Vector3 targPos;
    [SerializeField]private Vector3 targPosEnd;
    [SerializeField]private Vector3 direction;
    private float magnitudeDirection;
    private float tempMagnitedeDirection;
    private Rigidbody rig;
    
    #endregion

    #region properties

    public bool MoveSecondVariant => moveSecondVar;
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
    }

    private void FixedUpdate()
    {
        Debug.DrawLine(rig.velocity,rig.velocity * 10f,Color.black);
        //Move();
    }

    #endregion

    #region public functions
    
    public void Move()
    {
        if (targPos != Vector3.zero && targPosEnd != Vector3.zero)
        {
            SetDirection();
            SetMagnitude();
            if (magnitudeDirection >= 1)
            {
                UseForce();  
            }
            Debug.Log(magnitudeDirection);
            //transform.position = transform.position + (direction * mod);
        }
    }
    
    /// <summary>
    /// Метод чтобы сделать rb.velocity с другого класса, не подключая дополнительно rigidbody 
    /// </summary>
    public void UseForce()
    {
        rig.velocity = direction * modVelocity * magnitudeDirection;
        Debug.Log($"direction = {direction} | modVelocity = {modVelocity} | magnitude = {magnitudeDirection}, and rig.velocity = {rig.velocity}");  
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
    
    /// <summary>
    /// Переключение типа движения таблетки, через меню в паузе
    /// </summary>
    public void MoveSecondVar()
    {
        moveSecondVar = !moveSecondVar;
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

    private void SetMagnitude()
    {
        if (tempMagnitedeDirection == 0)
        {
            magnitudeDirection = (targPos - targPosEnd).magnitude;  
        }
        if (magnitudeDirection < 1)
        {
            magnitudeDirection = 1;
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