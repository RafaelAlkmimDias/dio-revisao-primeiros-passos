using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");

                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        foreach (Aluno a in alunos)
                        {
                            if( !string.IsNullOrEmpty(a.Nome) )
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                        }
                        break;

                    case "3":

                        if(indiceAluno == 0)
                            throw new Exception("Nenhum aluno adicionado!");
                        decimal notaTotal = 0;
                        for(int i = 0; i < indiceAluno; i++)
                        {
                            notaTotal = notaTotal + alunos[i].Nota;
                        }

                        decimal notaMedia = notaTotal/indiceAluno;
                        Conceito conceitoGeral;
                        if (notaMedia < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if(notaMedia < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if(notaMedia < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if(notaMedia < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }


                        Console.WriteLine($"Média = {notaMedia} - Conceito = {conceitoGeral}");
                        
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            return Console.ReadLine();
        }
    }
}
