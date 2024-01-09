using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class UnityServer : MonoBehaviour
{
    TcpListener server;
    TcpClient client;
    NetworkStream nwStream;
    AudioSource ass;
    public TextMeshProUGUI tmp;

    public Animator anim;
    public GameObject canvas;
    public TMP_InputField lat, longg, mag;

    public float a = 8;
    public float b = 9;
    public float c = 7;
    public float d = 4;
    public float temp;



    public void deathPre()
    {
        a = int.Parse(lat.text);
        b = int.Parse(longg.text);
        c = int.Parse(mag.text);


        


        Task.Run(async () => await ConnectAndCommunicateAsync());
    }

    private async Task ConnectAndCommunicateAsync()
    {
        server = new TcpListener(IPAddress.Any, 25007);
        server.Start();
        Debug.Log("Waiting for connection...");

        client = await server.AcceptTcpClientAsync();
        nwStream = client.GetStream();
        Debug.Log("Connected!");

        
        string dataToSend = $"{a},{b},{c},{d}\n";
        byte[] dataBytes = Encoding.UTF8.GetBytes(dataToSend);

        
        await nwStream.WriteAsync(dataBytes, 0, dataBytes.Length);

        
        byte[] buffer = new byte[client.ReceiveBufferSize];
        int bytesRead = await nwStream.ReadAsync(buffer, 0, client.ReceiveBufferSize);
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        
        string[] values = dataReceived.Split(',');
        a = float.Parse(values[0]);
        b = float.Parse(values[1]);
        c = float.Parse(values[2]);
        d = float.Parse(values[3]);

        Debug.Log(d / 500000000000);
        
    }

    public void sonuclar()
    {
        temp = (d / 500000000000);
        if (temp > 0)
        {
            tmp.text = temp.ToString("F3");
        }
        else
        {
            temp = temp * (-1);
            tmp.text = temp.ToString("F3");

        }
        
    }

    public void Sound()
    {
        ass = this.gameObject.GetComponent<AudioSource>();
        ass.Play();
    }

    public void deathPredictOpen()
    {
        
        
        anim.SetBool("control", true);
    }

    public void deathPredictClose()
    {
        anim.SetBool("control", false);
    }

    void OnDestroy()
    {
        // Unity uygulamasý sona erdiðinde baðlantýyý kapat
        if (client != null && client.Connected)
        {
            nwStream.Close();
            client.Close();
            server.Stop();
        }
    }

    
}