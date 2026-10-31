using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuIntro : MonoBehaviour
{
    [SerializeField] TMP_Text texteCoups;
    [SerializeField] TMP_Text texteBouton;

    public GestJeu jeu;
    AudioSource audioSource;
    [SerializeField] AudioClip UWin;
    [SerializeField] AudioClip winnin;
    [SerializeField] AudioClip hoorayTheme;

    void Start()
    {
        if (GestJeu.aGagne)
        {
            jeu.etat = EtatJeu.Fin;
        }
        else
        {
            jeu.etat = EtatJeu.Debut;
        }

        int nbCoups = PlayerPrefs.GetInt("NbCoups", 0);
        if (nbCoups > 1)
        {
            texteCoups.text = $"Dernier match :<br>{nbCoups} coups";

        }
        else if (nbCoups > -1 && nbCoups < 2)
        {
            texteCoups.text = $"Dernier match :<br>{nbCoups} coup";
        }
        else
        {
            texteCoups.text = $"Un match presque impossible!";
        }
        audioSource = GetComponent<AudioSource>();

        if (jeu.etat == EtatJeu.Fin)
        {
            texteBouton.text = $"Y O U  W I N";
        }
        else
        {
            texteBouton.text = $"Démarrer";
        }
    }

    void Update()
    {
        if (jeu.etat == EtatJeu.Fin)
        {
            audioSource.PlayOneShot(UWin);
            audioSource.PlayOneShot(hoorayTheme);
            audioSource.PlayOneShot(winnin);
        }
    }

    public void DemarrerJeu()
    {
        SceneManager.LoadScene("Jeu");
        jeu.etat = EtatJeu.Jeu;
    }

}
