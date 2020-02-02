using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class CoreAI : MonoBehaviour
    {
        // Start is called before the first frame update
        public bool moveRight;
        public bool moveLeft;
        public bool stop;
        public int speed;
        public bool hasExited;
        public GameObject roomCenter;
        public int wanderRange;
        public Component spriteFlipper;
        public bool flipDirection;
        public Transform exitSpot;
        public GameObject moveToRoom;
        private enum State
        {
            Wandering,
            Stopped,
            Leaving
        };

        private State current;

        void Start()
        {
            stop = false;
            moveRight = true;
            speed = 1;
            flipDirection = true;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            current = State.Wandering;
            roomCenter = GameManager.Instance.screenLocation.GetChild(0).gameObject;
            exitSpot = GameManager.Instance.screenLocation.GetChild(1);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                flipDirection = !flipDirection;
            }
            if (flipDirection)
            {
                Wander();
            }
            else
            {
                LeaveRoom(moveToRoom);
            }

            Movement();
        }

        public void Movement()
        {
            if (stop)
            {

            }
            else if (moveRight)
            {
                gameObject.transform.Translate(2 * Time.deltaTime * speed, 0, 0);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (moveLeft)
            {
                gameObject.transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        public void Stop()
        {
            stop = true;
            moveRight = false;
            moveLeft = false;
        }
        public void MoveRight()
        {
            stop = false;
            moveRight = true;
            moveLeft = false;
        }

        public void MoveLeft()
        {
            stop = false;
            moveRight = false;
            moveLeft = true;
        }

        public void MoveTo(Vector3 positionGo)
        {
            if ((gameObject.transform.position.x - positionGo.x) < 2)
            {
                gameObject.transform.position = positionGo;
                Stop();
            }
            else
            {
                if (gameObject.transform.position.x < positionGo.x)
                {
                    MoveRight();
                }
                else if (gameObject.transform.position.x > positionGo.x)
                {
                    MoveLeft();
                }
            }

        }

        public void Wander()
        {
            current = State.Wandering;
            if (Mathf.Abs(transform.position.x - roomCenter.transform.position.x) > wanderRange && transform.position.x > roomCenter.transform.position.x)
            {
                MoveLeft();
            }
            if (Mathf.Abs(transform.position.x - roomCenter.transform.position.x) > wanderRange && transform.position.x < roomCenter.transform.position.x)
            {
                MoveRight();
            }
        }

        public void LeaveRoom(GameObject targetRoom)
        {
            current = State.Leaving;
            if (hasExited == false)
            {
                MoveTo(exitSpot.position);
                if (stop == true)
                {
                    gameObject.transform.SetParent(targetRoom.transform);
                    hasExited = true;
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 2);

                }
            }
            else if (hasExited == true)
            {
                Wander();

            }

        }



    }
}