using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buleeeeeeeeeeeeeeeetScript : MonoBehaviour
{
    private int bounces = 0;

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.name)
        {
            case "BottomCollider":
                Destroy(gameObject);
                break;        
        }

        if(col.gameObject.name != "BottomCollider" && col.gameObject.tag != "Block")
            {
                bounces++;
                if(bounces >= 6)
                {
                    Destroy(gameObject);
                }
            

        }
    }
}
