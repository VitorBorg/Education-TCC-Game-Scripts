using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wordGlobalController : MonoBehaviour
{
    //prefab do controlador do word no mundo invertido
    [SerializeField]
    private GameObject prefabWordController;
    //Para instanciar os espacos
    [SerializeField]
    private GameObject prefabWordSpace;
    private GameObject player;
    //referencia do empty para posicao no mundo invertido
    [SerializeField]
    private GameObject posInverseWorld;

    //variavel para saber se o player esta no mundo invertido
    private bool sceneWord;
    //objeto recebido no qual sera feito o desafio
    private GameObject wordObject;
    //variavel da instanciacao do prefab la de cima (controlador do word)
    private GameObject instancePrefabWord;

    void Awake()
    {
        sceneWord = false;
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    public bool getSceneWord()
    {
        return sceneWord;
    }

    public void setSceneWord(GameObject wO)
    {
        wordObject = wO;
        sceneWord = true;
        createInverseWorld();
    }

    private void createInverseWorld()
    {
        //instancia o controlador do word
        instancePrefabWord = Instantiate(prefabWordController, new Vector3(posInverseWorld.transform.position.x, posInverseWorld.transform.position.y, posInverseWorld.transform.position.z + 5), Quaternion.Euler(0, -90, 0));
        //posiciona o prefab no mundo invertido
        instancePrefabWord.transform.parent = posInverseWorld.transform;
        
        //posiciona corretamente o objeto do desafio no mundo invertido
        wordObject.transform.parent = instancePrefabWord.transform.Find("object").transform;
        wordObject.transform.position = instancePrefabWord.transform.Find("object").transform.position;


        //define a dificuldade do desafio
        //pega as propriedades do objeto e cria novos espacos
        string word = wordObject.GetComponent<wordObject>().getWord();
        //regra de negocio
        int index = wordObject.GetComponent<wordObject>().getRandomLetter();
        //string word = wordObject.GetComponent<wordObject>().getNumberSyllables();
        Transform spaceObject = instancePrefabWord.transform.Find("space");


        //instancia e posiciona corretamente os spaces
        for (int space = 0; space < word.Length; space++)
        {
            Vector3 newPos = spaceObject.position;
            Transform instancePrefabSpaceWord = Instantiate(prefabWordSpace, new Vector3(newPos.x + (space - word.Length / 2), newPos.y, newPos.z), Quaternion.identity).transform;
            instancePrefabSpaceWord.parent = spaceObject;

            //coloca (ou nao) o/os agente/agentes no space
            if(space != index)
            {
                Vector3 newPosSpace = instancePrefabSpaceWord.position;
                Transform instanceLetter = Instantiate(prefabWordSpace, new Vector3(newPosSpace.x, newPosSpace.y + .5f, newPosSpace.z), Quaternion.identity).transform;
                instanceLetter.parent = instancePrefabSpaceWord;
            }
        }

       // Debug.Log(word);
        //int index = wordObject.GetComponent<wordObject>().getRandomLetter();
        //Debug.Log(index);

        //Debug.Log(word.Remove(0, 2).Insert(0, "  "));
        

        //instancia os agentes nos espacos

        //instancia os agentes

        player.transform.position = posInverseWorld.transform.position;
    }
}
