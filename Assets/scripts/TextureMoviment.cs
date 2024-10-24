using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class TextureMoviment : MonoBehaviour
{
    [SerializeField] private float speedY;
    [SerializeField] private float speedX;
    private MeshRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.mainTextureOffset = new Vector2(speedX * Time.timeSinceLevelLoad, speedY * Time.timeSinceLevelLoad);
    }
}
