using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class TriggerEvent : MonoBehaviour
{
    public string targetTag;

    public UnityEvent onTrigger;
    public UnityEvent<GameObject> OnTriggerWithGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == targetTag)
        {
                onTrigger?.Invoke();
                OnTriggerWithGameObject?.Invoke(collision.gameObject);
        }
    }
}
