class CajeroAutomatico
{
    double saldo = 10000;
    string usuarioCorrecto = "Emiliano";
    string pinCorrecto = "1234";
    int intentos = 0;
    bool logueado = false;

    void Login()
    {
        Console.WriteLine("===BIENVENIDO AL CAJERO AUTOMÁTICO===");
        while (!logueado && intentos < 3)
        {
            Console.Write("Ingresar usuario: ");
            string usuarioIngresado = Console.ReadLine();
            Console.Write("Ingresar PIN: ");
            string pinIngresado = Console.ReadLine();

            if (usuarioIngresado == usuarioCorrecto && pinIngresado == pinCorrecto)
            {
                logueado = true;
                Console.WriteLine("Login exitoso. Presione Enter para continuar...");
                Console.ReadKey();
            }
            else
            {
                intentos++;
                Console.WriteLine($"Login fallido. Intentos restantes: {3 - intentos}");
            }
        }
        if (!logueado)
        {
            Console.WriteLine("Demasiados intentos fallidos. El programa se cerrará.");
            Environment.Exit(0);
        }
    }
    void Menu()
    {
        string opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(@"===SELECCIONE LA OPERACIÓN===
1. Consultar saldo
2. Depositar
3. Retirar
4. Salir");

            Console.Write("Ingrese una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ConsultarSaldo();
                    break;
                case "2":
                    Depositar();
                    break;
                case "3":
                    Retirar();
                    break;
                case "4":
                    Salir();
                    break;
                default:
                    Console.WriteLine("Opcion no válida. Presione Enter para continuar...");
                    Console.ReadKey();
                    break;
            }

        } while (opcion != "4");
    }
    void ConsultarSaldo()
    {
        Console.Clear();
        Console.WriteLine($"Su saldo actual es: ${saldo}");
        OtraOperacion();
    }

    void Depositar()
    {
        Console.Clear();
        Console.Write("Ingrese el monto a depositar: ");
        double monto = Convert.ToDouble(Console.ReadLine());
        if (monto <= 0)
        {
            Console.WriteLine("El monto debe ser mayor a 0. Enter para reintentar... ");
            Console.ReadKey();
            Depositar();
        }
        else
        {
            saldo += monto;
            Console.WriteLine($"Depósito exitoso. Su nuevo saldo es: ${saldo}");
            OtraOperacion();
        }
    }

    void Retirar()
    {
        Console.Clear();
        Console.Write("Ingrese el monto a retirar: ");
        double retiro = Convert.ToDouble(Console.ReadLine());
        if (retiro == 0)
        {
            Console.WriteLine("Monto inválido. Ingrese un número distinto de 0. Presione Enter para reintentar...");
            Console.ReadKey();
            Retirar();
        }
        if (retiro > saldo)
        {
            Console.WriteLine("Fondos insuficientes. Presione Enter para reintentar...");
            Console.ReadKey();
            Retirar();
        }
        else
        {
            saldo -= retiro;
            Console.WriteLine($"Retiro exitoso. Su nuevo saldo es: ${saldo}");
            OtraOperacion();
        }
    }
    void Salir()
    {
        Console.Clear();
        Console.WriteLine(@"====================================================
Gracias por usar el cajero automático. ¡Hasta luego!
====================================================");
        Environment.Exit(0);
    }

    void OtraOperacion()
    {
        Console.WriteLine("\nDesea realizar otra operación? (1=SI / 2=NO)");
        int respuesta = Convert.ToInt32(Console.ReadLine());
        if (respuesta == 1)
        {
            Menu();
        }
        else
        {
            Salir();
        }
    }


    static void Main(string[] args)
    {
        CajeroAutomatico cajero = new CajeroAutomatico();
        cajero.Login();
        cajero.Menu();
    }
}