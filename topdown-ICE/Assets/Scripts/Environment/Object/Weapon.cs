using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float firerate;
    public List<float> fireRateModifier;
    public PoolObjectType type;

    private float timer = 0;
    // Start is called before the first frame update

    private void Awake() {
        fireRateModifier =  new List<float>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime > 0 ? timer - Time.deltaTime : 0f;
    }

    internal void addFireRateModifier(float modifier)
    {
        fireRateModifier.Add(modifier);
    }

    public void shoot()
    {
        if (timer == 0f)
        {
        //Debug.Log("tembak");
        ObjectPool.GetInstance().requestObject(type).activate(transform.position, transform.rotation);
        timer = firerate / getFireRateModifier();
        }
    }

    internal void removeFireRateModifier(float modifier)
    {
        fireRateModifier.Remove(modifier);
    }

    private float getFireRateModifier()
    {
        float mod = 1;
        foreach(float f in fireRateModifier)
        {
            mod += f;
        }
        return mod;
    }

    internal void clearModifier()
    {
        fireRateModifier.Clear();
    }
}
