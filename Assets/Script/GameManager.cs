using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] switches;

    [SerializeField]
    GameObject spikes;

    int noOfSwitches = 0;

    [SerializeField]
    Text switchCount;

    void Start()
    {
        GetNoOfSwitches();
    }

    public int GetNoOfSwitches()
    {
        int x = 0;

        for (int i = 0; i < switches.Length; i++)
        {
            if (switches[i].GetComponent<SwitchToggle>().isOn == false)
            {
                x++;
            }
            else if (switches[i].GetComponent<SwitchToggle>().isOn == true)
            {
                noOfSwitches--;
            }
        }

        return noOfSwitches;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spike")
        {
            Destroy(other.gameObject);
        }
    }

    
}
