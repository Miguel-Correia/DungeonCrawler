using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{

    public Transform character;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(character.position.x, character.position.y, -1.0f);
    }
}
