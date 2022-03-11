using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //public GameObject character;
    public Image Fill;
    PlayerShooting player;
    
     //Start is called before the first frame update
    void Start()
    {
        player= GetComponent<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        Fill.fillAmount=player.playerHealth/player.playerStartHealth;
    }
}
