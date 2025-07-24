using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        Man obj = new Man();

       
        int opc = 0;

        while (opc != 5)
        {
            Console.WriteLine("\nDiario Simplificado");
            Console.WriteLine("1. Nueva entrada");
            Console.WriteLine("2. Mostrar diario");
            Console.WriteLine("3. Guardar diario");
            Console.WriteLine("4. Cargar diario");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");

           
            string cap = Console.ReadLine();

            if (int.TryParse(cap, out opc))
            {
                switch (opc)
                {
                    case 1:
                        obj.AgrEnt();
                        break;
                    case 2:
                        obj.MosDia();
                        break;
                    case 3:
                        obj.GuaDia();
                        break;
                    case 4:
                        obj.CarDia();
                        break;
                    case 5:
                        Console.WriteLine("¡Hasta pronto!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor ingresa un número.");
            }
        }
    }
}




class Dia
{
   
    public string fec { get; set; }

    
    public string pre { get; set; }

    
    public string res { get; set; }

    public Dia(string preg, string resp)
    {
        fec = DateTime.Now.ToShortDateString();
        pre = preg;
        res = resp;
    }

    public Dia(string fecha, string preg, string resp)
    {
        fec = fecha;
        pre = preg;
        res = resp;
    }

    public override string ToString()
    {
        return $"{fec}: {pre}\n- {res}\n";
    }

   
    public string GenCad()
    {
        return $"{fec}~|~{pre}~|~{res}";
    }
}






class Man
{
    
    private List<Dia> lis = new List<Dia>();

    
    private List<string> pre = new List<string>()
    {
        "¿Quién fue la persona más interesante con la que interactué hoy?",
        "¿Cuál fue la mejor parte de mi día?",
        "¿Cómo vi la mano del Señor en mi vida hoy?",
        "¿Cuál fue la emoción más fuerte que sentí hoy?",
        "Si tuviera que hacer una cosa hoy, ¿qué sería?",
        "¿Qué aprendizaje nuevo tuve hoy?",
        "¿Por qué cosa estoy agradecido hoy?",
        "¿Qué podría haber hecho mejor hoy?"
    };

    
    public void AgrEnt()
    {
        
        Random rnd = new Random();
        int idx = rnd.Next(pre.Count);

        Console.WriteLine($"\n{pre[idx]}");
        Console.Write("> ");

       
        string res = Console.ReadLine();

        lis.Add(new Dia(pre[idx], res));
        Console.WriteLine("Entrada agregada.");
    }

   
    public void MosDia()
    {
        if (lis.Count == 0)
        {
            Console.WriteLine("\nEl diario está vacío.");
            return;
        }

        Console.WriteLine("\n--- Entradas del diario ---");
        foreach (Dia dia in lis)
        {
            Console.WriteLine(dia);
        }
    }

   
    public void GuaDia()
    {
        if (lis.Count == 0)
        {
            Console.WriteLine("\nNo hay entradas para guardar.");
            return;
        }

        Console.Write("\nNombre del archivo para guardar: ");
       
        string nom = Console.ReadLine();

        try
        {
            using (StreamWriter sw = new StreamWriter(nom))
            {
                foreach (Dia dia in lis)
                {
                    sw.WriteLine(dia.GenCad());
                }
            }
            Console.WriteLine($"Diario guardado en {nom}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar: {ex.Message}");
        }
    }

    
    public void CarDia()
    {
        Console.Write("\nNombre del archivo para cargar: ");
       
        string nom = Console.ReadLine();

        if (!File.Exists(nom))
        {
            Console.WriteLine("El archivo no existe.");
            return;
        }

        try
        {
           
            string[] lin = File.ReadAllLines(nom);

            
            List<Dia> tmp = new List<Dia>();

            foreach (string lin in lin)
            {
                
                string[] par = lin.Split(new[] { "~|~" }, StringSplitOptions.None);

                if (par.Length == 3)
                {
                    tmp.Add(new Dia(par[0], par[1], par[2]));
                }
            }

            lis = tmp;
            Console.WriteLine($"Diario cargado desde {nom} con {lis.Count} entradas.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar: {ex.Message}");
        }
    }
}
