using System;
using Editor_de_texto;
using System.IO;

namespace Editor_de_texto
{
    public class Menu
    {

        public static void Show()
        {

            Console.Clear();
            Console.WriteLine("o que voce deseja fazer ?");
            Console.WriteLine("1 - abrir arquivo");
            Console.WriteLine("2 - criar novo arquivo");
            Console.WriteLine("0 - sair");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu.Show(); break;
            }
        }

        public static void Abrir()
        {
            Console.Clear();
            Console.WriteLine(/*tive que colocar o @ pois o caractere '\' ele nao reconhece como uma string, e o @ força ele a ser uma string junto com a frase*/@"qual caminho do arquivo ? (C:Users\Desktop)");
            String path = Console.ReadLine();

            using/*usado para abrir e fechar uma aplicacao de forma correta, ate mesmo se o usuario esquecer*/ (var file = new StreamReader(path)/*StreamReader tem a funcao de ler os dados do arquivo*/)
            {

                string text = file.ReadToEnd(); /* ele vai ler o arquivo ate o final para podemos abrir.*/
                Console.WriteLine(text);    /* consequentemente vamos mostrar na tela o resultado da abertura do arquivo*/

            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu.Show();
        }
        public static void Editar()
        {
            Console.Clear();
            Console.WriteLine("digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("-----------------------");
            string text = "";

            do
            {
                text += Console.ReadLine(); /* ele concatena tudo o que o usuario digita em todas as linhas*/
                text += Environment.NewLine; /* ao fim de cada leitura ele quebra uma linha e continua fazendo a leitura, sem isso todas as linhas estaria concatenadas, mas essa segunda funcao faz a quebra de linha e da continuidade na leitura*/

            } while (Console.ReadKey().Key/*ele vai ler o que o usuario esta digitando e comparar se ele digitou o ESC para sair*/ != ConsoleKey.Escape /*toda tecla diferente do ESC aciona o while como verdadeiro e gera tudo o que esta dentro dele*/);

            Console.Write(text);
            Menu.Salvar(text);
        }
        public static void Salvar(String text /*pega o resultado do 'text' e passar para a funcao Salvar, para que depois o usuario possa 
decidi aonde o aquivo deva ser salvo */)
        {
            Console.Clear();

            Console.WriteLine("qual caminho para salvar o arquivo ?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter/*ele precisa usar o system.io para funcionar conforme la em cima*/(path))
            {
                file.Write(text);

                /*O StreamWriter é uma classe no C# que fornece um meio fácil de gravar em arquivos de texto.*/
                /*Note que usamos o comando "using" para garantir que o objeto StreamWriter será fechado e descartado 
                  corretamente após a conclusão da operação de gravação.*/
            }
            Console.WriteLine($"arquivo {path} salvo com sucesso");
            Console.ReadLine();
            Menu.Show();
        }
    }
}