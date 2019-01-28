# InternshipWinFormsEFCore
Structure for C# WinForms project with EF Core.

## Upute:

1. Napravit WinForms projekt, nazvat ga Presentation (.NET Framework)
2. Dodat Data i Domain class libraryje (.NET Framework)
3. U Domain referencirat Data, u Presentation referencirat Domain (i po potrebi Data)
4. Instalirat paket Microsoft.EntityFrameworkCore u Data i Domain projekte (obavezno u oba jer repository klase ne mogu radit bez EF Corea)
5. Instalirat paket Microsoft.EntityFrameworkCore.SqlServer u Data projektu
6. Instalirat paket Microsoft.EntityFrameworkCore.Tools u Data projektu
7. Napravit modele i context klasu, sa svim relacijama i mapiranjem kako je i pokazano na predavanju.
8. Data projekt desni klik -> references -> add reference -> assemblies -> označit System.Configuration i dodat
9. Uputit context klasu gdje da pronađe connection string:
```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["BloggingContext"].ConnectionString);
        }
```
10. U app.config od Data projekta dodat taj connection string:
```csharp
<connectionStrings>
    <add name="BloggingContext"
         connectionString="Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" />
  </connectionStrings>
```
11. Po potrebi možete napravit seedanje preko OnModelCreating metode (tu i podešavate sve relacije koje morate ručno):
```csharp
 protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(new Blog { BlogId = 1, Url = "http://sample.com" });
            modelBuilder.Entity<Post>().HasData(new { BlogId = 1, PostId = 1, Title = "First post", Content = "Test 1" });
        }
```
12. Desni klik na Data projekt -> set as startup project. Ovo radimo da bi mogli napravit migracije, pošto WinForms i EF Core nisu baš kompatibilni, prebacujemo startup project na Data samo dok stvorimo migraciju i pokrenemo je.
13. Otvorit view (na vrhu visual studia izbornik) -> other windows -> package manager console
14. Unijet iduću naredbu koja stvara migraciju imena InitialCreate:
```csharp
Add-Migration InitialCreate
```
15. Unijet iduću naredbu koja primjenjuje zadane migracije na bazu:
```csharp
Update-Database
```
16. Nakon izvršene migracije promijenit startup project natrag na presentation.
17. U Domain projektu stvorit repozitorije po potrebi.
18. U app.config od Presentation projekta također dodat connection string:
```csharp
<connectionStrings>
    <add name="BloggingContext"
         connectionString="Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" />
  </connectionStrings>
```
19. U Presentation projektu instancirat repozitorije i koristit metode kako god je potrebno.
20. Kad god je potrebno napravit novu migraciju ili izvršit, prebacit startup na Data, napravit šta treba i vratit startup na Presentation.
