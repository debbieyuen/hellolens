using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrosoftLogoAnimation : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] Material[] myMaterials;
    [SerializeField] float delayedTime = 2;

    // Start is called before the first frame update
    void Start()
    {

        meshRenderer.material = myMaterials[Random.Range(0, myMaterials.Length)];

        StartCoroutine(loopDelay());
    }

    IEnumerator loopDelay()
    {
        for (int i = 0; i < myMaterials.Length; i++)
        {
            meshRenderer.material = myMaterials[i];
            yield return new WaitForSeconds(delayedTime);
        }
        StartCoroutine(loopDelay());
    }

}
