using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject prevLight;
    public GameObject nextLight;
    public GameObject ground;
    public Material platformMaterial;
    public Material newColor;
    public AudioClip newSong;
    public AudioManager audioManager;

    public float newMoveSpeed;

    private bool isNewMusic = false;
    // Start is called before the first frame update
    void Start()
    {
        platformMaterial.color = Color.gray;
        platformMaterial.SetFloat("_Metallic", 1);
        platformMaterial.SetFloat("_Glossiness", 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerController>().respawnPoint = this.transform;
        other.gameObject.GetComponent<PlayerController>().moveSpeed = newMoveSpeed;

        Renderer render = GetComponent<Renderer>();
        render.material.color = Color.green;

        prevLight.SetActive(false);
        nextLight.SetActive(true);

        ground.GetComponent<Renderer>().material.color = Color.gray;
        platformMaterial.color = newColor.color;

        platformMaterial.SetFloat("_Metallic", 0);
        platformMaterial.SetFloat("_Glossiness", 0);

        if (!isNewMusic) {
            audioManager.ChangeMusic(newSong);
            isNewMusic = true;
        }
    }
}
