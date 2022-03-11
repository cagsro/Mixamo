using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    //public GameObject character;
    public Image Fill;
    EnemyController enemy;
    
     //Start is called before the first frame update
    void Start()
    {
        enemy= GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        Fill.fillAmount=enemy.enemyHealth/enemy.enemyStartHealth;
    }
}
