using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleFrame : MonoBehaviour
{
    public float duration;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime <0 ? 0 : timer - Time.deltaTime ;
    }

    public void activate()
    {
        timer = duration;
        StartCoroutine(blinking());
        deactiveCollider();
    }

    private void deactiveCollider()
    {
        GetComponent<Collider2D>().enabled = false;
    }
    private void activateCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    private IEnumerator blinking()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color defaultColor =  sr.color;
        Color hitColor = defaultColor;
        hitColor.a = 0.3f;
        while (timer > 0)
        {
            sr.color = hitColor;
            yield return new WaitForSeconds(0.2f);
            sr.color = default;
            yield return new WaitForSeconds(0.2f);
        }
        sr.color = defaultColor;
        activateCollider();
    }

    
}
