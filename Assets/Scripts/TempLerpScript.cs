using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempLerpScript : MonoBehaviour

//INFO: This script moves an adjustable value toward a set target value. It's an easy way to fake animation. For examples of how it's used check the switch prefab or microwave.
{
    [HideInInspector]
    public float floatVal;

    public Vector3 vecVal;
    [HideInInspector]
    public Color colorVal;
    
    [HideInInspector]
    public float floatTarget;

    public Vector3 vecTarget;
    [HideInInspector]
    public Color colorTarget;
    
    [HideInInspector]
    public float lerpSpeed = 1;

    [HideInInspector]
    public bool initialized;
    private bool deleteAfter;
    public bool doLerp;

    public enum LerpTiming
    {
        FixedUpdate = 0,
        Update = 1,
        LateUpdate = 2
    }
    public enum LerpType
    {
        Float = 0,
        Vector3 = 1,
        Color = 2
    }
    
    [HideInInspector]
    public LerpType typeOfLerp;
    [HideInInspector]
    public LerpTiming whenToLerp;

    void Update()
    {
        if (whenToLerp == LerpTiming.Update)
        {
            Count();
        }
    }

    private void LateUpdate()
    {
        if (whenToLerp == LerpTiming.LateUpdate)
        {
            Count();
        }
    }

    private void FixedUpdate()
    {
        if (whenToLerp == LerpTiming.FixedUpdate)
        {
            Count();
        }
    }

    void Count()
    {
        if (initialized && doLerp)
        { 
            if (typeOfLerp == null)
        {
            Debug.Log("YOU FORGOT TO SET LERP TYPE IDIOT");
        }
        
        if (typeOfLerp == LerpType.Float && Math.Abs(floatTarget - floatVal) > 0.01f)
        {
            float delta = floatTarget - floatVal;
            delta *= Time.deltaTime * lerpSpeed;
            floatVal += delta;

            if (Mathf.Abs(floatTarget - floatVal) < 0.01f)
            {
                floatVal = floatTarget;
            }
        }

        else if (typeOfLerp == LerpType.Vector3 && vecTarget != vecVal)
        {
            Vector3 delta = vecTarget - vecVal;

            delta *= Time.deltaTime * lerpSpeed;

            vecVal += delta;
            
            if (Mathf.Abs(vecTarget.x - vecVal.x) < 0.01f)
            {
                vecVal.x = vecTarget.x;
            }
            if (Mathf.Abs(vecTarget.y - vecVal.y) < 0.01f)
            {
                vecVal.y = vecTarget.y;
            }
            if (Mathf.Abs(vecTarget.z - vecVal.z) < 0.01f)
            {
                vecVal.z = vecTarget.z;
            }
        }
        
        else if (typeOfLerp == LerpType.Color && colorTarget != colorVal)
        {
            float deltaR = colorTarget.r - colorVal.r;
            float deltaG = colorTarget.g - colorVal.g;
            float deltaB = colorTarget.b - colorVal.b;
            float deltaA = colorTarget.a - colorVal.a;

            deltaR *= Time.deltaTime * lerpSpeed;
            deltaG *= Time.deltaTime * lerpSpeed;
            deltaB *= Time.deltaTime * lerpSpeed;
            deltaA *= Time.deltaTime * lerpSpeed;

            colorVal.r += deltaR;
            colorVal.g += deltaG;
            colorVal.b += deltaB;
            colorVal.a += deltaA;

            if (Mathf.Abs(colorTarget.r - colorVal.r) < 0.01f)
            {
                colorVal.r = colorTarget.r;
            }
            if (Mathf.Abs(colorTarget.g - colorVal.g) < 0.01f)
            {
                colorVal.g = colorTarget.g;
            }
            if (Mathf.Abs(colorTarget.b - colorVal.b) < 0.01f)
            {
                colorVal.b = colorTarget.b;
            }
            if (Mathf.Abs(colorTarget.a - colorVal.a) < 0.01f)
            {
                colorVal.a = colorTarget.a;
            }
        }
        
        SelfDelete();

        }
    }

    void CountVectorUpdater(GameObject subject, GameObject target)
    {
        vecVal = subject.transform.position;
        vecTarget = target.transform.position;
    }

    private void SelfDelete()
    {
        if (vecVal == vecTarget && deleteAfter)
        {
            Destroy(this);
        }
    }

    public void Initialize(Vector3 vectorToEdit, Vector3 target, int speed, bool deleteWhenDone)
    {
        typeOfLerp = LerpType.Vector3;
        vecVal = vectorToEdit;
        lerpSpeed = speed;
        vecTarget = target;
        doLerp = true;
        initialized = true;
    }

}
