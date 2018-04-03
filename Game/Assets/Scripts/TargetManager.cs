using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

    public GameObject[] monsters;
    public GameObject activeMonster = null;
    private void start()
    {
        
        foreach (GameObject monster in monsters)
        {

            monster.GetComponent<BoxCollider>().enabled = false;
            monster.SetActive(false);
        };
        ActivateMonster();
        
    }

    private void ActivateMonster()
    {
        int index = Random.Range(0, monsters.Length);
        activeMonster = monsters[index];
        activeMonster.SetActive(true);
        activeMonster.GetComponent<BoxCollider>().enabled = true;
    }
}
