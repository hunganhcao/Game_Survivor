using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoryEvents : MonoBehaviour
{
    private Rigidbody2D myBody;
    //private Animator anim;
    private GameObject playerCanvas;
    private Text playerText;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        playerCanvas = transform.GetChild(0).gameObject;
        playerText = GetComponentInChildren<Text>();
        
    }

    private void Start()
    {
        playerCanvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
   

    public void InitialAnimation()
    {
        StartCoroutine(Intro());

    }

    IEnumerator Intro()
    {
        this.transform.position = new Vector3(-3f, -3f, transform.position.z);
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 0f;
        playerCanvas.SetActive(true);
        string introMessage = ("I'm lucky to be alive!" + "\n" + "I need to escape soon or I will suffocate");
        playerText.text = "";
        foreach (char letter in introMessage)
        {
            playerText.text += letter;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(1f);
        playerCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void StoryEvent1()
    {
        StartCoroutine(Event1());
    }

    IEnumerator Event1()
    {
        //Move to base of the door
        myBody.velocity = Vector2.zero;
        Time.timeScale = 0f;
        //float timeToMove = 1f;
        //float i = 0f;
        //float rate = 1f / timeToMove;
        //Vector3 currentPosition = transform.position;
        //Vector3 endPosition = new Vector3(-0.95f, 6.5f, 0);
        //while (i < 1)
        //{
        //    i += 0.01f;
        //    transform.position = Vector3.Lerp(currentPosition, endPosition, i);
        //    yield return new WaitForSecondsRealtime(0.005f);
        //}
        playerCanvas.SetActive(true);
        string message = ("An ancient door!" + "\n" + "Hmm I believe it says: Collect the diamonds and the way will open.");
        playerText.text = "";
        foreach (char letter in message)
        {
            playerText.text += letter;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(1f);
        playerCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        StartCoroutine(EndOfGame());
    }

    IEnumerator EndOfGame()
    {
        Time.timeScale = 0f;
        playerCanvas.SetActive(true);
        string message = ("The surface, I survived!" + "\n" + "I think I'll write a book on my adventure and get rich...");
        playerText.text = "";
        foreach (char letter in message)
        {
            playerText.text += letter;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(1f);
        playerCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameplayController.instance.RestartGame();
    }
}
