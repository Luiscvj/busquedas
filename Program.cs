// See https://aka.ms/new-console-template for more information
public class Program
{
    public static void Main (string[] args)
    {   
        Queries busqueda = new Queries();

        //MostrarLibros(busqueda.GetAll()) ;
        //MostrarLibros(busqueda.ordenarPorTamaño());
      // var book=  busqueda.GetByName("Unlocking Android");
       //Console.WriteLine(book.Title);
     /*  foreach(int a in busqueda.VerPaginasByName("Unlocking Android"))
      {
        Console.WriteLine(a);
      }
 */

   //  MostrarLibros(busqueda.LibrosRecientesJava());
        /* foreach(var grupo in busqueda.VerGrupo())
        {  Console.WriteLine("===================================");
           Console.WriteLine($"Grupo del Año {grupo.Key}");
           foreach(Book b in grupo)
           {
              Console.WriteLine($"Titutlo: {b.Title}");
           }
             
        } */
        MostrarLibrosPorLetra(busqueda.LookUpLibro());


        
    }

    public static void MostrarLibros(List<Book> books)
    {   
        Console.WriteLine("{0,-10}{1,5}{2,20}{3,35}{4,50}","Titulo","Paginas","Categoria","Autores", "Fecha Publicacion");

        foreach(Book  b in books)
        {

        
            Console.WriteLine("{0,-10}{1,5}{2,20}{3,35}{4,50}",b.Title,b.PageCount,b.Categories[0],b.Authors[0],b.PublishedDate.Year);
        };
        
        
    }
    public static void MostrarLibrosPorLetra(ILookup<char,Book> grupo )
    {   Console.WriteLine("Introduzca la letra con la que desea buscar el libro");
      char letra =Convert.ToChar( Console.ReadLine());
        Console.WriteLine("{0,-10}{1,5}{2,20}{3,35}{4,50}","Titulo","Paginas","Categoria","Autores", "Fecha Publicacion");

        foreach(Book b   in grupo[letra])
        {
            
        
            Console.WriteLine("{0,-10}{1,5}{2,20}{3,35}{4,50}",b.Title,b.PageCount,b.Categories[0],b.Authors[0],b.PublishedDate.Year);
        };
        
        
    }

   
} 