using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class Level1_Hacker : MonoBehaviour
{
    private SpriteRenderer hacker;
    private int index;

    [SerializeField] private GameObject friend;
    [SerializeField] private Transform cam;
    [SerializeField] private GameObject Dialogue;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject PasswordBox;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject LevelCompleted;
    [SerializeField] private TextMeshProUGUI str;
    [SerializeField] private GameObject Strength;
    public Level1_HealthBar healthBar;
    [SerializeField] private GameObject HP;
    [SerializeField] private string[] lines;
    static public bool BossDialogue;
    static public bool BossFight;
    private bool WritePass;

    static public bool WinScene;
    [SerializeField] private Animator hackerAnimator;

    public GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        hacker = GetComponent<SpriteRenderer>();
        index = 1;
        text.text = lines[0];
        BossDialogue = true;
        BossFight = false;
        WritePass = true;
        WinScene = false;
    }

    void Update()
    {

        if (cam.position.x == 141.02f && cam.position.y == transform.position.y && BossDialogue)
        {
            Dialogue.SetActive(true);
            HP.SetActive(false);
            Strength.SetActive(false);
            Level1_Passwords.Pass = "";
            Level1_Passwords.done = -1;
            Level1_Passwords.flag0 = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (index >= lines.Length)
                {
                    Dialogue.SetActive(false);
                    BossDialogue = false;
                    Level1_Friend.FriendDialogue = true;
                }
                else
                {
                    text.text = lines[index];
                }
                index += 1;
            }
        }
        if (BossFight)
        {
            HP.SetActive(true);
            Strength.SetActive(true);
            StartCoroutine(StartBossFight());
        }
    }

    IEnumerator StartBossFight()
    {
        yield return new WaitForSeconds(0.5f);
        healthBar.DecHealth(1 * Time.deltaTime);
        
        GameObject.Find("Player").GetComponent<Level1_PlayerMovement>().stop = true;
        PasswordBox.SetActive(true);
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Level1_Passwords.Pass = inputField.text;
        }
        if(str.text == "Pass Strength Strong")
        {
            if(WritePass)
            {
                gameData.UserPassword = Level1_Passwords.Pass;
            }
            
            PasswordBox.SetActive(false);
            yield return new WaitForSeconds(0.5f);

            WinScene = true;
            hackerAnimator.Play("Hacker_Shrink", 0, 0.0f);
            AnimatorStateInfo info = hackerAnimator.GetCurrentAnimatorStateInfo(0);

            BossFight = false;
            
            StartCoroutine(Wait(info));

            print(Time.time);
            yield return new WaitForSeconds(3f);
            print(Time.time);

            LevelCompleted.SetActive(true);

            yield return new WaitForSeconds(1.5f);

            LevelCompleted.SetActive(false);

            yield return new WaitForSeconds(1f);

            if (healthBar.ReturnHealth() >= 50)
            {
                gameData.Lotus = true;
            }

            gameData.Level2 = true;
            SceneManager.LoadScene("Level2");
        }
    }

    IEnumerator Wait(AnimatorStateInfo info)
    {
        print(Time.time);
        yield return new WaitForSeconds(info.length);
        print(Time.time);
    }
}
