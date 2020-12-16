using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightModes
{
    SINGLE,
    AIRPLANE,
    PINGPONG
}

[System.Serializable]
public class LightSet
{
    public SpriteRenderer sp;
    public Sprite on, off;
}

public class LightShow : MonoBehaviour
{

    public float interval = 0.5f;
    bool lightShowRunning;
    public LightModes lightMode;
    public List<LightSet> lightList = new List<LightSet>();
    int lightIndex;
    int direction = 1;

    public void StartLightShow()
    {
        StartCoroutine(Blink());
    }

    public void StopLightShow()
    {
        lightShowRunning = false;

        foreach (var light in lightList)
        {
            light.sp.sprite = light.off;
        }
    }

    IEnumerator Blink()
    {
        if (lightShowRunning)
        {
            yield break;
        }

        lightShowRunning = true;
        direction = 1;

        while (lightShowRunning)
        {
            if (lightMode == LightModes.SINGLE)
            {
                // ON
                lightList[0].sp.sprite = lightList[0].on;
                // WAIT
                yield return new WaitForSeconds(interval);

                // OFF
                lightList[0].sp.sprite = lightList[0].off;
                // WAIT
                yield return new WaitForSeconds(interval);
            }
            else if (lightMode == LightModes.AIRPLANE)
            {
                // ON
                lightList[lightIndex].sp.sprite = lightList[lightIndex].on;
                // WAIT
                yield return new WaitForSeconds(interval);

                // OFF
                lightList[lightIndex].sp.sprite = lightList[lightIndex].off;
                // WAIT
                yield return new WaitForSeconds(interval);

                lightIndex++;

                if (lightIndex > lightList.Count - 1)
                {
                    lightIndex = 0;
                }
            }
            else if (lightMode == LightModes.PINGPONG)
            {
                // ON
                lightList[lightIndex].sp.sprite = lightList[lightIndex].on;
                // WAIT
                yield return new WaitForSeconds(interval);

                // OFF
                lightList[lightIndex].sp.sprite = lightList[lightIndex].off;
                // WAIT
                yield return new WaitForSeconds(interval);

                lightIndex += 1 * direction;

                if (lightIndex > lightList.Count - 1)
                {
                    lightIndex = lightIndex - 2;
                    direction = -1;
                }
                else if (lightIndex < 0)
                {
                    lightIndex = 1;
                    direction = 1;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartLightShow();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
