using VotacionesConFech.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        bool run = true;
        int Aceptan = 0;
        int Rechazan = 0;
        int Empate = 0;
        while (run)
        {
            Console.Clear();
            try
            {
                IList<University> Unis = new List<University>();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Numero de universidades: ");
                int num_Unis = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < num_Unis; i++)
                {
                    Unis.Add(votations());
                }
                Console.Clear();
                foreach (var U in Unis)
                {
                    var result = U.result[0] > U.result[1] ? Aceptan += 1 : (U.result[0] < U.result[1] ? Rechazan += 1 : (U.result[0] == U.result[1] ? Empate += 1 : 0));
                    // if (U.result[0] > U.result[1])
                    // {
                    //     Aceptan += 1;
                    // }else if(U.result[0] < U.result[1])
                    // {
                    //     Rechazan += 1 ;
                    // }else if(U.result[0] == U.result[1])
                    // {
                    //     Empate += 1 ;
                    // }
                }
                Console.WriteLine($"Universidades que aceptan: {Aceptan}");
                Console.WriteLine($"Universidades que Rechazan: {Rechazan}");
                Console.WriteLine($"Universidades con Empate: {Empate}");
                run = false;
            }
            catch (OverflowException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"El numero de entrada o salida es demasiado grande \n Mensaje: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Error: {e.StackTrace}\n\nMensaje: {e.Message}");
            }
            Console.ReadKey();

            static University votations()
            {
                University Uni = new University();
                bool isVote = true;
                int count = 1;
                Console.Clear();
                Console.Write("Universidad:");
                Uni.name = Console.ReadLine();
                Console.WriteLine($"aceptar (A), rechazar (R), nulo (N), blanco (B) finalizar (X)");
                Console.WriteLine($"*los votos no correspondientes seran considerados nulos*");
                while (isVote)
                {
                    Console.Write($"Voto {count}: ");
                    string vote = Console.ReadLine();
                    Uni.votes.Add(vote.ToUpper());
                    count++;
                    if (vote.ToUpper() == "X")
                    {
                        int A = 0;
                        int R = 0;
                        int N = 0;
                        int B = 0;
                        foreach (var item in Uni.votes)
                        {
                            var a = item.ToUpper() == "A" ? A += 1 : (item.ToUpper() == "R" ? R += 1 : (item.ToUpper() == "N" ? N += 1 : (item.ToUpper() == "B" ? B += 1 : (item.ToUpper() == "X" ? 0 : N += 1))));
                        }
                        Uni.result.Add(A);
                        Uni.result.Add(R);
                        Uni.result.Add(B);
                        Uni.result.Add(N);

                        Console.Write($"{Uni.name.ToUpper()}: {Uni.result[0]} Aceptan, {Uni.result[1]} Rechazan, {Uni.result[2]} Blancos, {Uni.result[3]} Nulos. ");
                        Console.ReadKey();
                        isVote = false;
                    }
                }
                return Uni;
            }
        }
    }
}