using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    public float range=4f;
    public Transform target;
    public Transform partToRotate;
    public GameObject[] enemies;
    PlayerShooting player;
    
    public float enemyHealth;
    public float enemyStartHealth=100f;
    public float enemyAttackDamage = 2f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    
    private void Awake()
    {        
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth=enemyStartHealth;
        InvokeRepeating("Shoot",0f,0.5f);
    }
    void Shoot()
    {
        enemies = GameObject.FindGameObjectsWithTag("Player");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy=null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy=Vector3.Distance(transform.position,enemy.transform.position);
            if (distanceToEnemy<shortestDistance)
            {
                shortestDistance=distanceToEnemy;
                nearestEnemy=enemy;
            }
        }
        if(nearestEnemy != null&&shortestDistance<=range)
        {
            target=nearestEnemy.transform;
            player =target.GetComponent<PlayerShooting>();
            Attack();
        }
        else
        {
            target=null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target==null)
        {
            partToRotate.rotation=Quaternion.Lerp(partToRotate.rotation, Quaternion.Euler(0,0,0),Time.deltaTime*10f);
            return;
            
        }
        Vector3 dir=target.position-transform.position;
        Quaternion lookRotation=Quaternion.LookRotation(dir);
        Vector3 rotation=Quaternion.Lerp(partToRotate.rotation, lookRotation,Time.deltaTime*10f).eulerAngles;
        partToRotate.rotation=Quaternion.Euler(0f,rotation.y,0f);
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,range);
    }
    public void Attack()
    {
        if(player.playerHealth>0)
        {
            Debug.Log("Player'a ates edildi");
            player.TakeDamage(enemyAttackDamage);
            GameObject bulletGO= (GameObject)Instantiate(bulletPrefab,firePoint.position,partToRotate.transform.rotation);
            Bullet bullet=bulletGO.GetComponent<Bullet>();
            if (bullet !=null)
            {
                bullet.Seek(target);
            }
        }
    }
    public void TakeDamage(float amount)
    {
        enemyHealth -= amount;
        Debug.Log("Dusman Can degeri:   "+enemyHealth);
        if (enemyHealth<=0)
        {
            Debug.Log("Dusman oldu");
            MoneyManager.instance.currentMoney+=10;
            Destroy (gameObject, 0f);
            return;
        }
    }
    
}
