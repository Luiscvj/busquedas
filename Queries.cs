public class Queries
{

    List<Book> books = new List<Book>();

    public Queries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.books = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text
            .Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true})?? new List<Book>();
        }
    }

    public List<Book> GetAll()
    {
        return this.books;
    }

    public Book  GetByName( string name){

        return this.books.Where(b => b.Title == name).FirstOrDefault() ?? new Book{};
    }

    public List<int>  VerPaginasByName(string name)
    {//Consultas de lenguaje integrado
        var  book = from c in this.books
                    where c.Title == name
                    select c.PageCount;

                    return book.ToList();
    }

    public  List<Book> ordenarPorTamaño()
    {
        var book = from c in this.books
                    orderby c.PageCount
                    select c;
        return book.ToList();
    }


    public List<Book> VerLibrosMayor2000()
    {//Year es una propiedad de un objeto datetime
        var book  = from b in this.books
                    where b.PublishedDate.Year > 2000 
                    select b;

            return book.ToList();
    }

    public List<Book> VerLibros200pagAction()
    {    //Sintaxis de lenguaje integrado de consulta
        var book = (from b in this.books
                where b.PageCount > 200 && b.Title.Contains("in Action")
                select b).ToList();

        return book;
    }

    public bool ComporbarStatus()
    {//All me comprueba si todos los elementos cumplen una condicion.
        return  this.books.All(b => b.Status != String.Empty);
           
    }

    public bool ComprobarPublicados2005()
    {
        return this.books.Any(b =>  b.PublishedDate.Year == 2005);
    }

    public List<Book> VerLibrosConPython()
    {//Me retorna una lista con los libros que contirnen en su categoria python
        return this.books.Where(b => (b.Categories ).Contains("Python")).ToList();
    }


    public List<Book> LibrosConJava()
    {//Me retorna libros con Categoria java de forma ascendenete
        return this.books.Where( b => (b.Categories).Contains("Java"))
                .OrderBy(b => b.Title).ToList();
    }

    public List<Book> LibrosConMas450Pag()
    {
            return this.books.Where(b => b.PageCount > 450)
                   .OrderByDescending(B => B.PageCount).ToList();
                   //Siempre como argumento para el Order paso el atributo que estoy analizando primeramnete
    }

    public List<Book> LibrosMasDosAutore()
    {
        return this.books.Where(b => b.Authors.Count > 2)
                .OrderBy(b => b.Authors.Count).ToList();
    }


    public List<Book> LibrosRecientesJava()
    {//Esta Take que me toma los primeros n elementos y takelast que me toma los n ultimos elementos
        return this.books.Where(b => (b.Categories).Contains("Java"))
                .OrderByDescending(b => b.PublishedDate.Year)
                .Take(3).ToList();    
    }

    public List<Book> LibrosMas400Pag()
    {   //Skip se usa para retornar los primeros n elementos que le indique
        return this.books.Where(b => b.PageCount >400 )
                .Take(4)
                .Skip(2).ToList();
    }

    public List<Book> VerTituloPaginas()
    {//Seleccion dinamica
        return  this.books.Take(3)
                .Select(book =>new Book{ Title = book.Title, PageCount = book.PageCount} ).ToList();
    }

    public int Count200Y500()
    {//Retorna un enetero con  el numero de resultados encontrados
        return this.books.Where(b => b.PageCount >200 && b.PageCount < 500)
                .Count();
    }

    public long Count200Y500Long()
    {//Me retorna el numero de coincidencias pero en long
        return this.books.
               LongCount(b => b.PageCount >200 && b.PageCount < 500);
    }

    public DateTime LibroAntiguo()
    {
        return books.Min(book => book.PublishedDate);
    }

    public  int LibroMasPaginas()
    {
        return books.Max( book => book.PageCount);
    }

    public int SumarPaginas()
    {
        return books.Where(b => b.PageCount <= 500)
        .Sum(b => b.PageCount);
    }

    //Agregate me permite acumular mis resultado
   /*  public string TitulosDepues2015Agregate()
    {
      return books.Where(b => b.PublishedDate.Year < 2015)
        .Aggregate("", (TituloLibro, next) =>
        {
            if(TituloLibro != String.Empty)
            {
                TituloLibro += "-" + next.Title;
            }else
            {
                TituloLibro += next.Title;
            }
        });
    } */

    public IEnumerable<IGrouping<int,Book>> VerGrupo()
    {//El grupo me crea diccionarios de mis busquedas donde la clave es la condicion que le indico que me haga de busqueda
        return books.Where(b => b.PublishedDate.Year > 2000)
            .GroupBy(b => b.PublishedDate.Year);

    }

    public ILookup<char, Book> LookUpLibro()
    {
        return books.ToLookup(book => book.Title[0]);
    }
    

    public List<Book> JoinLibros()
    {
        var mas500 = books.Where(b => b.PageCount > 500);
        var Despues2005 =books.Where(b => b.PublishedDate.Year >2005);
        return Despues2005.Join(mas500, p=> p.Title ,X => X.Title,(p,x)=> p).ToList();

    }

}