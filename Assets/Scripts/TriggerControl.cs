using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter (Collider other)
    {
        if(other.transform.tag=="pistol"&&MoneyManager.instance.currentMoney>=10)
        {
            MoneyManager.instance.currentMoney-=10;
            Debug.Log("Pistol");
            PlayerShooting.instance.myGun=PlayerShooting.guns.pistol;
            PlayerShooting.instance.SelectGun();
            Destroy (other.gameObject, 0f);
        }
        if(other.transform.tag=="rifle"&&MoneyManager.instance.currentMoney>=20)
        {
            MoneyManager.instance.currentMoney-=20;
            Debug.Log("Rifle");
            PlayerShooting.instance.myGun=PlayerShooting.guns.rifle;
            PlayerShooting.instance.SelectGun();
            Destroy (other.gameObject, 0f);
        }
    }
}
