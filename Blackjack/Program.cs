
int opcion = 0;
Random RNG = new Random();
int carta = RNG.Next(1,14); // Genera un número entre 1 y 14, siendo 1 una A, y las démas cartas números, excepto las figuras que son 11,12 y 13
int puntosJugador = 0, puntosDealer = 0;
string CartasMano = "";
string cartaRobada = "";

Console.WriteLine("<///////////////////////////\n" +
"///////BIENVENIDO A UN//////\n" +
"/////JUEGO DE BLACKJACK/////\n" +
"////////////////////////////>\n" +
"-Para empezar presiona un botón-");
Console.ReadLine();

do
{
    try
    {
        Console.WriteLine("Ahora estás en contra el dealer, que quieres hacer?");
        Console.WriteLine("1.Robar\n2.Plantarse");
        opcion = int.Parse(Console.ReadLine());

        if (opcion == 1) // Opción para robar una carta
        {
            carta = RNG.Next(1, 14); // Saca una carta random de la pila
            puntosDealer += carta;   // Suma los puntos al dealer
            carta = RNG.Next(1, 14); // Saca una carta random de la pila

            // Dependiendo del tipo de carta se añade a la cadena de la mano
            if (carta == 1) // Carta A
            {
                cartaRobada = "A";
                if (puntosJugador <= 10) puntosJugador += 11; else puntosJugador += 1;  // Suma los puntos al jugador  // Suma los puntos al jugador
            }
            else if (carta > 10 && carta < 14) // Cartas figuras
            {
                switch (carta)
                {
                    case 11: cartaRobada = "J"; break;

                    case 12: cartaRobada = "Q"; break;

                    case 13: cartaRobada = "K"; break;
                }
                puntosJugador += 10;  // Suma los puntos al jugador
            }
            else
            {
                puntosJugador += carta;         // Suma los puntos al jugador
                cartaRobada = carta.ToString(); // Transforma la carta a string
            }
            CartasMano += cartaRobada + " ";

            Console.WriteLine($"Has robado un {cartaRobada}");
            Console.WriteLine($"\n/////////////\nMano actual:{CartasMano}\n/////////////\n");

        }
        else if (opcion == 2) // El jugador se planta, se calculan los puntos del dealer y del jugador
        {
            Console.WriteLine($"Puntos del jugador: {puntosJugador}.");
            Console.WriteLine($"Puntos del dealer:  {puntosDealer}.");
            if (puntosJugador > 21)
            {
                Console.WriteLine("Perdiste. Te pasaste de 21 puntos.");
            }
            else if (puntosJugador > puntosDealer)
            {
                Console.WriteLine("¡Felicitaciones! Ganaste.\n");
            }
            else if (puntosDealer > puntosJugador)
            {
                Console.WriteLine("Perdiste. El dealer ganó.\n");
            }
            else
            {
                Console.WriteLine("Empate. La casa gana!\n");
            }
        }
        else
        {
            Console.WriteLine("Opción inválida, intentelo de nuevo");
        }
    }
    catch (Exception e){ 
        Console.WriteLine("Error en el sistema:" +e.Message+ "\nVolviendo con el dealer...");
    }

} while (opcion != 2);