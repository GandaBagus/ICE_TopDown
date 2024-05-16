using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectLifetime : MonoBehaviour
{
    public float lifetime;
    public float blinkingDelay;
    public UnityEvent OnTimerReachedZero;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = lifetime;

        StartCoroutine(ObjectTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
           OnTimerReachedZero?.Invoke();
        }

        
        timer -= Time.deltaTime;
    }

    private IEnumerator ObjectTimer()
    {
        Color  defaultColor = GetComponent<SpriteRenderer>().color;
        Color blinkColor = defaultColor;
        blinkColor.a = 0.5f;
        yield return new WaitForSeconds(lifetime * 0.7f);
        while (timer > 0)
        {
            GetComponent<SpriteRenderer>().color  = blinkColor ;
            yield return new WaitForSeconds(0.1f);
             GetComponent<SpriteRenderer>().color  = defaultColor;
             yield return new WaitForSeconds(blinkingDelay);
        }
    }
}
