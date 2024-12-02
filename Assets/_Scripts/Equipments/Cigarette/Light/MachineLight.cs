using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cigarette
{
    /// <summary>
    /// 香烟机器指示灯
    /// </summary>
    public class MachineLight :MonoBehaviour, IUpdateHandle
    {
        private Material greenLight;
        private Material GreenLight
        {
            get
            {
                if (greenLight==null)
                {
                    greenLight = transform.FindChildForName("Green").GetComponent<MeshRenderer>().material;
                }
                return greenLight;
            }
        }

        private Material yellowLight;
        private Material YellowLight
        {
            get
            {
                if (yellowLight == null)
                {
                    yellowLight = transform.FindChildForName("Yellow").GetComponent<MeshRenderer>().material;
                }
                return yellowLight;
            }
        }
        private Material redLight;
        private Material RedLight
        {
            get
            {
                if (redLight == null)
                {
                    redLight = transform.FindChildForName("Red").GetComponent<MeshRenderer>().material;
                }
                return redLight;
            }
        }

        private AudioSource buzzer;
        /// <summary>
        /// 蜂鸣器
        /// </summary>
        private AudioSource Buzzer
        {
            get
            {
                if (buzzer==null)
                {
                    buzzer = GetComponent<AudioSource>();
                }
                return buzzer;
            }
        }
        /// <summary>
        /// 闪烁的灯
        /// </summary>
        List<Material> SparkLight = new List<Material>();
        private void Start()
        {
            StartCoroutine("ISpark");
        }
        public void ReductionNormalState()
        {
            
        }

        public void UpdateHandle(object data)
        {
            //string state = data.ToString();
            //SetLightState(state);
            Signal signal = data as Signal;
            SetLightState(signal);
            SetBuzzer(signal);
        }

        private void SetBuzzer(Signal signal)
        {
            switch (signal.buzzerState)
            {
                case "OFF"://关闭
                    Buzzer.Stop();
                    break;

                case "ON"://打开

                    if (!Buzzer.isPlaying)
                    {
                        Buzzer.Stop();
                        Buzzer.Play();
                        Buzzer.loop = false; 
                    }
                    break;
                case "SPARK"://交替
                    if (!Buzzer.isPlaying)
                    {
                        Buzzer.Stop();
                        Buzzer.Play();
                    }
                    Buzzer.loop = true;
                    break;
                default:
                    break;
            }
        }

        private void SetLightState(string state)
        {
            switch (state.ToLower())
            {
                case "run":
                    GreenLight.EnableKeyword("_EMISSION");
                    RedLight.DisableKeyword("_EMISSION");
                    YellowLight.DisableKeyword("_EMISSION");
                    break;

                case "alarm":
                    GreenLight.DisableKeyword("_EMISSION");
                    RedLight.DisableKeyword("_EMISSION");
                    YellowLight.EnableKeyword("_EMISSION");
                    break;

                case "shutdown":
                    GreenLight.DisableKeyword("_EMISSION");
                    RedLight.EnableKeyword("_EMISSION");
                    YellowLight.DisableKeyword("_EMISSION");
                    break;

                default:
                    break;
            }
        }
        /// <summary>
        /// 设置灯的状态
        /// </summary>
        /// <param name="lightMat"></param>
        private void SetLightState(Signal signal)
        {
            //Signal[] signals = new Signal[] { new Signal() { greenLightState= "OFF", redLightState="OFF", yellowLightState ="OFF"},
            //    new Signal() { greenLightState= "ON", redLightState="ON", yellowLightState ="ON" },
            //     new Signal() { greenLightState= "SPARK", redLightState="SPARK", yellowLightState ="SPARK" },
            //      new Signal() { greenLightState= "OFF", redLightState="SPARK", yellowLightState ="ON" },
            //};
            //int index = Random.Range(0, 3);
            //signal = signals[index];
            //Debug.Log(index);
            Set__EMISSION(GreenLight, signal.greenLightState);
            Set__EMISSION(RedLight, signal.redLightState);
            Set__EMISSION(YellowLight, signal.yellowLightState);
        }

        private void Set__EMISSION(Material mat, string state)
        {

            switch (state)
            {
                case "OFF"://关闭
                    mat.DisableKeyword("_EMISSION");
                    if (SparkLight.Contains(mat))
                    {
                        SparkLight.Remove(mat);
                    }
                    break;

                case "ON"://打开
                    if (SparkLight.Contains(mat))
                    {
                        SparkLight.Remove(mat);
                    }
                    mat.EnableKeyword("_EMISSION");
                    break;
                case "SPARK"://闪烁
                    if (!SparkLight.Contains(mat))
                    {
                        SparkLight.Add(mat);
                    }
                   
                    break;
                default:
                    break;
            }
        }

        IEnumerator ISpark()
        {
            while (true)
            {
                for (int i = 0; i < SparkLight.Count; i++)
                {
                    int index = i;
                    SparkLight[index].EnableKeyword("_EMISSION");
                }
               
                yield return new WaitForSeconds(1);
                for (int i = 0; i < SparkLight.Count; i++)
                {
                    int index = i;
                    SparkLight[index].DisableKeyword("_EMISSION");
                }
                yield return new WaitForSeconds(1);
            }
        }
    }
}
