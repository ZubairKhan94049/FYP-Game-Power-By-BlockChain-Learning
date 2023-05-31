using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WebGLSendTransactionExample : MonoBehaviour
{
    public Text hash;
    async public void OnSendTransaction()
    {
        // account to send to
        string to = "0x18f8c5FD57becC3afb1528cF4Eb7964354EE04AB";
        // amount in wei to send 0.01 BNB
        string value = "10000000000000000";
        // gas limit OPTIONAL
        string gasLimit = "";
        // gas price OPTIONAL
        string gasPrice = "";
        // connects to user's browser wallet (metamask) to send a transaction
        try {
            string response = await Web3GL.SendTransaction(to, value, gasLimit, gasPrice);
            Debug.Log(response);
            hash.text = response;
        } catch (Exception e) {
            Debug.LogException(e, this);
        }
    }

    public void Update()
    {
        if (hash.text.Contains("0"))
        {
            SceneManager.LoadScene(2);
        }
        else {
            Debug.Log("Send Transaction Error : ");
        }
    }
}