using UnityEngine;

public class DrawArrow : MonoBehaviour
{
    
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 endPosition;
    [SerializeField] Transform pointToLook;
    [SerializeField] Transform transformStartPos;
    Transform _temp;
    [SerializeField] MoveToTarget moveToTarget;
    private void FixedUpdate()
    {
        TakePositionForDrawing();
        Strech(gameObject, startPosition, endPosition);
    }

    public void Strech(GameObject _sprite, Vector3 _initialPosition, Vector3 _finalPosition)
    {
        Vector3 centerPos = (_initialPosition + _finalPosition) / 2f;
        _sprite.transform.position = centerPos;
        Vector3 direction = (_finalPosition - _initialPosition).normalized;
        _sprite.transform.right = direction;
        Vector3 scale = new Vector3(1, 4, 1); //именно поэтому scale.y 4 а не 1, тогда стрелка более толстая и её хорошо видно
        scale.x = Vector3.Distance(_initialPosition, _finalPosition);
        _temp = _sprite.transform;
        _sprite.transform.localScale = scale/32; //это идеальные значения чтобы стрелку было видно
        _sprite.transform.rotation = Quaternion.Euler(270, _temp.rotation.eulerAngles.y, _temp.rotation.eulerAngles.z); //ставим угол по X 90, тоесть стрелка нормально видна
        if(moveToTarget.moveSecondVar)
            moveToTarget.ChangeMod((int)(scale.x/8)); //и отдаём mod половину от scale.x, тоесть половину разницы меж точкой A и B
    }
    void TakePositionForDrawing()
    {
        if (moveToTarget.moveSecondVar)
        {
            startPosition = transformStartPos.position;
            endPosition = moveToTarget.targPos;
        }else
            {
            startPosition = moveToTarget.targPosEnd;
            endPosition = moveToTarget.targPos;
            }
    }
}
