using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{

    public Rigidbody mainRigidbody;
    public bool isJump;
    public GameObject sphereTrigger;
    public GameObject plane;
    public GameObject car;
    float carAngle;
    public float carMaxAngle;
    public float carRotationSpeed;

    public float yOffset;
    public float yForce;
    public float speed;

    public float jumpForce;

    

    public float maxRange ;
    public float currentDestination;
    public PositionSlider positionslider;

    Vector2 startPos;
    Vector2 endPos;
    float startTime;

    public bool isGrounded;
    public bool canJump;
    public Animator animator;
    void Start()
    {
        maxRange = GameObject.FindGameObjectWithTag("EndTrigger").transform.position.z - transform.position.z;
        
        mainRigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        
        positionslider.SetMaxDestination(maxRange);
        

    }

    // Update is called once per frame
    void Update()
    {
        Destination(currentDestination);
        
       


        if (GameSceneManager.instance.isGameRunning == true)
        {
            if (transform.position.y > yOffset + 0.5f)
            {
                isGrounded = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
                startTime = Time.time;
                canJump = false;

            }
            else if (Input.GetMouseButton(0))
            {
                if (carAngle < carMaxAngle)
                {
                    car.transform.Rotate(carRotationSpeed, 0f, 0f);
                    carAngle += carRotationSpeed;
                }
                else if (isGrounded && carAngle > 0)
                {
                    car.transform.Rotate(-carRotationSpeed, 0f, 0f);
                    carAngle -= carRotationSpeed;
                }

                endPos = Input.mousePosition;

                Vector3 swipe = endPos - startPos;

                swipe = new Vector3(0, swipe.y, 0);


                if (endPos.y > startPos.y)
                {
                    mainRigidbody.AddForce(-swipe * yForce);
                }
                else
                    mainRigidbody.AddForce(swipe * yForce);

            }
            else if (Input.GetMouseButtonUp(0))
            {
                Vector3 swipe = new Vector3(0, (transform.position.y - yOffset), 0);


                if (isGrounded == true)
                {

                    if (endPos.y > startPos.y)
                        sphereTrigger.GetComponent<Rigidbody>().AddForce(swipe * jumpForce);

                    sphereTrigger.GetComponent<Rigidbody>().AddForce(-swipe * jumpForce);
                }

                carAngle = -carMaxAngle / 2f;
                car.transform.DOPause();
                car.transform.DORotate(new Vector3(carAngle, car.transform.eulerAngles.y, car.transform.eulerAngles.z), 0.3f);

                StartCoroutine(canJumpEnum());

            }
            else if (isGrounded == true && transform.position.y < yOffset - 1 && canJump)
            {
                Debug.Log("saaa");
                mainRigidbody.AddForce(0, (transform.position.y) * 10 * yForce, 0);
                car.transform.DOPause();
                car.transform.DORotate(new Vector3(0f, car.transform.eulerAngles.y, car.transform.eulerAngles.z), 0.1f);
            }

            mainRigidbody.transform.Translate(new Vector3(0, 0, speed));

            plane.transform.position = new Vector3(transform.position.x, plane.transform.position.y, transform.position.z);

            sphereTrigger.transform.position = new Vector3(transform.position.x, sphereTrigger.transform.position.y, transform.position.z + 0.1f);



        }
    }

    private void OnCollisionEnter(Collision collision)

    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }


    IEnumerator canJumpEnum()
    {
        yield return new WaitForSeconds(0.2f);
        canJump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            GameSceneManager.instance.finishPanel.SetActive(true);
             GameManager.instance.follow = false;
            GameSceneManager.instance.isGameRunning = false;

            mainRigidbody.AddForce(0, 0, 100, ForceMode.Impulse);
            GameManager.instance.ComplateLevel();
            //mainRigidbody.velocity = Vector3.zero;

        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("FinalTrigger"))
        {
            mainRigidbody.AddForce(0, 0, 50);


        }
    }

  
    void Destination(float destination)
    {
        currentDestination = transform.position.z;

        positionslider.SetDestination(currentDestination);
    }


}
