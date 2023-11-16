using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using Unity.VisualScripting;
using System.Data;
using static AwakeEvent;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;



public class CameraMovement : MonoBehaviour
{

    public string sceneToLoad;
    private int baseScore = 100;

    public int remainingPhotos;

    private Vector3 mousePosition;
    public GameObject pauseSymbol;
    public GameObject popupTextPrefab;
    private Camera mainCamera;

    public Camera innerCamera;

    public GameObject camWithCollider;
    public GameObject eventPrefab1;
    public GameObject eventPrefab2;
    public GameObject eventPrefab3;
    public GameObject eventPrefab4;
    public float moveSpeed = 0.01f;
    public bool trig;
    public Text ScoreCount;
    public Text photosRemainingText;
    private TMP_Text textPopup;

    public AudioClip defaultClip;
    public AudioSource audioSource;

    public AudioClip Coin;

    public AudioSource CoinPlayer;
    public Canvas canvas;
    private int score;
    private bool isPaused = false;
    List<GameObject> currentObjects = new List<GameObject>();




    public GameObject camSpriteSlim;
    public GameObject camSpriteOld;
    public Volume volume;
    private ColorAdjustments cAdj;

    public TileBase staticTile;
    public AnimatedTile animTile;


    public Text coinsCollected;
    public Vector3Int[] possiblePos;




    public Tilemap tilemap;
    public Vector3Int currTilePos;


    public Vector3 beastPos;




    // Start is called before the first frame update


    void Start()
    {
        beastPos = eventPrefab1.transform.position;


        StatsManager.instance.upgradeAvailable = true;




        currTilePos = new Vector3Int(-7, -3, 0); // The position where you want to set the tile
        tilemap.SetTile(currTilePos, animTile);

        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        CoinPlayer = GameObject.FindGameObjectWithTag("Coin").GetComponent<AudioSource>();
        innerCamera.orthographicSize = 0.6f + (0.1f * StatsManager.instance.focusMultiplier);

        float aspectRatio = (float)Screen.width / Screen.height;

        float width = 2.0f * innerCamera.orthographicSize * aspectRatio;
        float height = 2.0f * innerCamera.orthographicSize;



        BoxCollider2D colliderOfCam = camWithCollider.GetComponent<BoxCollider2D>();

        colliderOfCam.size = new Vector2(width, height);


        remainingPhotos = StatsManager.instance.extraSize + 20;

        Cursor.visible = false;
        score = 0;
        ScoreCount.text = score.ToString();
        photosRemainingText.text = remainingPhotos.ToString();
        volume.profile.TryGet<ColorAdjustments>(out cAdj);

        if (StatsManager.instance.betterUI == true)
        {
            camSpriteOld.SetActive(false);
            camSpriteSlim.SetActive(true);
        }

        else
        {
            camSpriteOld.SetActive(true);
            camSpriteSlim.SetActive(false);
        }





    }




    void newTile()
    {
        tilemap.SetTile(currTilePos, staticTile);

        Vector3Int nextPos = possiblePos[UnityEngine.Random.Range(0, possiblePos.Length)];
        while (nextPos == currTilePos)
        {
            nextPos = possiblePos[UnityEngine.Random.Range(0, possiblePos.Length)];
        }

        currTilePos = nextPos;
        tilemap.SetTile(currTilePos, animTile);



    }

    void Update()
    {


        if (Time.timeScale == 1)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, 0.01f * StatsManager.instance.speedMultiplier);


            if (Input.GetMouseButtonDown(0))
            {
                int thisScore = 0;
                List<GameObject> objectsToRemove = new List<GameObject>();

                foreach (GameObject obj in currentObjects)
                {
                    int multiplier = 1;


                    if (obj.name == "Beast")
                    {
                        float elapsedTime = Time.time - obj.GetComponent<AwakeEvent>().getTime();
                        if (elapsedTime < 0.3f) multiplier = 10;
                        else if (elapsedTime < 1f) multiplier = 7;
                        else if (elapsedTime < 2f) multiplier = 5;


                        objectsToRemove.Add(obj);
                    }

                    if (obj.name == "Camion")
                    {
                        multiplier = 4;
                        objectsToRemove.Add(obj);

                    }

                    if (obj.name == "Prision") multiplier = 0;

                    else

                    {
                        TilemapCollider2D coll;
                        if (obj.TryGetComponent<TilemapCollider2D>(out coll))
                        {
                            if (coll != null) Debug.Log("AÑAÑAÑAÑAÑA");

                            newTile();


                        }
                    }





                    thisScore += baseScore * multiplier;
                    score += thisScore;






                    // falta posar un parametre que serveixi per als multiplyers i que mostri la puntuació generada
                }

                foreach (GameObject obj in objectsToRemove)
                {
                    currentObjects.Remove(obj);
                    StartCoroutine(destruirEvent(obj));
                }
                remainingPhotos--;
                ScoreCount.text = score.ToString();
                photosRemainingText.text = remainingPhotos.ToString();
                ScoreManager.instance.score = score;

                if (thisScore > 1) ShowPopupText(thisScore.ToString(), Color.green);
                audioSource.Play();
                StartCoroutine(FlashEffect());
                currentObjects.Clear();




                if (remainingPhotos == 0) SceneManager.LoadScene(sceneToLoad);

            }

            /*

                        if (Input.GetKeyDown(KeyCode.N))
                        {

                            StartCoroutine(crearEvent(eventPrefab1));
                        }


            */


        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                cAdj.saturation.value = 100f;
                pauseSymbol.SetActive(false);
                ResumeGame();

            }
            else
            {
                cAdj.saturation.value = -100f;
                pauseSymbol.SetActive(true);

                PauseTheGame();

            }
        }
    }



    void OnTriggerEnter2D(Collider2D col)
    {



        if (col.gameObject.name == "Coin")
        {
            StatsManager.instance.coins++;
            CoinPlayer.Play();
            col.gameObject.SetActive(false);
        }
        else
            // Add the object to the list
            currentObjects.Add(col.gameObject);







    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Remove the object from the list
        currentObjects.Remove(col.gameObject);
    }


    void PauseTheGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    void ShowPopupText(string textToPut, Color c)
    {
        Vector3 yOffset = new Vector2(0, 200);
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition + yOffset, canvas.worldCamera, out position);

        GameObject popupText = Instantiate(popupTextPrefab, canvas.transform);
        popupText.transform.localPosition = position;
        popupText.SetActive(true);

        textPopup = popupText.GetComponent<TMP_Text>();
        textPopup.color = c;
        textPopup.text = textToPut;



        StartCoroutine(ChangeScaleAndOpacity(popupText));


        Destroy(popupText.gameObject, 1f); // Destroy the text after 2 seconds
    }


    IEnumerator crearEvent(GameObject eventPrefab)
    {

        Vector3 zoffset = new Vector3(0, 0, 10);
        GameObject newQuad = Instantiate(eventPrefab, mousePosition + zoffset, Quaternion.identity);
        newQuad.SetActive(true);

        yield return null;
    }

    IEnumerator destruirEvent(GameObject c)
    {

        Destroy(c.GetComponent<Collider2D>());
        SpriteRenderer renderer = c.GetComponent<SpriteRenderer>();

        yield return null;



    }
    IEnumerator FlashEffect()
    {
        float originalExposure = 0;
        float targetExposure = StatsManager.instance.flashIntensity * 5; // Set this to the desired flash exposure
        float duration = 0.1f; // Set this to the desired flash duration

        // Increase exposure to target value over half of the duration
        for (float t = 0; t < duration / 2; t += Time.deltaTime)
        {
            cAdj.postExposure.value = Mathf.Lerp(originalExposure, targetExposure, t / (duration / 2));
            yield return null;
        }

        // Ensure the postExposure value is exactly the target value at the end of the flash
        cAdj.postExposure.value = targetExposure;

        // Wait for a moment before fading out

        // Decrease exposure back to original value over the other half of the duration
        for (float t = 0; t < duration / 2; t += Time.deltaTime)
        {
            cAdj.postExposure.value = Mathf.Lerp(targetExposure, originalExposure, t / (duration / 2));
            yield return null;
        }

        cAdj.postExposure.value = originalExposure;
    }



    IEnumerator ChangeScaleAndOpacity(GameObject popupText)
    {
        float timer = 0f;
        float scaleUpDuration = 0.1f; // Duration over which the text will scale up

        // Scale up
        while (timer < scaleUpDuration)
        {
            timer += Time.deltaTime;
            float scale = Mathf.Lerp(0f, 1f, timer / scaleUpDuration);
            popupText.transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }

        // Reset timer for fade out
        timer = 0f;
        float fadeOutDuration = 0.8f; // Duration over which the text will fade out

        // Fade out
        while (timer < fadeOutDuration)
        {
            timer += Time.deltaTime;
            TMP_Text text = popupText.GetComponent<TMP_Text>();
            Color color = text.color;
            color.a = Mathf.Lerp(1f, 0f, timer / fadeOutDuration);
            text.color = color;
            yield return null;
        }
    }
}

