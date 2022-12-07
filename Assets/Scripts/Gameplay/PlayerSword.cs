using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    bool isAttacking = false;

    public bool isInverting = false;

    public static Queue<iCommand> commandList;

    private void Start()
    {
        commandList = new Queue<iCommand>();
    }

    public void OnAttack()
    {
        isAttacking = true;
        commandList.Enqueue(new MissingDuckCommand());
    }

    public void OnTriggerEnter(Collider col)
    {
       if(col.tag == "Enemy" && isAttacking == true)
        {
            EnemyController enemy = col.GetComponent<EnemyController>();
            enemy.DestroyEnemy();
            isAttacking = false;
            if(commandList.Count > 0)
            {
                commandList.Dequeue();
            }
            ScoreManager.instance.ScoreOnChange(1);
        }
    }

    public void Checked()
    {
        Debug.Log("MISSING:" + commandList.Count);
        isInverting = commandList.Count >= 2;
    }
}
