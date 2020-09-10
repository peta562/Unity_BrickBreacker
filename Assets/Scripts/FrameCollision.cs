using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteGlow;

[RequireComponent(typeof(SpriteGlowEffect))]

public class FrameCollision : MonoBehaviour
{
    private SpriteGlowEffect glow;
    // Start is called before the first frame update
    void Start()
    {
        glow = GetComponent<SpriteGlowEffect>();
        glow.enabled = false;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BallPrefab"))
        {
            StartCoroutine(StartGlow());
        }
    }

    private IEnumerator StartGlow()
    {
        glow.enabled = true;
        yield return new WaitForSeconds(0.1f);
        glow.enabled = false;
    }
}
