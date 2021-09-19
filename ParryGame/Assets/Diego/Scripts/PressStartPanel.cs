using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressStartPanel : MonoBehaviour
{
    private bool canShrink;
    [SerializeField]
    private float scaleFactor;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            canShrink = true;
        }

        if (canShrink)
        {
            if (transform.GetComponent<RectTransform>().localScale.x > 0)
            {
                transform.gameObject.SetActive(true);
                transform.GetComponent<RectTransform>().localScale += new Vector3(-scaleFactor * Time.deltaTime, -scaleFactor * Time.deltaTime, -scaleFactor * Time.deltaTime);
            }
            else
            {
                UIManager.instance.ShowMainMenuPanel();
                gameObject.SetActive(false);
                transform.GetComponent<RectTransform>().localScale = Vector3.zero;
                canShrink = false;
            }
        }
    }
}

