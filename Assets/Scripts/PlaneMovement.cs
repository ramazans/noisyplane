using UnityEngine;
using System.Collections;
[RequireComponent (typeof(AudioSource))]
public class PlaneMovement : MonoBehaviour {
	//main plane = gameObject this sscript is assigned to
	GameObject mainPlane;
	//broken plane disabled object
	public GameObject brokenPlane;
	//Senstivity of the plane
	public float liftSpeed = 2.0f;
	//What the tilt angle of the plane should be
	public float tiltAngle = 45.0f;
	//Fly up or down?
	float clickControl = 0.0f;
	//Game started?
	public bool started = false;
	//Are we dead?
	public bool isDead = false;
	//Lock value for x axis
	float lockX = 0.0f;
	//lefped click control value to have a bit more smooth effect
	float currentClickHoldValue = 0.0f;
	//audio source attached to the game object


    //voice control
    public float sensitivity = 50;
    AudioSource _audio;
    Rigidbody2D _rigidbody2D;
    float speed;
    public float loudness;


    void Start () {
		//Setting variables and default value
		mainPlane = gameObject;
		mainPlane.SetActive (true);
		brokenPlane.SetActive (false);
		lockX = -5.15f;


        //voice control
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
        _audio.clip = Microphone.Start(null, true, 10, 44100);
        _audio.loop = true;
        _audio.mute = false;
        //_audio.volume = 0;

        while (!(Microphone.GetPosition(null) > 0)) { }
        _audio.Play();
    }
	
	// Update is called once per frame
	void Update () {
        //voice control
        loudness = GetAveragedVolume() * sensitivity;
        //Debug.Log("voice : " + loudness.ToString());

        if (loudness > 0.5 && loudness < 1.7)
        {
            speed = 1f;
        }
        else if (loudness > 1.7 && loudness < 3)
        {
            speed = 1f;
        }
        else if (loudness > 3 && loudness < 5)
        {
            speed = 1f;
        }
        else if (loudness > 5 && loudness < 10)
        {
            speed = 1f;
        }
        else if (loudness > 10)
        {
            speed = 1f;
        }
        else{
            speed = -0.5f;
        }




        //if we are dead then don't do anything
        if (isDead)
			return;
		//Up and down movement input
		//if (Input.GetKey (KeyCode.Mouse0) && started) {
		//	clickControl = 1.0f;
		//} else if (started){
		//	clickControl = -1.0f;
		//}
		//Set the position of the plane
		mainPlane.transform.position = new Vector3 (lockX, mainPlane.transform.position.y, mainPlane.transform.position.z);
		//if the game haven't been started the fly on your own
		if (!started) {
			currentClickHoldValue = Mathf.PingPong (Time.time, 2.0f) - 1.0f;
			mainPlane.transform.Translate (Vector3.up * (currentClickHoldValue * Time.deltaTime * 1.5f));
		} else {
			lockX = Mathf.Lerp(lockX,-2.15f,Time.deltaTime*1.0f);
			currentClickHoldValue = Mathf.Lerp (currentClickHoldValue, speed, Time.deltaTime * 3.0f);
			mainPlane.transform.Translate (Vector3.up * (currentClickHoldValue * Time.deltaTime * liftSpeed));
		}
        //change pitch according to input
        //myAudio.pitch = 2.0f + currentClickHoldValue;
        //Tilt the plane
        mainPlane.transform.rotation = Quaternion.Euler(0.0f,0.0f,Mathf.LerpAngle(mainPlane.transform.eulerAngles.z,currentClickHoldValue*tiltAngle,Time.deltaTime*5.0f));


    }
	//Detect collision
	void OnTriggerEnter2D (Collider2D other){
		if (!other.GetComponent<Obstacle>())
			Die ();
	}
	//Die
	void Die (){
		isDead = true;
		brokenPlane.transform.position = mainPlane.transform.position;
		brokenPlane.transform.eulerAngles = mainPlane.transform.eulerAngles;
		mainPlane.SetActive(false);
		brokenPlane.SetActive (true);
	}
	//Start the game in 0.5 seconds
	void StartTheGame (){
		Invoke ("StartIn", 0.5f);
	}
	//start the game
	void StartIn (){
		started = true;
        Debug.Log("Oyun Başladı");
	}

    //Get Averaged Volume
    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data, 0);

        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}
