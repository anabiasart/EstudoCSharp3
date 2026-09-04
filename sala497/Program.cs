using System;

class Program
{
    static void Main()
    {
        string[] nomes = new string[5];
        string[] alibis = new string[5];

        bool[] esteveNoLocal = new bool[5];
        bool[] contradicao = new bool[5];
        bool[] acessoSala = new bool[5];

        int[] nervosismo = new int[5];
        int[] evidencias = new int[5];
        int[] suspeitas = new int[5];
 //cada suspeito recebe uma pontuação de suspeita, que é calculada com base nos critérios fornecidos.
//nervosismo sozinho não significa nada
int maiorSuspeita=int.MinValue;
int segundaMaior=int.MinValue;


int indicePrincipal=-1;
int indiceSecundario=-1;

int[] pessoaMencionada = new int[5];
bool[] afirmouEstarNoLocal = new bool[5];


        for(int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Digite o nome do suspeito {i + 1}:");
            nomes[i] = Console.ReadLine();

            Console.WriteLine($"Digite o álibi do suspeito {i + 1}:");
            alibis[i] = Console.ReadLine();

            Console.WriteLine($"O suspeito {nomes[i]} esteve no local do crime? (true/false):");
            esteveNoLocal[i] = bool.Parse(Console.ReadLine());

            Console.WriteLine($"O suspeito {nomes[i]} apresentou contradição em seu depoimento? (true/false):");
            contradicao[i] = bool.Parse(Console.ReadLine());

            Console.WriteLine($"O suspeito {nomes[i]} teve acesso à sala do crime? (true/false):");
            acessoSala[i] = bool.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o nível de nervosismo do suspeito {nomes[i]} (0 a 10):");
            nervosismo[i] = int.Parse(Console.ReadLine());

            Console.WriteLine($"Digite a quantidade de evidências encontradas contra o suspeito {nomes[i]}:");
            evidencias[i] = int.Parse(Console.ReadLine());

            Console.WriteLine("====ANALISANDO....======");

            if(esteveNoLocal[i])
            {
                suspeitas[i] += 2;
            }if(acessoSala[i])
            {
                suspeitas[i] += 2;
            }
            if (contradicao[i])
            {
                suspeitas[i] += 4;
            }if(nervosismo[i] > 7)
            {
                suspeitas[i] += 2;}

            if(evidencias[i] > 0)
            {
                suspeitas[i] += evidencias[i] * 3;

            } if (nervosismo[i] > 7 &&
                evidencias[i] == 0 &&
                contradicao[i] == false)
            {
                suspeitas[i] -= 1;
            }

        }

        for(int i = 0; i <nomes.Length; i++)
        {
            if(suspeitas[i] > maiorSuspeita)
            {
                segundaMaior = maiorSuspeita;
                indiceSecundario = indicePrincipal;

                maiorSuspeita = suspeitas[i];
                indicePrincipal = i;
            }
            else if (suspeitas[i] > segundaMaior)
            {
                segundaMaior = suspeitas[i];
                indiceSecundario = i;
            }
        }
       Console.WriteLine();
Console.WriteLine("===== DEPOIMENTO CRUZADO =====");

Console.WriteLine(
    nomes[indicePrincipal] +
    " é atualmente o principal suspeito."
);

Console.WriteLine();
Console.WriteLine("Quem " + nomes[indicePrincipal] + " mencionou?");

for (int i = 0; i < nomes.Length; i++)
{
    Console.WriteLine(
        "[" + (i + 1) + "] " + nomes[i]
    );
}

int escolha = int.Parse(Console.ReadLine());

if (escolha < 1 || escolha > 5)
{
    Console.WriteLine("Suspeito inválido.");
    return;
}

pessoaMencionada[indicePrincipal] = escolha - 1;

int acusado = pessoaMencionada[indicePrincipal];

if (acusado == indicePrincipal)
{
    Console.WriteLine("O suspeito não pode mencionar ele mesmo.");
    return;
}
// transforma 1-5 em índice 0-4


Console.WriteLine(
    nomes[indicePrincipal] +
    " afirmou que " +
    nomes[acusado] +
    " estava no local? (true/false)"
);

afirmouEstarNoLocal[indicePrincipal] =
    bool.Parse(Console.ReadLine());

if (afirmouEstarNoLocal[indicePrincipal] !=
    esteveNoLocal[acusado])
{
    Console.WriteLine();
    Console.WriteLine("!!! CONTRADIÇÃO DETECTADA !!!");

    Console.WriteLine(
        nomes[indicePrincipal] +
        " fez uma afirmação incompatível sobre " +
        nomes[acusado] + "."
    );

    suspeitas[indicePrincipal] += 2;

    Console.WriteLine(
        "Suspeita de " +
        nomes[indicePrincipal] +
        " aumentou para " +
        suspeitas[indicePrincipal]
    );
}
else
{
    Console.WriteLine();
    Console.WriteLine("O depoimento é compatível com os dados conhecidos.");
}

    }
    }
