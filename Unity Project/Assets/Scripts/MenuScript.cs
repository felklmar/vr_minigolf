using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour {

    string[] sceneNames = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10" };
    static int[] coursesScores = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    Canvas menuCanvas, scoreCanvas, controlsCanvas;
    TMP_Dropdown dropdown;

    public TextMeshProUGUI[] scoreText;

    GameObject ball, putter;
    Vector3 ballPosition, putterPosition;
    Quaternion putterRotation;

    void Awake() {
        dropdown = GetComponentInChildren<TMP_Dropdown>();
        Canvas[] canvases = GetComponentsInChildren<Canvas>();
        menuCanvas = canvases[0];
        scoreCanvas = canvases[1];
        controlsCanvas = canvases[2];

        ball = GameObject.Find( "Ball" );
        putter = GameObject.Find( "Putter" );

        ballPosition = ball.transform.position;
        putterPosition = putter.transform.position;
        putterRotation = putter.transform.rotation;
    }

    void Start() {
        menuCanvas.gameObject.SetActive( true );
        scoreCanvas.gameObject.SetActive( false );
        controlsCanvas.gameObject.SetActive( false );
    }

    public void resetButtonFunction() {
        coursesScores[dropdown.value] = 0;
        ball.transform.SetPositionAndRotation( ballPosition, Quaternion.identity );
        putter.transform.SetPositionAndRotation( putterPosition, putterRotation );
        ball.GetComponent<Rigidbody>().velocity = new Vector3( 0, 0, 0 );
        putter.GetComponent<Rigidbody>().velocity = new Vector3( 0, 0, 0 );
    }

    public void exitButtonFunction() {
        Application.Quit();
        Debug.Log("Game is exiting");
    }   

    public void scoreButtonFunction() {
        for ( int i = 0; i < scoreText.Length; i++ ) 
            scoreText[i].text = ( coursesScores[i] > 0 ) ? coursesScores[i].ToString() : "-";

        menuCanvas.gameObject.SetActive( false );
        scoreCanvas.gameObject.SetActive( true );
        controlsCanvas.gameObject.SetActive( false );
    }

    public void controlsButtonFunction() {
        menuCanvas.gameObject.SetActive( false );
        scoreCanvas.gameObject.SetActive( false );
        controlsCanvas.gameObject.SetActive( true );
    }

    public void returnButtonFunction() {
        menuCanvas.gameObject.SetActive( true );
        scoreCanvas.gameObject.SetActive( false );
        controlsCanvas.gameObject.SetActive( false );
    }

    public void dropdownMenuFunction( int value ) {
        SceneManager.LoadScene( "Scenes/Courses/" + sceneNames[value] );
    }

    public void increaseScore() {
        coursesScores[dropdown.value] += 1;
    }
}
