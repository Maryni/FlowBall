using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] Text textField;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] BoxDestroyer boxDestroyer;
    [SerializeField] ProtectorAgent protectorAgent;

    /// <summary>
    /// Когда кол-во DestroyCount от ящиков = 3, лвл ++, и заново
    /// </summary>
    public void ChangeLevel()
    {
        if(boxDestroyer.DestroyCount==3)
        {
            int a = int.Parse(textField.text); 
            a++;
            textField.text = a.ToString();
            for(int i =0; i<3;i++)
            {
                boxDestroyer.boxes[i].gameObject.SetActive(true);
            }
            protectorAgent.PlayerResetPosition();
            navMeshAgent.speed += 0.5f;
            boxDestroyer.DestroyCount = 0;
        }
    }
}
