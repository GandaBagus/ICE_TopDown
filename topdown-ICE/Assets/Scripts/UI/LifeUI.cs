using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    public GameObject[] life;
    public ScriptableInteger lifescriptable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<life.Length;i++)
        {
            if (i < lifescriptable.value)
            {
                life[i].SetActive(true);
            }
            else
            {
                life[i].SetActive(false);
            }
        }
    }
}
