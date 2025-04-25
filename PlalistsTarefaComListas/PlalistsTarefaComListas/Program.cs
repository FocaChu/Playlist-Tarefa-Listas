using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistExercicio
{
    internal class Program
    {
        static List<String> musicas = new List<String>();
        static List<String> nomesPlaylist = new List<String>();
        static List<List<String>> playlist = new List<List<String>>();

        static void Main(string[] args)
        {

            //Senha();

            Console.Clear();

            Menu();

            //Redkey pra impedir o console de fechar
            Console.ReadKey();
        }

        static void Senha()
        {
            String senha = "1234";

            while (true)
            {
                Console.Write("Digite sua senha: ");
                if (senha == Console.ReadLine())
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Senha Inválida!");
                }
            }
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n*** Bem vindo! ***\n");

                Console.WriteLine("1 - Cadastrar Música. \n2 - Ver Lista de Músicas. \n3 - Remover Música. \n4 - Criar Playlist. \n5 - Ver Playlists. \n6 - Modificar Playlists. \n7 - Remover Playlists. \n0 - Sair.");
                int menu = 0;

                while (true)
                {
                    try
                    {
                        menu = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Entrada Invalida!");
                    }
                }

                if (menu == 0) break;

                Console.Clear();

                switch (menu)
                {
                    case 1:
                        CadastrarMusicas();
                        break;

                    case 2:
                        MostrarLista();
                        break;

                    case 3:
                        RemoverMusica();
                        break;

                    case 4:
                        CriarPlalist();
                        break;

                    case 5:
                        VerPlalist();
                        break;

                    case 6:
                        ModificarPlaylist();
                        break;

                    case 7:
                        RemoverPlaylist();
                        break;

                    default:
                        Console.WriteLine("Entrada Inválida!");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void CadastrarMusicas()
        {
            Console.WriteLine("*** CADASTRAR MUSICA ***\n");



            while (true)
            {
                Console.WriteLine("Deseja cadastrar uma música a lista? (s/n)");
                String opCadastro = Console.ReadLine().ToLower();


                if (opCadastro == "n")
                {
                    Console.WriteLine("\nSaíndo...");
                    break;
                }
                else if (opCadastro == "s")
                {
                    Console.Write("\nDigite o nome da música: ");
                    musicas.Add(Console.ReadLine());
                    break;
                }
                else
                {
                    Console.WriteLine("\nEntrada Inválida");
                }
            }
        }

        static void MostrarLista()
        {
            musicas.Sort();

            Console.WriteLine("*** LISTA DE MÚSICAS ***");

            for (int i = 0; i < musicas.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {musicas[i]}");
            }
        }

        static void RemoverMusica()
        {
            while (true)
            {
                Console.WriteLine("*** REMOVER MÚSICA ***\n");

                MostrarLista();
                Console.WriteLine("\n");

                Console.WriteLine("\nDigite o ID da música que deseja remover. \n0 - Sair.");
                int idRemover = 0;

                while (true)
                {
                    try
                    {
                        idRemover = int.Parse(Console.ReadLine()) - 1;
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Entrada Invalida!");
                    }
                }

                if (idRemover == -1) break;

                Console.WriteLine($"\nDeseja remover a música {musicas[idRemover]} da sua lista? (s/n)");
                String op = Console.ReadLine().ToLower();

                if (op == "s")
                {
                    musicas.Remove(musicas[idRemover]);
                    Console.WriteLine("\nMúsica removida com sucesso!");
                }
                else if (op == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada Inválida");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void CriarPlalist()
        {

            Console.WriteLine("*** CRIAR PLAYLIST ***\n");

            while (true)
            {
                Console.WriteLine("Deseja criar uma nova playlist? (s/n)");
                String op = Console.ReadLine().ToLower();

                if (op == "n")
                {
                    Console.WriteLine("Saindo..");
                    break;
                }
                else if (op == "s")
                {
                    List<String> novaPlaylist = new List<String>();

                    Console.WriteLine("Escolha um nome para a playlist: ");
                    nomesPlaylist.Add(Console.ReadLine());

                    if (musicas.Count >= 1)
                    {

                        Console.WriteLine("Quantas músicas deseja adicionar na Playlist?");
                        int numeroDeMusicas = 0;

                        while (true)
                        {
                            try
                            {
                                numeroDeMusicas = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Entrada Invalida!");
                            }
                        }



                        Console.WriteLine("\n");
                        MostrarLista();
                        Console.WriteLine("\n");

                        for (int i = 0; i < numeroDeMusicas; i++)
                        {
                            Console.WriteLine($"Digite o ID da música da lista que deseja por na playlist: ");
                            int id = 0;

                            while (true)
                            {
                                try
                                {
                                    id = int.Parse(Console.ReadLine()) - 1;
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Entrada Invalida!");
                                }
                            }

                            if (id > -1 && id < musicas.Count)
                            {
                                novaPlaylist.Add(musicas[id]);
                            }
                            else
                            {
                                Console.WriteLine("Entrada Inválida!\n");
                                i--;
                            }
                        }
                    }

                    playlist.Add(novaPlaylist);

                    Console.WriteLine("Playlist criada");
                }
                else
                {
                    Console.WriteLine("Entrada Inválida");
                }
            }
        }

        static void VerPlalist()
        {
            Console.WriteLine("*** BIBLIOTECA DE PLAYLISTS ***\n");

            for (int i = 0; i < playlist.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {nomesPlaylist[i]}");
                foreach (String s in playlist[i])
                {
                    Console.WriteLine(s);
                }

                Console.WriteLine("\n");
            }
        }

        static void ModificarPlaylist()
        {
            Console.WriteLine("*** MODIFICAR PLAYLIST ***\n");

            while (true)
            {
                Console.WriteLine("Deseja modificar alguma playlist? (s/n)");
                String op = Console.ReadLine().ToLower();

                if (op == "n") break;

                else if (op == "s")
                {
                    VerPlalist();

                    while (true)
                    {
                        Console.Write("\nInsira o ID da playlist que deseja modificar: ");
                        int id = 0;

                        while (true)
                        {
                            try
                            {
                                id = int.Parse(Console.ReadLine()) - 1;
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Entrada Invalida!");
                            }
                        }

                        if (id > -1 && id < playlist.Count)
                        {

                            Console.WriteLine($"\nDeseja modificar a playlist {nomesPlaylist[id]}? (s/n)");
                            String opDois = Console.ReadLine().ToLower();

                            if (opDois == "n") break;
                            else
                            {
                                while (true)
                                {
                                    Console.WriteLine("\n1 - Mudar o nome da playlist. \n2 - Apagar uma musica a playlist \n3 - Adicionar uma musica a playlist.. \n4 - Apagar a playlis. \n0 - Sair.");
                                    int opEdicao = 0;

                                    while (true)
                                    {
                                        try
                                        {
                                            opEdicao = int.Parse(Console.ReadLine());
                                            break;
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Entrada Inválida!");
                                        }
                                    }

                                    if (opEdicao == 0) break;

                                    switch (opEdicao)
                                    {
                                        case 1:
                                            MudarNomePlaylist(id);
                                            break;

                                        case 2:
                                            RemovMusicaPlaylist(id);
                                            break;

                                        case 3:
                                            AddMusicaPlaylist(id);
                                            break;

                                        default:
                                            Console.WriteLine("\nEntrada Invalída!");
                                            break;

                                    }
                                }

                            }




                        }
                    }

                }
                else
                {
                    Console.WriteLine("\nEntrada Inválida");
                }
            }

        }

        static void MudarNomePlaylist(int id)
        {
            while (true)
            {
                Console.WriteLine("\nDeseja alterar o nome da playlist? (s/n)");
                String opNome = Console.ReadLine().ToLower();

                if (opNome == "s")
                {
                    Console.Write("\nInsira o novo nome: ");
                    nomesPlaylist[id] = Console.ReadLine();

                    Console.WriteLine($"\nNome alterado com sucesso para {nomesPlaylist[id]}");
                    break;
                }
                else if (opNome == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nEntrada Inválida");
                }
            }
        }

        static void RemovMusicaPlaylist(int id)
        {
            while (true)
            {
                Console.WriteLine("\nDeseja remover uma musica a playlist? (s/n)");
                String opRemover = Console.ReadLine().ToLower();

                if (opRemover == "s")
                {

                    MostrarLista();

                    Console.WriteLine($"\n*** PLAYLIST: {nomesPlaylist[id]}");
                    foreach (String s in playlist[id])
                    {
                        Console.WriteLine(s);
                    }

                    Console.Write("\nInsira o ID da musica que deseja remover: ");
                    int musicaID = 0;

                    while (true)
                    {
                        try
                        {
                            musicaID = int.Parse(Console.ReadLine()) - 1;
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Entrada Invalida!");
                        }
                    }

                    while (true)
                    {
                        if (musicaID <= playlist.Count && musicaID > -1)
                        {
                            playlist[id].Remove(musicas[musicaID]);

                            Console.WriteLine($"\nMusica {musicas[musicaID]} removida com sucesso da playlist!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nEntrada Inválida");
                        }
                        break;
                    }
                }
                else if (opRemover == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nEntrada Inválida");
                }
            }
        }

        static void AddMusicaPlaylist(int id)
        {
            while (true)
            {
                Console.WriteLine("\nDeseja adicionar uma musica da lista a playlist? (s/n)");
                String opAdicionar = Console.ReadLine().ToLower();

                if (opAdicionar == "s")
                {

                    MostrarLista();

                    while (true)
                    {
                        Console.Write("\nInsira o ID da musica que deseja adicionar: ");
                        int musicaID = 0;

                        while (true)
                        {
                            try
                            {
                                musicaID = int.Parse(Console.ReadLine()) - 1;
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Entrada Invalida!");
                            }
                        }

                        if (musicaID <= playlist.Count && musicaID > -1)
                        {
                            playlist[id].Add(musicas[musicaID]);

                            Console.WriteLine($"\nMusica {musicas[musicaID]} adicionada com sucesso a plalist");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nEntrada Inválida");
                        }
                    }
                }
                else if (opAdicionar == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nEntrada Inválida");
                }
            }
            while (true)
            {
                Console.WriteLine("\nDeseja adicionar uma musica nova a playlist? (s/n)");
                String opAdicionar = Console.ReadLine().ToLower();

                if (opAdicionar == "s")
                {

                    Console.Write("\nInsira nome da musica que deseja adicionar diretamente a playlist: ");
                    String novaMusica = Console.ReadLine();

                    playlist[id].Add(novaMusica);

                    Console.WriteLine($"\nMusica {novaMusica} adicionada com sucesso a playlist");

                }
                else if (opAdicionar == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nEntrada Inválida");
                }
            }
        }

        static void RemoverPlaylist()
        {

            Console.WriteLine("*** EXCLUIR PLAYLIST ***\n");

            while (true)
            {
                Console.WriteLine("Deseja excluir alguma playlist? (s/n)");
                String opExcluir = Console.ReadLine().ToLower();

                if (opExcluir == "n")
                {
                    Console.WriteLine("\nSaindo...");
                    break;
                }
                else if (opExcluir == "s")
                {
                    VerPlalist();

                    Console.Write("\nInsira o ID da playlist que deseja excluir: ");
                    int id = 0;

                    while (true)
                    {
                        try
                        {
                            id = int.Parse(Console.ReadLine()) - 1;
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Entrada Invalida!");
                        }
                    }

                    if (id > -1 && id < playlist.Count)
                    {
                        playlist.Remove(playlist[id]);
                        playlist.Sort();
                        Console.WriteLine("\nPlaylist excludia com sucesso!");
                    }

                }
                else
                {
                    Console.WriteLine("Entrada Inválida!");
                }

            }
        }
    }
}