using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting instance;

    public enum guns {pistol,rifle};
    public guns myGun;
    public GameObject pistol;
    public GameObject rifle;

    //public GameObject currentGun;
    public float range;
    public float playerAttackDamage;
    public float fireRate;
    
    public Transform target;
    public Transform partToRotate;

    public GameObject[] enemies;
    EnemyController enemy;
    
    public float playerHealth;
    public float playerStartHealth=100f;

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
        range=4f;
        playerAttackDamage=10f;
        fireRate=0.5f;
        playerHealth=playerStartHealth;
        InvokeRepeating("Shoot",0f,fireRate);
    }
    void Shoot()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
        if(nearestEnemy != null && shortestDistance<=range)
        {
            target=nearestEnemy.transform;
            enemy=target.GetComponent<EnemyController>();
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
        //SelectGun();
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
        if(enemy.enemyHealth>0)
        {
            enemy.TakeDamage(playerAttackDamage);
            Debug.Log("Dusman'a ates edildi");

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
        playerHealth -= amount;
        Debug.Log("Player Can degeri:   "+playerHealth);
        if (playerHealth<=0)
        {
            Debug.Log("Player oldu");
            Destroy (gameObject);
            return;
        }
    }
    public void SelectGun()
    {
        switch(myGun)
        {
            case guns.pistol: range=4f;playerAttackDamage=15f;fireRate=0.5f;pistol.SetActive(true);rifle.SetActive(false);
                break;
            case guns.rifle : range =6f;playerAttackDamage=25f;fireRate=0.3f;pistol.SetActive(false);rifle.SetActive(true);
                break;
        }
    }
}
