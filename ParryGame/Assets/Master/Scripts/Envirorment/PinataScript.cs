using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinataScript : MonoBehaviour
{

    public static PinataScript instance;

    //[SerializeField]
    //private Transform[] quadrants;
    //[SerializeField]
    //private float pinataQuadrantSpeed = .5f;
    //[SerializeField]
    //private float pinataLocalSpeed = .5f;
    //[SerializeField]
    //private float growSpeed = .5f;
    [SerializeField]
    private int maxGrowth;
    //[SerializeField]
    //private float growthStep;
    //[SerializeField]
    //private bool movementLocked;

    //private float quadrantChangeTimer;
    //private Vector3 nextLocalPosition;
    //private Transform currentQuadrant;
    //private bool arrivedToQuadrant = false;
    private int growth = 0;
    //private Vector3 scaleToVector;
    public UnityEvent onPassLevel;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        growth = 0;
        //currentQuadrant = quadrants[0];
    }

    void Update()
    {
        //Movement();
        //SetPinataScale();
    }

    //private void Movement()
    //{
    //    if (!movementLocked)
    //    {
    //        if (quadrantChangeTimer > 0)
    //        {
    //            quadrantChangeTimer -= Time.deltaTime;
    //        }
    //        else
    //        {
    //            quadrantChangeTimer = Random.Range(2, 5);
    //            int rndmQuadrantIndex = Random.Range(0, quadrants.Length);
    //            currentQuadrant = quadrants[rndmQuadrantIndex];
    //            arrivedToQuadrant = false;
    //        }
    //    }

    //    Vector3 pinataDistanceFromQuadrant = currentQuadrant.position - transform.position;

    //    if (pinataDistanceFromQuadrant.magnitude > 2)
    //    {
    //        transform.position = Vector3.Lerp(transform.position, currentQuadrant.position, pinataQuadrantSpeed * Time.deltaTime);
    //    }
    //    else
    //    {
    //        if (!movementLocked)
    //        {
    //            if (!arrivedToQuadrant)
    //            {
    //                arrivedToQuadrant = true;
    //                nextLocalPosition = new Vector3(currentQuadrant.position.x + Random.Range(-2, 2), currentQuadrant.position.y + Random.Range(-2, 2), 0);
    //            }

    //            Vector3 pinataDistanceFromLocal = nextLocalPosition - transform.position;
    //            if (pinataDistanceFromLocal.magnitude > .3f)
    //            {
    //                transform.position = Vector3.Lerp(transform.position, nextLocalPosition, pinataLocalSpeed * Time.deltaTime);
    //            }
    //            else
    //            {
    //                nextLocalPosition = new Vector3(currentQuadrant.position.x + Random.Range(-2, 2), currentQuadrant.position.y + Random.Range(-2, 2), 0);
    //            }
    //        }
    //    }
    //}

    //private void SetPinataScale()
    //{
    //    float scaleMagnitude = (scaleToVector - transform.localScale).magnitude;
    //    if (scaleMagnitude > .1)
    //    {
    //        transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale + new Vector3(growth, growth, growth), growSpeed * Time.deltaTime);
    //    }
    //}

    public void Grow()
    {
        growth++;
        if (growth >= maxGrowth)
        {
            onPassLevel.Invoke();
        }
        //scaleToVector = transform.localScale + new Vector3(growthStep * growth, growthStep * growth, growthStep * growth);
        
    }

    public void LevelFinished()
    {
        GetComponent<Animator>().SetTrigger("hit");
    }

    public void Explode()
    {
        LevelLoader.instance.LoadNextLevel();
       // LevelLoader.instance.LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
