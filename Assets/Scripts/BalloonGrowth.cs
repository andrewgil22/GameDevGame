using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGrowth : MonoBehaviour
{
    public float growthRate = -2f;  // How much the balloon grows each second

    private void Start()
    {
        StartCoroutine(GrowBalloon());
    }

    private IEnumerator GrowBalloon()
    {
        while (true) // Infinite loop, replace with your condition to stop growth
        {
            transform.localScale += new Vector3(growthRate, growthRate, growthRate);
            yield return new WaitForSeconds(1); // Wait for 1 second
        }
    }
}
