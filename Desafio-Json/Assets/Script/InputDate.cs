using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InputDate : MonoBehaviour
{

    public TMP_Text txtFeedback;

    [SerializeField] private ServiceAPI serviceAPI;

    private string fullName;
    private string email;
    private string date;

    public void GetFullName(string fullName)
    {
        this.fullName = fullName;
    }

    public void GetEmail(string email)
    {
        this.email = email;
    }

    public void GetDate(string date)
    {
        this.date = date;
    }

    public void BtnSubmit()
    {
        StartCoroutine(serviceAPI.GetInfoReturn(fullName, email, date));
        txtFeedback.text = "Enviando os dados \naguarde...";
        StartCoroutine(checkResult());
    }

    public IEnumerator checkResult()
    {
        yield return new WaitForSeconds(5);

        if (serviceAPI.isSucess == false)
        {
            txtFeedback.text = "Erro de Conexão";
        }
        else
        {
            if (serviceAPI.jsonDate.success == false || serviceAPI.jsonDate.status != "success" || serviceAPI.jsonDate.data.message == "")
            {
                txtFeedback.text = "Verifique se os dados foram preenchidos corretamente";
            }
            else
            {
                txtFeedback.text = serviceAPI.jsonDate.data.message;
            }
        }        
    }

    public void ResetScene(string cena)
    {
        SceneManager.LoadScene(cena);
    }
}
