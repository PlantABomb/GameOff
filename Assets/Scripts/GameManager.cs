using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    //SaveScore saver;
    AudioSource bgm;

    public CameraShake camera;
    public GameObject DestroyEffect;
    public GameObject AttackEffect;

    public static GameManager Instance;

    public float PlayerHpGain = 0.1f;
    public float PlayerHPDamage = 0.1f;
    public float PlayerHPDownRate = 0.1f;
    public float EnemyHPDamage = 0.1f;

    public Image EnemyHp;
    public Image PlayerHp;

    public Image nextBlock;

    public GameObject[] Combo;
    public GameObject[] Background;
    public GameObject[] block;
    public GameObject colorBlock;
    public GameObject GameOverPanel;
    public GameObject PausePanel;

    const int gridSizeX = 10;
    const int gridSizeY = 20;

    Sprite[] blockImg = new Sprite[7];

    GameObject currentBlock;

    bool[] checkBlock  = new bool[7];
    
    GameObject[,] grid = new GameObject[gridSizeY, gridSizeX];

    public float timer = 0;
    float moveWeight = .5f;
    public float invincible = 0f;
    int index;
    int backgroundIndex;

    public bool isDestory = false;
    bool isDocking = false;
    public bool isPlaying = true;

    float[] posX = new float[gridSizeX];
    float[] posY = new float[gridSizeY];

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        index = Random.Range(0, 7);
        backgroundIndex = 0;

        bgm = GetComponent<AudioSource>();

        for (int i = 1; i <= 7; i++)
        {
            checkBlock[i - 1] = true;
            string path = "Sprites/Blocks/B" + i;
            blockImg[i - 1] = Resources.Load<Sprite>(path) as Sprite;
        }

        for(int i = 0; i < gridSizeX; i++)
        {
            if (i == 0)
            {
                posX[i] = -2.25f;
                continue;
            }

            posX[i] = Mathf.Round((posX[i - 1] + .5f) * 100) * .01f;
        }

        for (int i = 0; i < gridSizeY; i++)
        {
            if (i == 0)
            {
                posY[i] = 4.75f;
                continue;
            }

            posY[i] = Mathf.Round((posY[i - 1] - .5f) * 100) * .01f;
        }

        GetCurrentBlock();
        Instantiate(Background[backgroundIndex++]);
        StartCoroutine(Deploy());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPlaying = false;
            PausePanel.SetActive(true);
        }

        if (isPlaying)
        {
            if(currentBlock != null)
            {
                BlockMove();

                if (CheckDocking()) 
                    StartCoroutine(Docking());
            }

            timer += Time.deltaTime;
            invincible += Time.deltaTime;

            if(!LevelController.Instance.anim.GetBool("pattern1on") && !LevelController.Instance.anim.GetBool("pattern2on"))
                PlayerHp.fillAmount -= PlayerHPDownRate * Time.deltaTime;

            if (invincible > 2f)
                currentBlock.transform.GetChild(0).gameObject.SetActive(false);

            if (IsGameOver())
            {
                StopAllCoroutines();
                GameOverPanel.SetActive(true);
                isPlaying = false;
            }else if (EnemyHp.fillAmount <= 0)
            {
                bgm.Stop();

                StopAllCoroutines();
                LevelController.Instance.anim.SetBool("bossisdead", true);
                SaveScore.scoresave((int)timer);
                isPlaying = false;

                StartCoroutine(ToEnding());
            }
        }
    }

    IEnumerator ToEnding()
    {
        yield return new WaitForSeconds(10f);
        print("to ending");
        SceneManager.LoadScene("Ending1");
    }

    public void BlockMove()
    {
        if (currentBlock == null)
            return;

        bool isRotate = false;

        Vector3 curPosition = currentBlock.transform.position;
        Vector3 newPosition = currentBlock.transform.position;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f; 
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            newPosition.x += moveWeight; 
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            newPosition.x -= moveWeight;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            newPosition.y += moveWeight;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            newPosition.y -= moveWeight;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            currentBlock.transform.Rotate(0, 0, -90);
            isRotate = true;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            newPosition.y += moveWeight;
        }

        currentBlock.transform.position = newPosition;

        if (!CheckPosition())        
        {
            if(isRotate)
                currentBlock.transform.Rotate(0, 0, 90);

            currentBlock.transform.position = curPosition;
        }
    }

    public void GetCurrentBlock()
    {
        if (currentBlock != null)
            return;

        bool flag = true;
        invincible = 0f;

        currentBlock = Instantiate(block[index]);

        checkBlock[index] = false;
        
        currentBlock.transform.position = transform.position;

        for (int i = 0; i < 7; i++)
        {
            if (checkBlock[i])
            {
                flag = false;
                break;
            }
        }

        if (flag)
        {
            for (int i = 0; i < 7; i++)
                checkBlock[i] = true;
        }

        while (!checkBlock[index])
            index = Random.Range(0, 7);
        
        nextBlock.sprite = blockImg[index];
    }

    public bool CheckPosition()
    {
        foreach (Transform block in currentBlock.transform) {
            if (block.name.Equals("Sheild"))
                continue;

            if (block.position.x < -2.5f || block.position.x > 2.5f || block.position.y < -5 || block.position.y > 5)
                return false;

            int col = (int)(Mathf.Round(Mathf.Round((block.position.x + 2.25f) * 100) * .01f * 2));
            int row = (int)(Mathf.Round(Mathf.Round((block.position.y - 4.75f) * 100) * .01f * 2));

            row = row > 0 ? row : row * -1;

            if (grid[row, col] != null)
                return false;
        }
        return true;
    }

    public bool CheckDocking()
    {
        if (isDocking)
            return false;

        foreach (Transform block in currentBlock.transform)
        {
            if (block.name.Equals("Sheild"))
                continue;

            int col = (int)(Mathf.Round(Mathf.Round((block.position.x + 2.25f) * 100 ) * .01f * 2));
            int row = (int)(Mathf.Round(Mathf.Round((block.position.y - 4.75f) * 100 ) * .01f * 2));

            row = row > 0 ? row : row * -1;

            if (row == 0 || (row > 0 && grid[row - 1, col] != null))
                return true;
        }

        return false;
    }

    IEnumerator Docking()
    {
        yield return new WaitForSeconds(.2f);

        if (!CheckDocking())
            yield break;

        isDocking = true;

        foreach (Transform block in currentBlock.transform)
        {
            if (block.name.Equals("Sheild"))
                continue;

            int col = (int)(Mathf.Round(Mathf.Round((block.position.x + 2.25f) * 100) * .01f * 2));
            int row = (int)(Mathf.Round(Mathf.Round((block.position.y - 4.75f) * 100) * .01f * 2));

            row = row > 0 ? row : row * -1;
            
            grid[row, col] = Instantiate(colorBlock);
            grid[row, col].transform.position = new Vector3(block.position.x, block.position.y, 1);
        }


        Destroy(currentBlock);
        currentBlock = null;

        PlayerHp.fillAmount += PlayerHpGain; 

        GetCurrentBlock();
        UpdateGrid();
        isDocking = false;
    }

    public void UpdateGrid()
    {
        int combo = 0;

        List<int> deleted = new List<int>();

        for (int i = 0; i < gridSizeY; i++)
        {
            bool flag = true;

            for (int j = 0; j < gridSizeX; j++)
            {
                if (grid[i, j] == null)
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                combo++;
                deleted.Add(i);

                GameObject Attack = Instantiate(AttackEffect);
                Attack.transform.position = new Vector3(0, posY[i], -1);
                Destroy(Attack, 0.75f);

                for (int j = 0; j < gridSizeX; j++)
                {
                    Destroy(grid[i, j]);
                    grid[i, j] = null;                  
                }                
            }
        }

        for(int i = 1; i < gridSizeY; i++)
        {
            for(int j = deleted.Count - 1; j >= 0; j--)
            {
                if(i > deleted[j])
                {
                    for(int k = 0; k < gridSizeX; k++)
                    {
                        if(grid[i, k] != null)
                        {
                            grid[i - j - 1, k] = grid[i, k];
                            grid[i, k] = null;

                            float x = posX[k] ;
                            float y = posY[i - j - 1];

                            grid[i - j - 1, k].transform.position = new Vector3(x, y, 0);
                        }                       
                    }

                    break;
                }
            }
        }

        if (combo >= 2)
            Destroy(Instantiate(Combo[combo - 2]), 1.5f);

        EnemyHp.fillAmount -= EnemyHPDamage * combo;
    }

    private bool IsGameOver()
    {
        if (PlayerHp.fillAmount == 0 || grid[17, 5] != null || grid[18, 5] != null)
            return true;

        return false;
    }


    public void DestroyMino()
    {
        invincible = 0f;

        GameObject effect = Instantiate(DestroyEffect);
        Destroy(effect, .7f);

        StartCoroutine(camera.Shake(.15f, .1f));
        PlayerHp.fillAmount -= PlayerHPDamage;
        Destroy(currentBlock);
        currentBlock = null;

        GetCurrentBlock();
    }

    public void BackToGame()
    {
        isPlaying = true;
        PausePanel.SetActive(false);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("InGame");
    }

    public void NextBackground()
    {
        Instantiate(Background[backgroundIndex++]);

        if (backgroundIndex >= Background.Length)
            backgroundIndex = 0;
    }

    IEnumerator Deploy()
    {
        while (true)
        {
            if (isPlaying && currentBlock != null)
            {
                Vector3 newPosition = new Vector3(currentBlock.transform.position.x, currentBlock.transform.position.y + moveWeight, 0);
                Vector3 curPosition = currentBlock.transform.position;

                currentBlock.transform.position = newPosition;

                if (!CheckPosition())
                    currentBlock.transform.position = curPosition;       
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
