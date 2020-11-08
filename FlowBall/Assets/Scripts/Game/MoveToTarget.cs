using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] float mod;
    [SerializeField] LayerMask layer;
    [SerializeField] public Vector3 targPos;
    [SerializeField] public Vector3 targPosEnd;
    [SerializeField] public Vector3 direction;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] public bool moveSecondVar;
    
    void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        if(moveSecondVar) targPosEnd = transform.position;  //Если делаем вектор в сторону куба(синего)
    
        if (targPos != Vector3.zero && targPosEnd != Vector3.zero)
            {
                direction = (targPos - targPosEnd).normalized;
                direction.y = 0;
                UseForce();
                //transform.position = transform.position + (direction * mod);
            }
    }
    /// <summary>
    /// Метод чтобы сделать rb.AddForce() с другого класса, не подключая дополнительно rigidbody 
    /// </summary>
    public void UseForce()
    {
        rigidbody.AddForce(direction * mod, ForceMode.VelocityChange);
    }
    /// <summary>
    /// Обнуленте векторов позиций и направления
    /// </summary>
    public void ResetPoints()
    {
        targPos = Vector3.zero;
        targPosEnd = Vector3.zero;
        direction = Vector3.zero;
    }
    /// <summary>
    /// Переключение типа движения таблетки, через меню в паузе
    /// </summary>
    public void MoveSecondVar() 
    { 
        if (!moveSecondVar) moveSecondVar = true; 
            else moveSecondVar = false; 
    }
    public void ChangeMod(int change)
    {
        mod = change; 
    }
}