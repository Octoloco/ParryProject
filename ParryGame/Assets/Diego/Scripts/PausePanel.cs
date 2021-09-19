using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : UIPanel
{
    private bool canShrink;
    [SerializeField]
    private float scaleFactor;

    new public void ShrinkChildren()
    {
        if (transform.GetComponent<RectTransform>().localScale.x > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.gameObject.SetActive(true);
                transform.GetComponent<RectTransform>().localScale += new Vector3(-scaleFactor * Time.deltaTime, -scaleFactor * Time.deltaTime, -scaleFactor * Time.deltaTime);
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetComponent<RectTransform>().localScale = Vector3.zero;
            }
            canShrink = false;
        }
    }
}
