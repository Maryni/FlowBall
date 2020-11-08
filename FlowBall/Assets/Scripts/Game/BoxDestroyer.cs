using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroyer : MonoBehaviour
{
    public int DestroyCount=0;
    [SerializeField] public List<GameObject> boxes;
    [SerializeField] LevelChanger levelChanger;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Box")
        {
            collision.gameObject.SetActive(false);
            boxes.Add(collision.gameObject);
            DestroyCount++;
            levelChanger.ChangeLevel();
            
        }
    }
}
