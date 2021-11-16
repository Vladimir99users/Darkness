using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalController : MonoBehaviour
{
    public Transform thisGameobect;
    public GameObject[] _deathPlayer;
    public float maxSpeed = 5f;
    public float Jump;
    //переменная для определения направления персонажа вправо/влево
    private bool isFacingRight = true;
    //ссылка на компонент анимаций
    private Animator anim;
    //находится ли персонаж на земле или в прыжке?
  //  public bool isGrounded = false;
  //  //ссылка на компонент Transform объекта
  //  //для определения соприкосновения с землей
  //  public Transform groundCheck;
  //  //радиус определения соприкосновения с землей
  //  private float groundRadius = 0.2f;
  //  //ссылка на слой, представляющий землю
  //  public LayerMask whatIsGround;
    private Rigidbody2D _rb;


    public bool isligth;
    private int indexligth;
    public float[] valueLigth_white;
    public Light yellowLg;
    public Light whiteLg;

    public float flyMoving;
    [SerializeField]
    private float FlyMove;
    /// <summary>
    /// Начальная инициализация
    /// </summary>
	private void Start()
    {
        
        thisGameobect = GetComponent<Transform>();
        indexligth = 0;
        isligth = false;
           anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Выполняем действия в методе FixedUpdate, т. к. в компоненте Animator персонажа
    /// выставлено значение Animate Physics = true и анимация синхронизируется с расчетами физики
    /// </summary>
    private void FixedUpdate()
    {
      
        float move = Input.GetAxis("Horizontal");
        float ymove =Input.GetAxis("Vertical");


        anim.SetFloat("Speed", Mathf.Abs(move));


        _rb.velocity = new Vector2(move * maxSpeed, ymove*flyMoving);

        //если нажали клавишу для перемещения вправо, а персонаж направлен влево
        if (move > 0 && !isFacingRight)
            //отражаем персонажа вправо
            Flip();
        //обратная ситуация. отражаем персонажа влево
        else if (move < 0 && isFacingRight)
            Flip();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameManadger._instanteat.DamageHero();
            if(ScrollManadger._instanteat.getUpdateLive() == 0)
            {
                anim.Play("DeathPlayer");
                Instantiate(_deathPlayer[0], thisGameobect.position, Quaternion.identity);
                Instantiate(_deathPlayer[1], thisGameobect.position, Quaternion.identity);
               
            }
        }

        if (collision.gameObject.tag == "Brother")
        {
            SetValueLigth();
            anim.Play("HappyFly");
            GameManadger._instanteat.GetUpdateValueBrother();
            Destroy(collision.gameObject);
        }
    }



    public void SetValueLigth()
    {
        if (!isligth)
        {
            
            isligth = true;
            SetIndexLigth();          
            StartCoroutine(WaitSetLitgh());
        }
    }

    public void SetIndexLigth()
    {
        if(GameManadger._instanteat.valueBrotherGet() < 2)
        {
            indexligth = 0;
        } else if(GameManadger._instanteat.valueBrotherGet() >= 2 && GameManadger._instanteat.valueBrotherGet() < 5)
        {
            indexligth = 1;
        }
        else if (GameManadger._instanteat.valueBrotherGet() >= 5 && GameManadger._instanteat.valueBrotherGet() < 7)
        {
            indexligth = 2;
        }
        else if (GameManadger._instanteat.valueBrotherGet() >= 7)
        {
            indexligth = 3;
        } else
        {
            Debug.LogError("Index is not");
        }


        whiteLg.range = valueLigth_white[indexligth];
    }

    IEnumerator WaitSetLitgh()
    {
        yield return new WaitForSeconds(1f);
        isligth = false;

    }

    private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }


   

}
