using System;
using UnityEngine;

public class DrawArrow : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject point;

    #endregion

    #region private variables
    
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Transform tempTransform;
    private int scaleMod = 32;

    #endregion

    #region public funtions

    public void SetStartPoint(GameObject gameObject)
    {
        player = gameObject;
    }
    
    public void SetEndPoint(GameObject gameObject)
    {
        point = gameObject;
    }

    public void Draw()
    {
        SetPoints();
        Strech(gameObject, startPosition, endPosition);
    }
    
    #endregion
    
    #region private functions

    private void Strech(GameObject sprite, Vector3 initialPosition, Vector3 finalPosition)
    {
        Vector3 centerPos = (initialPosition + finalPosition) / 2f;
        sprite.transform.position = centerPos;
        Vector3 direction = (finalPosition - initialPosition).normalized;
        sprite.transform.right = direction;
        Vector3 scale = new Vector3(1, 3, 1); //magic numbers for set good view on arrow
        scale.x = Vector3.Distance(initialPosition, finalPosition);
        tempTransform = sprite.transform;
        sprite.transform.localScale = scale/scaleMod; 
        sprite.transform.rotation = Quaternion.Euler(
            270, 
            tempTransform.rotation.eulerAngles.y, 
            tempTransform.rotation.eulerAngles.z); 
        
    }

    private void SetPoints()
    {
        endPosition = player.transform.position;;
        startPosition = point.transform.position;
    }

    #endregion
 
}
