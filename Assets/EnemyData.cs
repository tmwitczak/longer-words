using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public List<float> health;
    public List<float> multiplier;
    public List<float[]> position;

    public EnemyData(List<Enemy> enemy)
    {
        enemy = new List<Enemy>();
        {
            for (int i = 0; i < enemy.Count; i++)
            {
                health[i] = enemy[i].getHealth();
                multiplier[i] = enemy[i].getMultiplier();

                position[i] = new float[3];
                position[i][0] = enemy[i].transform.position.x;
                position[i][1] = enemy[i].transform.position.y;
                position[i][2] = enemy[i].transform.position.z;
            }
        }
    }
        

}
