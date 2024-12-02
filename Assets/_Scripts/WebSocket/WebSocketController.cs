using BestHTTP.WebSocket;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cigarettes
{
    public class WebSocketController : BaseController
    {
        public WebSocketController(GameFacade gameFacade) : base(gameFacade)
        {
        }
        WebSocket webSocket;
        // Start is called before the first frame update
        void Start()
        {
            webSocket = new WebSocket(new Uri("ws://localhost:9099/host/1234"));
            webSocket.OnOpen += OnWebSocketOpen;
            webSocket.OnMessage += OnMessageReceived;
            webSocket.OnClosed += OnWebSocketClosed;
            webSocket.OnError += OnError;
            //webSocket.StartPingThread = true;
            //webSocket.PingFrequency = 100000;
            webSocket.Open();
            // StartCoroutine(IHandle_dataForCigaretteMainPanelDatas());

        }
        public override void OnInit()
        {
            base.OnInit();
            Start();
        }

        private void OnError(WebSocket ws, Exception ex)
        {
            string errorMsg = string.Empty;
            //if (ws.InternalRequest.Response != null)
            //    errorMsg = string.Format("Status Code from Server: {0} and Message: {1}",
            //    ws.InternalRequest.Response.StatusCode,
            //    ws.InternalRequest.Response.Message);
            //Debug.Log("An error occured: " + (ex != null ? ex.Message : "Unknown: " +
            //errorMsg));
        }

        private void OnWebSocketClosed(WebSocket webSocket, ushort code, string message)
        {
            Debug.Log("WebSocket Closed!");
        }
        bool b = false;
        private void OnMessageReceived(WebSocket webSocket, string message)
        {
            Debug.Log("Text Message received from server: " + message);
            VerifyData data = JsonUtility.FromJson<VerifyData>(message);
            Debug.Log(data.code);
            if (data.code == 0 && data.success && data.msg == "success")
            {

                DataForCigaretteMainPanelData dataForCigaretteMainPanelData = JsonUtility.FromJson<DataForCigaretteMainPanelData>(message);

                //dataForCigaretteMainPanelDatas.Add(dataForCigaretteMainPanelData.data);
                GameFacade.Instance.HandleMsg(ActionCode.UpdateCigarettesMainPanel, dataForCigaretteMainPanelData.data);

                DataForLaserCodingMachineData dataForLaserCodingMachine = JsonUtility.FromJson<DataForLaserCodingMachineData>(message);
                Debug.Log(dataForLaserCodingMachine.data.signal.buzzerState);
                GameFacade.Instance.HandleMsg(ActionCode.UpdateCigarettesEquipment, dataForLaserCodingMachine);
                //b = true;
            }

        }
        List<CigaretteMainPanelData> dataForCigaretteMainPanelDatas = new List<CigaretteMainPanelData>();

        IEnumerator IHandle_dataForCigaretteMainPanelDatas()
        {

            while (true)
            {
                yield return 0;

                while (dataForCigaretteMainPanelDatas.Count != 0)
                {
                    GameFacade.Instance.HandleMsg(ActionCode.UpdateCigarettesMainPanel, dataForCigaretteMainPanelDatas[0]);
                    yield return new WaitForSeconds(2f);

                    dataForCigaretteMainPanelDatas.RemoveAt(0);
                }
            }
        }
        private void OnWebSocketOpen(WebSocket webSocket)
        {
            Debug.Log("WebSocket Open!");
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDestroy()
        {
            webSocket.Close();
        }
    }
}
/// <summary>
/// 核实信息
/// </summary>
[Serializable]
public class VerifyData
{
    public int code;

    public bool success;

    public string msg;


}
/// <summary>
/// 主页面的数据
/// </summary>
[Serializable]
public class DataForCigaretteMainPanelData
{
    public CigaretteMainPanelData data;
}
/// <summary>
/// 激光打码机数据
/// </summary>
[Serializable]
public class DataForLaserCodingMachineData
{
    public LaserCodingMachineData data;
}
