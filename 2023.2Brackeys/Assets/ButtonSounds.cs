using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField] AudioSource click;
    [SerializeField] AudioSource hover;
    public void Clicked()
    {
        click.Play();
    }
    public void Hover()
    {
        hover.Play();
    }
}
