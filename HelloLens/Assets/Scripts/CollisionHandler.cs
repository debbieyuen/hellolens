using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private ParticleSystem gemParticles;


    private void OnCollisionEnter(Collision collision)
    {


        switch (collision.gameObject.tag)
        {
            case "Plane":
                break;

            case "Gem":
                meshRenderer.material = collision.gameObject.GetComponent<Renderer>().material;
                Destroy(collision.gameObject);
                PlayParticles();
                break;

            default:
                break;
        }
    }

    private void PlayParticles()
    {
        gemParticles.Play();
    }
}
