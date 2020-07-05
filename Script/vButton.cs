using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vButton : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject vBtn,vBtnZwei, cube,sphere,cylinder,capsule;
    string vbName;
    VirtualButtonBehaviour[] virtualButtonBehaviours;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    TextMesh text;
    int count=0;
    string blaa;
    float speed = 45.5f;

    void Start()
    {

        text =GameObject.Find("text").GetComponent<TextMesh>();
        audioSource = GetComponent<AudioSource>();

        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < virtualButtonBehaviours.Length; i++)
            virtualButtonBehaviours[i].RegisterEventHandler(this);

    }


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        vbName = vb.VirtualButtonName;

        switch (vbName)
        {
            case "VirtualButton":
                playSound(0);
                activateObj(cube);
                deactivateObj(cube);
                if (count == 5)
                {
                    text.text = "Well Played";
                    count = 0;

                }
                break;

            case "VirtualButtonZwei":
                playSound(1);
                activateObj(capsule);
                deactivateObj(capsule);
                if (count == 4)
                {
                    text.text = "Play next So";
                    count++;
                }
                break;

            case "VirtualButtonDrei":
                playSound(2);
                activateObj(sphere);
                deactivateObj(sphere);
                if (count <=2 )
                {
                    text.text = "Play next RE";
                    count++;
                }else if(count == 3)
                {
                    text.text = "Play next MI";
                    count++;
                }
                break;

            case "VirtualButtonVier":
                playSound(3);
                activateObj(cylinder);
                deactivateObj(cylinder);
                break;

            case "PlayAgain":
                count = 0;
                break;


        }
        Debug.Log(count);
        
     
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
    }

    //activate the specific gameobject
    public void activateObj(GameObject obj)
    {

        obj.SetActive(true);
        /**
        if (obj.Equals(sphere))
        {
            obj.SetActive(true);
            sphere.transform.position = new Vector3(0.75f, 0.0f, 0.0f);
            sphere.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);

        }**/
    }

    //deactivate the gameobject after a specific time by using a caroutine
    public void deactivateObj(GameObject obj)
    {
        StartCoroutine(RemoveAfterSeconds(1));
        IEnumerator RemoveAfterSeconds(int seconds)
    {
        
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }

    }

    //Managing audios, playing and stoping the audioclip at the specific index

    public void playSound(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    public void stopSound(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Stop();
    }

    public string nextTone(int number,string value)
    {
        return count == number ? text.text = value : text.text = value;
    }
}
