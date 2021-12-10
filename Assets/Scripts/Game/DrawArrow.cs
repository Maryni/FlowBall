using UnityEngine;

public class DrawArrow : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 endPosition;
    [SerializeField] Transform pointToLook;
    [SerializeField] Transform transformStartPos;
    [SerializeField] MoveToTarget moveToTarget;
    
    #endregion

    #region private varaibles

    Transform _temp;

    #endregion

    #region Unity functions

    private void FixedUpdate()
    {
        TakePositionForDrawing();
        Strech(gameObject, startPosition, endPosition);
    }

    #endregion

    #region public funtions

    public void Strech(GameObject sprite, Vector3 initialPosition, Vector3 finalPosition)
    {
        Vector3 centerPos = (initialPosition + finalPosition) / 2f;
        sprite.transform.position = centerPos;
        Vector3 direction = (finalPosition - initialPosition).normalized;
        sprite.transform.right = direction;
        Vector3 scale = new Vector3(1, 4, 1); //именно поэтому scale.y 4 а не 1, тогда стрелка более толстая и её хорошо видно
        scale.x = Vector3.Distance(initialPosition, finalPosition);
        _temp = sprite.transform;
        sprite.transform.localScale = scale/32; //это идеальные значения чтобы стрелку было видно
        sprite.transform.rotation = Quaternion.Euler(270, _temp.rotation.eulerAngles.y, _temp.rotation.eulerAngles.z); //ставим угол по X 90, тоесть стрелка нормально видна
        if(moveToTarget.MoveSecondVariant)
            moveToTarget.ChangeMod((int)(scale.x/8)); //и отдаём mod половину от scale.x, тоесть половину разницы меж точкой A и B
    }

    #endregion

    #region private functions

    private void TakePositionForDrawing()
    {
        if (moveToTarget.MoveSecondVariant)
        {
            startPosition = transformStartPos.position;
            endPosition = moveToTarget.TargetPosition;
        }
        else
        {
            startPosition = moveToTarget.TargetPositionEnd;
            endPosition = moveToTarget.TargetPosition;
        }
    }

    #endregion
 
}
