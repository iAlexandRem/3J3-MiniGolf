using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public enum EtatJeu
{
    Debut,
    Jeu,
    Fin
}

public class GestJeu : MonoBehaviour
{
    public static GestJeu instance;
    public EtatJeu etat;

    public ActiverRigidBody activerRigidBodyGrosMoulin;
    public TourneMoulin tourneMoulin;

    public Balle compteur;
    public static bool aGagne;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        etat = EtatJeu.Jeu;
    }


    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            PlayerPrefs.SetInt("NbCoups", compteur.coups);
            SceneManager.LoadScene("Intro");
        }
    }

    public IEnumerator FinJeu()
    {
        etat = EtatJeu.Fin;
        aGagne = true;

        activerRigidBodyGrosMoulin.FaireTomberMoulin();
        tourneMoulin.TournePlusVite();

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Intro");
    }
}
