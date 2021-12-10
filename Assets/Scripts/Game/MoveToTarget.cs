using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    #region Inspector variables
    
    [SerializeField] private float modVelocity;
    [SerializeField] private float modReducedVelocity;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Vector3 targPos;
    [SerializeField] private Vector3 targPosEnd;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Rigidbody rig;
    [SerializeField] private bool moveSecondVar;

    #endregion

    #region properties

    public bool MoveSecondVariant => moveSecondVar;
    public Vector3 Direction => direction;
    public Vector3 TargetPosition => targPos;
    public Vector3 TargetPositionEnd => targPosEnd;

    #endregion

    #region Unity functions

    private void FixedUpdate()
    {
        Move();
    }

    #endregion

    #region public functions

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
    public void Move()
    {
        if (moveSecondVar)      //Если делаем вектор в сторону куба(синего)
        {
            targPosEnd = transform.position;
        } 
    
    
        if (targPos != Vector3.zero && targPosEnd != Vector3.zero)
        {
            direction = (targPos - targPosEnd).normalized;
            direction.y = 0;
            UseForce(false);
            //transform.position = transform.position + (direction * mod);
        }
    }
    /// <summary>
    /// Метод чтобы сделать rb.AddForce() с другого класса, не подключая дополнительно rigidbody 
    /// </summary>
    public void UseForce(bool usingWall)
    {
        if (!usingWall)
        {
            rig.AddForce(direction * modVelocity, ForceMode.VelocityChange);
        }
        else
        {
            rig.AddForce(direction * modVelocity * modReducedVelocity, ForceMode.VelocityChange);
        }
   
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

    #endregion
    
}